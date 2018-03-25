using System.Collections.Generic;
using HardwareHelperLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DriverList.Test
{
    [TestClass]
    public class DriverControlTest
    {
        private List<DEVICE_INFO> testDevices = new List<DEVICE_INFO>();

        [TestInitialize]
        public void TestInitialize()
        {            
            testDevices.Add(new DEVICE_INFO { hardwareId = "TestID" });
            testDevices.Add(new DEVICE_INFO { hardwareId = "TestID" });
            testDevices.Add(new DEVICE_INFO { hardwareId = "TestID2" });
        }

        [TestMethod]
        public void StopDevicesByIdTest()
        {
            Mock<IDriverProvider> mock = new Mock<IDriverProvider>();
            mock.Setup(oper => oper.GetDriverList()).Returns(testDevices);
            mock.Setup(oper => oper.StopDevice(It.IsAny<DEVICE_INFO>()));

            DriverControl dc = new DriverControl(mock.Object);

            dc.StopDeviceByID("TestID");

            mock.Verify(mck => mck.GetDriverList(), Times.Once());

            mock.Verify(mck => mck.StopDevice(It.IsAny<DEVICE_INFO>()), Times.Exactly(2));
        }
    }
}
