using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interface;
using System.Threading;

namespace WindowsFormsApp1
{
    class InterfaceController
    {
        static public int ID { get; private set; }
        static public string Organization { get; set; }
        public Form1 Main { get; private set; }
        public Sales Sales { get; private set; }
        public AutorizationSys AutorizationSys { get; private set; }
        public AdressAdd AdressAdd { get; private set; }

        public AddItemToAdress AddItemToAdress { get; private set; }

        public InterfaceController()
        {
            Main = new Form1();
            AutorizationSys = new AutorizationSys();
            AdressAdd = new AdressAdd();
            Main.LoginEvent += CreateLoginForm;
        }

        public void GetID(int id)
        {
            ID = id;
        }

        public void Start()
        {
            Application.Run(Main);
        }

        public void CreateSalesForm(string org = "", string location = "", List<List<string>> products = null)
        {
            Sales = new Sales();
            Thread thread = new Thread(delegate () { Sales.ShowDialog(); });
            thread.Start();
            Sales.UpdateProdList(org, location, products);
        }

        public void CreateLoginForm()
        {
            Thread thread = new Thread(delegate () { AutorizationSys.ShowDialog(); });
            thread.Start();
        }

        public void CreateProductAddForm(List<string> products, string address, string org)
        {
            AddItemToAdress = new AddItemToAdress(products, address, org);
            Thread thread = new Thread(delegate () { AddItemToAdress.ShowDialog(); });
            thread.ApartmentState = ApartmentState.STA;
            thread.Start();
        }

        public void CreateAddressAddForm(string[] locations)
        {
            AdressAdd = new AdressAdd();
            AdressAdd.UpdateCombos(locations);
            Thread thread = new Thread(delegate () { AdressAdd.ShowDialog(); });
            thread.Start();
        }
    }
}