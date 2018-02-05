using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

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
            foreach (IZone zone in zones.Values)
            {
                if (zone is IPark)
                    switch (zone.GetCategory())
                    {
                        case Park.PNN:
                            zone.GetPolygonArea().SetColor(GetPNNColor());
                            break;

                        case Park.ANU:
                            zone.GetPolygonArea().SetColor(GetANUColor());
                            break;
                        case Park.VP:
                            zone.GetPolygonArea().SetColor(GetVPColor());
                            break;
                        case Park.SFF:
                            zone.GetPolygonArea().SetColor(GetSFFColor());
                            break;
                        case Park.RN:
                            zone.GetPolygonArea().SetColor(GetRNColor());
                            break;

                    }
            }

            return zones.Values;
        }

        public ICollection<IZone> FilterZoneByCost()
        {

            IZone[] array = zones.Values.ToArray<IZone>();
            Comparison<IZone> comparison = new Comparison<IZone>(Park.ComparyByCost);
            Array.Sort<IZone>(array, comparison);
            ICollection<IZone> parks = new ArraySegment<IZone>(array);
            float obscurePercent = 0;
            foreach (IPark park in parks)
            {
                Color color = ControlPaint.Dark(GetDefaultParkColor(), obscurePercent);
                obscurePercent += 5;
                park.GetPolygonArea().SetColor(color);
            }
            return parks;

        }

        public ICollection<IZone> FilterZoneByOpeningState()
        {
            foreach (IPark park in zones.Values)
            {
                if (park.GetOpeningState())
                {
                    park.GetPolygonArea().SetColor(GetOpenColor());

                }
                else
                {
                    park.GetPolygonArea().SetColor(GetClosedColor());

                }

            }
            
            return zones.Values;
        }

        public ICollection<IZone> FilterZoneByVisitors()
        {
            IZone[] array = zones.Values.ToArray<IZone>();
            Comparison<IZone> comparison = new Comparison<IZone>(Zone.CompareByVisits);
            Array.Sort<IZone>(array, comparison);
            ICollection<IZone> parks = new ArraySegment<IZone>(array);

            float obscurePercent = 0;
            foreach (IPark park in parks)
            {
                Color color = ControlPaint.Dark(GetVisitPark(), obscurePercent);
                obscurePercent += 5;
                park.GetPolygonArea().SetColor(color);
            }
            return parks;

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

            IZone zone = new Park(name, category, polygon, resolution, territory, count >50);
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

            return Color.Green;

        }

        private Color GetVisitPark()
        {
            return Color.Honeydew;
        }

        private Color GetOpenColor()
        {
            return Color.FromArgb(100, 84, 107, 25);
        }

        private Color GetClosedColor()
        {
            return Color.FromArgb(100, 30, 38, 9);
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
            StreamReader reader = new StreamReader(path: path);

            reader.ReadLine();
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                string[] infoCosts = line.Split(',');
                string nameZone = infoCosts[1].Trim();
                IPark park = (IPark)GetZone(nameZone);
                CreateCost(infoCosts, park);
            }
        }

        private void CreateCost(string[] infoCosts, IPark park)
        {

            park.AddCost("Adulto Nacional o Extranjero Residente", infoCosts[2]);
            park.AddCost("Niños de 5 a 12 años", infoCosts[3]);
            park.AddCost("Estudiantes con carnet", infoCosts[4]);
            park.AddCost("Adulto Extranjero", infoCosts[5]);
            park.AddCost("Entada automovil", infoCosts[12]);
            park.AddCost("Entrada Collectivo", infoCosts[13]);
            park.AddCost("Entrada bus", infoCosts[14]);
            park.AddCost("Entada moto", infoCosts[15]);
            park.AddCost("Camping(TempBaja)", infoCosts[18]);
            park.AddCost("Camping(TempAlta)", infoCosts[19]);
        }

        public void ReadVisitorsFile(string path)
        {
            StreamReader reader = new StreamReader(path: path);
            reader.ReadLine();
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {

                string[] infoSplit = line.Split(',');
                string nameZone = ParseNameZone(infoSplit[1]);

                IZone zone = GetZone(nameZone);
                string month = infoSplit[2];
                int count = 35;
                AddVisits(zone, month, count, infoSplit);

            }


        }

        private string ParseNameZone(string info)
        {
            string[] infoNameZone = info.Split(' ');

            string nameZone = "";
            for (int i = 1; i < infoNameZone.Length; i++)
            {

                nameZone += infoNameZone[i] + " ";
            }

            return nameZone.Trim();
        }

        private void AddVisits(IZone zone, string month, int count, string[] infoSplit)
        {
            int year = 1995;
            for (int i = year; i <= 2014; i++)
            {
                int visitCount = Convert.ToInt32(infoSplit[count++]);
                zone.AddVisits("" + i, month, visitCount);
            }


        }

        public void SetMarker()
        {
            throw new NotImplementedException();
        }
    }
}
