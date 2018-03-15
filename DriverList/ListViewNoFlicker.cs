using System.Windows.Forms;

namespace DriverList
{
    /// <summary>
    /// Double buffered ListView
    /// </summary>
    public class ListViewNoFlicker : ListView
    {
        /// <summary>
        /// The class constructor
        /// </summary>
        public ListViewNoFlicker()
        {
            //Activate double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }
    }
}
