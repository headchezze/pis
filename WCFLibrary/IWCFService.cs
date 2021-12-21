using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFLibrary
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IWCFService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IWCFService
    {

        [OperationContract]
        int Connect();

        [OperationContract]
        int Disconnect(int id);

        [OperationContract]
        ICollection<OfficeProductsRepresent> FindProductsByOffice(string orgName, string officeLocation);

        [OperationContract]
        ICollection<OfficeRepresent> FindOrgs(string orgName = "", string orgType = "");

        [OperationContract]
        void CreateNewOffice(OfficeRepresent officeRepresent, OfficeRepresent to = null);

        [OperationContract]
        void AddProductToOffice(ICollection<OfficeProductsRepresent> officeProductsRepresent);

        [OperationContract]
        void CreateNewProduct(ProductRepresent productRepresent);

        [OperationContract]
        void DeleteProductFromOffice(OfficeProductsRepresent officeProductsRepresent);

        [OperationContract]
        void DeleteOffice(OfficeRepresent officeRepresent);

    }
}
