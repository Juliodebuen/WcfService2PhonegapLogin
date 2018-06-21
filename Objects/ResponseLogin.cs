using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfService1.Objects
{
    public class ResponseLogin
    {
        public ResponseLogin(string usuario, string nombre, bool resultado)
        {
            this.Usuario = usuario;
            this.Nombre = nombre;
            this.Resultado = resultado;
        }

        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public bool Resultado { get; set; }
    }
}