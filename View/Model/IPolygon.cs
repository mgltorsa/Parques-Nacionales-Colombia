using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model
{
    public interface IPolygon

    {

        double GetHectares();
        double GetHectares1();
        string GetScale();
        double GetStArea();
        double GetStLength();
        List<DoublePoint> GetPoints();
        Color GetColor();
        void SetColor(Color color);



    }
}
