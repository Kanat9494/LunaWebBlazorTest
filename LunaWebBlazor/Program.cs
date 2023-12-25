var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddControllers();


var app = builder.Build();

#region Localization

var locale = new LocalizationHelper(builder.Configuration);

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("ru");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("ru");

#endregion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseRequestLocalization(locale.GetLocalizationOptions());
app.UseAntiforgery();

app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
