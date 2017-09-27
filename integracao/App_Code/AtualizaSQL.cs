using System;
using System.Collections.Generic;
using System.Collections;
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

public class AtualizaSQL : System.Web.Services.WebService
{
	
        [WebMethod]
        public void AtualizaDraftFutureEspecifico(string demanda)
        {

            string status;

            ConexaoBD connbd = new ConexaoBD();
            MySqlConnection conn = connbd.Conectar();

            string sql = "update tcversions set STATUS = '6' where creation_ts >= '2016-11-25' " +
                "AND id in (SELECT node_id FROM cfield_design_values where value in (" + demanda + "))";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
                status = "OK";
            }
            catch (Exception ex)
            {
                status = "NOK " + ex.Message;
                connbd.Desconectar();
            }
            finally
            {
                connbd.Desconectar();
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(status));

        }

        [WebMethod]
        public void AtualizaDraftFutureTodas()
        {

            string status;

            ConexaoBD connbd = new ConexaoBD();
            MySqlConnection conn = connbd.Conectar();

            string sql = "update tcversions set STATUS = '6' where creation_ts >= '2016-11-25' AND STATUS = '1'";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
                status = "OK";
            }
            catch (Exception ex)
            {
                status = "NOK " + ex.Message;
                connbd.Desconectar();
            }
            finally
            {
                connbd.Desconectar();
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(status));

        }

        [WebMethod]
        public void AtualizaFutureDraftEspecifico(string demanda)
        {

            string status;

            ConexaoBD connbd = new ConexaoBD();
            MySqlConnection conn = connbd.Conectar();

            string sql = "update tcversions set STATUS = '1' where creation_ts >= '2016-11-25' " +
                "AND id in (SELECT node_id FROM cfield_design_values where value in (" + demanda + "))";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
                status = "OK";
            }
            catch (Exception ex)
            {
                status = "NOK " + ex.Message;
                connbd.Desconectar();
            }
            finally
            {
                connbd.Desconectar();
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(status));

        }

        [WebMethod]
        public void AtualizaFutureDraftTodas()
        {

            string status;

            ConexaoBD connbd = new ConexaoBD();
            MySqlConnection conn = connbd.Conectar();

            string sql = "update tcversions set STATUS = '1' where creation_ts >= '2016-11-25' AND STATUS = '6'";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
                status = "OK";
            }
            catch (Exception ex)
            {
                status = "NOK " + ex.Message;
                connbd.Desconectar();
            }
            finally
            {
                connbd.Desconectar();
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(status));

        }

        [WebMethod]
        public void AtualizaFutureFinalEspecifico(string demanda)
        {
            string status;

            ConexaoBD connbd = new ConexaoBD();
            MySqlConnection conn = connbd.Conectar();

            string sql = "update tcversions set STATUS = '7' where creation_ts >= '2016-11-25' " +
                "AND id in (SELECT node_id FROM cfield_design_values where value in (" + demanda + "))";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
                status = "OK";
            }
            catch (Exception ex)
            {
                status = "NOK " + ex.Message;
                connbd.Desconectar();
            }
            finally
            {
                connbd.Desconectar();
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(status));
        }

        [WebMethod]
        public void AtualizaFutureFinalTodas()
        {
            string status;

            ConexaoBD connbd = new ConexaoBD();
            MySqlConnection conn = connbd.Conectar();

            string sql = "update tcversions set STATUS = '7' where creation_ts >= '2016-11-25' AND STATUS = '6'";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
                status = "OK";
            }
            catch (Exception ex)
            {
                status = "NOK " + ex.Message;
                connbd.Desconectar();
            }
            finally
            {
                connbd.Desconectar();
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(status));
        }

        [WebMethod]
        public void AtualizaFinalFutureEspecifico(string demanda)
        {
            string status;

            ConexaoBD connbd = new ConexaoBD();
            MySqlConnection conn = connbd.Conectar();

            string sql = "update tcversions set STATUS = '6' where creation_ts >= '2016-11-25' " +
                "AND id in (SELECT node_id FROM cfield_design_values where value in (" + demanda + "))";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
                status = "OK";
            }
            catch (Exception ex)
            {
                status = "NOK " + ex.Message;
                connbd.Desconectar();
            }
            finally
            {
                connbd.Desconectar();
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(status));
        }

        [WebMethod]
        public void AtualizaFinalFutureTodas()
        {
            string status;

            ConexaoBD connbd = new ConexaoBD();
            MySqlConnection conn = connbd.Conectar();

            string sql = "update tcversions set STATUS = '6' where creation_ts >= '2016-11-25' AND STATUS = '7'";

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
                status = "OK";
            }
            catch (Exception ex)
            {
                status = "NOK " + ex.Message;
                connbd.Desconectar();
            }
            finally
            {
                connbd.Desconectar();
            }

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(status));
        }	


}