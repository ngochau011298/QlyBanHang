using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        //Singleton
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        //địa chỉ kêt nối   
        string connectionSTR = "Data Source=.\\sqlexpress;Initial Catalog=Project_BanHang;User ID=sa";






        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable dtt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();  //Mở cổng kết nối

                SqlCommand command = new SqlCommand(query, connection);    //Lệnh thực thi

                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter dta = new SqlDataAdapter(command);       //Chuyển đổi dữ liệu

                dta.Fill(dtt);  //Đỗ dữ liệu vào table

                connection.Close(); //Đóng kết nối
            }
            return dtt;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int dtt = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();  //Mở cổng kết nối

                SqlCommand command = new SqlCommand(query, connection);    //Lệnh thực thi

                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                dtt = command.ExecuteNonQuery();
                connection.Close(); //Đóng kết nối
            }
            return dtt;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object dtt = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();  //Mở cổng kết nối

                SqlCommand command = new SqlCommand(query, connection);    //Lệnh thực thi

                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                dtt = command.ExecuteScalar();
                connection.Close(); //Đóng kết nối
            }
            return dtt;
        }
    }
}
