using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;

namespace IntegraTestlinkWS
{
    public class ConexaoBD
    {

        public MySqlConnection Conectar()
        {
            MySqlConnection conn;
            conn = new MySqlConnection("server=localhost;database=testelink_producao;uid=root;pwd=1234");

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
    }
}