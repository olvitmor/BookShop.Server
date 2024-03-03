namespace BookShop.Service.Interfaces;

public interface IMigrationMonitor
{
    public event EventHandler OnDatabaseMigrationCompleted;
    
    public void Migrate();
    
    public Task MigrateAsync();
}