using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class KhachHangDAO
    {
        //Singleton
        private static KhachHangDAO instance;

        //Get  +set
        public static KhachHangDAO Instance
        {
            get { if (instance == null) instance = new KhachHangDAO(); return KhachHangDAO.instance; }
            private set { KhachHangDAO.instance = value; }
        }

        private KhachHangDAO() { }

        //load khách hàng
        public static List<KhachHangDTO> GetKhachHang()
        {
            List<KhachHangDTO> list = new List<KhachHangDTO>();
            string query = "SELECT * FROM KhachHang";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                KhachHangDTO kh = new KhachHangDTO(item);
                list.Add(kh);
            }
            return list;
        }

        public bool AddKhachHang(string makh, string tenkh, string diachi, string sdt)
        {
            string query = String.Format("INSERT INTO dbo.KhachHang (MAKH,TENKH,DIACHI,SDT)VALUES(N'{0}', N'{1}','{2}','{3}')",makh,tenkh,diachi,sdt);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool EditKhachHang(KhachHangDTO kh)
        {
            string query = String.Format("UPDATE dbo.KhachHang SET MAKH = N'{0}', TENKH = N'{1}', DIACHI = N'{2}', SDT = N'{3}' WHERE MAKH = N'{4}'",kh.Makh, kh.Tenkh,kh.Diachi,kh.Sdt,kh.Makh);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool GetByContact(int sdt)
        {
            try
            {
                string query = String.Format("Select * from KhachHang where SDT = '" + sdt + "'");
                int result = DataProvider.Instance.ExecuteNonQuery(query);
                return result > 0 ;

               /* SqlDataAdapter da = new SqlDataAdapter("Select * from KhachHang where SDT='" + sdt+ "'");
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;*/
            }
            catch
            {
                return false;
            }
        }
    }
}
