using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;

namespace Model
{
    public class ParkSystem : IParkSystem
    {
        private Dictionary<String, IZone> zones;


        public ParkSystem()
        {
            zones = new Dictionary<string, IZone>();
        }

        public ICollection<IZone> FilterZoneByCategory()
        {
            ICollection<IZone> collectionZone = zones.Values;
            foreach (IZone zone in collectionZone)
            {
                switch (zone.GetCategory())
                {
                    case Zone.PNN:
                        zone.GetPolygonArea().SetColor(GetPNNColor());
                        break;

                    case Zone.ANU:
                        zone.GetPolygonArea().SetColor(GetANUColor());
                        break;
                    case Zone.VP:
                        zone.GetPolygonArea().SetColor(GetVPColor());
                        break;
                    case Zone.SFF:
                        zone.GetPolygonArea().SetColor(GetSFFColor());
                        break;
                    case Zone.RN:
                        zone.GetPolygonArea().SetColor(GetRNColor());
                        break;

                }
            }

            return collectionZone;
        }

        public ICollection<IZone> FilterZoneByCost()
        {
            throw new NotImplementedException();
        }

        public ICollection<IZone> FilterZoneByOpeningState()
        {
            throw new NotImplementedException();
        }

        public ICollection<IZone> FilterZoneByVisitors()
        {
            throw new NotImplementedException();
        }

        public IZone GetZone(string name)
        {
            return zones[name];
        }

        public IZone GetZone(double lat, double lng)
        {
            throw new NotImplementedException();
        }

        public ICollection<IZone> GetZones()
        {
            return zones.Values;
        }


        public void ReadAreasFile(string path)
        {
            StreamReader reader = new StreamReader(path: path);
            reader.ReadLine();
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                IZone zone = CreateZone(line);
                zones[zone.GetName()] = zone;
            }

            reader.Close();
        }

        private IZone CreateZone(string line)
        {
            List<DoublePoint> points = null;
            string[] info = line.Split(',');
            string name = info[1];
            string category = info[2];
            int count = 3;
            points = new List<DoublePoint>();
            for (int i = count; i < info.Length; i++)
            {
                string lineCoordinate = info[i].Trim();
                string[] infoCoordinate = lineCoordinate.Split(' ');
                if (infoCoordinate.Length > 1)
                {
                    bool a = Double.TryParse(infoCoordinate[0], out double lng);
                    bool b = Double.TryParse(infoCoordinate[1], out double lat);
                    if (a && b)
                    {
                        points.Add(new DoublePoint(lat, lng));
                    }
                    else
                    {
                        count = i;
                        break;
                    }
                }
                else
                {
                    count = i;
                    break;
                }


            }
            string territory = info[count++];
            string resolution = info[count++];

            IPolygon polygon = CreatePolygonArea(info, points, count);
            IZone zone = new Zone(name, category, polygon, resolution, territory);
            return zone;
        }

        private IPolygon CreatePolygonArea(string[] infoPolygon, List<DoublePoint> points, int count)
        {
            double hectares = Convert.ToDouble(infoPolygon[count++]);
            double hectares1 = Convert.ToDouble(infoPolygon[count++]);
            string scale = infoPolygon[count++];
            double stArea = Convert.ToDouble(infoPolygon[count++]);
            double stLength = Convert.ToDouble(infoPolygon[count++]);
            Color color = GetDefaultParkColor();

            return new Polygon(hectares, hectares1, points, scale, stArea, stLength, color);
        }

        private Color GetDefaultParkColor()
        {
            return Color.FromArgb(100, 46, 196, 101);

        }

        private Color GetPNNColor()
        {
            return Color.FromArgb(100, 46, 196, 101);
        }

        private Color GetSFFColor()
        {
            return Color.FromArgb(100, 30, 171, 176);
        }

        private Color GetVPColor()
        {
            return Color.FromArgb(100, 160, 179, 39);
        }

        private Color GetANUColor()
        {
            return Color.FromArgb(100, 38, 112, 186);
        }

        private Color GetRNColor()
        {
            return Color.FromArgb(100, 188, 118, 39);
        }

        public void ReadCostsFile(string path)
        {
            throw new NotImplementedException();
        }

        public void ReadVisitorsFile(string path)
        {
            StreamReader reader = new StreamReader(path: path);
            reader.ReadLine();
            string line = null;
            while ((line = reader.ReadLine())!=null)
            {
                
                string[] infoSplit = line.Split(',');
                string nameZone = infoSplit[0].Split(' ')[1];
                IZone zone =GetZone(nameZone);
            }
            

        }

        public void SetMarker()
        {
            throw new NotImplementedException();
        }
    }
}
