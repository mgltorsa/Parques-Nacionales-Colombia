namespace View
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.classiControl = new View.ClassificationControl();
            this.filterControl1 = new View.FilterControl();
            this.map = new View.ControlMap();
            this.SuspendLayout();
            // 
            // classiControl
            // 
            this.classiControl.BackColor = System.Drawing.Color.LightGray;
            this.classiControl.Location = new System.Drawing.Point(489, 554);
            this.classiControl.Name = "classiControl";
            this.classiControl.Size = new System.Drawing.Size(632, 128);
            this.classiControl.TabIndex = 3;
            // 
            // filterControl1
            // 
            this.filterControl1.BackColor = System.Drawing.Color.LightGray;
            this.filterControl1.Location = new System.Drawing.Point(199, 62);
            this.filterControl1.Name = "filterControl1";
            this.filterControl1.Size = new System.Drawing.Size(189, 265);
            this.filterControl1.TabIndex = 2;
            // 
            // map
            // 
            this.map.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.map.BackColor = System.Drawing.Color.LightGray;
            this.map.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemmory = 5;
            this.map.Location = new System.Drawing.Point(412, 26);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 2;
            this.map.MinZoom = 2;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(756, 503);
            this.map.TabIndex = 0;
            this.map.Zoom = 0D;
            this.map.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MouseClick);
            this.map.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MouseDoubleClick);
            this.map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1194, 714);
            this.Controls.Add(this.classiControl);
            this.Controls.Add(this.filterControl1);
            this.Controls.Add(this.map);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parques Nacionales";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }


        #endregion

        private ControlMap map;
        private FilterControl filterControl1;
        private ClassificationControl classiControl;
    }
}

