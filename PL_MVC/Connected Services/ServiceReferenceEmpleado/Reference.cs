﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PL_MVC.ServiceReferenceEmpleado {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Result", Namespace="http://schemas.datacontract.org/2004/07/SLWCF")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Empleado))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Empresa))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Aseguradora))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Usuario))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Direccion))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Colonia))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Municipio))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Estado))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Pais))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Rol))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Exception))]
    public partial class Result : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool CorrectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Exception ExField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ObjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] ObjectsField;
        
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
        public bool Correct {
            get {
                return this.CorrectField;
            }
            set {
                if ((this.CorrectField.Equals(value) != true)) {
                    this.CorrectField = value;
                    this.RaisePropertyChanged("Correct");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Exception Ex {
            get {
                return this.ExField;
            }
            set {
                if ((object.ReferenceEquals(this.ExField, value) != true)) {
                    this.ExField = value;
                    this.RaisePropertyChanged("Ex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Object {
            get {
                return this.ObjectField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectField, value) != true)) {
                    this.ObjectField = value;
                    this.RaisePropertyChanged("Object");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] Objects {
            get {
                return this.ObjectsField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectsField, value) != true)) {
                    this.ObjectsField = value;
                    this.RaisePropertyChanged("Objects");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReferenceEmpleado.IEmpleadoService")]
    public interface IEmpleadoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmpleadoService/Add", ReplyAction="http://tempuri.org/IEmpleadoService/AddResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Empresa))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Aseguradora))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Usuario))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Direccion))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Colonia))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Municipio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Estado))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Pais))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Rol))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL_MVC.ServiceReferenceEmpleado.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        PL_MVC.ServiceReferenceEmpleado.Result Add(ML.Empleado empleado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmpleadoService/Add", ReplyAction="http://tempuri.org/IEmpleadoService/AddResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceReferenceEmpleado.Result> AddAsync(ML.Empleado empleado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmpleadoService/Update", ReplyAction="http://tempuri.org/IEmpleadoService/UpdateResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Empresa))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Aseguradora))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Usuario))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Direccion))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Colonia))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Municipio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Estado))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Pais))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Rol))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL_MVC.ServiceReferenceEmpleado.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        PL_MVC.ServiceReferenceEmpleado.Result Update(ML.Empleado empleado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmpleadoService/Update", ReplyAction="http://tempuri.org/IEmpleadoService/UpdateResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceReferenceEmpleado.Result> UpdateAsync(ML.Empleado empleado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmpleadoService/Delete", ReplyAction="http://tempuri.org/IEmpleadoService/DeleteResponse")]
        PL_MVC.ServiceReferenceEmpleado.Result Delete(string numeroEmpleado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmpleadoService/Delete", ReplyAction="http://tempuri.org/IEmpleadoService/DeleteResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceReferenceEmpleado.Result> DeleteAsync(string numeroEmpleado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmpleadoService/GetAll", ReplyAction="http://tempuri.org/IEmpleadoService/GetAllResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Empresa))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Aseguradora))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Usuario))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Direccion))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Colonia))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Municipio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Estado))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Pais))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(ML.Rol))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(PL_MVC.ServiceReferenceEmpleado.Result))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Exception))]
        PL_MVC.ServiceReferenceEmpleado.Result GetAll(ML.Empleado empleado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmpleadoService/GetAll", ReplyAction="http://tempuri.org/IEmpleadoService/GetAllResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceReferenceEmpleado.Result> GetAllAsync(ML.Empleado empleado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmpleadoService/GetById", ReplyAction="http://tempuri.org/IEmpleadoService/GetByIdResponse")]
        PL_MVC.ServiceReferenceEmpleado.Result GetById(string numeroEmpleado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmpleadoService/GetById", ReplyAction="http://tempuri.org/IEmpleadoService/GetByIdResponse")]
        System.Threading.Tasks.Task<PL_MVC.ServiceReferenceEmpleado.Result> GetByIdAsync(string numeroEmpleado);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmpleadoServiceChannel : PL_MVC.ServiceReferenceEmpleado.IEmpleadoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmpleadoServiceClient : System.ServiceModel.ClientBase<PL_MVC.ServiceReferenceEmpleado.IEmpleadoService>, PL_MVC.ServiceReferenceEmpleado.IEmpleadoService {
        
        public EmpleadoServiceClient() {
        }
        
        public EmpleadoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmpleadoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmpleadoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmpleadoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public PL_MVC.ServiceReferenceEmpleado.Result Add(ML.Empleado empleado) {
            return base.Channel.Add(empleado);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceReferenceEmpleado.Result> AddAsync(ML.Empleado empleado) {
            return base.Channel.AddAsync(empleado);
        }
        
        public PL_MVC.ServiceReferenceEmpleado.Result Update(ML.Empleado empleado) {
            return base.Channel.Update(empleado);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceReferenceEmpleado.Result> UpdateAsync(ML.Empleado empleado) {
            return base.Channel.UpdateAsync(empleado);
        }
        
        public PL_MVC.ServiceReferenceEmpleado.Result Delete(string numeroEmpleado) {
            return base.Channel.Delete(numeroEmpleado);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceReferenceEmpleado.Result> DeleteAsync(string numeroEmpleado) {
            return base.Channel.DeleteAsync(numeroEmpleado);
        }
        
        public PL_MVC.ServiceReferenceEmpleado.Result GetAll(ML.Empleado empleado) {
            return base.Channel.GetAll(empleado);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceReferenceEmpleado.Result> GetAllAsync(ML.Empleado empleado) {
            return base.Channel.GetAllAsync(empleado);
        }
        
        public PL_MVC.ServiceReferenceEmpleado.Result GetById(string numeroEmpleado) {
            return base.Channel.GetById(numeroEmpleado);
        }
        
        public System.Threading.Tasks.Task<PL_MVC.ServiceReferenceEmpleado.Result> GetByIdAsync(string numeroEmpleado) {
            return base.Channel.GetByIdAsync(numeroEmpleado);
        }
    }
}