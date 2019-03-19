namespace DAO
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class ExecuteQuery
    {
        public static List<String[]> getAll(String table)
        {
            SqlConnection conn = Connection.GetConnection();
            conn.Open();
            List<String[]> result = new List<String[]>();
            String sql = "";
            if (table == "HoaDon")
                sql = @"SELECT HoaDon.id,ngay,tongtien,diachigiao,giaohang,idkhachhang,ten,diachi,sdt from HoaDon, KhachHang where HoaDon.idkhachhang=KhachHang.id";
            else
                sql = "SELECT * FROM " + table;
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        String[] tmp = new String[10];
                        for(int i=0;i<reader.FieldCount;i++)
                        {
                            tmp[i] = reader[i].ToString();
                        }
                        result.Add(tmp);
                    }
                };
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                return result;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public static List<String[]> getCTHDbyID(String id)
        {
            SqlConnection conn = Connection.GetConnection();
            conn.Open();
            List<String[]> result = new List<String[]>();
            String sql = $"select CTHoaDon.id,CTHoaDon.soluong,ThietBi.id,ThietBi.ten,ThietBi.gia,ThietBi.soluong,ThietBi.loai from CTHoaDon, ThietBi where CTHoaDon.idthietbi = ThietBi.id AND CTHoaDon.id='{id}'";
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        String[] tmp = new String[10];
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            tmp[i] = reader[i].ToString();
                        }
                        result.Add(tmp);
                    }
                };
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                return result;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public static String[] getOne(String id, String table)
        {
            String[] result = { };
            SqlConnection conn = Connection.GetConnection();
            conn.Open();
            String sql = "SELECT * FROM " + table + "WHERE id =\'" + id +"\'";
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = new String[reader.FieldCount];
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        result[i] = reader[i].ToString();
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                return result;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public static String[] getLoaiTB()
        {
            String[] result = {};
            SqlConnection conn = Connection.GetConnection();
            conn.Open();
            String sql = "SELECT loai FROM ThietBi GROUP BY loai";
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                SqlDataReader reader = cmd.ExecuteReader();
                List<String> tmp = new List<string>();
                while (reader.Read())
                    tmp.Add(reader[0].ToString());
                result = new string[tmp.Count];
                for (int i = 0; i < tmp.Count; i++)
                    result[i] = tmp[i];
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                return result;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public static int AddRows(String obj,String table)
        {
            int result = 0;
            SqlConnection conn = Connection.GetConnection();
            conn.Open();
            String sql = "INSERT INTO " + table + " VALUES(" + obj + ")";
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                return result;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
        public static int DeleteRows(String id,String table)
        {
            int result = 0;
            SqlConnection conn = Connection.GetConnection();
            conn.Open();
            String sql = "DELETE FROM " + table + " WHERE id='" + id +"'";
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                return result;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        public static string getMahd()
        {
            String result="HD0000000001";
            SqlConnection conn = Connection.GetConnection();
            conn.Open();
            String sql = "SELECT MAX(id) FROM HoaDon";
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                result = reader[0].ToString();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                return result;
            }
            finally
            {
                conn.Close();
            }
        }

        public static int RefeshSL(String id, int soluong)
        {
            int result = 0;
            SqlConnection conn = Connection.GetConnection();
            conn.Open();
            String sql = $"UPDATE ThietBi SET soluong = soluong - {soluong} WHERE id = '{id}'";
            try
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                return result;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }
    }
}
