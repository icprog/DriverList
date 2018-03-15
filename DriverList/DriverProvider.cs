using HardwareHelperLib;
using System.Collections.Generic;
using System.Linq;

namespace DriverList
{
    /// <summary>
    /// Class that provides access to hardware library
    /// </summary>
    public class DriverProvider
    {        
        private static HH_Lib hhl = new HH_Lib();

        /// <summary>
        /// Get list of all available devices
        /// </summary>
        /// <returns>IEnumerable of DEVICE_INFO containing available information about device</returns>
        public static IEnumerable<DEVICE_INFO> GetDriverList()
        {           
            return hhl.GetAll().OrderBy(items => items.name);
        }

        /// <summary>
        /// Tries to stop any device
        /// </summary>
        /// <param name="device">DEVICE_INFO containing available information about device that should be stopped</param>
        /// <exception cref="System.Exception">Thrown when app is not running with administrator privileges</exception>
        public static void StopDevice(DEVICE_INFO device)
        {
            hhl.SetDeviceState(device, false);
        }
    }
}
