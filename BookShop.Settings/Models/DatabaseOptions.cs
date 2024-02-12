namespace BookShop.Settings.Models;

public class DatabaseOptions
{
    public const string OptionsKey = "DatabaseOptions";
    
    public string POSTGRESQL_HOST { get; set; }

    public int POSTGRESQL_PORT { get; set; }

    public string POSTGRESQL_DBNAME { get; set; }

    public string POSTGRESQL_USER { get; set; }

    public string POSTGRESQL_PASSWORD { get; set; }

    public string GetConnectionString() =>
        $"Host={POSTGRESQL_HOST};Port={POSTGRESQL_PORT};Database={POSTGRESQL_DBNAME};Username={POSTGRESQL_USER};Password={POSTGRESQL_PASSWORD}";
}