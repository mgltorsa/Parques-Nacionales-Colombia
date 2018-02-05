using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Visit
    {
        private string month;
        private string year;
        private double visits;



        public Visit(string month, string year, double visitsCount)
        {
            this.month = month;
            this.year = year;
            this.visits = visitsCount;

        }


        public double GetVisits()
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

        public int GetIntMonth()
        {

            return DateTime.Parse("01/" + month + "/" + year).Month;
        }



    }
}
