using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FPOSReports.BusinessObjects
{
    public static class Globals
    {
        /// <summary>
        /// The connection string name within the xml collection
        /// </summary>
        public static string CONNECTION_STRING_NAME = "FPOSReports.Properties.Settings.fpos5ConnectionString";
        /// <summary>
        /// Connection string timeout setting in seconds
        /// </summary>
        public static string TIMEOUT = "3";
        /// <summary>
        /// User displayed error messages
        /// </summary>
        public static Dictionary<String, String> MESSAGES = new Dictionary<string, string>()
        {
            {"ErrorInit","Error during initialization"},
            {"ErrorLateStart","Start date cant be later then end date"},
            {"ErrorUpdateData","Error updating report data"},
        };
        /// <summary>
        /// Exception messages
        /// </summary>
        public static Dictionary<String, String> EXCEPTIONS = new Dictionary<string, string>()
        {
            {"CStringInvalidFormat","The connection string is in an invalid format"},
            {"CStringArgNull","The name and connection string must be provided"}
        };
    }
}
