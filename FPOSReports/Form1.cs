using FPOSReports.BusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPOSReports
{
    public partial class Form1 : Form
    {
        public static string CONNECTION_STRING_NAME = "FPOSReports.Properties.Settings.fpos5ConnectionString";

        public Form1()
        {
            try
            {
                InitializeComponent();

                Initialize();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void Initialize()
        {
            dtpEndDate.Value = dtpStartDate.Value = DateTime.Today;
            this.ItemSoldTableAdapter.ClearBeforeFill = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateData(new DateParameter(dtpStartDate.Value, dtpEndDate.Value));
        }

        private void PopulateData(DateParameter dates)
        {
            if (DateTime.Compare(dates.StartDate, dates.EndDate) > 0)
            {
                MessageBox.Show("Start date cant be later then end date");
                return;
            }

            try
            {
                this.ItemSoldTableAdapter.Connection.ConnectionString = ConnectionString.GetConnectionString(CONNECTION_STRING_NAME).ToString();
                this.ItemSoldTableAdapter.Fill(this.fpos5DataSet.ItemSoldTable, dates.StartDate, dates.EndDate);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
    
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var dates = new DateParameter(dtpStartDate.Value, dtpEndDate.Value);
                PopulateData(dates);
        }

        private void pbxSettings_Click(object sender, EventArgs e)
        {
            Form connect = new ConnectionSettings();
            var result = connect.ShowDialog();

            if (result == DialogResult.OK)
                PopulateData(new DateParameter(dtpStartDate.Value, dtpEndDate.Value));
            else
                connect.Close();
        }
    }
}