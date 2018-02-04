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
            GMapOverlay polygonOverlay = new GMapOverlay("PolygonOverlay");


            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] info = line.Split(',');
                int count = 3;
                List<PointLatLng> points = new List<PointLatLng>();

                for (int i = count; i < info.Length; i++)
                {
                    string infoCoordinates = info[i].Trim();
                    string[] parCoordinates = infoCoordinates.Split(' ');

                    
                    if (!(parCoordinates.Length > 1))
                    {
                        break;
                    }

                    
                   bool a= Double.TryParse(parCoordinates[0], out double lng);
                   bool b = Double.TryParse(parCoordinates[1], out double lat);


                    if (a&&b)
                    {
                        points.Add(new PointLatLng(lat, lng));
                    }

                }



                GMapPolygon polygon = new GMapPolygon(points, "Polygon1")
                {
                    Fill = Brushes.GreenYellow

                };
                polygonOverlay.Polygons.Add(polygon);
            }




            sw.Close();

            map.Overlays.Add(polygonOverlay);
            map.Zoom += 1;
            map.Zoom -= 1;
        }

       



       
    }
}
