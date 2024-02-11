namespace BookShop.Settings.Models;

public class DbSettings
{
    public string POSTGRESQL_HOST { get; set; }

    public int POSTGRESQL_PORT { get; set; }

    public string POSTGRESQL_DBNAME { get; set; }

    public string POSTGRESQL_USER { get; set; }

    public string POSTGRESQL_PASSWORD { get; set; }

    public string GetConnectionString() =>
        $"Host={POSTGRESQL_HOST};Port={POSTGRESQL_PORT};Database={POSTGRESQL_DBNAME};Username={POSTGRESQL_USER};Password={POSTGRESQL_PASSWORD}";

    internal string GetHostKey() => "POSTGRESQL_HOST";
    internal string GetPortKey() => "POSTGRESQL_PORT";
    internal string GetDbNameKey() => "POSTGRESQL_DBNAME";
    internal string GetUserKey() => "POSTGRESQL_USER";
    internal string GetPasswordKey() => "POSTGRESQL_PASSWORD";

    public void Apply(string host, int port, string dbName, string user, string password)
    {
        ThrowIfNotValid(host, port, dbName, user, password);

        POSTGRESQL_HOST = host;
        POSTGRESQL_PORT = port;
        POSTGRESQL_DBNAME = dbName;
        POSTGRESQL_USER = user;
        POSTGRESQL_PASSWORD = password;
    }

    private void ThrowIfNotValid(string host, int port, string dbName, string user, string password)
    {
        if (string.IsNullOrEmpty(host))
            throw new ArgumentException($"Database host '{host}' is not valid. Fix {GetHostKey()} field.");

        if (string.IsNullOrEmpty(dbName))
            throw new ArgumentException($"Database name '{dbName}' is not valid. Fix {GetDbNameKey()} field.");

        if (string.IsNullOrEmpty(user))
            throw new ArgumentException($"Database user '{user}' is not valid. Fix {GetUserKey()} field.");
    }
}