using Microsoft.AspNetCore.Mvc;
using rasberry_pi_pico_front_mvc.Services;
using System.Text.Json;

namespace rasberry_pi_pico_front_mvc.Controllers
{
    [Route("AI")]
    public class AIController : Controller
    {
        private readonly IGeminiService _gemini;

        public AIController(IGeminiService gemini)
        {
            _gemini = gemini;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Ask")]
        public async Task<IActionResult> Ask([FromBody] AskRequest req)
        {
            if (req == null || string.IsNullOrWhiteSpace(req.Question))
                return Json(new { answer = "❌ Soru alınamadı şefim." });

            var raw = await _gemini.AskGeminiAsync(req.Question);

            if (string.IsNullOrEmpty(raw))
                return Json(new { answer = "❌ Sunucu boş cevap döndü şefim." });

            if (raw.Contains("\"error\""))
                return Json(new { answer = "❌ AI hata verdi:\n" + raw });

            try
            {
                using var doc = JsonDocument.Parse(raw);

                var answer = doc.RootElement
                    .GetProperty("candidates")[0]
                    .GetProperty("content")
                    .GetProperty("parts")[0]
                    .GetProperty("text")
                    .GetString() ?? "Cevap alınamadı şefim.";

                return Json(new { answer });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    answer = $"❌ JSON parse edilemedi şefim: {ex.Message}\n\nHam cevap:\n{raw}"
                });
            }
        }

        public class AskRequest
        {
            public string Question { get; set; }
        }
    }
}
