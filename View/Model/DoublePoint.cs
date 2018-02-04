using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DoublePoint
    {
        private double latitude;
        private double length;

        public double Latitude { get => latitude; set => latitude = value; }
        public double Length { get => length; set => length = value; }

        public DoublePoint(double latitude, double length)
        {
            this.latitude = latitude;
            this.length = length;
        }

        override
        public string ToString()
        {
            return latitude + "," + length;
        }
    }
}
