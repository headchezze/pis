﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1.WCFService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FindOfficeFlag", Namespace="http://schemas.datacontract.org/2004/07/WCFLibrary")]
    public enum FindOfficeFlag : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Main = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AddressAdd = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OfficeProductsRepresent", Namespace="http://schemas.datacontract.org/2004/07/WCFLibrary")]
    [System.SerializableAttribute()]
    public partial class OfficeProductsRepresent : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal CostField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CountField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WindowsFormsApp1.WCFService.OfficeRepresent OfficeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProductField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Cost {
            get {
                return this.CostField;
            }
            set {
                if ((this.CostField.Equals(value) != true)) {
                    this.CostField = value;
                    this.RaisePropertyChanged("Cost");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Count {
            get {
                return this.CountField;
            }
            set {
                if ((this.CountField.Equals(value) != true)) {
                    this.CountField = value;
                    this.RaisePropertyChanged("Count");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WindowsFormsApp1.WCFService.OfficeRepresent Office {
            get {
                return this.OfficeField;
            }
            set {
                if ((object.ReferenceEquals(this.OfficeField, value) != true)) {
                    this.OfficeField = value;
                    this.RaisePropertyChanged("Office");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Product {
            get {
                return this.ProductField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductField, value) != true)) {
                    this.ProductField = value;
                    this.RaisePropertyChanged("Product");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OfficeRepresent", Namespace="http://schemas.datacontract.org/2004/07/WCFLibrary")]
    [System.SerializableAttribute()]
    public partial class OfficeRepresent : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrgTypeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrganizationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WindowsFormsApp1.WCFService.OfficeProductsRepresent[] ProductsRepresentsField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Location {
            get {
                return this.LocationField;
            }
            set {
                if ((object.ReferenceEquals(this.LocationField, value) != true)) {
                    this.LocationField = value;
                    this.RaisePropertyChanged("Location");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string OrgType {
            get {
                return this.OrgTypeField;
            }
            set {
                if ((object.ReferenceEquals(this.OrgTypeField, value) != true)) {
                    this.OrgTypeField = value;
                    this.RaisePropertyChanged("OrgType");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Organization {
            get {
                return this.OrganizationField;
            }
            set {
                if ((object.ReferenceEquals(this.OrganizationField, value) != true)) {
                    this.OrganizationField = value;
                    this.RaisePropertyChanged("Organization");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public WindowsFormsApp1.WCFService.OfficeProductsRepresent[] ProductsRepresents {
            get {
                return this.ProductsRepresentsField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductsRepresentsField, value) != true)) {
                    this.ProductsRepresentsField = value;
                    this.RaisePropertyChanged("ProductsRepresents");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProductRepresent", Namespace="http://schemas.datacontract.org/2004/07/WCFLibrary")]
    [System.SerializableAttribute()]
    public partial class ProductRepresent : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WCFService.IWCFService", CallbackContract=typeof(WindowsFormsApp1.WCFService.IWCFServiceCallback))]
    public interface IWCFService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/Connect", ReplyAction="http://tempuri.org/IWCFService/ConnectResponse")]
        int Connect();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/Connect", ReplyAction="http://tempuri.org/IWCFService/ConnectResponse")]
        System.Threading.Tasks.Task<int> ConnectAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/Disconnect", ReplyAction="http://tempuri.org/IWCFService/DisconnectResponse")]
        void Disconnect(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/Disconnect", ReplyAction="http://tempuri.org/IWCFService/DisconnectResponse")]
        System.Threading.Tasks.Task DisconnectAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/FindProductsByOffice", ReplyAction="http://tempuri.org/IWCFService/FindProductsByOfficeResponse")]
        void FindProductsByOffice(int id, string orgName, string officeLocation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/FindProductsByOffice", ReplyAction="http://tempuri.org/IWCFService/FindProductsByOfficeResponse")]
        System.Threading.Tasks.Task FindProductsByOfficeAsync(int id, string orgName, string officeLocation);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWCFService/FindOrgs")]
        void FindOrgs(int id, WindowsFormsApp1.WCFService.FindOfficeFlag flag, string orgName, string orgType);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWCFService/FindOrgs")]
        System.Threading.Tasks.Task FindOrgsAsync(int id, WindowsFormsApp1.WCFService.FindOfficeFlag flag, string orgName, string orgType);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/AddProductToOffice", ReplyAction="http://tempuri.org/IWCFService/AddProductToOfficeResponse")]
        void AddProductToOffice(int id, WindowsFormsApp1.WCFService.OfficeProductsRepresent[] officeProductsRepresent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/AddProductToOffice", ReplyAction="http://tempuri.org/IWCFService/AddProductToOfficeResponse")]
        System.Threading.Tasks.Task AddProductToOfficeAsync(int id, WindowsFormsApp1.WCFService.OfficeProductsRepresent[] officeProductsRepresent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/CreateNewProduct", ReplyAction="http://tempuri.org/IWCFService/CreateNewProductResponse")]
        void CreateNewProduct(int id, WindowsFormsApp1.WCFService.ProductRepresent productRepresent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/CreateNewProduct", ReplyAction="http://tempuri.org/IWCFService/CreateNewProductResponse")]
        System.Threading.Tasks.Task CreateNewProductAsync(int id, WindowsFormsApp1.WCFService.ProductRepresent productRepresent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/DeleteProductFromOffice", ReplyAction="http://tempuri.org/IWCFService/DeleteProductFromOfficeResponse")]
        void DeleteProductFromOffice(int id, WindowsFormsApp1.WCFService.OfficeProductsRepresent officeProductsRepresent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/DeleteProductFromOffice", ReplyAction="http://tempuri.org/IWCFService/DeleteProductFromOfficeResponse")]
        System.Threading.Tasks.Task DeleteProductFromOfficeAsync(int id, WindowsFormsApp1.WCFService.OfficeProductsRepresent officeProductsRepresent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/DeleteOffice", ReplyAction="http://tempuri.org/IWCFService/DeleteOfficeResponse")]
        void DeleteOffice(int id, WindowsFormsApp1.WCFService.OfficeRepresent officeRepresent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/DeleteOffice", ReplyAction="http://tempuri.org/IWCFService/DeleteOfficeResponse")]
        System.Threading.Tasks.Task DeleteOfficeAsync(int id, WindowsFormsApp1.WCFService.OfficeRepresent officeRepresent);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWCFService/GetOrgsAndTypes")]
        void GetOrgsAndTypes(int id);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWCFService/GetOrgsAndTypes")]
        System.Threading.Tasks.Task GetOrgsAndTypesAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWCFService/Login")]
        void Login(int id, [System.ServiceModel.MessageParameterAttribute(Name="login")] string login1, string password);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWCFService/Login")]
        System.Threading.Tasks.Task LoginAsync(int id, string login, string password);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWCFService/AddNewOffice")]
        void AddNewOffice(int id, string org, string address);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWCFService/AddNewOffice")]
        System.Threading.Tasks.Task AddNewOfficeAsync(int id, string org, string address);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWCFServiceCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/AddProductToOfficeCallback", ReplyAction="http://tempuri.org/IWCFService/AddProductToOfficeCallbackResponse")]
        string AddProductToOfficeCallback(WindowsFormsApp1.WCFService.OfficeProductsRepresent[] officeProductsRepresent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/CreateNewProductCallback", ReplyAction="http://tempuri.org/IWCFService/CreateNewProductCallbackResponse")]
        string CreateNewProductCallback(WindowsFormsApp1.WCFService.ProductRepresent productRepresent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/DeleteProductFromOfficeCallback", ReplyAction="http://tempuri.org/IWCFService/DeleteProductFromOfficeCallbackResponse")]
        string DeleteProductFromOfficeCallback(WindowsFormsApp1.WCFService.OfficeProductsRepresent officeProductsRepresent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/DeleteOfficeCallback", ReplyAction="http://tempuri.org/IWCFService/DeleteOfficeCallbackResponse")]
        string DeleteOfficeCallback(WindowsFormsApp1.WCFService.OfficeRepresent officeRepresent);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWCFService/FindProductsByOfficeCallback", ReplyAction="http://tempuri.org/IWCFService/FindProductsByOfficeCallbackResponse")]
        void FindProductsByOfficeCallback(WindowsFormsApp1.WCFService.OfficeRepresent office);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWCFService/FindOrgsToMainCallback")]
        void FindOrgsToMainCallback(WindowsFormsApp1.WCFService.OfficeRepresent[] officeRepresents);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWCFService/FindOrgsToAddressAddCallback")]
        void FindOrgsToAddressAddCallback(WindowsFormsApp1.WCFService.OfficeRepresent[] officeRepresents);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWCFService/GetOrgsAndTypesCallback")]
        void GetOrgsAndTypesCallback(string[] org, string[] types);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWCFService/LoginCallback")]
        void LoginCallback(string fullname, string org);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IWCFService/AddNewOfficeCallback")]
        void AddNewOfficeCallback(bool isCreated);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWCFServiceChannel : WindowsFormsApp1.WCFService.IWCFService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WCFServiceClient : System.ServiceModel.DuplexClientBase<WindowsFormsApp1.WCFService.IWCFService>, WindowsFormsApp1.WCFService.IWCFService {
        
        public WCFServiceClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public WCFServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public WCFServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public WCFServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public WCFServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public int Connect() {
            return base.Channel.Connect();
        }
        
        public System.Threading.Tasks.Task<int> ConnectAsync() {
            return base.Channel.ConnectAsync();
        }
        
        public void Disconnect(int id) {
            base.Channel.Disconnect(id);
        }
        
        public System.Threading.Tasks.Task DisconnectAsync(int id) {
            return base.Channel.DisconnectAsync(id);
        }
        
        public void FindProductsByOffice(int id, string orgName, string officeLocation) {
            base.Channel.FindProductsByOffice(id, orgName, officeLocation);
        }
        
        public System.Threading.Tasks.Task FindProductsByOfficeAsync(int id, string orgName, string officeLocation) {
            return base.Channel.FindProductsByOfficeAsync(id, orgName, officeLocation);
        }
        
        public void FindOrgs(int id, WindowsFormsApp1.WCFService.FindOfficeFlag flag, string orgName, string orgType) {
            base.Channel.FindOrgs(id, flag, orgName, orgType);
        }
        
        public System.Threading.Tasks.Task FindOrgsAsync(int id, WindowsFormsApp1.WCFService.FindOfficeFlag flag, string orgName, string orgType) {
            return base.Channel.FindOrgsAsync(id, flag, orgName, orgType);
        }
        
        public void AddProductToOffice(int id, WindowsFormsApp1.WCFService.OfficeProductsRepresent[] officeProductsRepresent) {
            base.Channel.AddProductToOffice(id, officeProductsRepresent);
        }
        
        public System.Threading.Tasks.Task AddProductToOfficeAsync(int id, WindowsFormsApp1.WCFService.OfficeProductsRepresent[] officeProductsRepresent) {
            return base.Channel.AddProductToOfficeAsync(id, officeProductsRepresent);
        }
        
        public void CreateNewProduct(int id, WindowsFormsApp1.WCFService.ProductRepresent productRepresent) {
            base.Channel.CreateNewProduct(id, productRepresent);
        }
        
        public System.Threading.Tasks.Task CreateNewProductAsync(int id, WindowsFormsApp1.WCFService.ProductRepresent productRepresent) {
            return base.Channel.CreateNewProductAsync(id, productRepresent);
        }
        
        public void DeleteProductFromOffice(int id, WindowsFormsApp1.WCFService.OfficeProductsRepresent officeProductsRepresent) {
            base.Channel.DeleteProductFromOffice(id, officeProductsRepresent);
        }
        
        public System.Threading.Tasks.Task DeleteProductFromOfficeAsync(int id, WindowsFormsApp1.WCFService.OfficeProductsRepresent officeProductsRepresent) {
            return base.Channel.DeleteProductFromOfficeAsync(id, officeProductsRepresent);
        }
        
        public void DeleteOffice(int id, WindowsFormsApp1.WCFService.OfficeRepresent officeRepresent) {
            base.Channel.DeleteOffice(id, officeRepresent);
        }
        
        public System.Threading.Tasks.Task DeleteOfficeAsync(int id, WindowsFormsApp1.WCFService.OfficeRepresent officeRepresent) {
            return base.Channel.DeleteOfficeAsync(id, officeRepresent);
        }
        
        public void GetOrgsAndTypes(int id) {
            base.Channel.GetOrgsAndTypes(id);
        }
        
        public System.Threading.Tasks.Task GetOrgsAndTypesAsync(int id) {
            return base.Channel.GetOrgsAndTypesAsync(id);
        }
        
        public void Login(int id, string login1, string password) {
            base.Channel.Login(id, login1, password);
        }
        
        public System.Threading.Tasks.Task LoginAsync(int id, string login, string password) {
            return base.Channel.LoginAsync(id, login, password);
        }
        
        public void AddNewOffice(int id, string org, string address) {
            base.Channel.AddNewOffice(id, org, address);
        }
        
        public System.Threading.Tasks.Task AddNewOfficeAsync(int id, string org, string address) {
            return base.Channel.AddNewOfficeAsync(id, org, address);
        }
    }
}
