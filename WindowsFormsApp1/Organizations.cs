using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using WindowsFormsApp1;
using System.Threading;

namespace Interface 
{
    public partial class Form1 : Form
    {
        public delegate void FormHandler(int id, WindowsFormsApp1.WCFService.FindOfficeFlag flag,  string orgName, string orgType);
        public delegate void FindProductsHandler(int id, string orgName, string typeName);
        public delegate void ComboHadler(int id);
        public delegate void LoginHandler();
        public delegate void AddressAddHandler(int id, WindowsFormsApp1.WCFService.FindOfficeFlag flag, string orgName, string orgType);
        public event AddressAddHandler AddressAddEvent;
        public event LoginHandler LoginEvent;
        public event FormHandler FindOfficesEvent;
        public event FindProductsHandler FindProductsEvent;
        public event ComboHadler UpdateComboEvent;
        public event FindProductsHandler DeleteOfficeEvent;

        public Form1()
        {
            InitializeComponent();
        }


        public async void UpdateOrgList(List<List<string>> offices)
        {
            for (int i = 0; i < offices.Count; i++)
            {
                dataGridView1.Rows.Add(offices[i][0], offices[i][1], offices[i][2]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            Thread.Sleep(4000);
            AddressAddEvent?.Invoke(InterfaceController.ID, WindowsFormsApp1.WCFService.FindOfficeFlag.AddressAdd, InterfaceController.Organization, "");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ItemAddToSys itemAdd = new ItemAddToSys();
            itemAdd.Show();
        }

        private async void AutorizButton_Click(object sender, EventArgs e)
        {
            LoginEvent?.Invoke();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void ExportXLSX_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            exApp.Workbooks.Add();
            Excel.Worksheet excelOrg = (Excel.Worksheet)exApp.ActiveSheet;
            Excel.Range actualyTime = excelOrg.get_Range("A1", "C1").Cells;
            Excel.Range BoldName = excelOrg.get_Range("A1", "C2").Cells;
            actualyTime.Merge(Type.Missing); // Объединение
            actualyTime.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; // Центрирование
            actualyTime.EntireRow.Font.Italic = true;
            BoldName.EntireRow.Font.Bold = true;
            excelOrg.Cells[1, 1] = "***Список организаций на " + DateTime.Now + "***";
            excelOrg.Cells[2, 1] = "Название организации";
            excelOrg.Cells[2, 2] = "Адрес";
            excelOrg.Cells[2, 3] = "Тип организации";
            int count = 2; // Для создание заголовков, иначе выход за пределы i++
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    excelOrg.Cells[count + 1, j + 1] = dataGridView1[j, i].Value.ToString();
                }
                count++;
            }
            excelOrg.Columns.EntireColumn.AutoFit();
            exApp.Visible = true;
        }

      
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            var organizName = comboBox1.Text;
            var organizType = comboBox2.Text;
            organizName = organizName.Replace("ё", "е"); // Это решение проблемы с расхождением букв
            organizName = organizName.Replace("Ё", "Е");
            FindOfficesEvent?.Invoke(InterfaceController.ID, WindowsFormsApp1.WCFService.FindOfficeFlag.Main, organizName, organizType);
        }

        public void UpdateOrgAndTypesCombo(string[] orgs, string[] types)
        {
            comboBox1.Items.AddRange(orgs);
            comboBox2.Items.AddRange(types);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Thread.Sleep(3000);
            UpdateComboEvent?.Invoke(InterfaceController.ID);
        }

        public void LogedIn(string fullname, string org)
        {
            label4.Text = "Работник: "  + fullname + Environment.NewLine + "Организация: " + org;
            InterfaceController.Organization = org;
            autorizButton.Visible = false;
            this.Width = 835;
            this.Height = 664;
            label3.Visible = true;
            label4.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
           DeleteOfficeEvent?.Invoke(InterfaceController.ID, dataGridView1.Rows[rowIndex].Cells[0].Value.ToString(), dataGridView1.Rows[rowIndex].Cells[1].Value.ToString());
        }

        public void DeleteSelectedRow(bool isDeleted)
        {
            if (isDeleted)
            {
                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                MessageBox.Show("Филиал по выбранному адресу успешно удален","Подсказка");
            }
            else
            {
                MessageBox.Show("Другая организация", "Ошибка");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true; // Выделение всей строки
            FindProductsEvent?.Invoke(InterfaceController.ID, dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void ComboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox2.Text = "";
        }

        private void ComboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Text = "";
        }
    }
}
