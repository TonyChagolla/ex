using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace WebAppPaises
{
    public class SqlConnect
    {
        private SqlConnectionStringBuilder builder;
        private SqlConnection conn = null;

        public SqlConnect(string server, string user, string pass, string database)
        {
            builder = new SqlConnectionStringBuilder();
            builder.DataSource = server;
            builder.UserID = user;
            builder.Password = pass;
            builder.InitialCatalog = database;
        }

        public bool OpenConnection()
        {
            conn = new SqlConnection(builder.ConnectionString);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
            return true;
        }

        public bool CloseConnection()
        {
            try
            {
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
            return true;
        }


        public DataTable ExcecuteQuery(string query)
        {
            string res = "";
            try
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                    string JSONString = string.Empty;
                    JSONString = JsonConvert.SerializeObject(dataTable);
                    //return JSONString;
                }
                Console.WriteLine("Registros afectados: " + res);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}\n", e.Message);
                return null;
            }
        }

        public DataTable ExcecuteQueryVar(string query, string name)
        {
            string res = "";
            try
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@nombre", name);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                    string JSONString = string.Empty;
                    JSONString = JsonConvert.SerializeObject(dataTable);
                    //return JSONString;
                }
                Console.WriteLine("Registros afectados: " + res);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}\n", e.Message);
                return null;
            }
        }

        public DataTable fillTable(string query)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = query;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch(SqlException e)
            {
                return null;
            }
           
        }

        public bool GetStatus()
        {

            if (conn.State.ToString() == "open")
            {
                return true;
            }
            return false;
        }
    }
}