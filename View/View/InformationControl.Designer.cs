namespace View
{
    partial class InformationControl
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
            this.lbVisits = new System.Windows.Forms.Label();
            this.lbForecast = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.btForecast = new System.Windows.Forms.Button();
            this.lbCost = new System.Windows.Forms.Label();
            this.lbSchedule = new System.Windows.Forms.Label();
            this.btCosts = new System.Windows.Forms.Button();
            this.btSchedule = new System.Windows.Forms.Button();
            this.btViewVisits = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbVisits
            // 
            this.lbVisits.AutoSize = true;
            this.lbVisits.Location = new System.Drawing.Point(19, 95);
            this.lbVisits.Name = "lbVisits";
            this.lbVisits.Size = new System.Drawing.Size(127, 13);
            this.lbVisits.TabIndex = 0;
            this.lbVisits.Text = "Visitas (últimos dos años):";
            // 
            // lbForecast
            // 
            this.lbForecast.AutoSize = true;
            this.lbForecast.Location = new System.Drawing.Point(19, 138);
            this.lbForecast.Name = "lbForecast";
            this.lbForecast.Size = new System.Drawing.Size(107, 13);
            this.lbForecast.TabIndex = 1;
            this.lbForecast.Text = "Pronostico de visitas:";
            // 
            // date
            // 
            this.date.CustomFormat = "MMMM/yyyy";
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date.Location = new System.Drawing.Point(152, 132);
            this.date.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.date.MinDate = new System.DateTime(1996, 1, 1, 0, 0, 0, 0);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(97, 20);
            this.date.TabIndex = 2;
            this.date.ValueChanged += new System.EventHandler(this.date_ValueChanged);
            // 
            // btForecast
            // 
            this.btForecast.Location = new System.Drawing.Point(162, 172);
            this.btForecast.Name = "btForecast";
            this.btForecast.Size = new System.Drawing.Size(75, 23);
            this.btForecast.TabIndex = 3;
            this.btForecast.Text = "Pronosticar";
            this.btForecast.UseVisualStyleBackColor = true;
            this.btForecast.Click += new System.EventHandler(this.BtForecast_Click);
            // 
            // lbCost
            // 
            this.lbCost.AutoSize = true;
            this.lbCost.Location = new System.Drawing.Point(22, 25);
            this.lbCost.Name = "lbCost";
            this.lbCost.Size = new System.Drawing.Size(81, 13);
            this.lbCost.TabIndex = 4;
            this.lbCost.Text = "Precios entrada";
            // 
            // lbSchedule
            // 
            this.lbSchedule.AutoSize = true;
            this.lbSchedule.Location = new System.Drawing.Point(22, 58);
            this.lbSchedule.Name = "lbSchedule";
            this.lbSchedule.Size = new System.Drawing.Size(46, 13);
            this.lbSchedule.TabIndex = 5;
            this.lbSchedule.Text = "Horarios";
            // 
            // btCosts
            // 
            this.btCosts.Location = new System.Drawing.Point(162, 20);
            this.btCosts.Name = "btCosts";
            this.btCosts.Size = new System.Drawing.Size(75, 23);
            this.btCosts.TabIndex = 7;
            this.btCosts.Text = "Visualizar";
            this.btCosts.UseVisualStyleBackColor = true;
            this.btCosts.Click += new System.EventHandler(this.BtCosts_Click);
            // 
            // btSchedule
            // 
            this.btSchedule.Location = new System.Drawing.Point(162, 58);
            this.btSchedule.Name = "btSchedule";
            this.btSchedule.Size = new System.Drawing.Size(75, 23);
            this.btSchedule.TabIndex = 7;
            this.btSchedule.Text = "Visualizar";
            this.btSchedule.UseVisualStyleBackColor = true;
            this.btSchedule.Click += new System.EventHandler(this.BtSchedule_Click);
            // 
            // btViewVisits
            // 
            this.btViewVisits.Location = new System.Drawing.Point(162, 95);
            this.btViewVisits.Name = "btViewVisits";
            this.btViewVisits.Size = new System.Drawing.Size(75, 23);
            this.btViewVisits.TabIndex = 8;
            this.btViewVisits.Text = "Visualizar";
            this.btViewVisits.UseVisualStyleBackColor = true;
            this.btViewVisits.Click += new System.EventHandler(this.btViewVisits_Click);
            // 
            // InformationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btViewVisits);
            this.Controls.Add(this.btSchedule);
            this.Controls.Add(this.btCosts);
            this.Controls.Add(this.lbSchedule);
            this.Controls.Add(this.lbCost);
            this.Controls.Add(this.btForecast);
            this.Controls.Add(this.date);
            this.Controls.Add(this.lbForecast);
            this.Controls.Add(this.lbVisits);
            this.Name = "InformationControl";
            this.Size = new System.Drawing.Size(286, 222);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbVisits;
        private System.Windows.Forms.Label lbForecast;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Button btForecast;
        private System.Windows.Forms.Label lbCost;
        private System.Windows.Forms.Label lbSchedule;
        private System.Windows.Forms.Button btCosts;
        private System.Windows.Forms.Button btSchedule;
        private Main main;
        private System.Windows.Forms.Button btViewVisits;
    }
}
