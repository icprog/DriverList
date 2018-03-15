using HardwareHelperLib;
using System;
using System.Collections.Generic;
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

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            if (scheduleDriverCombo.SelectedItem != null) 
                foreach (var device in DriverProvider.GetDriverList().Where(x => x.hardwareId == (string)scheduleDriverCombo.SelectedValue)) //find all devices with selected hardwareId
                    DriverProvider.StopDevice(device); //Stop device
        }

        private void StartReloadingDevices()
        {
            Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(10)) //Start new observable timer
                           .Select(x =>
                       {
                           return DriverProvider.GetDriverList();  //on each timer tick get list of all drivers in separate thread
                       })
                       .TakeUntil(stopSubject)  //more control. If we want we can stop it anytime
                       .ObserveOn(SynchronizationContext.Current)   //Sync results with current thread
                       .Subscribe(result => //receive results to process them
                       {
                           ReloadDriversGrid(result); //reload grid saving selection
                           ReloadDriversCombo(result); // reload combobox saving selection
                       }, exception =>
                       {
                           //todo : log error or show it to user somehow
                       });
        }

        private void ReloadDriversGrid(IEnumerable<DEVICE_INFO> result)
        {
            var selectedindex = -1;

            if (listDrivers.SelectedIndices.Count > 0)
            {
                selectedindex = listDrivers.SelectedIndices[0];
            }

            var results = result.Select(device => new ListViewItem(new string[] { device.name, device.friendlyName, device.hardwareId, device.status.ToString() })).ToArray();

            listDrivers.Items.Clear();
            listDrivers.Items.AddRange(results);

            if (selectedindex > 0 && listDrivers.Items.Count > selectedindex)
                listDrivers.Items[selectedindex].Selected = true;
        }

        private void ReloadDriversCombo(IEnumerable<DEVICE_INFO> result)
        {
            var selected = (DriverDetails)scheduleDriverCombo.SelectedItem;

            var datasource = result.Select(x =>
            new DriverDetails
            {
                Name = x.name + (string.IsNullOrEmpty(x.hardwareId) ? "" : string.Format(" ({0})", x.hardwareId)),  //make items more unique
                DeviceID = x.hardwareId
            }).ToList();

            scheduleDriverCombo.DataSource = datasource;

            scheduleDriverCombo.Refresh();

            if (selected != null)
            {
                scheduleDriverCombo.SelectedText = selected.Name;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopSubject.OnNext(Unit.Default);
        }
    }
}
