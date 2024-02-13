namespace BookShop.Settings.Models;

public class AppBehaviourOptions
{
    public const string OptionsKey = nameof(AppBehaviourOptions);

    public bool FALL_IF_MIGRATION_FAILED { get; set; } = true;
}