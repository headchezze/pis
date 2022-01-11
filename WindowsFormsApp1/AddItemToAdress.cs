using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.WCFService;
using WindowsFormsApp1;

namespace Interface
{
    public partial class AddItemToAdress : Form
    {
        public delegate void AddItemsHandler(int id, string address, string org, OfficeProductsRepresent[] products);
        public event AddItemsHandler AddItemsEvent;
        public List<string> Products { private get;  set; }

        public string Address { get; private set; }
        public string Org { get; private set; }

        public AddItemToAdress(List<string> products, string address, string org)
        {
            Address = address;
            Org = org;
            Products = products;
            InitializeComponent();
            (dataGridView1.Columns[0] as DataGridViewComboBoxColumn).DataSource = products;
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

        private void button1_Click(object sender, EventArgs e)
        {
            List<OfficeProductsRepresent> productsRepresents = new List<OfficeProductsRepresent>();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                productsRepresents.Add(new OfficeProductsRepresent() { Product = dataGridView1.Rows[i].Cells[0].Value.ToString(), Cost = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value), Count = Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value) });   
            }

            AddItemsEvent?.Invoke(InterfaceController.ID, Address, Org, productsRepresents.ToArray());
        }
    }
}
