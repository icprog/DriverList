namespace DriverList
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listDrivers = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.scheduleButton = new System.Windows.Forms.Button();
            this.scheduleTimePicker = new System.Windows.Forms.DateTimePicker();
            this.scheduleDriverCombo = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(733, 272);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listDrivers);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(727, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loaded Drivers";
            // 
            // listDrivers
            // 
            this.listDrivers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDrivers.FullRowSelect = true;
            this.listDrivers.Location = new System.Drawing.Point(3, 16);
            this.listDrivers.MultiSelect = false;
            this.listDrivers.Name = "listDrivers";
            this.listDrivers.Size = new System.Drawing.Size(721, 197);
            this.listDrivers.TabIndex = 0;
            this.listDrivers.UseCompatibleStateImageBehavior = false;
            this.listDrivers.View = System.Windows.Forms.View.Details;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 225);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(727, 44);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Driver Stop Schedule";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.scheduleButton, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.scheduleTimePicker, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.scheduleDriverCombo, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(721, 25);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // scheduleButton
            // 
            this.scheduleButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleButton.Location = new System.Drawing.Point(622, 1);
            this.scheduleButton.Margin = new System.Windows.Forms.Padding(1);
            this.scheduleButton.Name = "scheduleButton";
            this.scheduleButton.Size = new System.Drawing.Size(98, 23);
            this.scheduleButton.TabIndex = 0;
            this.scheduleButton.Text = "Set";
            this.scheduleButton.UseVisualStyleBackColor = true;
            this.scheduleButton.Click += new System.EventHandler(this.scheduleButton_Click);
            // 
            // scheduleTimePicker
            // 
            this.scheduleTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.scheduleTimePicker.Location = new System.Drawing.Point(2, 2);
            this.scheduleTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.scheduleTimePicker.Name = "scheduleTimePicker";
            this.scheduleTimePicker.ShowUpDown = true;
            this.scheduleTimePicker.Size = new System.Drawing.Size(96, 20);
            this.scheduleTimePicker.TabIndex = 1;
            // 
            // scheduleDriverCombo
            // 
            this.scheduleDriverCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scheduleDriverCombo.FormattingEnabled = true;
            this.scheduleDriverCombo.Location = new System.Drawing.Point(102, 2);
            this.scheduleDriverCombo.Margin = new System.Windows.Forms.Padding(2);
            this.scheduleDriverCombo.Name = "scheduleDriverCombo";
            this.scheduleDriverCombo.Size = new System.Drawing.Size(517, 21);
            this.scheduleDriverCombo.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 272);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(749, 311);
            this.Name = "MainForm";
            this.Text = "Driver List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button scheduleButton;
        private System.Windows.Forms.DateTimePicker scheduleTimePicker;
        private System.Windows.Forms.ComboBox scheduleDriverCombo;
        private System.Windows.Forms.ListView listDrivers;
    }
}


