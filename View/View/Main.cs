using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using System.IO;
using GMap.NET.MapProviders;



namespace View
{
    public partial class Main : Form
    {
        public const double INIT_LAT = 4.0000000;
        public const double INIT_LNG = -72.0000000;
        public const string LIMITS_PATH = "..//..//Resources/LimitesParques.csv";
        const string PATTERN = @"\[([^\]]*)\]";



        public Main()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            map.DragButton = MouseButtons.Left;
            map.CanDragMap = true;
            map.Position = new PointLatLng(INIT_LAT, INIT_LNG);
            map.MapProvider = GMapProviders.GoogleTerrainMap;
            map.MinZoom = 0;
            map.MaxZoom = 24;
            map.Zoom = 9;
            map.AutoScroll = true;

            LoadGeoPolygon();
        }

        private void LoadGeoPolygon()
        {
            StreamReader sr = new StreamReader(path: LIMITS_PATH);

            SaveFileDialog s = new SaveFileDialog();
            s.ShowDialog();

            StreamWriter sw = new StreamWriter(s.OpenFile());
            sr.ReadLine();

            List<PointLatLng> points = new List<PointLatLng>();

            string line = sr.ReadLine();
            string[] info = line.Split(',');
            int count = 3;
            for (int i = count; i < info.Length; i++)
            {
                string infoCoordinates = info[i].Trim();
                string[] parCoordinates = infoCoordinates.Split(' ');

                double lng = 0;
                double lat = 0;
                if (parCoordinates.Length>1)
                {
                    Double.TryParse(parCoordinates[0], out lng);
                    Double.TryParse(parCoordinates[1], out lat);
                }

                if (lng == 0 || lat == 0)
                {
                    count = i;
                    break;
                }
                else
                {
                    sw.WriteLine(parCoordinates[0] + " " + parCoordinates[1]);
                    points.Add(new PointLatLng(lat, lng));
                }
            }




            sw.Close();

            GMapOverlay polygonOverlay = new GMapOverlay("PolygonOverlay");
            GMapPolygon polygon = new GMapPolygon(points, "Polygon1")
            {
                Fill = Brushes.Black
            };
            polygonOverlay.Polygons.Add(polygon);
            map.Overlays.Add(polygonOverlay);
            map.Zoom += 1;
            map.Zoom -= 1;
        }

        private string[] ConvertToLimitCoor(string[] coorPolygon)
        {
            string[] polygon = new string[coorPolygon.Length];
            for (int i = 0; i < coorPolygon.Length; i++)
            {
                polygon[i] = coorPolygon[i].Trim();
            }

            return polygon;
        }



        private string GetMultyPolygonLine(string[] infoLine)
        {
            return null;
        }
    }
}
