# Modbus/MQTT Data Logger Dashboard

![image](https://github.com/user-attachments/assets/a379d9e3-f82a-4cf1-9097-26d7e9d1f00f)

## 📌 Overview
The Industrial Sensor Data Logger & Dashboard is a WinForms application that connects to industrial sensors using MQTT and Modbus TCP/IP, logs sensor data into a SQLite database, and visualizes real-time trends using LiveCharts.
The app provides features for data logging, chart visualization, historical data export, and alert notifications based on user-defined thresholds.

## 🎯 Features
- ✅ Supports both MQTT and Modbus (switchable via UI)
- ✅ Real-time charting with LiveCharts
- ✅ Logs data in a SQLite database
- ✅ Alerts for high/low values
- ✅ Historical data viewing & filtering
- ✅ CSV export for analysis
- ✅ Modbus simulation support for testing

## 🛠️ Installation & Setup Guide
### 1️⃣ Prerequisites
Ensure you have the following installed:
- .NET Framework 4.7.2+
- Visual Studio (Community Edition is fine)
- NuGet Packages Installed
### 2️⃣ Install Required Packages
Open Visual Studio, go to Tools > NuGet Package Manager > Manage NuGet Packages for Solution and install:
```diff
- MQTTnet (v4.3.7)
- Newtonsoft.Json
- LiveCharts.WinForms
- System.Data.SQLite
- NModbus
```
### 3️⃣ MQTT Broker Setup
This app uses HiveMQ as a public MQTT broker. If you want to use your own broker:
1. Set up a local broker (e.g., Mosquitto)
2. Change the MQTT server address in Form1.cs:
```csharp
ChannelOptions = new MqttClientTcpOptions
{
    Server = "your-mqtt-broker-address",
    Port = 1883
}
```
### 4️⃣ Modbus Simulator Setup
If you don't have a real Modbus TCP device, you can use a Modbus simulator.
- 🛠️ Option 1: Modbus Slave (ModbusTools)
    - Download Modbus Slave from ModbusTools
    - Set up Holding Register 40001 with random values
- 🛠️ Option 2: ModbusPal (Java-based)
    - Download ModbusPal from here
    - Add Holding Register 40001
    - Start Modbus server on 127.0.0.1:502
 
## 💡 How It Works
1. Data Collection
    - MQTT Mode: Connects to HiveMQ (or a custom broker) and listens for sensor/dataIndustrial topic.
    - Modbus Mode: Connects to a Modbus TCP device or simulator and reads register 40001.
2. Real-time Visualization
    - Data is displayed in a LiveCharts Line Chart.
    - Alerts are shown when values exceed user-defined thresholds.
3. Data Storage & Export
    - SQLite Database: Stores all pressure readings.
    - CSV Export: Allows users to export logs for analysis.
