using System.Linq;

namespace DriverList
{
    /// <summary>
    /// Class that controls devices by stopping them
    /// </summary>
    public class DriverControl
    {
        private IDriverProvider provider;

        /// <summary>
        /// DriverControl Contructor 
        /// </summary>
        /// <param name="driverProvider">Instance of <see cref="IDriverProvider"/> implementing class</param>
        public DriverControl(IDriverProvider driverProvider)
        {
            provider = driverProvider;
        }

        /// <summary>
        /// DriverControl Contructor 
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
