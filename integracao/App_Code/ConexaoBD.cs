using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;


 public class ConexaoBD
 {

    private MySqlConnection conn;

     public MySqlConnection Conectar()
     {

		conn = new MySqlConnection("server=172.16.148.110;database=testlink;uid=admin;pwd=admin"); // -- Conexão com banco do servidor
		//conn = new MySqlConnection("server=localhost;database=testlink;uid=root;pwd=1234");

         try
         {
             conn.Open();

             if(conn.State == ConnectionState.Open)
             {
                 return conn;
             }

         }
         catch (Exception)
         {
             return conn;
         }

             return conn;
     }

     public void Desconectar()
     {
         conn.Close();
     }
 }