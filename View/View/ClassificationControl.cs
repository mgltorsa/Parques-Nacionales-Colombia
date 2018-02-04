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
    public partial class ClassificationControl : UserControl
    {
       
        public ClassificationControl()
        {
            InitializeComponent();
        }

        public void SetMain(Main main)
        {
            this.main = main;
        }

        private void ChangeLisener(object sender, EventArgs e)
        {

            if (( (RadioButton) sender).Checked)
            {

                if (sender == rbCategory)
                {
                    main.FilterByCategory();
                }
                else if (sender == rbCost)
                {
                    MessageBox.Show("RbCost");
                }
                else if (sender == rbOpeningState)
                {
                    MessageBox.Show("rbOp");
                }
                else if (sender == rbVIsitors)
                {
                    MessageBox.Show("rbVisit");

                }
            }
        }

        
    }
}
