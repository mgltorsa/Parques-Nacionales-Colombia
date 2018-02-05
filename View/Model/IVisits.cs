using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IVisits
    {
        double GetTotalVisits(string year);
        double GetVisits(string year, string month);
        double GetTotalVisits();
        double GetForecastVisits(string year, string month);
        double GetForecastVisits(string year);
        void Add(string year, string month, int countVisits);
        void GetVisitsData(string year, string[] serie, List<double> data);
        void GetVisitsSerie(string year,List<string> serie);
        List<Visit> GetVisits();

    }
}
