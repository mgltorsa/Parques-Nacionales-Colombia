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
        ICollection<IZone> GetZones();
        void ReadAreasFile(string path);
        void ReadVisitorsFile(string path);
        void ReadCostsFile(string path);
        void SetMarker();
        IZone FilterZoneByCost();
        IZone FilterZoneByCategory();
        IZone FilterZoneByVisitors();
        IZone FilterZoneByOpeningState();

    }
}
