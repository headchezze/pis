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
    public partial class AddItemToAdress : Form
    {
        public AddItemToAdress()
        {
            InitializeComponent();
            string[] countrys = new string[] { "Ошейник", "Прививка", "Аквариум" };
            (dataGridView1.Columns[0] as DataGridViewComboBoxColumn).DataSource = countrys;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddItemToAdress_Load(object sender, EventArgs e)
        {

        }
    }
}
