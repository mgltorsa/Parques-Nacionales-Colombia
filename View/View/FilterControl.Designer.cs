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
            this.chForecast = new System.Windows.Forms.CheckBox();
            this.chNames = new System.Windows.Forms.CheckBox();
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
            // 
            // chForecast
            // 
            this.chForecast.AutoSize = true;
            this.chForecast.Location = new System.Drawing.Point(6, 216);
            this.chForecast.Name = "chForecast";
            this.chForecast.Size = new System.Drawing.Size(123, 17);
            this.chForecast.TabIndex = 3;
            this.chForecast.Text = "Pronostico de visitas";
            this.chForecast.UseVisualStyleBackColor = true;
            // 
            // chNames
            // 
            this.chNames.AutoSize = true;
            this.chNames.Location = new System.Drawing.Point(6, 271);
            this.chNames.Name = "chNames";
            this.chNames.Size = new System.Drawing.Size(113, 17);
            this.chNames.TabIndex = 4;
            this.chNames.Text = "Visualizar nombres";
            this.chNames.UseVisualStyleBackColor = true;
            // 
            // group
            // 
            this.group.Controls.Add(this.cbCost);
            this.group.Controls.Add(this.chNames);
            this.group.Controls.Add(this.cbSchedule);
            this.group.Controls.Add(this.chForecast);
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
            this.Load += new System.EventHandler(this.FilterControl_Load);
            this.group.ResumeLayout(false);
            this.group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbCost;
        private System.Windows.Forms.CheckBox cbSchedule;
        private System.Windows.Forms.CheckBox cbVisitors;
        private System.Windows.Forms.CheckBox chForecast;
        private System.Windows.Forms.CheckBox chNames;
        private System.Windows.Forms.GroupBox group;
    }
}
