using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace View
{
    partial class Dialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbInfo1 = new System.Windows.Forms.Label();
            this.lbInfo2 = new System.Windows.Forms.Label();
            this.lbInfo3 = new System.Windows.Forms.Label();
            this.lbInfo4 = new System.Windows.Forms.Label();
            this.btBack = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.graphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.graphic)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Location = new System.Drawing.Point(173, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(27, 13);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Title";
            // 
            // lbInfo1
            // 
            this.lbInfo1.AutoSize = true;
            this.lbInfo1.Location = new System.Drawing.Point(88, 57);
            this.lbInfo1.Name = "lbInfo1";
            this.lbInfo1.Size = new System.Drawing.Size(35, 13);
            this.lbInfo1.TabIndex = 1;
            this.lbInfo1.Text = "label1";
            // 
            // lbInfo2
            // 
            this.lbInfo2.AutoSize = true;
            this.lbInfo2.Location = new System.Drawing.Point(88, 105);
            this.lbInfo2.Name = "lbInfo2";
            this.lbInfo2.Size = new System.Drawing.Size(35, 13);
            this.lbInfo2.TabIndex = 2;
            this.lbInfo2.Text = "label2";
            // 
            // lbInfo3
            // 
            this.lbInfo3.AutoSize = true;
            this.lbInfo3.Location = new System.Drawing.Point(88, 149);
            this.lbInfo3.Name = "lbInfo3";
            this.lbInfo3.Size = new System.Drawing.Size(35, 13);
            this.lbInfo3.TabIndex = 3;
            this.lbInfo3.Text = "label3";
            // 
            // lbInfo4
            // 
            this.lbInfo4.AutoSize = true;
            this.lbInfo4.Location = new System.Drawing.Point(88, 196);
            this.lbInfo4.Name = "lbInfo4";
            this.lbInfo4.Size = new System.Drawing.Size(35, 13);
            this.lbInfo4.TabIndex = 4;
            this.lbInfo4.Text = "label4";
            // 
            // btBack
            // 
            this.btBack.Location = new System.Drawing.Point(91, 244);
            this.btBack.Name = "btBack";
            this.btBack.Size = new System.Drawing.Size(75, 23);
            this.btBack.TabIndex = 5;
            this.btBack.Text = "Anterior";
            this.btBack.UseVisualStyleBackColor = true;
            this.btBack.Click += new System.EventHandler(this.BtBack_Click);
            // 
            // btNext
            // 
            this.btNext.Location = new System.Drawing.Point(208, 244);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 23);
            this.btNext.TabIndex = 6;
            this.btNext.Text = "Siguiente";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.BtNext_Click);
            // 
            // graphic
            // 
            chartArea2.Name = "ChartArea1";
            this.graphic.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.graphic.Legends.Add(legend2);
            this.graphic.Location = new System.Drawing.Point(12, 9);
            this.graphic.Name = "graphic";
            this.graphic.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.graphic.Series.Add(series2);
            this.graphic.Size = new System.Drawing.Size(364, 301);
            this.graphic.TabIndex = 7;
            this.graphic.Text = "chart";
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 322);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.btBack);
            this.Controls.Add(this.lbInfo4);
            this.Controls.Add(this.lbInfo3);
            this.Controls.Add(this.lbInfo2);
            this.Controls.Add(this.lbInfo1);
            this.Controls.Add(this.lbTitle);
            this.Name = "Dialog";
            this.Text = "Dialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Dialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.graphic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbInfo1;
        private System.Windows.Forms.Label lbInfo2;
        private System.Windows.Forms.Label lbInfo3;
        private System.Windows.Forms.Label lbInfo4;
        private System.Windows.Forms.Button btBack;
        private System.Windows.Forms.Button btNext;

        private string[] info;
        private int currentIndex;
        private Main main;
        private Chart graphic;
        private System.Windows.Forms.Label[] lbs;
        public const int BACK = -1;
        public const int NEXT = 1;
    }
}