#include <WiFi.h>
#include <PubSubClient.h>

// WiFi Credentials
const char* ssid = "MTM-uWifi";       // 🔹 Replace with your WiFi SSID
const char* password = "!qaz@wsx";   // 🔹 Replace with your WiFi Password

// MQTT Broker Settings
const char* mqtt_server = "broker.hivemq.com";  // HiveMQ Public Broker
const char* mqtt_topic = "sensor/dataIndustrial";         // MQTT Topic to publish data

WiFiClient espClient;
PubSubClient client(espClient);

void setup() {
    Serial.begin(115200);
    
    // Connect to WiFi
    WiFi.begin(ssid, password);
    while (WiFi.status() != WL_CONNECTED) {
        delay(1000);
        Serial.println("Connecting to WiFi...");
    }
    Serial.println("WiFi connected!");

    // Connect to MQTT Broker
    client.setServer(mqtt_server, 1883);
    while (!client.connected()) {
        Serial.println("Connecting to MQTT...");
        if (client.connect("ESP32_Client")) {
            Serial.println("Connected to MQTT!");
        } else {
            Serial.print("Failed, retrying in 5 seconds...");
            delay(5000);
        }
    }
}

void loop() {
    if (!client.connected()) {
        Serial.println("MQTT Disconnected! Reconnecting...");
        client.connect("ESP32_Client");
    }

    // Generate Random Pressure Data (in Pascals)
    float pressure = random(95000, 105000) / 100.0; // Simulating between 950.00hPa to 1050.00hPa

    // Create JSON Payload
    String payload = "{ \"pressure\": " + String(pressure, 2) + " }";
    
    // Publish to MQTT Topic
    client.publish(mqtt_topic, payload.c_str());
    
    Serial.println("Published: " + payload);

    client.loop();
    delay(2000); // Send data every 2 seconds
}
