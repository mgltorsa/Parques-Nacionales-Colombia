using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Polygon : IPolygon
    {


        private double hectares;
        private double hectares1;
        private List<DoublePoint> points;
        private string scale;
        private double stArea;
        private double stLength;
        private Color color;

        

       

        public Polygon(double hectares, double hectares1, List<DoublePoint> points, string scale, double stArea, double stLength, Color color)
        {
            
            this.hectares = hectares;
            this.hectares1 = hectares1;
            this.points = points;
            this.scale = scale;
            this.stArea = stArea;
            this.stLength = stLength;
            this.color = color;
        }

        public Color GetColor()
        {
            return color;
        }

        public double GetHectares()
        {
            return hectares;
        }

        public double GetHectares1()
        {
            return hectares1;
        }

        public List<DoublePoint> GetPoints()
        {
            return points;
        }

        public string GetScale()
        {
            return scale;
        }

        public double GetStArea()
        {
            return stArea;
        }

        public double GetStLength()
        {
            return stLength;
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }
    }
}
