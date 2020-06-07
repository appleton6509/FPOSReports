using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FPOSReports
{
    public class ConnectionString
    {

        public string Name { get; set; }
        public string Database { get; set; }
        public string Instance { get; set; }

        private static Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public void UpdateConnection()
        {
            var connectionStringsSection = (ConnectionStringsSection)_config.GetSection("connectionStrings");

            connectionStringsSection.ConnectionStrings[this.Name].ConnectionString = this.ToString();
            _config.Save(ConfigurationSaveMode.Modified,true);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        public static ConnectionString GetConnectionString(string name)
        {
            var connectionStringsSection = (ConnectionStringsSection)_config.GetSection("connectionStrings");

            var connectString = connectionStringsSection.ConnectionStrings[name].ConnectionString;
            var instance = connectString
                .Split(';')
                .FirstOrDefault(x => x.Contains("Data Source="))
                .Split('=')[1];
            var database = connectString
                .Split(';')
                .FirstOrDefault(x => x.Contains("Initial Catalog="))
                .Split('=')[1];
            return new ConnectionString()
            {
                Database = database,
                Name = name,
                Instance = instance
            };
        }

        public override string ToString()
        {
            return $"Data Source={this.Instance};Initial Catalog={this.Database};Integrated Security=True;Connection Timeout=3";
        }
    }
}
