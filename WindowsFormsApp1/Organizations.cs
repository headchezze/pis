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
using WindowsFormsApp1.WCFService;
using System.Data.SqlClient;
using System.Data.Sql;

namespace Interface 
{
    public partial class Form1 : Form, IWCFServiceCallback
    {
        private WCFServiceClient client;
        private int ID;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new WCFServiceClient(new System.ServiceModel.InstanceContext(this));
            ID = client.Connect();
            MessageBox.Show(ID.ToString());
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

        private void AutorizButton_Click(object sender, EventArgs e)
        {
            AutorizationSys itemAdd = new AutorizationSys();
            itemAdd.Show();
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

        public string CreateNewOfficeCallback(OfficeRepresent officeRepresent, OfficeRepresent to)
        {
            throw new NotImplementedException();
        }

        public string AddProductToOfficeCallback(OfficeProductsRepresent[] officeProductsRepresent)
        {
            throw new NotImplementedException();
        }

        public string CreateNewProductCallback(ProductRepresent productRepresent)
        {
            throw new NotImplementedException();
        }

        public string DeleteProductFromOfficeCallback(OfficeProductsRepresent officeProductsRepresent)
        {
            throw new NotImplementedException();
        }

        public string DeleteOfficeCallback(OfficeRepresent officeRepresent)
        {
            throw new NotImplementedException();
        }

        public OfficeProductsRepresent[] FindProductsByOfficeCallback(string orgName, string officeLocation)
        {
            throw new NotImplementedException();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.Disconnect(ID);
            client = null;
        }


        public void FindOrgsCallback(OfficeRepresent[] officeRepresents)
        {
            if (client.InnerChannel.State != System.ServiceModel.CommunicationState.Faulted)
            {
                foreach (var officeRepresent in officeRepresents)
                {
                    dataGridView1.Rows.Add(officeRepresent.Organization, officeRepresent.Location, "Allo");
                }
            }
            else
            {
                client = new WCFServiceClient(new System.ServiceModel.InstanceContext(this));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.FindOrgs(ID, "", "");
        }
    }
}
