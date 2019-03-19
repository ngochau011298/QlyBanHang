using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO
{
    public class Connection
    {
        
            protected SqlConnection conn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QLBH;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        
        //public static List<T> ExecuteCommand(String query/*, params SqlParameter[] parameterlist*/)
        //{
        //    SqlConnection conn = GetConnection();
        //    conn.Open();
        //    List<T> result = new List<T>();
        //    String sql = "";
        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = sql;
        //        SqlDataReader reader = cmd.ExecuteReader();
        //    return result;
        //    //int result = 0;
        //    //using (SqlConnection sqlConn = GetConnection())
        //    //{
        //    //    SqlCommand cmd = new SqlCommand();
        //    //    cmd.Connection = sqlConn;
        //    //    cmd.CommandText = query;
        //    //    cmd.CommandType = System.Data.CommandType.Text;
        //    //    cmd.Parameters.AddRange(parameterlist);
        //    //    sqlConn.Open();
        //    //    result = cmd.ExecuteNonQuery();
        //    //}
        //    //    return result;
        //}
            
        //public SqlDataReader ExecuteReader(string query, params SqlParameter[] parametersList)
        //{
        //    try
        //    {
        //        SqlConnection sqlConn = GetConnection();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = sqlConn;
        //        cmd.CommandText = query;
        //        cmd.CommandType = System.Data.CommandType.Text;
        //        cmd.Parameters.AddRange(parametersList);
        //        sqlConn.Open();

        //        return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        //    }
        //    catch(Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
