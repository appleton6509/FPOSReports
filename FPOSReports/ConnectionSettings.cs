using FPOSReports.BusinessObjects;
using System;
using System.Windows.Forms;

namespace FPOSReports
{
    public partial class ConnectionSettings : Form
    {
        private static string CONNECTION_STRING = Globals.CONNECTION_STRING_NAME;

        public ConnectionSettings()
        {
            InitializeComponent();

            UpdateTextFields();
        }
        /// <summary>
        /// Update the UI text fields
        /// </summary>
        private void UpdateTextFields()
        {
            ConnectionString connect = ConnectionString.GetXMLConnectionString(CONNECTION_STRING);
            tbxDatabase.Text = connect.Database;
            tbxInstance.Text = connect.Instance;
        }
        /// <summary>
        /// Update the XML collection string
        /// </summary>
        private void UpdateConnection()
        {
            var db = tbxDatabase.Text;
            var instance = tbxInstance.Text;
            ConnectionString.UpdateXMLConnectionString(new ConnectionString(CONNECTION_STRING, db, instance));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            UpdateConnection();
            this.DialogResult = DialogResult.OK;
        }

    }
}
