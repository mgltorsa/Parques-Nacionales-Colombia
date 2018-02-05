using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace View
{

    public partial class Dialog : Form
    {
        public Dialog()
        {
            InitializeComponent();

            InitLbs();
        }


        public void SetMain(Main main)
        {
            this.main = main;
        }
        private void InitLbs()
        {
            lbs = new Label[4];
            lbs[0] = lbInfo1;
            lbs[1] = lbInfo2;
            lbs[2] = lbInfo3;
            lbs[3] = lbInfo4;

        }

        public void SetInfo(string[] info)
        {

            currentIndex = 0;

            this.info = info;
            SetLabelInfo(0);
        }

        private void BtBack_Click(object sender, EventArgs e)
        {
            SetLabelInfo(BACK);
        }

        private void SetLabelInfo(int button)
        {
            if (button == BACK)
            {
                if (currentIndex - 4 >= 0)
                {
                    currentIndex = currentIndex - 4;
                }

            }

            if (button == NEXT)
            {
                if (currentIndex + 4 < info.Length)
                {
                    currentIndex = currentIndex + 4;
                }
            }

            int i = 0;
            int count = currentIndex;
            for (; count >= 0 && count < info.Length && i < lbs.Length; i++, count++)
            {
                lbs[i].Text = info[count];

            }
            if (i < lbs.Length && count > 0)
            {
                lbs[i].Text = "";
            }



        }



        public void SetTitle(string title)
        {
            lbTitle.Text = title;
        }

        private void BtNext_Click(object sender, EventArgs e)
        {

            SetLabelInfo(NEXT);


        }

        private void Dialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            this.Enabled = false;
        }

        public void SetChartMode(bool chartMode)
        {

            foreach (Control item in this.Controls)
            {
                item.Visible = !chartMode;
                item.Enabled = !chartMode;
            }

            if (chartMode)
            {
                graphic.Enabled = chartMode;
                this.Controls.Add(graphic);
                LoadSeriesChart();

            }
            else
            {
                this.Controls.Remove(graphic);
            }



        }

        public void LoadSeriesChart()
        {
            string[] serie = main.GetSerieVisits((DateTime.Now.Year - 6) + "");
            if (serie != null && serie.Length > 0)
            {
                double[] points = main.GetVisits((DateTime.Now.Year - 6) + "", serie);

                graphic.Titles.Add("Visitantes: 2012-2014");
                for (int i = 0; i < serie.Length; i++)
                {


                    Series series = graphic.Series.Add(i+"");
                    series.Label = points[i].ToString();
                    series.Points.Add(points);
                }

                SetChartMode(true);
                Enabled = true;
                ShowDialog();
            }
            else
            {
                MessageBox.Show("No hay visitas disponibles para este periodo");
            }
        }
    }
}
