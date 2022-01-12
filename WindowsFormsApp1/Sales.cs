using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace Interface
{
    public partial class Sales : Form
    {
        public delegate void ItemAddCreateHandler(int id, string address, string org);
        public delegate void ItemDeleteHandler(int id, string address, string org, string product);

        public event ItemAddCreateHandler ItemAddCreateEvent;
        public event ItemDeleteHandler ItemDeleteEvent;
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

        private void button1_Click(object sender, EventArgs e)
        {
            ItemAddCreateEvent?.Invoke(InterfaceController.ID, label2.Text, label1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
            ItemDeleteEvent?.Invoke(InterfaceController.ID, label2.Text, label1.Text, dataGridView1.Rows[rowIndex].Cells[0].Value.ToString());
        }

        public void DeleteProduct(bool isDeleted)
        {
            if (isDeleted)
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            else
                MessageBox.Show("Организации не совпадают");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }
    }
}
