using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Data;
using Newtonsoft.Json;

namespace WebAppPaises
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        SqlConnect con = new SqlConnect("localhost", "examen", "examen", "Prueba");
        [WebMethod]
        public string GetPaises()
        {
            string query = "SELECT pais_id, nombre FROM pais;";
            con.OpenConnection();
            DataTable dt = con.ExcecuteQuery(query);
            con.CloseConnection();
            string JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }

        [WebMethod]
        public string GetEstados(int pais_id)
        {
            string query = "SELECT e.estado_id, e.nombre FROM estado e WHERE e.pais_id = " + pais_id.ToString();
            con.OpenConnection();
            DataTable dt = con.ExcecuteQuery(query);
            con.CloseConnection();
            string JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }

        [WebMethod]
        public string GetCiudad(string ciudad)
        {
            string query = "SELECT c.ciudad_id, c.nombre AS 'Ciudad', e.nombre AS 'Estado', p.nombre AS 'Pais'"
                        + " FROM ((ciudad c INNER JOIN estado e "
                        + " ON c.estado_id = e.estado_id AND c.nombre = @nombre AND c.estatus = 1) "
                        + " INNER JOIN pais p ON e.pais_id = p.pais_id) ";
            con.OpenConnection();
            DataTable dt = con.ExcecuteQueryVar(query, ciudad);
            con.CloseConnection();
            string JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }

        [WebMethod]
        public string GetCiudades()
        {
            string query = "SELECT c.ciudad_id, c.nombre AS 'Ciudad', e.nombre AS 'Estado', p.nombre AS 'Pais'"
                        + " FROM ((ciudad c INNER JOIN estado e "
                        + " ON c.estado_id = e.estado_id AND c.estatus = 1) "
                        + " INNER JOIN pais p ON e.pais_id = p.pais_id) ";
            con.OpenConnection();
            DataTable dt = con.ExcecuteQuery(query);
            con.CloseConnection();
            string JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }

        [WebMethod]
        public string updateCiudad(int ciudad_id, string newName)
        {
            string query = "UPDATE ciudad SET nombre = @nombre WHERE ciudad_id = " +ciudad_id;
            con.OpenConnection();
            DataTable dt = con.ExcecuteQueryVar(query, newName);
            con.CloseConnection();
            string JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }

        [WebMethod]
        public string deleteCiudad(int ciudad_id)
        {
            string query = "UPDATE ciudad SET estatus = 0 WHERE ciudad_id = " + Regex.Escape(ciudad_id.ToString());
            con.OpenConnection();
            DataTable dt = con.ExcecuteQuery(query);
            con.CloseConnection();
            string JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }

        [WebMethod]
        public string insertCiudad(int estado_id, string nombre)
        {
            string query = "INSERT INTO ciudad(nombre, estado_id, estatus) VALUES(@nombre," + estado_id +",1)";
            con.OpenConnection();
            DataTable dt = con.ExcecuteQueryVar(query, nombre);
            con.CloseConnection();
            string JSONString = JsonConvert.SerializeObject(dt);
            return JSONString;
        }
    }
}
