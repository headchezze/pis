using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interface.Формы;

namespace Interface 
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("Рога и Копыта", "Перекопская 13", "Приют");
            dataGridView1.Rows.Add("Дружок", "Мельникайте 93а", "Ветклиника");
            dataGridView1.Rows.Add("Котопес", "Грибоедоова 13", "Ветклиника");
            dataGridView1.Rows.Add("Простоквашино", "Пушкина 32", "Ветслужба");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox1.SelectedValue = null;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            AdressAdd adressAdd = new AdressAdd();
            adressAdd.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ItemAddToSys itemAdd = new ItemAddToSys();
            itemAdd.Show();
        }
    }
}
