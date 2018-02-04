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
    public partial class FilterControl : UserControl
    {


        public FilterControl()
        {
            InitializeComponent();
        }

        public void SetMain(Main main)
        {
            this.main = main;
        }

        private void ChangeListener(object sender, EventArgs e)
        {
            if (sender == cbNames)
            {
                main.ShowNamesLabels(cbNames.Checked);
            }


        }




        public bool[] GetFiltersInformation()
        {
            bool[] filters = new bool[4];
            filters[COST] = cbCost.Checked;
            filters[FORECAST] = cbForecast.Checked;
            filters[SCHEDULE] = cbSchedule.Checked;
            filters[VISITS] = cbVisitors.Checked;

            
            return filters;
        }
    }
}
