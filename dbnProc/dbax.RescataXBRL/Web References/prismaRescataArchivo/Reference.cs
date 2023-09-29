﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace dbax.RescataXBRL.prismaRescataArchivo {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ServicioPrismaRescataSoap", Namespace="http://www.prismafinanciero.com/PrismaRescataArchivo")]
    public partial class ServicioPrismaRescata : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback getArchivosOperationCompleted;
        
        private System.Threading.SendOrPostCallback getArchivoOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ServicioPrismaRescata() {
            this.Url = "https://pf.cl.dbnetcorp.com/PrismaWss/PrismaRescataArchivo.asmx";
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event getArchivosCompletedEventHandler getArchivosCompleted;
        
        /// <remarks/>
        public event getArchivoCompletedEventHandler getArchivoCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.prismafinanciero.com/PrismaRescataArchivo/getArchivos", RequestNamespace="http://www.prismafinanciero.com/PrismaRescataArchivo", ResponseNamespace="http://www.prismafinanciero.com/PrismaRescataArchivo", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public RespuestaArchivos getArchivos(string pCodi_usua, string pPass_usua, string pVers_tras) {
            object[] results = this.Invoke("getArchivos", new object[] {
                        pCodi_usua,
                        pPass_usua,
                        pVers_tras});
            return ((RespuestaArchivos)(results[0]));
        }
        
        /// <remarks/>
        public void getArchivosAsync(string pCodi_usua, string pPass_usua, string pVers_tras) {
            this.getArchivosAsync(pCodi_usua, pPass_usua, pVers_tras, null);
        }
        
        /// <remarks/>
        public void getArchivosAsync(string pCodi_usua, string pPass_usua, string pVers_tras, object userState) {
            if ((this.getArchivosOperationCompleted == null)) {
                this.getArchivosOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetArchivosOperationCompleted);
            }
            this.InvokeAsync("getArchivos", new object[] {
                        pCodi_usua,
                        pPass_usua,
                        pVers_tras}, this.getArchivosOperationCompleted, userState);
        }
        
        private void OngetArchivosOperationCompleted(object arg) {
            if ((this.getArchivosCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getArchivosCompleted(this, new getArchivosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.prismafinanciero.com/PrismaRescataArchivo/getArchivo", RequestNamespace="http://www.prismafinanciero.com/PrismaRescataArchivo", ResponseNamespace="http://www.prismafinanciero.com/PrismaRescataArchivo", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public RespuestaXBRL getArchivo(string pCorr_sess, string pCodi_usua, string pCodi_arch, string pNomb_arch) {
            object[] results = this.Invoke("getArchivo", new object[] {
                        pCorr_sess,
                        pCodi_usua,
                        pCodi_arch,
                        pNomb_arch});
            return ((RespuestaXBRL)(results[0]));
        }
        
        /// <remarks/>
        public void getArchivoAsync(string pCorr_sess, string pCodi_usua, string pCodi_arch, string pNomb_arch) {
            this.getArchivoAsync(pCorr_sess, pCodi_usua, pCodi_arch, pNomb_arch, null);
        }
        
        /// <remarks/>
        public void getArchivoAsync(string pCorr_sess, string pCodi_usua, string pCodi_arch, string pNomb_arch, object userState) {
            if ((this.getArchivoOperationCompleted == null)) {
                this.getArchivoOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetArchivoOperationCompleted);
            }
            this.InvokeAsync("getArchivo", new object[] {
                        pCorr_sess,
                        pCodi_usua,
                        pCodi_arch,
                        pNomb_arch}, this.getArchivoOperationCompleted, userState);
        }
        
        private void OngetArchivoOperationCompleted(object arg) {
            if ((this.getArchivoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getArchivoCompleted(this, new getArchivoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.prismafinanciero.com/PrismaRescataArchivo")]
    public partial class RespuestaArchivos {
        
        private string estadoField;
        
        private string mensajeField;
        
        private string corrSessField;
        
        private string versTrasField;
        
        private string cantArchField;
        
        private ArchivoXbrl[] archivosField;
        
        /// <remarks/>
        public string Estado {
            get {
                return this.estadoField;
            }
            set {
                this.estadoField = value;
            }
        }
        
        /// <remarks/>
        public string Mensaje {
            get {
                return this.mensajeField;
            }
            set {
                this.mensajeField = value;
            }
        }
        
        /// <remarks/>
        public string CorrSess {
            get {
                return this.corrSessField;
            }
            set {
                this.corrSessField = value;
            }
        }
        
        /// <remarks/>
        public string VersTras {
            get {
                return this.versTrasField;
            }
            set {
                this.versTrasField = value;
            }
        }
        
        /// <remarks/>
        public string CantArch {
            get {
                return this.cantArchField;
            }
            set {
                this.cantArchField = value;
            }
        }
        
        /// <remarks/>
        public ArchivoXbrl[] Archivos {
            get {
                return this.archivosField;
            }
            set {
                this.archivosField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.prismafinanciero.com/PrismaRescataArchivo")]
    public partial class ArchivoXbrl {
        
        private string codiArchField;
        
        private string archXbrlField;
        
        /// <remarks/>
        public string CodiArch {
            get {
                return this.codiArchField;
            }
            set {
                this.codiArchField = value;
            }
        }
        
        /// <remarks/>
        public string ArchXbrl {
            get {
                return this.archXbrlField;
            }
            set {
                this.archXbrlField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.prismafinanciero.com/PrismaRescataArchivo")]
    public partial class RespuestaXBRL {
        
        private string estadoField;
        
        private string mensajeField;
        
        private byte[] archivoBytesField;
        
        /// <remarks/>
        public string Estado {
            get {
                return this.estadoField;
            }
            set {
                this.estadoField = value;
            }
        }
        
        /// <remarks/>
        public string Mensaje {
            get {
                return this.mensajeField;
            }
            set {
                this.mensajeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] ArchivoBytes {
            get {
                return this.archivoBytesField;
            }
            set {
                this.archivoBytesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void getArchivosCompletedEventHandler(object sender, getArchivosCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getArchivosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getArchivosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public RespuestaArchivos Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((RespuestaArchivos)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void getArchivoCompletedEventHandler(object sender, getArchivoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getArchivoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getArchivoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public RespuestaXBRL Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((RespuestaXBRL)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591