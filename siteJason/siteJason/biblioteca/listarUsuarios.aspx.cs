using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace siteJason.biblioteca
{
    public partial class listarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            List<Usuario> listaUsuarios = usuarios.Listar();

            //string resposta = "";

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string json = serializer.Serialize(listaUsuarios);

            //foreach (Usuario item in listaUsuarios)
            //{
            //    resposta += item.Nome;
            //}

            Response.Write(json);
        }
    }
}