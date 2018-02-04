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



        public ControlMap()
        {
            InitializeComponent();
            viewLabelsName = false;
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
            MapProvider = GoogleTerrainMapProvider.Instance;
            Manager.Mode = AccessMode.ServerOnly;


            MinZoom = 0;
            MaxZoom = 24;
            Zoom = 9;
            AutoScroll = true;
            AddOverlay(polygonOverlay);
            AddOverlay(markerOverlay);
        }

        public void ShowNamesLabels(bool check)
        {
            viewLabelsName = check;
            foreach (var item in polygonOverlay.Markers)
            {
                if (viewLabelsName)
                {
                    item.ToolTipMode = MarkerTooltipMode.Always;

                }
                else
                {
                    item.ToolTipMode = MarkerTooltipMode.Never;
                }
                item.IsVisible = viewLabelsName;

            }

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


                GMarkerGoogle marker = new GMarkerGoogle(points.ToArray()[0], GMarkerGoogleType.green_dot);
                marker.ToolTipText = zone.GetName();

                polygonOverlay.Markers.Add(marker);
                polygonOverlay.Polygons.Add(mapPolygon);

            }
            ShowNamesLabels(viewLabelsName);
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
                polygonOverlay.Markers.Remove(currentMarker);
                currentMarker = new GMarkerGoogle(point, GMarkerGoogleType.blue_small)
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
