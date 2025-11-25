using rasberry_pi_pico_front_mvc.Services;
using System.Text;
using System.Text.Json;

public class GeminiService : IGeminiService
{
    private readonly IConfiguration _config;
    private readonly HttpClient _http;

    private const string MODEL = "gemini-2.5-flash";


    public GeminiService(IConfiguration config)
    {
        _config = config;
        _http = new HttpClient();
    }

    public async Task<string> AskGeminiAsync(string question)
    {
        var apiKey = _config["Gemini:ApiKey"];
        if (string.IsNullOrEmpty(apiKey))
            return "API key okunamadı (null).";

        var url =
            $"https://generativelanguage.googleapis.com/v1beta/models/{MODEL}:generateContent?key={apiKey}";

        var payload = new
        {
            contents = new[]
            {
                new {
                    parts = new[]
                    {
                        new { text = question }
                    }
                }
            }
        };

        var json = JsonSerializer.Serialize(payload);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var res = await _http.PostAsync(url, content);

        var txt = await res.Content.ReadAsStringAsync();

        Console.WriteLine("========== RAW API RESPONSE ==========");
        Console.WriteLine(txt);
        Console.WriteLine("======================================");

        return txt;
    }
}
