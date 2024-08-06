using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using MySql.Data.MySqlClient;

public class Usuarios : Banco
{
    public List<Usuario> Listar()
    {   
        List<Usuario> lista = new List<Usuario>();
        try
        {
            MySqlDataReader dados = Consultar("listarUsuarios");
            while (dados.Read()) 
            {
                Usuario usuario = new Usuario(dados.GetString("nm_login"), dados.GetString("nm_usuario"));
                lista.Add(usuario);
            }
            if (dados != null)
            {
                if (!dados.IsClosed)
                {
                    dados.Close();
                }
            }
        }
        catch (Exception)
        {
            throw new Exception("Não foi possível listar os usuários.");
        }
        finally
        {
            Desconectar();
        }
        return lista;
    }

    public Usuario Acessar(string login, string senha)
    {
        Usuario usuario = null;

        try
        {
            List<MySqlParameter> parametros = new List<MySqlParameter>();
            parametros.Add(new MySqlParameter("pLogin", login));    
            parametros.Add(new MySqlParameter("pSenha", senha));

            MySqlDataReader dados = Consultar("acessar", parametros);

            if (dados.Read())
            {
                usuario = new Usuario(login, dados.GetString(0));
            }
            if (dados != null)
            {
                if (!dados.IsClosed)
                {
                    dados.Close();
                }
            }

        }
        catch (Exception)
        {
            throw new Exception("Login e/ou Senha Inválidos.");
        }
        finally
        {
            Desconectar();
        }
        return usuario;
    }
}
