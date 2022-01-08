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
    public partial class AdressAdd : Form
    {
        public delegate void AddNewOffice(int id, string org, string address);
        public event AddNewOffice AddNewOfficeEvent;
        public AdressAdd()
        {
            InitializeComponent();
        }

        private void AdressAdd_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Replace(",", " ");
            textBox1.Text = textBox1.Text.Replace(";", " ");
            textBox1.Text = textBox1.Text.Replace(".", " ");
            AddNewOfficeEvent?.Invoke(InterfaceController.ID, InterfaceController.Organization, textBox1.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void UpdateCombos(string[] locations)
        {
            comboBox1.Items.AddRange(locations);
        }

        public void ShowAddressMessage()
        {
            MessageBox.Show("Филиал успешно создан!");
        }
    }
}
