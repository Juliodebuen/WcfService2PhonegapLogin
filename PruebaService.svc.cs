using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WcfService1.Objects;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PruebaService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PruebaService.svc or PruebaService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class PruebaService : IPruebaService
    {
        int folio = 0;
        public void DoWork()
        {
        }

        public string Login(Data data)
        {
            DBConnect cn = new DBConnect();
            List<string>[] result = cn.Select(data.user, data.pass);
            if (result[0].Count > 0)
            {
                ResponseLogin rl = new ResponseLogin(result[1].ElementAt(0), result[2].ElementAt(0), true);
                return JsonConvert.SerializeObject(rl);
                //return true;
            }
            else
            {
                ResponseLogin rl = new ResponseLogin("usuario", "nombre", false);
                return JsonConvert.SerializeObject(rl);
               // return false;
            }
        }

        public string NuevoRegistro(Data data)
        {
            //     folio++;
            //return "Bien hecho " + name + " Tu registro ha sido almacenado exitosamente con el folio " + folio;
            //

            /*       StreamReader reader = new StreamReader(name);
                   string res = reader.ReadToEnd();
                   reader.Close();
                   reader.Dispose();

                   var dict = HttpUtility.ParseQueryString(res);
                   var json = new JavaScriptSerializer().Serialize(
                                                            dict.Keys.Cast<string>()
                                                                .ToDictionary(k => k, k => dict[k]));
                   JObject obj = JObject.Parse(json);

                   return "Received: " + obj;*/
            DBConnect cn = new DBConnect();
            if(cn.Insert(data.name, data.user, data.pass) > 0)
            {
                return "registro exitoso";
            }
            else
            {
                return "error";
            }

        }

        public string Welcome(string name)
        {
            return "Welcome to this new web api service " + name;
        }

    }
}
