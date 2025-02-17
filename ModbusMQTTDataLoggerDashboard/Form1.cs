using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Packets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.IO;
using System.Data.SQLite;
using System.Net.Sockets;
using NModbus;

namespace ModbusMQTTDataLoggerDashboard
{
    public partial class Form1 : Form
    {
        private IMqttClient mqttClient;
        private ChartValues<float> pressureValues = new ChartValues<float>();
        private float lowPressureThreshold = 960;
        private float highPressureThreshold = 1040;
        private string dbPath = "Data Source=sensor_data.db;Version=3;";
        private bool useModbus = false;
        private bool isPollingActive = false;
        private System.Timers.Timer modbusTimer;
        private float latestMQTTPressure = 0;
        public Form1()
        {
            InitializeComponent();
            InitializeChart();
            InitializeDatabase();

            dataGridViewLogs.ColumnCount = 2;
            dataGridViewLogs.Columns[0].Name = "Timestamp";
            dataGridViewLogs.Columns[1].Name = "Message";
        }

        private async Task PollModbusData()
        {
            float pressure = await ReadModbusPressureAsync("127.0.0.1", 502, 0); //MODBUS SLAVE SETTINGS
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Invoke((MethodInvoker)(() =>
            {
                SaveDataToDatabase(timestamp, pressure);
                LogPressureData(pressure);
            }));
        }

        private void StartModbusPolling()
        {
            if (isPollingActive) return;

            isPollingActive = true;
            modbusTimer = new System.Timers.Timer(5000);
            modbusTimer.Elapsed += async (sender, e) => await PollModbusData();
            modbusTimer.AutoReset = true;
            modbusTimer.Start();

            MessageBox.Show("Started continuous Modbus polling.", "Modbus", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void ConnectToMQTT()
        {
            var factory = new MqttFactory();
            mqttClient = factory.CreateMqttClient();

            var mqttOptions = new MqttClientOptionsBuilder()
        .WithClientId(Guid.NewGuid().ToString())
        .WithTcpServer("broker.hivemq.com", 1883)
        .Build();

            mqttClient.ConnectedAsync += async e =>
            {
                MessageBox.Show("Connected to MQTT Broker!");

                await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder()
                    .WithTopic("sensor/dataIndustrial")
                    .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce)
                    .Build());

                await Task.CompletedTask; 
            };
            mqttClient.ApplicationMessageReceivedAsync += async e =>
            {
                try
                {
                    string payload = Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment.ToArray());
                    JObject json = JObject.Parse(payload);

                    latestMQTTPressure = json["pressure"]?.Value<float>() ?? 0;
                    string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    Invoke((MethodInvoker)(() =>
                    {
                        LogPressureData(latestMQTTPressure);
                    }));

                    await Task.CompletedTask; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error parsing MQTT message: " + ex.Message);
                }
            };

