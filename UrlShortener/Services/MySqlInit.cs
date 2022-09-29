using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using UrlShortener.Interfaces;

namespace UrlShortener;

public class MySqlInit
{
    public MySqlInit(IConfiguration configuration)
        => DataConnection.DefaultSettings = new DbSettings(configuration);

    public void CreateDatabase()
    {
        using var db = new DataConnection();
        try
        {
            _ = db.GetTable<Url>().Any();
        }
        catch
        {
            db.CreateTable<Url>();
        }
    }
}

public class DbSettings : ILinqToDBSettings
{
    private readonly IConfiguration _configuration;

    public DbSettings(IConfiguration configuration)
        => _configuration = configuration;

    public IEnumerable<IDataProviderSettings> DataProviders
        => Enumerable.Empty<IDataProviderSettings>();

    public string DefaultConfiguration => "SqlServer";
    public string DefaultDataProvider => "SqlServer";

    public IEnumerable<IConnectionStringSettings> ConnectionStrings => new[]
    {
        new ConnectionStringSettings(_configuration["MySql:Database"],
            $"Server={_configuration["MySql:Host"]}; " +
            $"Database={_configuration["MySql:Database"]}; " +
            $"User Id={_configuration["MySql:Username"]}; " +
            $"Password={_configuration["MySql:Password"]};",
            ProviderName.MySql)
    };
}