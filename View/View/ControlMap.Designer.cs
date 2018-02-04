using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace View
{
    partial class ControlMap
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ControlMap
            // 
            this.Name = "ControlMap";
            this.ResumeLayout(false);

        }

        #endregion
        private GMapOverlay polygonOverlay;
        private GMapOverlay markerOverlay;
        private Main main;
        private GMarkerGoogle currentMarker;
        private GMapPolygon currentPolygon;
        private bool viewLabelsName;
    }
}
