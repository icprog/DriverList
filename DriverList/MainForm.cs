using HardwareHelperLib;
using System.Linq;
using System.Windows.Forms;

namespace DriverList
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            HH_Lib hhl = new HH_Lib();
            var devices = hhl.GetAll();

            var listItems = devices.Select(device => new ListViewItem(new string[] { device.name, device.friendlyName, device.hardwareId, device.status.ToString() })).ToArray();            
            listDrivers.Items.Clear();
            listDrivers.Items.AddRange(listItems);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void scheduleButton_Click(object sender, System.EventArgs e)
        {

        }
    }
}
