using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.WindowsForms;
using System.IO;
using GMap.NET.MapProviders;
using Model;

namespace View
{
    public partial class ControlMap : GMapControl
    {
        private GMapOverlay overlayPolygons;

        public ControlMap()
        {
            InitializeComponent();
        }

        internal void SetDefaultOptions()
        {
            overlayPolygons = new GMapOverlay("Polygons");
            DragButton = MouseButtons.Left;
            CanDragMap = true;
            Position = new PointLatLng(Main.INIT_LAT, Main.INIT_LNG);
            MapProvider = GMapProviders.GoogleTerrainMap;
            MinZoom = 0;
            MaxZoom = 24;
            Zoom = 9;
            AutoScroll = true;
            AddOverlay(overlayPolygons);
        }

        private void AddOverlay(GMapOverlay overlayPolygons)
        {
            Overlays.Add(overlayPolygons);
        }

        public void RefreshAreas(ICollection<IZone> collectionZone)
        {
            foreach (IZone zone in collectionZone)
            {
                List<PointLatLng> points = new List<PointLatLng>();
                IPolygon  iPolygon= zone.GetPolygonArea();
                foreach (DoublePoint point in iPolygon.GetPoints())
                {
                    double lat = point.Latitude;
                    double length = point.Length;
                    points.Add(new PointLatLng(lat,length));
                }


                GMapPolygon mapPolygon = new GMapPolygon(points, zone.GetName() + "Polygon")
                {
                    Fill = new SolidBrush(iPolygon.GetColor()),
                    Stroke = Pens.Black
                };

                overlayPolygons.Polygons.Add(mapPolygon);
            }
            Zoom += 1;
            Zoom -= 1;


        }

      
    }
}
