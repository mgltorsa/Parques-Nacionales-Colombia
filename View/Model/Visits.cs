using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Visits : IVisits
    {
        private Dictionary<String, Dictionary<String, Visit>> visits;
        private int totalVisits = -1;
        private bool changeEvent = false;

        public Visits()

        {
            visits = new Dictionary<string, Dictionary<string, Visit>>();
        }

        public int GetForecastVisits(string year, string month)
        {

            throw new NotImplementedException();
        }

        public int GetVisits(string year)
        {
            int visitsCount = 0;
            visits.TryGetValue(year, out Dictionary<string, Visit> dic);
            if (dic != null)
            {
                foreach (var itemVisit in dic.Values)
                {

                    visitsCount += itemVisit.GetVisits();

                }

            }

            return visitsCount;
        }

        public void Add(string year, string month, int visitsCount)
        {
            visits.TryGetValue(year,out Dictionary<String,Visit> dic);
            if (dic == null)
            {
                Dictionary<String, Visit> visitDic= new Dictionary<string, Visit>();
                visits[year] = visitDic;
                visitDic[month] = new Visit(month,year,visitsCount);
            }
            else
            {
                dic[month] = new Visit(month,year,visitsCount);
            }
        }

        public int GetVisits(string year, string month)
        {
            int visitsCount = 0;

            visits.TryGetValue(year, out Dictionary<string, Visit> dic);

            dic.TryGetValue(month, out Visit visit);
            if (visit != null)
            {
                visitsCount = visit.GetVisits();
            }

            return visitsCount;
        }

        public int GetTotalVisits()
        {
            int visitsCount = 0;
            if (changeEvent || totalVisits == -1)
            {
                visitsCount = CalculateTotalVisits();
                changeEvent = false;
            }

            return visitsCount;
        }

        private int CalculateTotalVisits()
        {
            int visitsCount = 0;
            foreach (var item in visits.Values)
            {
                foreach (var itemVisit in item.Values)
                {
                    visitsCount += itemVisit.GetVisits();
                }

            }

            return visitsCount;
        }

        public int GetVisitsTwoYears(int oldYear, int currentYear)
        {
            throw new NotImplementedException();
        }

        public int GetVisitsTwoYears(string oldYear, string currentYear)
        {
            throw new NotImplementedException();
        }

        public List<Visit> GetVisits()
        {
            List<Visit> visitList = new List<Visit>();
            foreach (var item1 in visits.Values)
            {
                foreach (var item in item1.Values)
                {
                    visitList.Add(item);
                }
            }

            return visitList;
        }
    }
}
