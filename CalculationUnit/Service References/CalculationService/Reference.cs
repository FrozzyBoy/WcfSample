﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CalculationUnit.CalculationService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CalculationInput", Namespace="http://schemas.datacontract.org/2004/07/WcfService")]
    [System.SerializableAttribute()]
    public partial class CalculationInput : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EndField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StartField;
        
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
        public int End {
            get {
                return this.EndField;
            }
            set {
                if ((this.EndField.Equals(value) != true)) {
                    this.EndField = value;
                    this.RaisePropertyChanged("End");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Start {
            get {
                return this.StartField;
            }
            set {
                if ((this.StartField.Equals(value) != true)) {
                    this.StartField = value;
                    this.RaisePropertyChanged("Start");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="CalculationOutput", Namespace="http://schemas.datacontract.org/2004/07/WcfService")]
    [System.SerializableAttribute()]
    public partial class CalculationOutput : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ResultField;
        
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
        public int Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CalculationService.IВistributedСalculation", CallbackContract=typeof(CalculationUnit.CalculationService.IВistributedСalculationCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IВistributedСalculation {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IВistributedСalculation/RememberCalculationUnit", ReplyAction="http://tempuri.org/IВistributedСalculation/RememberCalculationUnitResponse")]
        bool RememberCalculationUnit();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IВistributedСalculation/RememberCalculationUnit", ReplyAction="http://tempuri.org/IВistributedСalculation/RememberCalculationUnitResponse")]
        System.Threading.Tasks.Task<bool> RememberCalculationUnitAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IВistributedСalculation/GetCalculation", ReplyAction="http://tempuri.org/IВistributedСalculation/GetCalculationResponse")]
        CalculationUnit.CalculationService.CalculationOutput GetCalculation(CalculationUnit.CalculationService.CalculationInput input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IВistributedСalculation/GetCalculation", ReplyAction="http://tempuri.org/IВistributedСalculation/GetCalculationResponse")]
        System.Threading.Tasks.Task<CalculationUnit.CalculationService.CalculationOutput> GetCalculationAsync(CalculationUnit.CalculationService.CalculationInput input);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IВistributedСalculationCallback {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IВistributedСalculation/Calculate", ReplyAction="http://tempuri.org/IВistributedСalculation/CalculateResponse")]
        CalculationUnit.CalculationService.CalculationOutput Calculate(CalculationUnit.CalculationService.CalculationInput input);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IВistributedСalculation/Ping", ReplyAction="http://tempuri.org/IВistributedСalculation/PingResponse")]
        bool Ping();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IВistributedСalculationChannel : CalculationUnit.CalculationService.IВistributedСalculation, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ВistributedСalculationClient : System.ServiceModel.DuplexClientBase<CalculationUnit.CalculationService.IВistributedСalculation>, CalculationUnit.CalculationService.IВistributedСalculation {
        
        public ВistributedСalculationClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ВistributedСalculationClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ВistributedСalculationClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ВistributedСalculationClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ВistributedСalculationClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public bool RememberCalculationUnit() {
            return base.Channel.RememberCalculationUnit();
        }
        
        public System.Threading.Tasks.Task<bool> RememberCalculationUnitAsync() {
            return base.Channel.RememberCalculationUnitAsync();
        }
        
        public CalculationUnit.CalculationService.CalculationOutput GetCalculation(CalculationUnit.CalculationService.CalculationInput input) {
            return base.Channel.GetCalculation(input);
        }
        
        public System.Threading.Tasks.Task<CalculationUnit.CalculationService.CalculationOutput> GetCalculationAsync(CalculationUnit.CalculationService.CalculationInput input) {
            return base.Channel.GetCalculationAsync(input);
        }
    }
}
