using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IZone
    {
        string GetName();
        string GetCategory();
        IPolygon GetPolygonArea();
        string GetTerritory();
        string GetResolution();


    }
}
