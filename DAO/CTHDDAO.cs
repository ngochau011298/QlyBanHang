using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAO
{
    public class CTHDDAO
    {
        private static CTHDDAO instance;
        public static CTHDDAO Instance
        {
            get { if (instance == null) instance = new CTHDDAO(); return CTHDDAO.instance; }
            private set { CTHDDAO.instance = value; }
        }
        public static List<CTHDDTO> GetCTHD()
        {
            List<CTHDDTO> list = new List<CTHDDTO>();
            string query = "SELECT * FROM CTHD";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                CTHDDTO hd = new CTHDDTO(item);
                list.Add(hd);
            }
            return list;
        }

        public bool AddCTHD(string mahd, string matb, int soluong)
        {
            string query = String.Format("INSERT INTO dbo.CTHD (MAHD,MATB,SOLUONG)VALUES(N'{0}', N'{1}','{2}')", mahd, matb, soluong);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //Sửa
        public bool FixCTHD(CTHDDTO cthd)

        {
            string query = String.Format("UPDATE CTHD SET  SOLUONG='{0}' WHERE MAHD='{1}'AND MATB='{2}' ",cthd.Mahd, cthd.Matb, cthd.Soluong);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //Xóa
        public bool DelCTHD(CTHDDTO cthd)
        {
            string query = String.Format("DELETE CTHD WHERE MAHD= '{0}'",cthd.Mahd);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}

