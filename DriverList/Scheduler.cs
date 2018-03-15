using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace DriverList
{
    public class Scheduler
    {
        [Serializable]
        public struct Schedule
        {
            public string DeviceID;
            public string DeviceName;
            public TimeSpan ScheduleTime;
            public bool IsSet;
        }      

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
                catch (Exception ex)
                {
                    //todo : log error or show it to user somehow
                }
            });
        }
    }
}
