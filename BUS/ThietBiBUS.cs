using System;
using System.Collections.Generic;
using DTO;
using DAO;
using System.Data;

namespace BUS
{
    public class ThietBiBUS
    {
        public static List<ThietBiDTO> ListTB()
        {
            return ThietBiDAO.GetThietBi();
        }
        public static List<ThietBiDTO> GetThietbiTheoLoai(String loai)
        {
            return ThietBiDAO.GetThietbiTheoLoai(loai);
        }
        public List<string> LoadLoaiTB()
        {
            return ThietBiDAO.Instance.LoadLoaiTB();
        }
        public bool AddThietBi(string matb, string tentb, string loai, string soluong, string dongia)
        {
            return ThietBiDAO.Instance.AddThietBi(matb,tentb,loai,soluong,dongia);
        }
        public bool DelThietBi(ThietBiDTO tb)
        {
            return ThietBiDAO.Instance.DelThietBi(tb);
        }
        public bool FixThietbi(ThietBiDTO tb)
        {
            return ThietBiDAO.Instance.FixThietBi(tb);
        }
    }
}
