using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace DTO
{
    public class CTHDDTO
    {
        private string mahd, matb;
        private int soluong;

        public CTHDDTO(string mahd, string matb, int soluong)
        {
            this.mahd = mahd;
            this.matb = matb;
            this.soluong = soluong;
        }

        public string Mahd { get => mahd; set => mahd = value; }
        public string Matb { get => matb; set => matb = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public CTHDDTO(DataRow row)
        {
            this.Mahd = row["mahd"].ToString();
            this.Matb = row["matb"].ToString();
            this.Soluong = (int)row["soluong"];

        }
        SqlConnection cnn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Project_BanHang;User ID=sa,Password=123");

        //ExecuteQuery
        public DataTable ExecuteQuery(string query)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(query, cnn);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        //ExecuteNonQuery
        public void ExecuteNonQuery(string query)
        {
            SqlCommand cmd = new SqlCommand(query, cnn);

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }
}

