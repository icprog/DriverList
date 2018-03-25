using HardwareHelperLib;
using System.Collections;
using System.Collections.Generic;

namespace DriverList
{
    /// <summary>
    /// Interface that dictates structure for every DriverProvider class
    /// </summary>
    public interface IDriverProvider
    {
        /// <summary>
        /// Method that returns list of drivers available
        /// </summary>
        /// <returns><see cref="IEnumerable"/> of <see cref="DEVICE_INFO"/> available</returns>
        IEnumerable<DEVICE_INFO> GetDriverList();

        /// <summary>
        /// MEthod that thop device by it's known info
        /// </summary>
        /// <param name="device"><see cref="DEVICE_INFO"/> of device to stop</param>
        void StopDevice(DEVICE_INFO device);
    }
}
