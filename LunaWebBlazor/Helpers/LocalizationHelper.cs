namespace LunaWebBlazor.Helpers;

public class LocalizationHelper
{
    public LocalizationHelper(IConfiguration config)
    {
        _config = config;
    }

    private readonly IConfiguration _config;
    public RequestLocalizationOptions GetLocalizationOptions()
    {
        var cultures = _config.GetSection("Cultures")
        .GetChildren().ToDictionary(x => x.Key, x => x.Value);

        var supportedCultures = cultures.Keys.ToArray();

        var localizationOptions = new RequestLocalizationOptions()
            .AddSupportedCultures(supportedCultures)
            .AddSupportedUICultures(supportedCultures);

        return localizationOptions;
    }
}
