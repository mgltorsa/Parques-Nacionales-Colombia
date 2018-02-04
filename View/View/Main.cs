﻿using System;
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
using Model;
using View;


namespace View
{
    public partial class Main : Form
    {
        public const double INIT_LAT = 4.0000000;
        public const double INIT_LNG = -72.0000000;
        public const string LIMITS_PATH = "..//..//Resources/LimitesParques.csv";
        const string PATTERN = @"\[([^\]]*)\]";

        private IParkSystem parkSystem;




        public Main()
        {
            InitializeComponent();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            parkSystem = new ParkSystem();
            map.SetDefaultOptions();
            LoadAreasFile();
            LoadVisitorsFile();
            LoadCostsFile();


        }

        private void LoadCostsFile()
        {
        }

        private void LoadVisitorsFile()
        {
        }

        private void LoadAreasFile()
        {
            parkSystem.ReadAreasFile(LIMITS_PATH);
            map.RefreshAreas(parkSystem.GetZones());
        }

        private void SaveAreasDocument()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            StreamWriter sw = new StreamWriter(save.OpenFile());

            ICollection<IZone> zones = parkSystem.GetZones();
            foreach (var zone in zones)
            {
                sw.WriteLine("Name: " + zone.GetName() + " " + zone.GetCategory() +
                    " " + zone.GetResolution() + " " + zone.GetTerritory());
                IPolygon polygon = zone.GetPolygonArea();
                sw.WriteLine("Polygon: " + polygon.GetHectares() + " " + polygon.GetHectares1() + " "
                    + polygon.GetScale() + " " + polygon.GetStArea() + " " + polygon.GetStLength());
                sw.WriteLine("Points: ");
                List<DoublePoint> points = polygon.GetPoints();
                foreach (DoublePoint point in points)
                {
                    sw.WriteLine("1: " + point.ToString());
                }


            }
            sw.Close();
        }

        
    }
}
