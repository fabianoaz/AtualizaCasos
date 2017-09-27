using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using MySql.Data;
using MySql.Data.MySqlClient;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]

public class MeuService : System.Web.Services.WebService
{
    [WebMethod]
    public string service()
    {
		return "SOCORRO...";
    }	
	
   [WebMethod]
    public void RetornaNome(string n)
    {
		string nome = n;
						
		JavaScriptSerializer js = new JavaScriptSerializer();
		Context.Response.Write(js.Serialize(nome));
    }
	
	//[WebMethod]
	//public void conecta()
	//{
	//	Conectar();
	//}
	
	
	private MySqlConnection conn;

	
	 //public MySqlConnection Conectar()
	 [WebMethod]
	 public string Conectar()
     {

		conn = new MySqlConnection("server=172.16.148.110;database=testlink;uid=admin;pwd=admin"); // -- Conexão com banco do servidor

         try
         {
             conn.Open();
			 
			 if(conn.State == System.Data.ConnectionState.Open)
			 {
				//return conn;
				return "Conectou";
			 }
			 else
			 {
				 //return null;
				 return "Deu galho..";
			 }			 
         }
         catch (Exception ex)
         {
			//return conn;
			return "Caiu na excessão";
            Desconectar();
         }
			//return conn;
			return "Saiu do TRY";
			Desconectar();
     }

     public void Desconectar()
     {
         conn.Close();
     }
}
