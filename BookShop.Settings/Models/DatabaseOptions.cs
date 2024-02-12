namespace BookShop.Settings.Models;

public class DatabaseOptions
{
    public const string OptionsKey = "DatabaseOptions";

    public string POSTGRESQL_HOST { get; set; } = "localhost";

    public int POSTGRESQL_PORT { get; set; } = 5432;

    public string POSTGRESQL_DBNAME { get; set; } = "bookshop";

    public string POSTGRESQL_USER { get; set; } = "postgres";

    public string POSTGRESQL_PASSWORD { get; set; } = "postgres";

    public string GetConnectionString() =>
        $"Host={POSTGRESQL_HOST};Port={POSTGRESQL_PORT};Database={POSTGRESQL_DBNAME};Username={POSTGRESQL_USER};Password={POSTGRESQL_PASSWORD}";
}