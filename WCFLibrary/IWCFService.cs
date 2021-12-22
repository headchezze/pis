﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFLibrary
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IWCFService" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IWCFServiceCallback))]
    public interface IWCFService
    {

        [OperationContract]
        int Connect();

        [OperationContract]
        void Disconnect(int id);

        [OperationContract]
        ICollection<OfficeProductsRepresent> FindProductsByOffice(string orgName, string officeLocation);

        [OperationContract]
        ICollection<OfficeRepresent> FindOrgs(int id, string orgName = "", string orgType = "");

        [OperationContract]
        void CreateNewOffice(int id, OfficeRepresent officeRepresent, OfficeRepresent to = null);

        [OperationContract]
        void AddProductToOffice(int id, ICollection<OfficeProductsRepresent> officeProductsRepresent);

        [OperationContract]
        void CreateNewProduct(int id, ProductRepresent productRepresent);

        [OperationContract]
        void DeleteProductFromOffice(int id, OfficeProductsRepresent officeProductsRepresent);

        [OperationContract]
        void DeleteOffice(int id, OfficeRepresent officeRepresent);

    }

    public interface IWCFServiceCallback
    {
        [OperationContract]
        string CreateNewOfficeCallback(OfficeRepresent officeRepresent, OfficeRepresent to = null);

        [OperationContract]
        string AddProductToOfficeCallback(ICollection<OfficeProductsRepresent> officeProductsRepresent);

        [OperationContract]
        string CreateNewProductCallback(ProductRepresent productRepresent);

        [OperationContract]
        string DeleteProductFromOfficeCallback(OfficeProductsRepresent officeProductsRepresent);

        [OperationContract]
        string DeleteOfficeCallback(OfficeRepresent officeRepresent);
        [OperationContract]
        ICollection<OfficeProductsRepresent> FindProductsByOfficeCallback(string orgName, string officeLocation);

        [OperationContract]
        ICollection<OfficeRepresent> FindOrgsCallback(string orgName = "", string orgType = "");
    }
}
