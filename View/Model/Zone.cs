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


        public Zone(string name, string category, IPolygon polygon, string resolution, string territory)
        {
            this.name = name;
            this.category = category;
            this.polygon = polygon;
            this.resolution = resolution;
            this.territory = territory;
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
    }
}
