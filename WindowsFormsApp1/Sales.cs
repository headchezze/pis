using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    public partial class Sales : Form
    {

        public Sales()
        {
            InitializeComponent();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
           
        }

        private void Sales_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        public void UpdateProdList(string org, string location, List<List<string>> products)
        {
            label1.Text = org;
            label2.Text = location;
            
            for (int i = 0; i < products.Count; i++)
            {
                dataGridView1.Rows.Add(products[i][0], products[i][1], products[i][2]);
            }

        }
    }
}
