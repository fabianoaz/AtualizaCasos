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

    public class ConsultaSQL : System.Web.Services.WebService
    {
            [WebMethod]
            public void consultaDraft()
            {
            
            string msgErro;
            ArrayList meuArray = new ArrayList();
            
            ConexaoBD connbd = new ConexaoBD();
            MySqlConnection conn = connbd.Conectar();
            
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

                try
                {
                    while (reader.Read())
                    {
                        meuArray.Add(Convert.ToString(reader.GetInt32(0)));
                    }
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(meuArray));
                }catch(Exception ex){
                    msgErro = "Ocorreu o erro: " + ex.Message;
                    reader.Close();
                    connbd.Desconectar();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(msgErro));
                }finally{
                    reader.Close();
                    connbd.Desconectar();
                }
        }

            [WebMethod]
            public void consultaFuture()
            {
                string msgErro;
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

                try
                {
                    while (reader.Read())
                    {
                        meuArray.Add(Convert.ToString(reader.GetInt32(0)));
                    }
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(meuArray));
                }catch(Exception ex){
                    msgErro = "Ocorreu o erro: " + ex.Message;
                    reader.Close();
                    connbd.Desconectar();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(msgErro));
                }finally{
                    reader.Close();
                    connbd.Desconectar();
                }
            }

            [WebMethod]
            public void consultaFinal()
            {
                string msgErro;
                ArrayList meuArray = new ArrayList();

                ConexaoBD connbd = new ConexaoBD();
                MySqlConnection conn = connbd.Conectar();

                string sql = "SELECT distinct cfield_design_values.value " +
                            "FROM cfield_design_values inner join tcversions " +
                            "on cfield_design_values.node_id = tcversions.id " +
                            "and tcversions.creation_ts >= '2016-11-25' " +
                            "and tcversions.status = 7	" +
                            "and tcversions.execution_type = 1 " +
                            "order by tcversions.creation_ts desc limit 10;";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        meuArray.Add(Convert.ToString(reader.GetInt32(0)));
                    }
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        Context.Response.Write(js.Serialize(meuArray));
                }catch(Exception ex){
                    msgErro = "Ocorreu o erro: " + ex.Message;
                    reader.Close();
                    connbd.Desconectar();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(msgErro));
                }finally{
                    reader.Close();
                    connbd.Desconectar();
                }
            }	

            [WebMethod]
            public void calculoTempo(string dataHora)
            {
                string msgErro;
                int totalEstimado = 0;
                int totalRealizado = 0;
                ArrayList meuArray = new ArrayList();
            
                ConexaoBD connbd = new ConexaoBD();
                MySqlConnection conn = connbd.Conectar();

                string sql = "select a.tc_external_id, c.value, ifnull(a.estimated_exec_duration,0) 'Estimado' , ifnull(b.execution_duration, 0) 'Realizado' " +
                            " from tcversions a inner join executions b " +
                            " on a.id = b.tcversion_id " +
                            " inner join cfield_design_values c " +
                            " on c.node_id = a.id " +
                            " where b.testplan_id = (select testplan_id from testplan_tcversions where creation_ts = '" + dataHora + "' limit 1) " +
                            " and a.execution_type = 1 " +
                            " and b.status = 'p' " +
                            " order by c.value desc;"; 

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                MySqlDataReader reader = cmd.ExecuteReader();
                
                try
                {
                    while (reader.Read())
                    {
            
                        Tempos t = new Tempos();
            
                        t.caso = reader.GetInt32(0);
                        t.tkt = reader.GetInt32(1);
                        t.est = reader.GetInt32(2);
                        t.real = reader.GetInt32(3);

                        totalEstimado = totalEstimado + t.est;
                        totalRealizado = totalRealizado + t.real;

                        t.totalEst = totalEstimado;
                        t.totalReal = totalRealizado;

                        t.percent = ((Convert.ToDouble(t.real)/Convert.ToDouble(t.est))*100)-100;

                        t.percent = Math.Abs(t.percent);
                        
                        meuArray.Add(t);
                }
                        // Esta opção retorna um JSON com todos resultados da consulta
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        Context.Response.Write(js.Serialize(meuArray));
                }catch(Exception ex){
                    msgErro = "Ocorreu o erro: " + ex.Message;
                    reader.Close();
                    connbd.Desconectar();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(msgErro));
                }finally{
                    reader.Close();
                    connbd.Desconectar();
                }
            }        

            [WebMethod]
            public void listaDataRegressivos()
            {
                string msgErro;
                ArrayList meuArray = new ArrayList();

                ConexaoBD connbd = new ConexaoBD();
                MySqlConnection conn = connbd.Conectar();

                string sql = "SELECT  creation_ts FROM testplan_tcversions group by testplan_id;";

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                MySqlDataReader reader = cmd.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        Generica g = new Generica();

                        g.p4 = Convert.ToString(reader.GetValue(0));                    

                        meuArray.Add(g);

                    }
                    // Esta opção retorna um JSON com todos resultados da consulta
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(meuArray));
                }
                catch (Exception ex)
                {
                    msgErro = "Ocorreu o erro: " + ex.Message;
                    reader.Close();
                    connbd.Desconectar();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    Context.Response.Write(js.Serialize(msgErro));
                }
                finally
                {
                    reader.Close();
                    connbd.Desconectar();
                }
            }

    }
