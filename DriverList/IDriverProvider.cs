using HardwareHelperLib;
using System.Collections.Generic;

namespace DriverList
{
    /// <summary>
    /// 
    /// </summary>
   public interface IDriverProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<DEVICE_INFO> GetDriverList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="device"></param>
        void StopDevice(DEVICE_INFO device);
    }
}
