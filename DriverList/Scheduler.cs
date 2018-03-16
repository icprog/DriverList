using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace DriverList
{
    /// <summary>
    /// Class that executes schedule at desired time
    /// </summary>
    public class StopDeviceScheduler
    {
        /// <summary>
        /// Structure that stores schedule details
        /// </summary>
        [Serializable]
        public struct Schedule
        {
            /// <summary>
            /// Hardware ID of device that will be stopped by scheduler
            /// </summary>
            public string DeviceID;

            /// <summary>
            /// Device name of device that will be stopped by scheduler
            /// </summary>
            public string DeviceName;

            /// <summary>
            /// Time of the day when scheduler will run
            /// </summary>
            public TimeSpan ScheduleTime;

            /// <summary>
            /// Flag that show state of schedule
            /// </summary>
            public bool IsSet;
        }      

        /// <summary>
        /// Start daily schedule to stop desired device at desired time
        /// </summary>
        /// <param name="scheduleTime">Daytime to execute schedule task</param>
        /// <param name="deviceId">Device ID that should be stopped</param>
        /// <param name="stopSubject">Control subject, to stop schedule anytime</param>
        public static void StartSchedule(TimeSpan scheduleTime, string deviceId, Subject<Unit> stopSubject)
        {
            var now = DateTime.Now;
            var fireDate = DateTime.Today.Add(scheduleTime);

            var delay = (now > fireDate ? fireDate.AddDays(1) : fireDate) - now; //calculating delay to due time

            Observable.Timer(delay, TimeSpan.FromDays(1))
            .TakeUntil(stopSubject)
            .Subscribe(result =>
            {
                try
                {
                    foreach (var device in DriverProvider.GetDriverList().Where(x => x.hardwareId == deviceId))
                        DriverProvider.StopDevice(device);
                }
                catch
                {
                    //todo : log error or show it to user somehow
                }
            });
        }
    }
}