            try
            {
                await mqttClient.ConnectAsync(mqttOptions, CancellationToken.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show("MQTT Connection Failed: " + ex.Message);
            }
        }
        private void LogPressureData(float pressure)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            Invoke((MethodInvoker)(() =>
            {
                dataGridViewLogs.Rows.Add(timestamp, pressure);
                pressureValues.Add(pressure);

                if (pressureValues.Count > 20)
                {
                    pressureValues.RemoveAt(0);
                }

                chartPressure.AxisX[0].Labels.Add(DateTime.Now.ToShortTimeString());
                if (chartPressure.AxisX[0].Labels.Count > 20)
                {
                    chartPressure.AxisX[0].Labels.RemoveAt(0);
                }

                chartPressure.Update();
                SaveDataToDatabase(timestamp, pressure);

                if (pressure < lowPressureThreshold)
                {
                    MessageBox.Show($"Warning: Pressure too LOW ({pressure} hPa)!", "Low Pressure Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (pressure > highPressureThreshold)
                {
                    MessageBox.Show($"Warning: Pressure too HIGH ({pressure} hPa)!", "High Pressure Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }));
        }

        private void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string createTableQuery = @"CREATE TABLE IF NOT EXISTS PressureLog (
                                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Timestamp TEXT,
                                    Pressure REAL)";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        private void InitializeChart()
        {
            chartPressure.Series = new SeriesCollection
    {
        new LineSeries
        {
            Title = "Pressure (hPa)",
            Values = pressureValues
        }
    };

            chartPressure.AxisX.Add(new Axis
            {
                Title = "Time",
                Labels = new List<string>()
            });

            chartPressure.AxisY.Add(new Axis
            {
                Title = "Pressure (hPa)",
                MinValue = 950,
                MaxValue = 1050
            });
        }

        private void SaveDataToDatabase(string timestamp, float pressure)
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string insertQuery = "INSERT INTO PressureLog (Timestamp, Pressure) VALUES (@timestamp, @pressure)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@timestamp", timestamp);
                    command.Parameters.AddWithValue("@pressure", pressure);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void LoadDataFromDatabase()
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = "SELECT Timestamp, Pressure FROM PressureLog ORDER BY Id DESC LIMIT 100";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    dataGridViewLogs.Rows.Clear();

                    while (reader.Read())
                    {
                        string timestamp = reader["Timestamp"].ToString();
                        float pressure = reader.GetFloat(1);
                        dataGridViewLogs.Rows.Add(timestamp, pressure);
                    }
                }
            }
        }

        private void LoadFilteredDataFromDatabase()
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string query = "SELECT Timestamp, Pressure FROM PressureLog WHERE Timestamp BETWEEN @startDate AND @endDate AND Pressure BETWEEN @minPressure AND @maxPressure ORDER BY Timestamp ASC";

                using (var command = new SQLiteCommand(query, connection))
                {
                    string startDate = dateTimePickerStart.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    string endDate = dateTimePickerEnd.Value.ToString("yyyy-MM-dd HH:mm:ss");
                    float minPressure = (float)numericMinPressure.Value;
                    float maxPressure = (float)numericMaxPressure.Value;

                    command.Parameters.AddWithValue("@startDate", startDate);
                    command.Parameters.AddWithValue("@endDate", endDate);
                    command.Parameters.AddWithValue("@minPressure", minPressure);
                    command.Parameters.AddWithValue("@maxPressure", maxPressure);

                    using (var reader = command.ExecuteReader())
                    {
                        dataGridViewLogs.Rows.Clear();

                        while (reader.Read())
                        {
                            string timestamp = reader["Timestamp"].ToString();
                            float pressure = reader.GetFloat(1);
                            dataGridViewLogs.Rows.Add(timestamp, pressure);
                        }
                    }
                }
            }
        }
        private void ExportFilteredDataToCSV()
        {
            if (dataGridViewLogs.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = "Filtered_PressureData.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(sfd.FileName))
                        {
                            writer.WriteLine("Timestamp,Pressure (hPa)");

                            foreach (DataGridViewRow row in dataGridViewLogs.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    string timestamp = row.Cells[0].Value?.ToString() ?? "";
                                    string pressure = row.Cells[1].Value?.ToString() ?? "";
                                    writer.WriteLine($"{timestamp},{pressure}");
                                }
                            }
                        }

                        MessageBox.Show("Filtered data exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting CSV: " + ex.Message);
                    }
                }
            }
        }
        private async Task<float> ReadModbusPressureAsync(string ipAddress, ushort port, ushort register)
        {
            try
            {
                using (TcpClient client = new TcpClient(ipAddress, port))
                {
                    var factory = new ModbusFactory();
                    var master = factory.CreateMaster(client);

                    ushort[] registers = await master.ReadHoldingRegistersAsync(1, 0, 1);

                    return registers[0] / 10.0f;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Modbus Read Error: " + ex.Message);
                return 0;
            }
        }

        private void buttonStartLogging_Click_1(object sender, EventArgs e)
        {
            if (useModbus)
            {
                StartModbusPolling();
            }
            else
            {
                ConnectToMQTT();
            }
        }

        private void buttonStopLogging_Click_1(object sender, EventArgs e)
        {
            if (useModbus)
            {
                if (modbusTimer != null)
                {
                    modbusTimer.Stop();
                    modbusTimer.Dispose();
                    isPollingActive = false;
                    MessageBox.Show("Stopped Modbus polling.", "Modbus", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (mqttClient != null && mqttClient.IsConnected)
                {
                    try
                    {
                        mqttClient.DisconnectAsync();
                        MessageBox.Show("Disconnected from MQTT Broker!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error disconnecting: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("MQTT is already disconnected.");
                }
            }
        }

        private void buttonExportCSV_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewLogs.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = "PressureData.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(sfd.FileName))
                        {
                            writer.WriteLine("Timestamp,Pressure (hPa)");

                            foreach (DataGridViewRow row in dataGridViewLogs.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    string timestamp = row.Cells[0].Value?.ToString() ?? "";
                                    string pressure = row.Cells[1].Value?.ToString() ?? "";
                                    writer.WriteLine($"{timestamp};{pressure}");
                                }
                            }
                        }

                        MessageBox.Show("Data exported successfully!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting CSV: " + ex.Message);
                    }
                }
            }
        }

        private void buttonSetThresholds_Click_1(object sender, EventArgs e)
        {
            lowPressureThreshold = (float)numericLowThreshold.Value;
            highPressureThreshold = (float)numericHighThreshold.Value;
            MessageBox.Show($"Thresholds Updated!\nLow: {lowPressureThreshold} hPa\nHigh: {highPressureThreshold} hPa",
                            "Alert Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonViewHistory_Click_1(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
            MessageBox.Show("Loaded last 100 pressure readings!", "History Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonFilterHistory_Click_1(object sender, EventArgs e)
        {
            LoadFilteredDataFromDatabase();
            MessageBox.Show("Filtered data loaded!", "Filter Applied", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonExportFilteredCSV_Click_1(object sender, EventArgs e)
        {
            ExportFilteredDataToCSV();
            MessageBox.Show("Data exported successfully!");
        }

        private void checkBoxMode_CheckedChanged_1(object sender, EventArgs e)
        {
            useModbus = checkBoxMode.Checked;
            MessageBox.Show($"Switched to {(useModbus ? "Modbus" : "MQTT")} mode.", "Mode Switch", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
