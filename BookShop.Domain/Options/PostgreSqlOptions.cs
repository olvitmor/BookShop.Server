using System.Text;

namespace BookShop.Domain.Options;

public class PostgreSqlOptions
{
    public const string OptionsKey = nameof(PostgreSqlOptions);

    public string POSTGRESQL_HOST { get; set; } = "localhost";

    public int POSTGRESQL_PORT { get; set; } = 5432;

    public string POSTGRESQL_DATABASE { get; set; } = "bookshop";

    public string POSTGRESQL_USER { get; set; } = "postgres";

    public string POSTGRESQL_PASSWORD { get; set; } = "postgres";

    public string ConnectionString
    {
        get
        {
            return $"Server={POSTGRESQL_HOST};Username={POSTGRESQL_USER};Database={POSTGRESQL_DATABASE};Port={POSTGRESQL_PORT};Password={POSTGRESQL_PASSWORD}";
        }
    }
}