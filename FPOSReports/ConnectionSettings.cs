using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ConnectionString connect = ConnectionString.GetConnectionString(Form1.CONNECTION_STRING_NAME);
            tbxDatabase.Text = connect.Database;
            tbxInstance.Text = connect.Instance;
        }

        private void UpdateConnection()
        {
            var db = tbxDatabase.Text;
            var instance = tbxInstance.Text;

            ConnectionString connect = new ConnectionString()
            {
                Name = Form1.CONNECTION_STRING_NAME,
                Database = db,
                Instance = instance
            };
            connect.UpdateConnection();
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
