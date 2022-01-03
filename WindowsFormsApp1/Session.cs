using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            Application.Run(MainForm);

            MainForm.GetID(ID);
            form.Notivfy += client.FindOrgs;

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
                foreach (var officeRepresent in officeRepresents)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.SetValues(officeRepresent.Location, officeRepresent.Organization, "allo");
                    MainForm.UpdateOrgList(row);
                }
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
