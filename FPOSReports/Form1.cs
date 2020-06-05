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
            catch (Exception)
            {
                MessageBox.Show("unable to connect to database");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: This line of code loads data into the 'fpos5DataSet.ItemSoldTable' table. You can move, or remove it, as needed.
                this.ItemSoldTableAdapter.Fill(this.fpos5DataSet.ItemSoldTable);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception)
            {

            }
        }

#pragma warning disable IDE1006 // Naming Styles
        private void reportViewer1_Load(object sender, EventArgs e)
#pragma warning restore IDE1006 // Naming Styles
        {

        }
    }
}