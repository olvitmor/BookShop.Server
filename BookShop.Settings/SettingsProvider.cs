using BookShop.Settings.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BookShop.Settings;

public class SettingsProvider
{
    public DbSettings DbSettings { get; private set; }

    private readonly IConfiguration _configuration;

    private readonly ILogger<SettingsProvider> _logger;

    public SettingsProvider(IConfiguration configuration, ILogger<SettingsProvider> logger)
    {
        _configuration = configuration;
        _logger = logger;
        
        Initialize();
    }

    private void Initialize()
    {
        _logger.LogInformation("Applying application settings");

        ApplyDatabaseSettings();
    }

    private void ApplyDatabaseSettings()
    {
        _logger.LogInformation("Applying database settings");

        DbSettings = new DbSettings();

        var host = _configuration[DbSettings.GetHostKey()];
        var port = Int32.Parse(_configuration[DbSettings.GetPortKey()] ?? "5432");
        var dbName = _configuration[DbSettings.GetDbNameKey()];
        var user = _configuration[DbSettings.GetUserKey()];
        var password = _configuration[DbSettings.GetPasswordKey()];

        try
        {
            DbSettings.Apply(host, port, dbName, user, password);
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex?.Message);
            throw;
        }
    }
}