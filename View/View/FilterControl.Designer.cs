namespace View
{
    partial class FilterControl
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbCost = new System.Windows.Forms.CheckBox();
            this.cbSchedule = new System.Windows.Forms.CheckBox();
            this.cbVisitors = new System.Windows.Forms.CheckBox();
            this.cbForecast = new System.Windows.Forms.CheckBox();
            this.cbNames = new System.Windows.Forms.CheckBox();
            this.group = new System.Windows.Forms.GroupBox();
            this.group.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbCost
            // 
            this.cbCost.AutoSize = true;
            this.cbCost.Location = new System.Drawing.Point(6, 36);
            this.cbCost.Name = "cbCost";
            this.cbCost.Size = new System.Drawing.Size(110, 17);
            this.cbCost.TabIndex = 0;
            this.cbCost.Text = "Precio de entrada";
            this.cbCost.UseVisualStyleBackColor = true;
            this.cbCost.CheckedChanged += new System.EventHandler(this.ChangeListener);
            // 
            // cbSchedule
            // 
            this.cbSchedule.AutoSize = true;
            this.cbSchedule.Location = new System.Drawing.Point(6, 94);
            this.cbSchedule.Name = "cbSchedule";
            this.cbSchedule.Size = new System.Drawing.Size(122, 17);
            this.cbSchedule.TabIndex = 1;
            this.cbSchedule.Text = "Horarios de apertura";
            this.cbSchedule.UseVisualStyleBackColor = true;
            this.cbSchedule.CheckedChanged += new System.EventHandler(this.ChangeListener);
            // 
            // cbVisitors
            // 
            this.cbVisitors.AutoSize = true;
            this.cbVisitors.Location = new System.Drawing.Point(6, 154);
            this.cbVisitors.Name = "cbVisitors";
            this.cbVisitors.Size = new System.Drawing.Size(157, 17);
            this.cbVisitors.TabIndex = 2;
            this.cbVisitors.Text = "Visitas en los últimos 2 años";
            this.cbVisitors.UseVisualStyleBackColor = true;
            this.cbVisitors.CheckedChanged += new System.EventHandler(this.ChangeListener);
            // 
            // cbForecast
            // 
            this.cbForecast.AutoSize = true;
            this.cbForecast.Location = new System.Drawing.Point(6, 216);
            this.cbForecast.Name = "cbForecast";
            this.cbForecast.Size = new System.Drawing.Size(123, 17);
            this.cbForecast.TabIndex = 3;
            this.cbForecast.Text = "Pronostico de visitas";
            this.cbForecast.UseVisualStyleBackColor = true;
            this.cbForecast.CheckedChanged += new System.EventHandler(this.ChangeListener);
            // 
            // cbNames
            // 
            this.cbNames.AutoSize = true;
            this.cbNames.Location = new System.Drawing.Point(6, 271);
            this.cbNames.Name = "cbNames";
            this.cbNames.Size = new System.Drawing.Size(113, 17);
            this.cbNames.TabIndex = 4;
            this.cbNames.Text = "Visualizar nombres";
            this.cbNames.UseVisualStyleBackColor = true;
            this.cbNames.CheckedChanged += new System.EventHandler(this.ChangeListener);
            // 
            // group
            // 
            this.group.Controls.Add(this.cbCost);
            this.group.Controls.Add(this.cbNames);
            this.group.Controls.Add(this.cbSchedule);
            this.group.Controls.Add(this.cbForecast);
            this.group.Controls.Add(this.cbVisitors);
            this.group.Location = new System.Drawing.Point(3, 13);
            this.group.Name = "group";
            this.group.Size = new System.Drawing.Size(199, 309);
            this.group.TabIndex = 5;
            this.group.TabStop = false;
            this.group.Text = "Filtrar información";
            // 
            // FilterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.group);
            this.Name = "FilterControl";
            this.Size = new System.Drawing.Size(205, 325);
            this.group.ResumeLayout(false);
            this.group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbCost;
        private System.Windows.Forms.CheckBox cbSchedule;
        private System.Windows.Forms.CheckBox cbVisitors;
        private System.Windows.Forms.CheckBox cbForecast;
        private System.Windows.Forms.CheckBox cbNames;
        private System.Windows.Forms.GroupBox group;
        private Main main;
        public const int COST = 0;
        public const int SCHEDULE = 1;
        public const int VISITS = 2;
        public const short FORECAST = 3;
        

        
    }
}
