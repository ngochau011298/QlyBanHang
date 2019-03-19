using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAO
{
    public class ThietBiDAO
    {
        //Singleton
        private static ThietBiDAO instance;

        //Get  +set
        public static ThietBiDAO Instance
        {
            get { if (instance == null) instance = new ThietBiDAO(); return ThietBiDAO.instance; }
            private set { ThietBiDAO.instance = value; }
        }

        private ThietBiDAO() { }

        //load thiet bi theo loai
        public static List<ThietBiDTO> GetThietbiTheoLoai(String loai)
        {
            List<ThietBiDTO> list = new List<ThietBiDTO>();
            string query = $"SELECT * FROM ThietBi WHERE LOAI = '{loai}'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ThietBiDTO ThietBi = new ThietBiDTO(item);
                list.Add(ThietBi);
            }
            return list;
        }

        //load thiet bi
        public static List<ThietBiDTO> GetThietBi()
        {
            List<ThietBiDTO> list = new List<ThietBiDTO>();
            string query = "SELECT * FROM ThietBi";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                ThietBiDTO ThietBi = new ThietBiDTO(item);
                list.Add(ThietBi);
            }
            return list;
        }

        //load loai thiet bi
        public List<string> LoadLoaiTB()
        {
            List<string> list = new List<string>();
            string query = "SELECT LOAI FROM ThietBi GROUP BY LOAI";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                list.Add(item.ItemArray[0].ToString());
            }
            return list;
            
        }

        //Trừ số lượng khi order
        public void UpdateQuantity(int sltru, int id)
        {
            string query = String.Format("UPDATE dbo.ThietBi SET SOLUONG = SOLUONG - {0} WHERE MATB = {1}", sltru, id);
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        //Show số lượng thức ăn sau khi trừ
        public int Quantity(int matb)
        {
            string query = "USP_ShowQuantityofTB @matb";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query, new object[] { matb });

            int quantity = (int)dt.Rows[0][0];
            return quantity;
        }

        //Thêm
        public bool AddThietBi(string matb, string tentb, string loai, string soluong, string dongia)
        {
            string query = String.Format("INSERT INTO dbo.ThietBi (MATB,TENTB,LOAI,SOLUONG,DONGIA)VALUES(N'{0}', N'{1}','{2}','{3}',{4})", matb, tentb, loai, soluong, dongia);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //Sửa
        public bool FixThietBi(ThietBiDTO tb)
        {
            string query = String.Format("UPDATE dbo.ThietBi SET MATB = N'{0}', TENTB = N'{1}', LOAI = N'{2}', SOLUONG = N'{3}', DONGIA = N'{4}' WHERE MATB = N'{5}'", tb.Matb, tb.Tentb, tb.Loai, tb.Soluong, tb.Dongia,tb.Matb);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //Xóa
        public bool DelThietBi(ThietBiDTO tb)
        {
            string query = String.Format("DELETE FROM ThietBi WHERE MATB= '{0}'",tb.Matb);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
