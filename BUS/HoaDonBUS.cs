using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class HoaDonBUS
    {
        public static List<HoaDonDTO> ListHD()
        {
            return HoaDonDAO.GetHoaDon();
        }
        public bool AddHoaDon(string mahd, string makh, string diachigiao,int giaohang, float thanhtien, DateTime ngayhd)
        {
            return HoaDonDAO.Instance.AddHoaDon(mahd, makh, diachigiao,giaohang, thanhtien, ngayhd);
        }
        public bool DelHoaDon(HoaDonDTO hd)
        {
            return HoaDonDAO.Instance.DelHoaDon(hd);
        }
        public bool FixHoaDon(HoaDonDTO hd)
        {
            return HoaDonDAO.Instance.FixHoaDon(hd);
        }
    }
}
