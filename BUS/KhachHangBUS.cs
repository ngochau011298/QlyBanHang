using DTO;
using DAO;
using System.Collections.Generic;



namespace BUS
{
    public class KhachHangBUS
    {
        public static List<KhachHangDTO> ListKH()
        {
            return KhachHangDAO.GetKhachHang();
        }
        public bool AddKhachHang(string makh, string tenkh, string diachi, string sdt)
        {
            return KhachHangDAO.Instance.AddKhachHang(makh,tenkh,diachi,sdt);
        }
        public bool EditKhachHang(KhachHangDTO kh)
        {
            return KhachHangDAO.Instance.EditKhachHang(kh);
        }
        public bool GetByContact(int sdt)
        {
            return KhachHangDAO.Instance.GetByContact(sdt);
        }
    }
}
