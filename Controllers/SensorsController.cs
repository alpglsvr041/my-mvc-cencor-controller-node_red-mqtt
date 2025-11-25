using Microsoft.AspNetCore.Mvc;

namespace rasberry_pi_pico_front_mvc.Controllers
{
    public class SensorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // API'den sıcaklık-nem çekmek için endpoint
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            // ÖRNEK - Raspberry Pi Pico’dan gelecek şekilde düzenleyebilirsin

            var result = new
            {
                sicaklik = 24.7,
                nem = 52.3
            };

            return Json(result);
        }
    }
}
