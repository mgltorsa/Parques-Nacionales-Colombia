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
        private DoublePoint slope;
        private DoublePoint axis;


        public Visits()
        {
            visits = new Dictionary<string, Dictionary<string, Visit>>();

        }



        public double GetForecastVisits(string year, string month)
        {
            if (slope == null)
            {
                CalculatePersonYearAndMonth();
            }
            if (slope != null)
            {
                int result = 0;
                if (visits.TryGetValue(year, out Dictionary<string, Visit> dic))
                {
                    if (dic.TryGetValue(month, out Visit visit))
                    {
                        return visit.GetVisits();
                    }

                }

                int x = DateTime.Parse(month + "/" + year).Month;
                result = Convert.ToInt32((slope.Length * x) + axis.Length);
                Visit vis = new Visit(month, year, result);
                if (dic != null)
                {

                    dic[month] = vis;
                }
                else
                {
                    visits[year] = new Dictionary<string, Visit>();
                    visits[year].Add(month, vis);
                }





                return result;
            }
            return 0;
        }

        public double GetForecastVisits(string year)
        {

            if (slope == null)
            {
                CalculatePersonYearAndMonth();
            }
            if (slope != null)
            {
                double result = 0;

                if (visits.TryGetValue(year, out Dictionary<string, Visit> dic))
                {
                    result = GetTotalVisits(year);
                }
                else
                {
                    int x = DateTime.Parse("01/" + year).Year;
                    result = (slope.Latitude * x) + axis.Latitude;
                    Visit visit = new Visit("Diciembre", year, result);
                    visits[year] = new Dictionary<string, Visit>();
                    visits[year].Add("Diciembre", visit);


                }

                return result;
            }
            return 0;
        }



        private void CalculatePersonYearAndMonth()
        {
            double pearson1 = GetPearsonYear();
            double pearson2 = GetPearsonMonth();



        }

        private double GetPearsonYear()
        {
            if (visits.Values.ToArray().Length > 0)
            {
                Dictionary<string, Visit>[] array = visits.Values.ToArray();
                double[] dataArray = new double[array.Length];
                double[] productArray = new double[array.Length];
                int initYear = 1995;
                for (int i = 0; i < dataArray.Length; i++, initYear++)
                {
                    double count = 5;
                    foreach (var item in array[i].Values)
                    {
                        count += item.GetVisits();
                    }
                    dataArray[i] = count;
                    productArray[i] = initYear * count;
                }

                double averageX = 2005;
                double desviationX = 5.4772255750517;
                double averageY = dataArray.Average();
                double desviationY = GetDesviation(averageY, dataArray);
                double sumProducts = productArray.Sum();

                double pearson = ((1 / 6) * sumProducts - (averageX * averageY)) / (desviationX * desviationY);
                double slp = pearson * (desviationY / desviationX);
                double axi = averageY - (slp * averageX);
                slope = new DoublePoint(slp, 0.0);
                axis = new DoublePoint(axi, 0.0);

                return pearson;
            }
            return 0;

        }


        private double GetPearsonMonth()
        {
            if (visits.Values.ToArray().Length > 0)
            {

                Visit[] array = visits["2014"].Values.ToArray<Visit>();
                double[] dataArray = new double[array.Length];
                double[] productArray = new double[array.Length];
                int i = 0;
                for (; i < array.Length; i++)
                {
                    productArray[i] = (i + 1) * array[i].GetVisits();
                    dataArray[i] = array[i].GetVisits();
                }
                double averageY = dataArray.Average();
                double averageX = 6.5;
                double desviationY = GetDesviation(averageY, dataArray);
                double desviationX = 3.4520525295347;
                double sumProducts = productArray.Sum();
                double pearson = ((1 / 6) * sumProducts - (averageX * averageY)) / (desviationX * desviationY);
                double slp = pearson * (desviationY / desviationX);
                double axi = averageY - (slp * averageX);
                slope.Length = slp;
                axis.Length = axi;
                return pearson;
            }
            return 0;
        }

        private double GetDesviation(double average, double[] dataArray)
        {
            int n = dataArray.Length;
            double sum = 0;
            foreach (var item in dataArray)
            {
                sum += Math.Pow(Convert.ToDouble((item - average)), 2.0);
            }

            double var = ((double)(1 / (n - 1))) * sum;
            double desviation = Math.Sqrt(var);
            return desviation;
        }

        public double GetTotalVisits(string year)
        {
            double visitsCount = 0;
            visits.TryGetValue(year, out Dictionary<string, Visit> dic);
            if (dic != null)
            {
                foreach (var itemVisit in dic.Values)
                {

                    visitsCount += itemVisit.GetVisits();

                }

            }
            else
            {
                visitsCount = GetForecastVisits(year);
            }
            return visitsCount;
        }

        public void Add(string year, string month, int visitsCount)
        {
            visits.TryGetValue(year, out Dictionary<String, Visit> dic);
            if (dic == null)
            {
                Dictionary<String, Visit> visitDic = new Dictionary<string, Visit>();
                visits.Add(year, visitDic);
                visitDic.Add(month, new Visit(month, year, visitsCount));
            }
            else
            {
                dic[month] = new Visit(month, year, visitsCount);
            }
        }

        public double GetVisits(string year, string month)
        {
            double visitsCount = 0;

            visits.TryGetValue(year, out Dictionary<string, Visit> dic);

            dic.TryGetValue(month, out Visit visit);
            if (visit != null)
            {
                visitsCount = visit.GetVisits();
            }

            return visitsCount;
        }

        public double GetTotalVisits()
        {
            double visitsCount = 0;
            if (changeEvent || totalVisits == -1)
            {
                visitsCount = CalculateTotalVisits();
                changeEvent = false;
            }

            return visitsCount;
        }

        private double CalculateTotalVisits()
        {
            double visitsCount = 0;
            foreach (var item in visits.Values)
            {
                foreach (var itemVisit in item.Values)
                {
                    visitsCount += itemVisit.GetVisits();
                }

            }

            return visitsCount;
        }

        public void GetVisitsData(string year, string[] serie, List<double> data)
        {

            Dictionary<string, Visit> dic = visits[year];
            for (int i = 0; i < serie.Length; i++)
            {
                data.Add(dic[serie[i]].GetVisits());

            }

        }


        public void GetVisitsSerie(string year, List<string> serie)
        {


            string[] array1 = visits[year].Keys.ToArray();
            Dictionary<string, string> added = new Dictionary<string, string>();
            for (int i = 0; i < array1.Length; i++)
            {
                string key = array1[i];
                if (!added.TryGetValue(key, out string found))
                {
                    serie.Add(key);
                    added[key] = key;
                }

            }



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
