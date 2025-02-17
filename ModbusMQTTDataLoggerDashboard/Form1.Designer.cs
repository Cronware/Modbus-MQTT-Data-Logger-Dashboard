namespace ModbusMQTTDataLoggerDashboard
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.checkBoxMode = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonViewHistory = new System.Windows.Forms.Button();
            this.buttonStopLogging = new System.Windows.Forms.Button();
            this.buttonExportCSV = new System.Windows.Forms.Button();
            this.buttonStartLogging = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSetThresholds = new System.Windows.Forms.Button();
            this.numericHighThreshold = new System.Windows.Forms.NumericUpDown();
            this.numericLowThreshold = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonExportFilteredCSV = new System.Windows.Forms.Button();
            this.buttonFilterHistory = new System.Windows.Forms.Button();
            this.numericMaxPressure = new System.Windows.Forms.NumericUpDown();
            this.numericMinPressure = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewLogs = new System.Windows.Forms.DataGridView();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.chartPressure = new LiveCharts.Wpf.CartesianChart();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHighThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLowThreshold)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxPressure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinPressure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxMode
            // 
            this.checkBoxMode.AutoSize = true;
            this.checkBoxMode.Location = new System.Drawing.Point(12, 12);
            this.checkBoxMode.Name = "checkBoxMode";
            this.checkBoxMode.Size = new System.Drawing.Size(194, 17);
            this.checkBoxMode.TabIndex = 0;
            this.checkBoxMode.Text = "Use Modbus (Unchecked = MQTT)";
            this.checkBoxMode.UseVisualStyleBackColor = true;
            this.checkBoxMode.CheckedChanged += new System.EventHandler(this.checkBoxMode_CheckedChanged_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonViewHistory);
            this.groupBox1.Controls.Add(this.buttonStopLogging);
            this.groupBox1.Controls.Add(this.buttonExportCSV);
            this.groupBox1.Controls.Add(this.buttonStartLogging);
            this.groupBox1.Location = new System.Drawing.Point(12, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 112);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sensor Data Logger";
            // 
            // buttonViewHistory
            // 
            this.buttonViewHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonViewHistory.Location = new System.Drawing.Point(192, 64);
            this.buttonViewHistory.Name = "buttonViewHistory";
            this.buttonViewHistory.Size = new System.Drawing.Size(180, 39);
            this.buttonViewHistory.TabIndex = 3;
            this.buttonViewHistory.Text = "View History";
            this.buttonViewHistory.UseVisualStyleBackColor = true;
            this.buttonViewHistory.Click += new System.EventHandler(this.buttonViewHistory_Click_1);
            // 
            // buttonStopLogging
            // 
            this.buttonStopLogging.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStopLogging.Location = new System.Drawing.Point(6, 64);
            this.buttonStopLogging.Name = "buttonStopLogging";
            this.buttonStopLogging.Size = new System.Drawing.Size(180, 39);
            this.buttonStopLogging.TabIndex = 2;
            this.buttonStopLogging.Text = "Stop Logging";
            this.buttonStopLogging.UseVisualStyleBackColor = true;
            this.buttonStopLogging.Click += new System.EventHandler(this.buttonStopLogging_Click_1);
            // 
            // buttonExportCSV
            // 
            this.buttonExportCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportCSV.Location = new System.Drawing.Point(192, 19);
            this.buttonExportCSV.Name = "buttonExportCSV";
            this.buttonExportCSV.Size = new System.Drawing.Size(180, 39);
            this.buttonExportCSV.TabIndex = 1;
            this.buttonExportCSV.Text = "Export to CSV";
            this.buttonExportCSV.UseVisualStyleBackColor = true;
            this.buttonExportCSV.Click += new System.EventHandler(this.buttonExportCSV_Click_1);
            // 
            // buttonStartLogging
            // 
            this.buttonStartLogging.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartLogging.Location = new System.Drawing.Point(6, 19);
            this.buttonStartLogging.Name = "buttonStartLogging";
            this.buttonStartLogging.Size = new System.Drawing.Size(180, 39);
            this.buttonStartLogging.TabIndex = 0;
            this.buttonStartLogging.Text = "Start Logging";
            this.buttonStartLogging.UseVisualStyleBackColor = true;
            this.buttonStartLogging.Click += new System.EventHandler(this.buttonStartLogging_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSetThresholds);
            this.groupBox2.Controls.Add(this.numericHighThreshold);
            this.groupBox2.Controls.Add(this.numericLowThreshold);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(399, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 112);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thresholds";
            // 
            // buttonSetThresholds
            // 
            this.buttonSetThresholds.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetThresholds.Location = new System.Drawing.Point(357, 26);
            this.buttonSetThresholds.Name = "buttonSetThresholds";
            this.buttonSetThresholds.Size = new System.Drawing.Size(26, 69);
            this.buttonSetThresholds.TabIndex = 3;
            this.buttonSetThresholds.Text = "SET";
            this.buttonSetThresholds.UseVisualStyleBackColor = true;
            this.buttonSetThresholds.Click += new System.EventHandler(this.buttonSetThresholds_Click_1);
            // 
            // numericHighThreshold
            // 
            this.numericHighThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericHighThreshold.Location = new System.Drawing.Point(241, 68);
            this.numericHighThreshold.Maximum = new decimal(new int[] {
            1100,
            0,
            0,
            0});
            this.numericHighThreshold.Minimum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericHighThreshold.Name = "numericHighThreshold";
            this.numericHighThreshold.Size = new System.Drawing.Size(110, 26);
            this.numericHighThreshold.TabIndex = 3;
            this.numericHighThreshold.Value = new decimal(new int[] {
            940,
            0,
            0,
            0});
            // 
            // numericLowThreshold
            // 
            this.numericLowThreshold.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericLowThreshold.Location = new System.Drawing.Point(241, 30);
            this.numericLowThreshold.Maximum = new decimal(new int[] {
            1100,
            0,
            0,
            0});
            this.numericLowThreshold.Minimum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericLowThreshold.Name = "numericLowThreshold";
            this.numericLowThreshold.Size = new System.Drawing.Size(110, 26);
            this.numericLowThreshold.TabIndex = 2;
            this.numericLowThreshold.Value = new decimal(new int[] {
            960,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "High Pressure Threshold (hPa):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Low Pressure Threshold (hPa):";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonExportFilteredCSV);
            this.groupBox3.Controls.Add(this.buttonFilterHistory);
            this.groupBox3.Controls.Add(this.numericMaxPressure);
            this.groupBox3.Controls.Add(this.numericMinPressure);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dateTimePickerEnd);
            this.groupBox3.Controls.Add(this.dateTimePickerStart);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 153);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(776, 77);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filters";
            // 
            // buttonExportFilteredCSV
            // 
            this.buttonExportFilteredCSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExportFilteredCSV.Location = new System.Drawing.Point(654, 16);
            this.buttonExportFilteredCSV.Name = "buttonExportFilteredCSV";
            this.buttonExportFilteredCSV.Size = new System.Drawing.Size(109, 50);
            this.buttonExportFilteredCSV.TabIndex = 8;
            this.buttonExportFilteredCSV.Text = "Filtered CSV";
            this.buttonExportFilteredCSV.UseVisualStyleBackColor = true;
            this.buttonExportFilteredCSV.Click += new System.EventHandler(this.buttonExportFilteredCSV_Click_1);
            // 
            // buttonFilterHistory
            // 
            this.buttonFilterHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFilterHistory.Location = new System.Drawing.Point(539, 16);
            this.buttonFilterHistory.Name = "buttonFilterHistory";
            this.buttonFilterHistory.Size = new System.Drawing.Size(109, 50);
            this.buttonFilterHistory.TabIndex = 7;
            this.buttonFilterHistory.Text = "Filter History";
            this.buttonFilterHistory.UseVisualStyleBackColor = true;
            this.buttonFilterHistory.Click += new System.EventHandler(this.buttonFilterHistory_Click_1);
            // 
            // numericMaxPressure
            // 
            this.numericMaxPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericMaxPressure.Location = new System.Drawing.Point(431, 42);
            this.numericMaxPressure.Maximum = new decimal(new int[] {
            1100,
            0,
            0,
            0});
            this.numericMaxPressure.Minimum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericMaxPressure.Name = "numericMaxPressure";
            this.numericMaxPressure.Size = new System.Drawing.Size(86, 24);
            this.numericMaxPressure.TabIndex = 6;
            this.numericMaxPressure.Value = new decimal(new int[] {
            1050,
            0,
            0,
            0});
            // 
            // numericMinPressure
            // 
            this.numericMinPressure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericMinPressure.Location = new System.Drawing.Point(431, 16);
            this.numericMinPressure.Maximum = new decimal(new int[] {
            1100,
            0,
            0,
            0});
            this.numericMinPressure.Minimum = new decimal(new int[] {
            900,
            0,
            0,
            0});
            this.numericMinPressure.Name = "numericMinPressure";
            this.numericMinPressure.Size = new System.Drawing.Size(86, 24);
            this.numericMinPressure.TabIndex = 4;
            this.numericMinPressure.Value = new decimal(new int[] {
            950,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(321, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 18);
            this.label6.TabIndex = 5;
            this.label6.Text = "Max Pressure:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(325, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 18);
            this.label5.TabIndex = 4;
            this.label5.Text = "Min Pressure:";
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(90, 44);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(195, 20);
            this.dateTimePickerEnd.TabIndex = 3;
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(90, 16);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(195, 20);
            this.dateTimePickerStart.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "End Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Start Date:";
            // 
            // dataGridViewLogs
            // 
            this.dataGridViewLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLogs.Location = new System.Drawing.Point(12, 236);
            this.dataGridViewLogs.Name = "dataGridViewLogs";
            this.dataGridViewLogs.Size = new System.Drawing.Size(381, 202);
            this.dataGridViewLogs.TabIndex = 4;
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(399, 236);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(389, 202);
            this.elementHost1.TabIndex = 5;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = this.chartPressure;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.elementHost1);
            this.Controls.Add(this.dataGridViewLogs);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxMode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Modbus/MQTT Data Logger Dashboard";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericHighThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLowThreshold)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaxPressure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinPressure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxMode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonViewHistory;
        private System.Windows.Forms.Button buttonStopLogging;
        private System.Windows.Forms.Button buttonExportCSV;
        private System.Windows.Forms.Button buttonStartLogging;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericLowThreshold;
        private System.Windows.Forms.Button buttonSetThresholds;
        private System.Windows.Forms.NumericUpDown numericHighThreshold;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonFilterHistory;
        private System.Windows.Forms.NumericUpDown numericMaxPressure;
        private System.Windows.Forms.NumericUpDown numericMinPressure;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonExportFilteredCSV;
        private System.Windows.Forms.DataGridView dataGridViewLogs;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
        private LiveCharts.Wpf.CartesianChart chartPressure;
    }
}

