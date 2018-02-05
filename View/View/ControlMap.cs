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
            currentOverlay = new GMapOverlay("Currents");
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
            AddOverlay(currentOverlay);
        }

        public string GetCurrentZone()
        {

            if (currentPolygon != null)
            {
                return currentPolygon.Name;
            }

            return null;

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


                GMarkerGoogle marker = new GMarkerGoogle(points.ToArray()[0], GMarkerGoogleType.green_dot)
                {
                    ToolTipText = zone.GetName()
                };

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

            bool nul = currentMarker == null;
            if (!nul)
            {
                currentOverlay.Markers.Remove(currentMarker);
            }
            PointLatLng point = new PointLatLng(lat, lng);
            currentMarker = new GMarkerGoogle(point, GMarkerGoogleType.blue_dot)
            {
                ToolTipMode = MarkerTooltipMode.OnMouseOver,
                ToolTipText = "Latitud: " + lat + " Longitud: " + lng
            };

            currentPolygon = SelectPolygon(point);
            if (currentPolygon != null)
            {

                currentMarker.ToolTipText = GetInfoZone(currentPolygon.Name);

            }

            currentOverlay.Markers.Add(currentMarker);

        }

        internal void MouseMoved(int x, int y)
        {

            PointLatLng point = FromLocalToLatLng(x, y);


            GMapPolygon polygon = SelectPolygon(point);
            if (currentMarker == null)
            {
                currentPolygon = polygon;
            }





        }

        private GMapPolygon SelectPolygon(PointLatLng point)
        {
            GMapPolygon polygon = null;
            foreach (GMapPolygon item in polygonOverlay.Polygons)
            {
                polygon = InsidePolygon(item, point);
                if (polygon != null)
                {
                    break;
                }
            }

            return polygon;

        }

        private GMapPolygon InsidePolygon(GMapPolygon item, PointLatLng point)
        {
            if (item.IsInside(point))
            {
                markerOverlay.Markers.Clear();

                if (currentMarker != null && item.IsInside(currentMarker.Position))
                {

                    currentMarker.ToolTipText = GetInfoZone(currentPolygon.Name);
                    return item;

                }
                else
                {
                    GMarkerGoogle marker = new GMarkerGoogle(point, GMarkerGoogleType.blue_small)
                    {
                        ToolTipMode = MarkerTooltipMode.OnMouseOver,
                        ToolTipText = GetInfoZone(item.Name)
                    };
                    markerOverlay.Markers.Add(marker);
                    return item;
                }
            }
            return null;

        }

        public void MouseRightOption()
        {
            if (currentMarker != null)
            {
                if (currentMarker.IsMouseOver)
                {
                    polygonOverlay.Markers.Remove(currentMarker);
                    currentMarker = null;
                }
            }
        }


    }
}
