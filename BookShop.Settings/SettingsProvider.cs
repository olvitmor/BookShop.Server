﻿using BookShop.Settings.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BookShop.Settings;

public class SettingsProvider
{
    public DatabaseOptions DatabaseOptions { get; private set; }
    public AppBehaviourOptions AppBehaviourOptions { get; private set; }

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
        ApplyDatabaseOptions();
        ApplyAppBehaviourOptions();
    }

    private void ApplyAppBehaviourOptions()
    {
        _logger.LogInformation($"Applying {nameof(Models.AppBehaviourOptions)} options");

        AppBehaviourOptions = new AppBehaviourOptions();
        
        _configuration.GetSection(AppBehaviourOptions.OptionsKey).Bind(AppBehaviourOptions);
    }

    private void ApplyDatabaseOptions()
    {
        _logger.LogInformation($"Applying {nameof(Models.DatabaseOptions)} options");

        DatabaseOptions = new DatabaseOptions();

        _configuration.GetSection(DatabaseOptions.OptionsKey).Bind(DatabaseOptions);
    }
}