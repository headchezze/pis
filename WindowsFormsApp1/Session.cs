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
        private Form1 MainForm;

        public Session(Form1 form)
        {
            client = new WCFServiceClient(new System.ServiceModel.InstanceContext(this));
            ID = client.Connect();
            MainForm = form;


            MainForm.GetID(ID);
            MainForm.Notivfy += client.FindOrgs;

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

        public async void FindOrgsCallback(OfficeRepresent[] officeRepresents)
        {

            if (client.InnerChannel.State != System.ServiceModel.CommunicationState.Faulted)
            {
                List<List<string>> values = new List<List<string>>();
                foreach (var officeRepresent in officeRepresents)
                {
                    values.Add(new List<string>() { officeRepresent.Organization, officeRepresent.Location });
                }

                MainForm.Invoke((Action<List<List<string>>>)MainForm.UpdateOrgList, values);
            }
            else
            {
                client = new WCFServiceClient(new System.ServiceModel.InstanceContext(this));
            }
        }

        public OfficeProductsRepresent[] FindProductsByOfficeCallback(string orgName, string officeLocation)
        {
            throw new NotImplementedException();
        }
    }
}
