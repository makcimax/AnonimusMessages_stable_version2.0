﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientWinForm.Service {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Abonent", Namespace="http://schemas.datacontract.org/2004/07/Server")]
    [System.SerializableAttribute()]
    public partial class Abonent : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ClientWinForm.Service.Status statusField;
        
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
        public int id {
            get {
                return this.idField;
            }
            set {
                if ((this.idField.Equals(value) != true)) {
                    this.idField = value;
                    this.RaisePropertyChanged("id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                if ((object.ReferenceEquals(this.nameField, value) != true)) {
                    this.nameField = value;
                    this.RaisePropertyChanged("name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ClientWinForm.Service.Status status {
            get {
                return this.statusField;
            }
            set {
                if ((this.statusField.Equals(value) != true)) {
                    this.statusField = value;
                    this.RaisePropertyChanged("status");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Message", Namespace="http://schemas.datacontract.org/2004/07/Server")]
    [System.SerializableAttribute()]
    public partial class Message : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RecipientIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SenderIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextOfMessageField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RecipientId {
            get {
                return this.RecipientIdField;
            }
            set {
                if ((this.RecipientIdField.Equals(value) != true)) {
                    this.RecipientIdField = value;
                    this.RaisePropertyChanged("RecipientId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int SenderId {
            get {
                return this.SenderIdField;
            }
            set {
                if ((this.SenderIdField.Equals(value) != true)) {
                    this.SenderIdField = value;
                    this.RaisePropertyChanged("SenderId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TextOfMessage {
            get {
                return this.TextOfMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.TextOfMessageField, value) != true)) {
                    this.TextOfMessageField = value;
                    this.RaisePropertyChanged("TextOfMessage");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Status", Namespace="http://schemas.datacontract.org/2004/07/Server")]
    public enum Status : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Online = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Offline = 1,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Service.IServer", CallbackContract=typeof(ClientWinForm.Service.IServerCallback))]
    public interface IServer {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/SendMessage")]
        void SendMessage(int senderId, int[] recipientsId, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/SendMessage")]
        System.Threading.Tasks.Task SendMessageAsync(int senderId, int[] recipientsId, string message);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServer/ShowAbonents", ReplyAction="http://tempuri.org/IServer/ShowAbonentsResponse")]
        System.Collections.Generic.Dictionary<int, ClientWinForm.Service.Abonent> ShowAbonents(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServer/ShowAbonents", ReplyAction="http://tempuri.org/IServer/ShowAbonentsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int, ClientWinForm.Service.Abonent>> ShowAbonentsAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServer/ProvideMessage", ReplyAction="http://tempuri.org/IServer/ProvideMessageResponse")]
        ClientWinForm.Service.Message[] ProvideMessage(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServer/ProvideMessage", ReplyAction="http://tempuri.org/IServer/ProvideMessageResponse")]
        System.Threading.Tasks.Task<ClientWinForm.Service.Message[]> ProvideMessageAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServer/Connect", ReplyAction="http://tempuri.org/IServer/ConnectResponse")]
        int Connect(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServer/Connect", ReplyAction="http://tempuri.org/IServer/ConnectResponse")]
        System.Threading.Tasks.Task<int> ConnectAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/Disconnect")]
        void Disconnect(int id);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/Disconnect")]
        System.Threading.Tasks.Task DisconnectAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServerCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/cbSendMessage")]
        void cbSendMessage(string senderName, string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/cbShowAbonent")]
        void cbShowAbonent(ClientWinForm.Service.Abonent abonent);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServerChannel : ClientWinForm.Service.IServer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServerClient : System.ServiceModel.DuplexClientBase<ClientWinForm.Service.IServer>, ClientWinForm.Service.IServer {
        
        public ServerClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServerClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void SendMessage(int senderId, int[] recipientsId, string message) {
            base.Channel.SendMessage(senderId, recipientsId, message);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(int senderId, int[] recipientsId, string message) {
            return base.Channel.SendMessageAsync(senderId, recipientsId, message);
        }
        
        public System.Collections.Generic.Dictionary<int, ClientWinForm.Service.Abonent> ShowAbonents(int id) {
            return base.Channel.ShowAbonents(id);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int, ClientWinForm.Service.Abonent>> ShowAbonentsAsync(int id) {
            return base.Channel.ShowAbonentsAsync(id);
        }
        
        public ClientWinForm.Service.Message[] ProvideMessage(int id) {
            return base.Channel.ProvideMessage(id);
        }
        
        public System.Threading.Tasks.Task<ClientWinForm.Service.Message[]> ProvideMessageAsync(int id) {
            return base.Channel.ProvideMessageAsync(id);
        }
        
        public int Connect(string name) {
            return base.Channel.Connect(name);
        }
        
        public System.Threading.Tasks.Task<int> ConnectAsync(string name) {
            return base.Channel.ConnectAsync(name);
        }
        
        public void Disconnect(int id) {
            base.Channel.Disconnect(id);
        }
        
        public System.Threading.Tasks.Task DisconnectAsync(int id) {
            return base.Channel.DisconnectAsync(id);
        }
    }
}
