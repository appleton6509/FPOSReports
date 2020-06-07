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
    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                InitializeComponent();

                Initialize();
            }
            catch (Exception e)
            {
                MessageBox.Show("unable to connect to database" + e.StackTrace);
            }

        }

        private void Initialize()
        {
            dtpEndDate.Value = DateTime.Today;
            dtpStartDate.Value = DateTime.Today;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                PopulateData(dtpStartDate.Value, dtpEndDate.Value);
            }
            catch (Exception f)
            {
                MessageBox.Show("unable to connect to database" + f.StackTrace);
            }
        }

        private void PopulateData(DateTime startDate, DateTime endDate)
        {
            // TODO: This line of code loads data into the 'fpos5DataSet.ItemSoldTable' table. You can move, or remove it, as needed.
            this.ItemSoldTableAdapter.Fill(this.fpos5DataSet.ItemSoldTable,startDate, endDate);
            this.reportViewer1.RefreshReport();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var end = dtpEndDate.Value;
            var start = dtpStartDate.Value;

            if (DateTime.Compare(start, end) <= 0)
                PopulateData(start, end);
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblFrom_Click(object sender, EventArgs e)
        {

        }
    }
}