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
        private string Fullname, Org;
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
            InterfaceController.AutorizationSys.LoginEvent += client.Login;
            InterfaceController.Main.AddressAddEvent += client.FindOrgs;
            InterfaceController.Main.DeleteOfficeEvent += client.DeleteOffice;

        }

        public void AddNewOfficeCallback(bool isCreated)
        {
            if (isCreated)
                InterfaceController.AdressAdd.Invoke((Action)InterfaceController.AdressAdd.ShowAddressMessage);
        }

        public string AddProductToOfficeCallback(OfficeProductsRepresent[] officeProductsRepresent)
        {
            throw new NotImplementedException();
        }

        public string CreateNewProductCallback(ProductRepresent productRepresent)
        {
            throw new NotImplementedException();
        }

        public void DeleteOfficeCallback(bool isDeleted)
        {
            InterfaceController.Main.Invoke((Action<bool>)InterfaceController.Main.DeleteSelectedRow, isDeleted);
        }

        public string DeleteProductFromOfficeCallback(OfficeProductsRepresent officeProductsRepresent)
        {
            throw new NotImplementedException();
        }

        public void FindOrgsToAddressAddCallback(OfficeRepresent[] officeRepresents)
        {
            if (client.InnerChannel.State != System.ServiceModel.CommunicationState.Faulted)
            {
                List<string> values = new List<string>();
                foreach (var officeRepresent in officeRepresents)
                {
                    values.Add(officeRepresent.Location);
                }

                InterfaceController.CreateAddressAddForm(values.ToArray());
                InterfaceController.AdressAdd.AddNewOfficeEvent += client.AddNewOffice;
            }
            else
            {
                client = new WCFServiceClient(new System.ServiceModel.InstanceContext(this));
            }
        }

        public void FindOrgsToMainCallback(OfficeRepresent[] officeRepresents)
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

        public void LoginCallback(string fullname, string org)
        {
            if (fullname == String.Empty || org == String.Empty)
            {
                InterfaceController.AutorizationSys.Invoke((Action)InterfaceController.AutorizationSys.ShowErrorMessage);
                return;
            }

            Fullname = fullname;
            Org = org;
            InterfaceController.Main.Invoke((Action<string, string>)InterfaceController.Main.LogedIn, fullname, org);
            InterfaceController.AutorizationSys.Invoke((Action)InterfaceController.AutorizationSys.Close);
        }
    }
}
