
namespace Lelya.Infra.Database.Migration;

public class DbUpConfiguration
{
    public string ConnectionString;

    public DbUpConfiguration(string connectionString)
    {
        ConnectionString = connectionString;
    }
}