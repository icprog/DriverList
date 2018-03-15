using System.Windows.Forms;

namespace DriverList
{
    public class ListViewNoFlicker : ListView
    {
        public ListViewNoFlicker()
        {
            //Activate double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }
    }
}
