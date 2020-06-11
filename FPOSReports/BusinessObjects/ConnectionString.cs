using FPOSReports.BusinessObjects;
using System;
using System.Configuration;
using System.Linq;


namespace FPOSReports
{
    /// <summary>
    /// A class representing a database connection string
    /// </summary>
    public class ConnectionString
    {
        /// <summary>
        /// The name of the connection string contained within the xml collection
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// the name of the database
        /// </summary>
        public string Database { get; set; }
        /// <summary>
        /// The device and instance data source string i.e. LOCALHOST\MSSQL
        /// </summary>
        public string Instance { get; set; }

        private static readonly Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public ConnectionString(string name, string connectionString)
        {
            Build(name, connectionString);
        }

        public ConnectionString(string name, string database, string instance) 
        {
            Instance = instance ?? throw new ArgumentNullException(nameof(instance));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Database = database ?? throw new ArgumentNullException(nameof(database));
        }

        /// <summary>
        /// Builds the connection string object
        /// </summary>
        /// <param name="name"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public ConnectionString Build(string name, string connectionString)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(connectionString))
                throw new ArgumentNullException(Globals.EXCEPTIONS["CStringArgNull"]);
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
            }
            catch (Exception)
            {
                throw new ArgumentException(Globals.EXCEPTIONS["CStringInvalidFormat"] + connectionString);
            }
            return this;
        }
        /// <summary>
        /// Update a connection string within the xml collection
        /// </summary>
        /// <param name="connectionString"></param>
        public static void UpdateXMLConnectionString(ConnectionString connectionString)
        {
            var connectionStringsSection = (ConnectionStringsSection)_config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings[connectionString.Name].ConnectionString = connectionString.ToString();
            _config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        /// <summary>
        /// Retrieve a Connection string from the xml collection
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static ConnectionString GetXMLConnectionString(string name)
        {
            var connectionStringsSection = (ConnectionStringsSection)_config.GetSection("connectionStrings");
            var connectString = connectionStringsSection.ConnectionStrings[name].ConnectionString;
            return new ConnectionString(name, connectString);
        }

        public override string ToString()
        {
            return $"Data Source={this.Instance};Initial Catalog={this.Database};Integrated Security=True;Connection Timeout={Globals.TIMEOUT}";
        }
    }
}
