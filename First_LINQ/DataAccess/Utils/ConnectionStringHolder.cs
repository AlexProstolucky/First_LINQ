using System.Configuration;

namespace First_LINQ.DataAccess.Utils
{
    internal sealed class ConnectionStringHolder
    {
        public string ConnectionString { get; set; }

        public string GetConnectionString()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["SqliteConnection"].ConnectionString;
            return ConnectionString;
        }
    }
}
