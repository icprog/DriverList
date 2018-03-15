using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DriverList
{
    /// <summary>
    /// Class that controls save and load processes for schedule
    /// </summary>
    public class ScheduleSettingsProvider
    {
        private static string filename = "Schedule.bin";

        /// <summary>
        /// Serializes schedule and saves it to bin file in local directory
        /// </summary>
        /// <param name="schedule">Schedule to save</param>
        public static void Save(StopDeviceScheduler.Schedule schedule)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None))
                    formatter.Serialize(stream, schedule);
            }
            catch
            {
                //todo : log error or show it to user somehow
            }
        }

        /// <summary>
        /// Load and deserialize schedule from bin file from local directory
        /// </summary>
        /// <returns>Schedule details</returns>
        public static StopDeviceScheduler.Schedule Load()
        {
            if (File.Exists(filename))
            {
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                        return (StopDeviceScheduler.Schedule)formatter.Deserialize(stream);
                }
                catch
                {
                    //todo : log error or show it to user somehow
                }
            }
            return new StopDeviceScheduler.Schedule();
        }

        /// <summary>
        /// Removes serialized schedule file from local directory
        /// </summary>
        public static void Clear()
        {
            try
            {
                if (File.Exists(filename))
                    File.Delete(filename);
            }
            catch
            {
                //todo : log error or show it to user somehow
            }
        }

    }
}
