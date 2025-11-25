using Microsoft.AspNetCore.SignalR;

namespace rasberry_pi_pico_front_mvc.Hubs
{
    public class SensorHub : Hub
    {
        // Sitedeki JavaScript bu metodu dinleyecek
        public async Task SendSensorData(double temp, double hum)
        {
            await Clients.All.SendAsync("ReceiveSensorData", temp, hum);
        }
    }
}