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
    public class CTHDBUS
    {
        public static List<CTHDDTO> ListCTHD()
        {
            return CTHDDAO.GetCTHD();
        }
        public bool AddCTHD(string mahd, string matb, int soluong)
        {
            return CTHDDAO.Instance.AddCTHD(mahd, matb, soluong);
        }
        public bool FixCTHD(CTHDDTO cthd)
        {
            return CTHDDAO.Instance.FixCTHD(cthd);
        }
        public bool DelCTHD(CTHDDTO cthd)
        {
            return CTHDDAO.Instance.DelCTHD(cthd);
        }
    }
}

