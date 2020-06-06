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
            }
            catch (Exception e)
            {
                MessageBox.Show("unable to connect to database" + e.StackTrace);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                PopulateData(DateTime.Today, DateTime.Today);
            }
            catch (Exception f)
            {
                MessageBox.Show("unable to connect to database" + f.StackTrace);
            }
        }

        private void PopulateData(DateTime startDate, DateTime endDate)
        {
            // TODO: This line of code loads data into the 'fpos5DataSet.ItemSoldTable' table. You can move, or remove it, as needed.
            this.ItemSoldTableAdapter.Fill(this.fpos5DataSet.ItemSoldTable, startDate.ToString(), endDate.ToString());
            this.reportViewer1.RefreshReport();
        }
    }
}