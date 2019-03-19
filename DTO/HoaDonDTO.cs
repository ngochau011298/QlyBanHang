using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DTO
{
    public class HoaDonDTO
    {
        private string mahd, makh, diachigiao;
        private int giaohang;
        private float thanhtien;
        private DateTime ngayhd;

        
        public HoaDonDTO(DataRow row)
        {
            this.Mahd = row["mahd"].ToString();
            this.Makh = row["makh"].ToString();
            this.Diachigiao = row["diachigiao"].ToString();
            this.Giaohang = (int)row["giaohang"];
            this.Thanhtien = (float)Convert.ToDouble(row["thanhtien"].ToString());
            this.ngayhd = (DateTime)row["ngayhd"];
        }

        public HoaDonDTO(string mahd, string makh, string diachigiao, int giaohang, float thanhtien, DateTime ngayhd)
        {
            this.mahd = mahd;
            this.makh = makh;
            this.diachigiao = diachigiao;
            this.giaohang = giaohang;
            this.thanhtien = thanhtien;
            this.ngayhd = ngayhd;
        }

        public string Mahd { get => mahd; set => mahd = value; }
        public string Makh { get => makh; set => makh = value; }
        public string Diachigiao { get => diachigiao; set => diachigiao = value; }
        public float Thanhtien { get => thanhtien; set => thanhtien = value; }
        public DateTime Ngayhd { get => ngayhd; set => ngayhd = value; }
        public int Giaohang { get => giaohang; set => giaohang = value; }

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
