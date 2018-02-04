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

        public Park(string name, string category, IPolygon polygon, string resolution, string territory) : base(name, category, polygon, resolution, territory)
        {
            cost = new Cost();
        }

        public void AddCost(string description, string value)
        {
            cost.AddCost(description,value);
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
            throw new NotImplementedException();
        }
    }
}
