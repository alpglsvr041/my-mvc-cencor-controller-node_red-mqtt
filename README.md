# Greenhouse Control System (ASP.NET MVC + Node-RED + MQTT + Gemini AI)

This project is an AI‑enhanced greenhouse monitoring and control system developed for Gülkay Greenhouse Technologies. It provides a unified dashboard for machine status tracking, temperature & humidity monitoring, historical data analysis, and remote operational control.

## 🚀 Features

* **ASP.NET MVC Frontend**

  * User‑friendly dashboard
  * Real‑time status cards
  * Temperature & humidity monitoring
  * Historical data visualization
  * Integrated AI assistant

* **Node‑RED Backend**

  * MQTT communication with Raspberry Pi Pico
  * Machine start/stop operations
  * Sensor data processing
  * AI integration using Gemini

* **AI Assistant**

  * Natural language Q&A about greenhouse status
  * Provides temperature, humidity, and machine state information
  * Interprets control commands (start/stop)

## 🧱 Tech Stack

* **ASP.NET MVC 8**
* **Bootstrap 5**
* **Node‑RED**
* **MQTT (Mosquitto)**
* **Raspberry Pi Pico**
* **Gemini AI API (secure backend usage)**

## 🔧 Architecture Overview

1. The user interacts with the ASP.NET MVC interface.
2. Commands are forwarded to Node‑RED via MQTT.
3. Device sensor data is processed and returned through Node‑RED.
4. The AI assistant communicates securely with Gemini through backend logic.
5. All updates are reflected on the frontend in real time.

## 📦 Setup

### 1. Clone the repository

```bash
git clone <https://github.com/alpglsvr041/my-mvc-cencor-controller-node_red-mqtt>
```

### 2. Run the ASP.NET application

* Open in Visual Studio
* Configure settings inside `appsettings.json`
* Run the project

### 3. Import Node‑RED Flow

* Open Node‑RED editor
* Import the flow file
* Configure MQTT broker settings

### 4. Connect the Device

* Set up Raspberry Pi Pico with MQTT
* Publish sensor data
* Subscribe to control topics

## 🔐 Security

* API keys are **never stored on the frontend**.
* All AI requests are executed from the backend.
* `appsettings.json` is server‑side only and not visible to users.

## 🖼 Example Screenshots

(You can add screenshots here)

## 📄 License

This project was created for Gülkay Greenhouse Technologies.

---

If you want to extend, optimize, or integrate more features, I'm here to help 🚀
