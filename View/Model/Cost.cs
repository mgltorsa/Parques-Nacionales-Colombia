using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Cost
    {

        private Dictionary<string, string> costs;
        private double cost;

        public Cost()
        {
            cost = 0;
            costs = new Dictionary<string, string>();
        }

        public void AddCost(string description, string value)
        {

            costs[description] = value.Trim();

        }

        public string GetCosts()
        {
            string info = "";
            foreach (var key in costs.Keys)
            {
                string value = costs[key];
                info += key+": ";
                if (Double.TryParse(value, out double num))
                {
                    info += " $";
                }
                
                    info += costs[key]+",";
                

            }
            

            return info;
        }


        public string GetCost(string description)
        {
            costs.TryGetValue(description, out string value);
            if (value == null)
            {
                return "Not found";
            }
            else
            {
                return description + " " + value;
            }
        }

        public double GetCost()
        {
            if (cost == 0)
            {
                double c = 0.0;
                foreach (var item in costs.Values)
                {
                    if (Double.TryParse(item, out double parse))
                    {
                        c += parse;
                    }
                }

                cost = c;
            }

            return cost;
        }
    }
}
