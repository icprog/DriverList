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

        }

        private void StartReloadingDevices()
        {
            Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(10))
                           .Select(x =>
                       {                           
                           return DriverProvider.GetDriverList().ToList();
                       })
                       .TakeUntil(stopSubject)
                       .ObserveOn(SynchronizationContext.Current)
                       .Subscribe(result =>
                       {
                           ReloadDriversGrid(result);
                       }, exception =>
                       {
                //todo : log error or show it to user somehow
            });
        }

        private void ReloadDriversGrid(List<DEVICE_INFO> result)
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

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopSubject.OnNext(Unit.Default);
        }        
    }
}
