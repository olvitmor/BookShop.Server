namespace BookShop.Domain.Options;

public class ApplicationOptions
{
    public const string OptionsKey = nameof(ApplicationOptions);

    public bool FALL_IF_MIGRATION_FAILED { get; set; } = true;
}