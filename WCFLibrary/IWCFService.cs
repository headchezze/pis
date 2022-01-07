using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFLibrary
{
    public enum FindOfficeFlag
    {
        Main,
        AddressAdd
    }


    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IWCFService" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IWCFServiceCallback))]
    public interface IWCFService
    {

        [OperationContract]
        int Connect();

        [OperationContract]
        void Disconnect(int id);

        [OperationContract]
        void FindProductsByOffice(int id, string orgName, string officeLocation);

        [OperationContract(IsOneWay = true)]
        void FindOrgs(int id, FindOfficeFlag flag, string orgName = "", string orgType = "");

        [OperationContract]
        void AddProductToOffice(int id, ICollection<OfficeProductsRepresent> officeProductsRepresent);

        [OperationContract]
        void CreateNewProduct(int id, ProductRepresent productRepresent);

        [OperationContract]
        void DeleteProductFromOffice(int id, OfficeProductsRepresent officeProductsRepresent);

        [OperationContract]
        void DeleteOffice(int id, OfficeRepresent officeRepresent);

        [OperationContract(IsOneWay = true)]
        void GetOrgsAndTypes(int id);

        [OperationContract(IsOneWay = true)]
        void Login(int id, string login, string password);

        [OperationContract(IsOneWay = true)]
        void AddNewOffice(int id, string org, string address);

    }

    public interface IWCFServiceCallback
    {

        [OperationContract]
        string AddProductToOfficeCallback(ICollection<OfficeProductsRepresent> officeProductsRepresent);

        [OperationContract]
        string CreateNewProductCallback(ProductRepresent productRepresent);

        [OperationContract]
        string DeleteProductFromOfficeCallback(OfficeProductsRepresent officeProductsRepresent);

        [OperationContract]
        string DeleteOfficeCallback(OfficeRepresent officeRepresent);
        [OperationContract]
        void FindProductsByOfficeCallback(OfficeRepresent office);

        [OperationContract(IsOneWay = true)]
        void FindOrgsToMainCallback(List<OfficeRepresent> officeRepresents);

        [OperationContract(IsOneWay = true)]
        void FindOrgsToAddressAddCallback(List<OfficeRepresent> officeRepresents);

        [OperationContract(IsOneWay = true)]
        void GetOrgsAndTypesCallback(List<string> org, List<string> types);

        [OperationContract(IsOneWay = true)]
        void LoginCallback(string fullname, string org);
        
        [OperationContract(IsOneWay = true)]
        void AddNewOfficeCallback(bool isCreated);

    }
}
