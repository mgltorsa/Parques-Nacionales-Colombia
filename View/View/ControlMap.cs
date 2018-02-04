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
using GMap.NET.WindowsForms.Markers;
using Model;

namespace View
{
    public partial class ControlMap : GMapControl
    {

        private GMapOverlay polygonOverlay;
        private GMapOverlay markerOverlay;
        private Main main;
        private GMarkerGoogle currentMarker;
        private GMapPolygon currentPolygon;

        public ControlMap()
        {
            InitializeComponent();
        }

        public void SetMain(Main main)
        {
            this.main = main;
        }

        internal void SetDefaultOptions()
        {
            polygonOverlay = new GMapOverlay("Polygons");
            markerOverlay = new GMapOverlay("Markers");
            DragButton = MouseButtons.Left;
            CanDragMap = true;
            Position = new PointLatLng(Main.INIT_LAT, Main.INIT_LNG);
            MapProvider = GMapProviders.GoogleTerrainMap;
            MinZoom = 0;
            MaxZoom = 24;
            Zoom = 9;
            AutoScroll = true;
            AddOverlay(polygonOverlay);
            AddOverlay(markerOverlay);
        }

        private void AddOverlay(GMapOverlay overlay)
        {
            Overlays.Add(overlay);

        }



        public void RefreshAreas(ICollection<IZone> collectionZone)
        {
            foreach (IZone zone in collectionZone)
            {
                List<PointLatLng> points = new List<PointLatLng>();
                IPolygon iPolygon = zone.GetPolygonArea();

                foreach (DoublePoint point in iPolygon.GetPoints())
                {
                    double lat = point.Latitude;
                    double length = point.Length;
                    PointLatLng pointL = new PointLatLng(lat, length);
                    points.Add(pointL);
                }
                GMapPolygon mapPolygon = new GMapPolygon(points, zone.GetName())
                {
                    Fill = new SolidBrush(iPolygon.GetColor()),
                    Stroke = Pens.Black,
                    IsVisible = true
                };
                polygonOverlay.Polygons.Add(mapPolygon);
            }
        }

        public string GetInfoZone(string zoneName)
        {
            return main.GetInfoZone(zoneName);

        }

        public void AddMarker(int x, int y)
        {
            double lat = FromLocalToLatLng(x, y).Lat;
            double lng = FromLocalToLatLng(x, y).Lng;

            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.blue_pushpin)
            {
                ToolTipMode = MarkerTooltipMode.OnMouseOver,
                ToolTipText = "Latitud: " + lat + " Longitud: " + lng
            };
            markerOverlay.Markers.Add(marker);
        }

        internal void MouseMoved(int x, int y)
        {
            PointLatLng point = FromLocalToLatLng(x, y);
            if (!(currentPolygon != null && currentPolygon.IsInside(point)))
            {
                SelectPolygon(point);
            }
        }

        private void SelectPolygon(PointLatLng point)
        {
            foreach (GMapPolygon item in polygonOverlay.Polygons)
            {
                InsidePolygon(item, point);
            }
        }

        private void InsidePolygon(GMapPolygon item, PointLatLng point)
        {
            if (item.IsInside(point))
            {
                currentPolygon = item;
                polygonOverlay.Markers.Clear();
                currentMarker = new GMarkerGoogle(point, GMarkerGoogleType.green_dot)
                {
                    ToolTipMode = MarkerTooltipMode.OnMouseOver,
                    ToolTipText = GetInfoZone(item.Name)
                };
                polygonOverlay.Markers.Add(currentMarker);

            }
        }

        public void MouseRightOption()
        {
            foreach (var marker in markerOverlay.Markers)
            {
                if (marker.IsMouseOver)
                {
                    markerOverlay.Markers.Remove(marker);
                    return;
                }
            }
        }

       
    }
}
