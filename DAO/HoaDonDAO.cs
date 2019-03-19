using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class HoaDonDAO
    {
        private static HoaDonDAO instance;
        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return HoaDonDAO.instance; }
            private set { HoaDonDAO.instance = value; }
        }


        //load hoa don
        public static List<HoaDonDTO> GetHoaDon()
        {
            List<HoaDonDTO> list = new List<HoaDonDTO>();
            string query = "SELECT * FROM HoaDon";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                HoaDonDTO hd = new HoaDonDTO(item);
                list.Add(hd);
            }
            return list;
        }

        public bool AddHoaDon(string mahd, string makh, string diachigiao, int giaohang, float thanhtien, DateTime ngayhd)
        {
            string query = String.Format("INSERT INTO dbo.HoaDon (MAHD,MAKH,DIACHIGIAO,GIAOHANG,THANHTIEN,NGAYHD)VALUES(N'{0}', N'{1}','{2}','{3}','{4}','{5}')", mahd, makh, diachigiao,giaohang, thanhtien, ngayhd);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //S?a
        public bool FixHoaDon(HoaDonDTO hd)
        {
            string query = String.Format("UPDATE dbo.HoaDon SET MAKH='{0}',DIACHIGIAO='{1}',GIAOHANG='{2}', THANHTIEN='{3}',NGAYHD='{4}' WHERE MAHD='{5}' ", hd.Makh, hd.Diachigiao,hd.Giaohang, hd.Thanhtien, hd.Ngayhd, hd.Mahd);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //Xóa
        public bool DelHoaDon(HoaDonDTO hd)
        {
            string query = String.Format("DELETE FROM dbo.HoaDon WHERE MAHD= '{0}'", hd.Mahd);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
