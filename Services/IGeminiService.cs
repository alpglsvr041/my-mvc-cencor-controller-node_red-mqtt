namespace rasberry_pi_pico_front_mvc.Services;

public interface IGeminiService
{
    Task<string> AskGeminiAsync(string question);
}
