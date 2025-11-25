using rasberry_pi_pico_front_mvc.Hubs;
using rasberry_pi_pico_front_mvc.Services;

var builder = WebApplication.CreateBuilder(args);

// --- 1. SERVÝSLERÝN EKLENMESÝ (Build iþleminden ÖNCE yapýlmalý) ---

// appsettings.json yükleme
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// MVC Servisi
builder.Services.AddControllersWithViews();

// SignalR Servisi
builder.Services.AddSignalR();

// Gemini Servisi
builder.Services.AddScoped<IGeminiService, GeminiService>();

// --- 2. UYGULAMANIN DERLENMESÝ (Sadece 1 kere ve servislerden sonra) ---
var app = builder.Build();


// --- 3. MIDDLEWARE AYARLARI (Build iþleminden SONRA) ---

// Error Handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Default Route (Ana Sayfa)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

// SignalR Hub Rotasý
app.MapHub<SensorHub>("/sensorHub");

app.Run();  