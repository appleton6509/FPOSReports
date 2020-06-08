using System;
using System.Configuration;
using System.Linq;


namespace FPOSReports
{
    public class ConnectionString
    {

        public string Name { get; set; }
        public string Database { get; set; }
        public string Instance { get; set; }

        private static readonly Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public ConnectionString(string name, string connectionString)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException($"The name and connection string must be provided");

            try
            {
                var instance = connectionString
                    .Split(';')
                    .FirstOrDefault(x => x.Contains("Data Source="))
                    .Split('=')[1];
                var database = connectionString
                    .Split(';')
                    .FirstOrDefault(x => x.Contains("Initial Catalog="))
                    .Split('=')[1];
                this.Database = database;
                this.Instance = instance;
                this.Name = name;
            } catch (Exception e)
            {
                throw new ArgumentException($"The connection string is in an invalid format: " + connectionString);
            }
        }

        public ConnectionString(string name, string database, string instance) 
        {
            Instance = instance ?? throw new ArgumentNullException(nameof(instance));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public static void UpdateXMLConnectionString(ConnectionString connectionString)
        {
            var connectionStringsSection = (ConnectionStringsSection)_config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings[connectionString.Name].ConnectionString = connectionString.ToString();
            _config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public static ConnectionString GetXMLConnectionString(string name)
        {
            var connectionStringsSection = (ConnectionStringsSection)_config.GetSection("connectionStrings");
            var connectString = connectionStringsSection.ConnectionStrings[name].ConnectionString;
            return new ConnectionString(name, connectString);
        }

        public override string ToString()
        {
            return $"Data Source={this.Instance};Initial Catalog={this.Database};Integrated Security=True;Connection Timeout=3";
        }
    }
}
