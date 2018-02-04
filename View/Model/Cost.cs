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

        public Cost()
        {
            costs = new Dictionary<string, string>();
        }

        public void AddCost(string description, string value)
        {
            costs[description] = value;

        }

        public string GetCosts()
        {
            string info = "";
            foreach (var key in costs.Keys)
            {
                info += key + " "+"\n" +" " +costs[key] +" "+ "\n";
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
    }
}
