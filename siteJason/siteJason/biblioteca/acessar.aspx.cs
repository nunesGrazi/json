using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace siteJason.biblioteca
{
    public partial class acessar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";

            if (Request["login"] == null)
            {
                string resposta = "{'situacao':'false'}";
                Response.Write(resposta.Replace("'","\""));
                return;
            }

            if (String.IsNullOrEmpty(Request["login"].ToString()))
            {
                string resposta = "{'situacao':'false'}";
                Response.Write(resposta.Replace("'", "\""));
                return;
            }

            if (Request["senha"] == null)
            {
                string resposta = "{'situacao':'false'}";
                Response.Write(resposta.Replace("'", "\""));
                return;
            }

            if (String.IsNullOrEmpty(Request["senha"].ToString()))
            {
                string resposta = "{'situacao':'false'}";
                Response.Write(resposta.Replace("'", "\""));
                return;
            }

            string supostoLogin = Request["login"].ToString();
            string supostaSenha = Request["senha"].ToString();
            try
            {
                Usuarios usuarios = new Usuarios();
                Usuario usuario = usuarios.Acessar(supostoLogin, supostaSenha);

                if (usuario != null)
                {
                    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                    string resposta = javaScriptSerializer.Serialize(usuario);
                    Response.Write(resposta);
                }
                else
                {
                    string resposta = "{'situacao':'false'}";
                    Response.Write(resposta.Replace("'", "\""));
                }

            }
            catch
            {
                string resposta = "{'situacao':'false'}";
                Response.Write(resposta.Replace("'", "\""));
            }
        }
    }
}