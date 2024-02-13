namespace BookShop.Settings.Models;

public class DatabaseOptions
{
    public const string OptionsKey = nameof(DatabaseOptions);

    public string POSTGRESQL_HOST { get; set; } = "localhost";

    public int POSTGRESQL_PORT { get; set; } = 5432;

    public string POSTGRESQL_DBNAME { get; set; } = "bookshop";

    public string POSTGRESQL_USER { get; set; } = "postgres";

    public string POSTGRESQL_PASSWORD { get; set; } = "postgres";
}