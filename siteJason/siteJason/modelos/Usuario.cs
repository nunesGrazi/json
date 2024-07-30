using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Usuario
{
	public string Login { get; set; }
	public string Senha { get; set; }
	public string Nome { get; set; }

	Usuario() { }

	public Usuario(string Login, string Nome)
	{
		this.Login = Login;
		this.Nome = Nome;
	}
}
