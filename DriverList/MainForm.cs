using HardwareHelperLib;
using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Windows.Forms;

namespace DriverList
{
    public partial class MainForm : Form
    {
        readonly Subject<Unit> stopSubject = new Subject<Unit>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartReloadingDevices();
        }

        private void scheduleButton_Click(object sender, System.EventArgs e)
        {

        }

        private void StartReloadingDevices()
        {
            Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(10))
                           .Select(x =>
                       {
                           HH_Lib hhl = new HH_Lib();
                           return hhl.GetAll();
                       })
                       .TakeUntil(stopSubject)
                       .ObserveOn(SynchronizationContext.Current)
                       .Subscribe(result =>
                       {
                           var listItems = result.Select(device => new ListViewItem(new string[] { device.name, device.friendlyName, device.hardwareId, device.status.ToString() })).ToArray();
                           listDrivers.Items.Clear();
                           listDrivers.Items.AddRange(listItems);
                       }, exception =>
                       {
                //todo : log error or show it to user somehow
            });
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopSubject.OnNext(Unit.Default);
        }        
    }
}
