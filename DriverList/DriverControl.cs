using System.Linq;

namespace DriverList
{
    /// <summary>
    /// 
    /// </summary>
    public class DriverControl
    {
        private IDriverProvider provider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="driverProvider"></param>
        public DriverControl(IDriverProvider driverProvider)
        {
            provider = driverProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        public DriverControl()
        {
            provider = new DriverProvider();
        }
        /// <summary>
        /// Tries to stop any device by it's id
        /// </summary>
        /// <param name="deviceId"> ID of device that should be stopped</param>
        public void StopDeviceByID(string deviceId)
        {
            foreach (var device in provider.GetDriverList().Where(x => x.hardwareId == deviceId))
                provider.StopDevice(device);
        }
    }
}
