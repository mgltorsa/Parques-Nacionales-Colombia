using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Model
{
    public interface IParkSystem
    {
        IZone GetZone(string name);
        IZone GetZone(double lat, double lng);
        List<IZone> GetZones();
        void ReadAreasFile(Stream stream);
        void ReadVisitorsFile(Stream stream);
        void ReadCostsFile(Stream stream);
        void SetMarker();
        List<IZone> GetZonesByCategory(string category);

    }
}
