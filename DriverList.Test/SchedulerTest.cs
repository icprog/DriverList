using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DriverList.Test
{
    [TestClass]
    public class SchedulerTest
    {
        TimeSpan defaultSpan = TimeSpan.FromHours(1);
        string defaultDeviceName = "TestDevice";
        string defaultDeviceId = "TestID";

        [TestMethod]
        public void SetUnsetScheduleTest()
        {
            StopDeviceScheduler.Schedule schedule = new StopDeviceScheduler.Schedule();

            Assert.IsFalse(schedule.IsSet);

            schedule.SetSchedule(defaultSpan, defaultDeviceName, defaultDeviceId);

            Assert.AreEqual(schedule.ScheduleTime, defaultSpan);
            Assert.AreEqual(schedule.DeviceName, defaultDeviceName);
            Assert.AreEqual(schedule.DeviceID, defaultDeviceId);
            Assert.IsTrue(schedule.IsSet);

            schedule.UnsetSchedule();

            Assert.AreEqual(schedule.ScheduleTime, TimeSpan.Zero);
            Assert.AreEqual(schedule.DeviceName, string.Empty);
            Assert.AreEqual(schedule.DeviceID, string.Empty);
            Assert.IsFalse(schedule.IsSet);
        }

        [TestMethod]
        public void DelayCalculationTest()
        {
            StopDeviceScheduler scheduler = new StopDeviceScheduler();

            var resultingSpan = scheduler.CalculateDelay(DateTime.Today, defaultSpan);
            Assert.AreEqual(resultingSpan, defaultSpan);

            resultingSpan = scheduler.CalculateDelay(DateTime.Today.AddHours(2), defaultSpan);

            Assert.AreEqual(resultingSpan, TimeSpan.FromHours(23));
        }
    }
}
