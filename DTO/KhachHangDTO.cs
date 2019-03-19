using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHangDTO
    {
        private string makh, tenkh, diachi;
        private int sdt;

        public KhachHangDTO(DataRow row)
        {
            this.Makh = row["makh"].ToString();
            this.Tenkh = row["tenkh"].ToString();
            this.Diachi = row["diachi"].ToString();
            this.Sdt = (int)row["sdt"];
        }

        public KhachHangDTO(string makh, string tenkh, string diachi, int sdt)
        {
            this.Makh = makh;
            this.Tenkh = tenkh;
            this.Diachi = diachi;
            this.Sdt = sdt;
        }

        public string Makh { get => makh; set => makh = value; }
        public string Tenkh { get => tenkh; set => tenkh = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public int Sdt { get => sdt; set => sdt = value; }
    }
}
