using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Visit
    {
        const int FINAL_DAY = 15;
        private string month;
        private string year;
        private int visits;

        public Visit(string month, string year, int visitsCount)
        {

            this.month = month;
            this.year = year;
            this.visits = visitsCount;

        }
        public int GetVisits()
        {
            return visits;
        }

        public string GetYear()
        {
            return year;
        }

        public string GetMonth()
        {
            return month;
        }


    }
}
