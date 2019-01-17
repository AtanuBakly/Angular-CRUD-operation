using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ApiRegistrationDemo.Models
{
    public class SqlExecute
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);

        public Int32 ExecuteNonQuery(string sql)
        {
            conn.Open();
            Int32 rec = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                rec = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
            return rec;
        }
        public DataSet ExecuteDataSet(string sql)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(ds);
            return ds;
        }

        public SqlDataReader ExecuteReader(string sql)
        {
            conn.Open();
            SqlDataReader reader = null;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
            }
            finally
            {
               // conn.Close();
            }
            return reader;
        }
    }
}