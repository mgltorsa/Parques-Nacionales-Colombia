using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class InformationControl : UserControl
    {
        public InformationControl()
        {
            InitializeComponent();
        }

        public void SetMain(Main main)
        {
            this.main = main;
        }

        private void BtCosts_Click(object sender, EventArgs e)
        {
            main.ShowCostForm();
        }

        private void BtSchedule_Click(object sender, EventArgs e)
        {
            main.ShowScheduleForm();
        }

        private void BtForecast_Click(object sender, EventArgs e)
        {
            
        }

        private void date_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btViewVisits_Click(object sender, EventArgs e)
        {
            main.ShowViewerForm();

        }
    }
}
