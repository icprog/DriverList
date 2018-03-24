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

            /// <summary>
            /// Set schedule fields and mark it as active
            /// </summary>
            /// <param name="scheduleTime">Time to run schedule</param>
            /// <param name="deviceName">Device name to stop by schedule</param>
            /// <param name="deviceID">DeviceId to stop by schedule</param>
            public void SetSchedule(TimeSpan scheduleTime, string deviceName, string deviceID)
            {
                this.IsSet = true;
                this.ScheduleTime = scheduleTime;
                this.DeviceName = deviceName;
                this.DeviceID = deviceID;
            }

            /// <summary>
            /// Start schedule execution 
            /// </summary>
            /// <param name="stopSubject">Control subject, to stop schedule anytime</param>
            public void StartSchedule(Subject<Unit> stopSubject)
            {
                StopDeviceScheduler.StartSchedule(this.ScheduleTime, this.DeviceID, stopSubject);
            }

            /// <summary>
            /// Unset all fields and mark schedule as inactive
            /// </summary>
            public void UnsetSchedule()
            {
                this.IsSet = false;
                this.ScheduleTime = TimeSpan.Zero;
                this.DeviceID = string.Empty;
                this.DeviceName = string.Empty;
            }
        }

        /// <summary>
        /// Calculate delay to due time from DateTime.Now
        /// </summary>
        /// <param name="scheduleTime"></param>
        /// <returns></returns>
        private static TimeSpan CalculateDelay(TimeSpan scheduleTime)
        {
            return CalculateDelay(DateTime.Now, scheduleTime);
        }

        /// <summary>
        /// Calculate delay to due time from desired DateTime
        /// </summary>
        /// <param name="startDate">DateTime from which delay will be calculated</param>
        /// <param name="scheduleTime">Time to which delay will be calculated</param>
        /// <returns></returns>
        private static TimeSpan CalculateDelay(DateTime startDate, TimeSpan scheduleTime)
        {
            var fireDate = startDate.Date.Add(scheduleTime);

            return (startDate > fireDate ? fireDate.AddDays(1) : fireDate) - startDate; //calculating delay to due time
        }

        /// <summary>
        /// Start daily schedule to stop desired device at desired time
        /// </summary>
        /// <param name="scheduleTime">Daytime to execute schedule task</param>
        /// <param name="deviceId">Device ID that should be stopped</param>
        /// <param name="stopSubject">Control subject, to stop schedule anytime</param>
        public static void StartSchedule(TimeSpan scheduleTime, string deviceId, Subject<Unit> stopSubject)
        {
            var delay = CalculateDelay(scheduleTime); //calculating delay to due time

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
