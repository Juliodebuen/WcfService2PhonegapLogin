using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPruebaService" in both code and config file together.
    [ServiceContract]
    public interface IPruebaService
    {
        [OperationContract]
        void DoWork();
        [OperationContract]
        [WebInvoke(Method="GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "/HelloWorld/{name}")]
        string Welcome(string name);
        [WebInvoke(Method = "POST",RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/RegistroNombre")]
        string NuevoRegistro(Data data);
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/Login")]
        string Login(Data data);
    }

    [DataContract]
    public class Data
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string user { get; set; }

        [DataMember]
        public string pass { get; set; }
    }
}
