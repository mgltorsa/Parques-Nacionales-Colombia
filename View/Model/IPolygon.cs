using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IPolygon
    {
        double GetHectareas();
        double GetHectareas1();
        double GetScale();
        double GetStArea();
        double GetStLength();
        List<double[]> GetPoints();

    }
}
