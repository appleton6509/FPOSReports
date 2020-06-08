using FPOSReports.BusinessObjects;
using System;
using System.Windows.Forms;

namespace FPOSReports
{
    public partial class ConnectionSettings : Form
    {

        public ConnectionSettings()
        {
            InitializeComponent();

            UpdateTextFields();
        }

        private void UpdateTextFields()
        {
            ConnectionString connect = ConnectionString.GetXMLConnectionString(Globals.CONNECTION_STRING_NAME);
            tbxDatabase.Text = connect.Database;
            tbxInstance.Text = connect.Instance;
        }

        private void UpdateConnection()
        {
            var db = tbxDatabase.Text;
            var instance = tbxInstance.Text;
            ConnectionString.UpdateXMLConnectionString(new ConnectionString(Globals.CONNECTION_STRING_NAME, db, instance));
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
