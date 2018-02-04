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
using Model;
using View;


namespace View
{
    public partial class Main : Form
    {
        public const double INIT_LAT = 4.0000000;
        public const double INIT_LNG = -72.0000000;
        public const string LIMITS_PATH = "..//..//Resources/LimitesParques.csv";
        public const string VISITORS_PATH = "..//..//Resources/Visitantes.csv";
        public const string COST_PATH = "..//..//Resources/Precios.csv";


        
        public Main()
        {
            InitializeComponent();

        }

        public void ShowNamesLabels(bool check)
        {
            map.ShowNamesLabels(check);
        }

        const string PATTERN = @"\[([^\]]*)\]";



        public void FilterByCost()
        {
            ICollection<IZone> zones = parkSystem.FilterZoneByCost();
            map.RefreshAreas(zones);
        }

        public void FilterByOpeningState()
        {
            ICollection<IZone> zones = parkSystem.FilterZoneByOpeningState();
            map.RefreshAreas(zones);
        }

        public void FilterByVisitors()
        {
            ICollection<IZone> zones = parkSystem.FilterZoneByVisitors();
            map.RefreshAreas(zones);
        }

        public void FilterByCategory()
        {
            ICollection<IZone> zones = parkSystem.FilterZoneByCategory();
            map.RefreshAreas(zones);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            StreamWriter sw = new StreamWriter(save.OpenFile());
            StreamReader reader = new StreamReader(path: COST_PATH);

            reader.ReadLine();
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                string[] infoCosts = line.Split(',');
                foreach (var item in infoCosts)
                {
                    sw.Write(item+" ");
                }
                sw.WriteLine();
            }

            reader.Close();
            sw.Close();
        }

        private void LoadDefaultOptions()
        {
            parkSystem = new ParkSystem();
            map.SetDefaultOptions();
            map.SetMain(this);
            classiControl.SetMain(this);
            filterControl.SetMain(this);
            LoadAreasFile();
            LoadVisitorsFile();
            LoadCostsFile();
            System.GC.Collect();
        }

        private void LoadCostsFile()
        {
            parkSystem.ReadCostsFile(COST_PATH);
            SaveCostsFile();
        }

        private void SaveCostsFile()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            StreamWriter sw = new StreamWriter(save.OpenFile());
            ICollection<IZone> zones = parkSystem.GetZones();
            foreach (IPark zone in zones)
            {
                sw.WriteLine(zone.GetName());
                sw.WriteLine(zone.GetCosts());
            }

            sw.Close();
        }

        private void LoadVisitorsFile()
        {
            parkSystem.ReadVisitorsFile(VISITORS_PATH);
        }


        private void SaveVisitorsFile()
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
            StreamWriter sw = new StreamWriter(save.OpenFile());
            ICollection<IZone> zones = parkSystem.GetZones();
            foreach (var zone in zones)
            {
                IVisits visits = zone.GetVisits();
                List<Visit> list = visits.GetVisits();
                sw.WriteLine(zone.GetName());
                foreach (var item in list)
                {
                    sw.WriteLine("Anio: " + item.GetYear() + " Mes " + item.GetMonth()
                        + " Visitas " + item.GetVisits());

                }


            }

            sw.Close();
        }

        private void LoadAreasFile()
        {
            parkSystem.ReadAreasFile(LIMITS_PATH);
            RefreshMap();
        }

        private void RefreshMap()
        {
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

        private void MouseDoubleClick(object sender, MouseEventArgs e)
        {
            map.AddMarker(e.X, e.Y);
        }

        internal string GetInfoZone(string zoneName)
        {
            bool[] filters = filterControl.GetFiltersInformation();

            IZone zone = parkSystem.GetZone(zoneName);

            string infoZone = GetDefaultInfoZone(zone);
            IPark park = (IPark)zone;
            if (filters[FilterControl.COST])
            {
                infoZone += "Precio entrada: " + park.GetCosts() + "\n";
            }

            if (filters[FilterControl.SCHEDULE])
            {
                infoZone += "Horario de apertura: " + park.GetSchedule() + "\n";
            }

            if (filters[FilterControl.VISITS])
            {
                infoZone += "Visitas Ultimos dos años: " + park.GetVisits().GetVisitsTwoYears(DateTime.Now.Year - 2 + "", DateTime.Now.Year + "");
            }

            if (filters[FilterControl.FORECAST])
            {
                infoZone += "Pronostico de visitas: " + park.GetVisits();

            }


            infoZone += GetDefaultInfoPolygon(zone.GetPolygonArea());



            return infoZone;
        }

        private string GetDefaultInfoPolygon(IPolygon polygon)
        {
            string hectares = "Hectareas: " + polygon.GetHectares() + "\n";
            string hectares1 = "Hectareas1: " + polygon.GetHectares1() + "\n";
            string area = "Area: " + polygon.GetStArea() + "\n";
            string length = "Longitud: " + polygon.GetStLength() + "\n";

            string info = hectares + hectares1 + area + length;
            return info;
        }

        private string GetDefaultInfoZone(IZone zone)
        {
            string name = "Nombre: " + zone.GetName() + "\n";
            string category = "Tipo: " + zone.GetCategory() + "\n";
            string territory = "Territoria: " + zone.GetTerritory() + "\n";
            string resolution = zone.GetResolution() + "\n";
            string infoZone = name + category + territory + resolution;
            return infoZone;
        }

        private void MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                map.MouseRightOption();
            }
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            map.MouseMoved(e.X, e.Y);
        }


    }
}
