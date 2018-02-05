using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Park : Zone, IPark
    {
        public const string PNN = "PNN";
        public const string SFF = "SFF";
        public const string RN = "RN";
        public const string ANU = "ANU";
        public const string VP = "VP";

        private Cost cost;
        private bool openingState;

        public Park(string name, string category, IPolygon polygon, string resolution, string territory, bool openingState) : base(name, category, polygon, resolution, territory)
        {
            cost = new Cost();
            this.openingState = openingState;
        }

        public void AddCost(string description, string value)
        {
            cost.AddCost(description, value);
        }


        public string GetCosts()
        {
            if (cost != null)
            {
                return cost.GetCosts();
            }

            else
            {
                return "N/A";
            }
        }

        public string GetSchedule()
        {
            return "No disponible";
        }

        public bool GetOpeningState()
        {
            return openingState;
        }

        public static int ComparyByCost(IZone zone1, IZone zone2)
        {
            IPark z1 = (IPark)zone1;
            IPark z2 = (IPark)zone2;
            if (z1.GetCost() < z2.GetCost())
            {
                return 1;
            }
            else if (z1.GetCost() > z2.GetCost())
            {
                return -1;
            }

            return 0;

        }

        public double GetCost()
        {
            return cost.GetCost();
        }
    }
}
