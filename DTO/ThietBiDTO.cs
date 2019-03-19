using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThietBiDTO
    {
        private string matb, tentb, loai;
        private int soluong;
        private float dongia;

        public ThietBiDTO(string matb, string tentb, string loai, int soluong, float dongia)
        {
            this.Matb = matb;
            this.Tentb = tentb;
            this.Loai = loai;
            this.Soluong = soluong;
            this.Dongia = dongia;
        }

        public ThietBiDTO(DataRow row)
        {
            this.Matb = row["matb"].ToString();
            this.Tentb = row["tentb"].ToString();
            this.Loai = row["loai"].ToString();
            this.Soluong = (int)row["soluong"];
            this.Dongia = (float)Convert.ToDouble(row["dongia"].ToString());
        }

        public string Matb { get => matb; set => matb = value; }
        public string Tentb { get => tentb; set => tentb = value; }
        public string Loai { get => loai; set => loai = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public float Dongia { get => dongia; set => dongia = value; }

        SqlConnection cnn = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=Project_BanHang;User ID=sa");

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
