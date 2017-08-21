using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace IntegraTestlinkWS
{
    /// <summary>
    /// Summary description for AtualizaInformacoesTestlink
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AtualizaInformacoesTestlink : System.Web.Services.WebService
    {

        [WebMethod]
        public string AtualizaDraftFutureEspecifico(int demanda)
        {
            string sql = "update tcversions set STATUS = '6' where creation_ts >= '2016-11-25' AND id in (SELECT node_id FROM cfield_design_values where value in ("+demanda+"))";
            return sql;
        }

        [WebMethod]
        public string AtualizaDraftFutureTodas()
        {
            string sql = "update tcversions set STATUS = '6' where creation_ts >= '2016-11-25' AND STATUS = '1'";
            return sql;
        }

        [WebMethod]
        public string AtualizaFutureFinalEspecifico(int demanda)
        {
            string sql = "update tcversions set STATUS = '7' where creation_ts >= '2016-11-25' AND id in (SELECT node_id FROM cfield_design_values where value in (" + demanda + "))";
            return sql;
        }

        [WebMethod]
        public string AtualizaFutureFinalTodas()
        {
            string sql = "update tcversions set STATUS = '7' where creation_ts >= '2016-11-25' AND STATUS = '6'";
            return sql;
        }
    }
}
