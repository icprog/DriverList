using HardwareHelperLib;
using System.Collections.Generic;
using System.Linq;

namespace DriverList
{
    public class DriverProvider
    {
        static HH_Lib hhl = new HH_Lib();

        public static IEnumerable<DEVICE_INFO> GetDriverList()
        {
            return hhl.GetAll().OrderBy(items => items.name);
        }

        public static void StopDevice(DEVICE_INFO device)
        {
            hhl.SetDeviceState(device, false);
        }
    }
}
