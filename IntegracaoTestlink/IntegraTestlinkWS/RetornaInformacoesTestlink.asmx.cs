using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data.MySqlClient;
using System.Data;

namespace IntegraTestlinkWS
{
    /// <summary>
    /// Summary description for Integra1WS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class RetornaInformacoesTestlink : System.Web.Services.WebService
    {

        [WebMethod]
        public string ConsultaDraft()
        {
            ArrayList meuArray = new ArrayList();

            ConexaoBD connbd = new ConexaoBD();
            MySqlConnection conn = connbd.Conectar();

            //string sql = "SELECT value FROM cfield_design_values";

            string sql = "SELECT distinct cfield_design_values.value " +
                         "FROM cfield_design_values inner join tcversions " +
                         "on cfield_design_values.node_id = tcversions.id " +
                         "and tcversions.creation_ts >= '2016-11-25' " +
                         "and tcversions.status = 1	" +
                         "order by tcversions.creation_ts desc limit 100;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                meuArray.Add(Convert.ToString(reader.GetInt32(0)));
            }

            string result = "";

            foreach (string dados in meuArray)
            {
                if (meuArray.Count <= 1)
                {
                    result = result + dados;
                }else
                {
                    result = result + dados + ";" ;
                }
            }
                return result;
        }

        [WebMethod]
        public string ConsultaFuture()
        {
            ArrayList meuArray = new ArrayList();

            ConexaoBD connbd = new ConexaoBD();
            MySqlConnection conn = connbd.Conectar();

            string sql = "SELECT distinct cfield_design_values.value " +
                         "FROM cfield_design_values inner join tcversions " +
                         "on cfield_design_values.node_id = tcversions.id " +
                         "and tcversions.creation_ts >= '2016-11-25' " +
                         "and tcversions.status = 6	" +
                         "order by tcversions.creation_ts desc limit 100;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                meuArray.Add(Convert.ToString(reader.GetInt32(0)));
            }

            string result = "";

            foreach (string dados in meuArray)
            {
                if (meuArray.Count <= 1)
                {
                    result = result + dados;
                }
                else
                {
                    result = result + dados + ";";
                }
            }
            return result;
        }

        [WebMethod]
        public string ConsultaFinal()
        {
            ArrayList meuArray = new ArrayList();

            ConexaoBD connbd = new ConexaoBD();
            MySqlConnection conn = connbd.Conectar();

            string sql = "SELECT distinct cfield_design_values.value " +
                         "FROM cfield_design_values inner join tcversions " +
                         "on cfield_design_values.node_id = tcversions.id " +
                         "and tcversions.creation_ts >= '2016-11-25' " +
                         "and tcversions.status = 7	" +
                         "order by tcversions.creation_ts desc limit 100;";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                meuArray.Add(Convert.ToString(reader.GetInt32(0)));
            }

            string result = "";

            foreach (string dados in meuArray)
            {
                if (meuArray.Count <= 1)
                {
                    result = result + dados;
                }
                else
                {
                    result = result + dados + ";";
                }
            }

                return result;

        }
    }
}
