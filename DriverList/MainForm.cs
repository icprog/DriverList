﻿using HardwareHelperLib;
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
        readonly Subject<Unit> scheduleStopSubject = new Subject<Unit>();

        Scheduler.Schedule schedule = new Scheduler.Schedule();

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
            if (!schedule.IsSet && scheduleDriverCombo.SelectedItem != null)
            {
                schedule.IsSet = true;
                schedule.ScheduleTime = new TimeSpan(scheduleTimePicker.Value.Hour, scheduleTimePicker.Value.Minute, scheduleTimePicker.Value.Second);
                schedule.DeviceID = ((DriverDetails)scheduleDriverCombo.SelectedItem).DeviceID;
                schedule.DeviceName = ((DriverDetails)scheduleDriverCombo.SelectedItem).Name;

                scheduleStopSubject.OnNext(Unit.Default); //stop scheduler if it's running

                Scheduler.StartSchedule(schedule.ScheduleTime, schedule.DeviceID, scheduleStopSubject); //starting schedule again

                UpdateScheduleUI();
            }
            else if (schedule.IsSet)
            {
                schedule = new Scheduler.Schedule();
                scheduleStopSubject.OnNext(Unit.Default);   //stop scheduler if it's running         
                ClearScheduleUI();
            }
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

        private void UpdateScheduleUI()
        {
            scheduleButton.Text = schedule.IsSet ? "Unset" : "Set";
            if (schedule.IsSet)
            {
                scheduleTimePicker.Value = DateTime.Today.Add(schedule.ScheduleTime);

                scheduleDriverCombo.SelectedValue = schedule.DeviceID;
            }
        }

        private void ClearScheduleUI()
        {
            scheduleButton.Text = "Set";
            if (schedule.IsSet)
            {
                scheduleDriverCombo.SelectedIndex = 0;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopSubject.OnNext(Unit.Default);
            scheduleStopSubject.OnNext(Unit.Default);
        }
    }
}
