using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using rasberry_pi_pico_front_mvc.Hubs;

namespace rasberry_pi_pico_front_mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorApiController : ControllerBase
    {
        private readonly IHubContext<SensorHub> _hubContext;

        public SensorApiController(IHubContext<SensorHub> hubContext)
        {
            _hubContext = hubContext;
        }

        // Node-RED buraya POST isteği atacak
        [HttpPost]
        public async Task<IActionResult> PostSensorData([FromBody] SensorData data)
        {
            // Gelen veriyi anında sitedeki herkese (Frontend'e) fırlat
            await _hubContext.Clients.All.SendAsync("ReceiveSensorData", data.Temperature, data.Humidity);

            return Ok(new { status = "Veri alındı ve siteye basıldı şefim!" });
        }
    }

    // Gelen verinin modeli
    public class SensorData
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
    }
}