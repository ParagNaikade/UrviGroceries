using System.Text;
using Contracts.Models;

namespace DataAccessLayer
{
    internal static class ConnectionStringsHelper
    {
        internal static string GetConnectionString(AppSettings appSettings)
        {
            var connectionString = new StringBuilder();

            connectionString.Append("User ID=");
            connectionString.Append(appSettings.DbConfig.UserId);
            connectionString.Append(";Password=");
            connectionString.Append(appSettings.DbConfig.Password);
            connectionString.Append(";Data Source=");
            connectionString.Append(appSettings.DbConfig.Server);
            connectionString.Append(";Initial Catalog=");
            connectionString.Append(appSettings.DbConfig.Database);

            return connectionString.ToString();
        }
    }
}
