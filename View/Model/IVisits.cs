using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IVisits
    {
        int GetVisits(string year);
        int GetVisits(string year, string month);
        int GetTotalVisits();
        int GetForecastVisits(string year, string month);
        int GetVisitsTwoYears(string oldYear, string currentYear);
        void Add(string year, string month, int countVisits);
        List<Visit> GetVisits();

    }
}
