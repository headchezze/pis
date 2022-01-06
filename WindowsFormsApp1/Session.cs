using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interface;
using WindowsFormsApp1.WCFService;

namespace WindowsFormsApp1
{
    class Session :  IWCFServiceCallback
    {
        private WCFServiceClient client;
        private int ID;
        private InterfaceController InterfaceController;

        public Session(InterfaceController interfaceController)
        {
            client = new WCFServiceClient(new System.ServiceModel.InstanceContext(this));
            ID = client.Connect();
            InterfaceController = interfaceController;


            InterfaceController.GetID(ID);
            InterfaceController.Main.FindOfficesEvent += client.FindOrgs;
            InterfaceController.Main.FindProductsEvent += client.FindProductsByOffice;
            InterfaceController.Main.UpdateComboEvent += client.GetOrgsAndTypes;

        }

        public string AddProductToOfficeCallback(OfficeProductsRepresent[] officeProductsRepresent)
        {
            throw new NotImplementedException();
        }

        public string CreateNewOfficeCallback(OfficeRepresent officeRepresent, OfficeRepresent to)
        {
            throw new NotImplementedException();
        }

        public string CreateNewProductCallback(ProductRepresent productRepresent)
        {
            throw new NotImplementedException();
        }

        public string DeleteOfficeCallback(OfficeRepresent officeRepresent)
        {
            throw new NotImplementedException();
        }

        public string DeleteProductFromOfficeCallback(OfficeProductsRepresent officeProductsRepresent)
        {
            throw new NotImplementedException();
        }

        public void FindOrgsCallback(OfficeRepresent[] officeRepresents)
        {

            if (client.InnerChannel.State != System.ServiceModel.CommunicationState.Faulted)
            {
                List<List<string>> values = new List<List<string>>();
                foreach (var officeRepresent in officeRepresents)
                {
                    values.Add(new List<string>() { officeRepresent.Organization, officeRepresent.Location, officeRepresent.OrgType });
                }

                InterfaceController.Main.Invoke((Action<List<List<string>>>)InterfaceController.Main.UpdateOrgList, values);
            }
            else
            {
                client = new WCFServiceClient(new System.ServiceModel.InstanceContext(this));
            }
        }

        public void FindProductsByOfficeCallback(OfficeRepresent office)
        {
            if (client.InnerChannel.State != System.ServiceModel.CommunicationState.Faulted)
            {
                List<List<string>> products = new List<List<string>>();
                foreach (var product in office.ProductsRepresents)
                {
                    products.Add(new List<string>() { product.Product, product.Cost.ToString(), product.Count.ToString() });
                }


                InterfaceController.CreateSalesForm(office.Organization, office.Location, products);
            }
            else
            {
                client = new WCFServiceClient(new System.ServiceModel.InstanceContext(this));
            }
        }

        public void GetOrgsAndTypesCallback(string[] org, string[] types)
        {
            if (client.InnerChannel.State != System.ServiceModel.CommunicationState.Faulted)
            {
                InterfaceController.Main.Invoke((Action<string[], string[]>)InterfaceController.Main.UpdateOrgAndTypesCombo, org, types);
            }
            else
            {
                client = new WCFServiceClient(new System.ServiceModel.InstanceContext(this));
            }
        }
    }
}
