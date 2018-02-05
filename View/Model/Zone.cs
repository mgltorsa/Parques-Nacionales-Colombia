using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Zone : IZone
    {
       


        private string name;
        private string category;
        private IPolygon polygon;
        private string resolution;
        private string territory;
        private IVisits visits;
        


        public Zone(string name, string category, IPolygon polygon, string resolution, string territory)
        {
            this.name = name;
            this.category = category;
            this.polygon = polygon;
            this.resolution = resolution;
            this.territory = territory;
            visits = new Visits();
        }

     
        public void AddVisits(string year, string month, int visitCount)
        {
            visits.Add(year,month,visitCount);
        }

        public string GetCategory()
        {
            return category;
        }

        public string GetName()
        {
            return name;
        }

        public IPolygon GetPolygonArea()
        {
            return polygon;
        }

        public string GetResolution()
        {
            return resolution;
        }

        public string GetTerritory()
        {
            return territory;
        }

        public IVisits GetVisits()
        {
            return visits;
        }

        public static int CompareByVisits(IZone park1, IZone park2)
        {
            if (park1.GetVisits().GetTotalVisits() < park2.GetVisits().GetTotalVisits())
            {
                return -1;
            }
           else  if (park1.GetVisits().GetTotalVisits() > park2.GetVisits().GetTotalVisits())
            {
                return 1;
            }

            return 0;

        }

    }
}
