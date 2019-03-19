using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BUS;
using DTO;

namespace GUIwebform
{
    public partial class _Default : Page
    {
        static KhachHangBUS khBus = new KhachHangBUS();

        static ThietBiBUS tbbus = new ThietBiBUS();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ThietBiDTO> ltb = ThietBiBUS.ListTB();
            foreach (var row in ltb)
            {

                HtmlTableRow row2 = new HtmlTableRow();

                var cel = new HtmlTableCell();
                cel.InnerHtml = "<input type='checkbox' runat='server' ID='chkSelected' value='" + row.Matb + "' OnCheckedChanged='addListSelect'/>";
                row2.Controls.Add(cel);

                //var cell = new HtmlTableCell();
                //cell.InnerText = row.Matb.ToString();
                //row2.Controls.Add(cell);

                var cell1 = new HtmlTableCell();
                cell1.InnerText = row.Tentb.ToString();
                row2.Controls.Add(cell1);

                var cell2 = new HtmlTableCell();
                cell2.InnerText = row.Loai.ToString();
                row2.Controls.Add(cell2);

                var cell3 = new HtmlTableCell();
                cell3.InnerText = row.Dongia.ToString();
                row2.Controls.Add(cell3);

                var cell4 = new HtmlTableCell();
                cell4.InnerText = row.Soluong.ToString();
                row2.Controls.Add(cell4);

                tbl_ThietBi.Controls.Add(row2);
            }

        }
        [WebMethod]
        public static void SaveInvoice(string diachigiao,float thanhtien)
        {
            string mahd = "";
            string makh = "";
            int giaohang = 0;
            DateTime ngayhd = DateTime.Now;
            HoaDonBUS hd = new HoaDonBUS();
            HoaDonDTO entity = new HoaDonDTO(mahd,makh,diachigiao,giaohang,thanhtien,ngayhd);
            hd.AddHoaDon(mahd, makh, diachigiao, giaohang, thanhtien, ngayhd);
        }
        /*public static void SaveInvoice(string makh, string thanhtien, double saleoff)
        {
            CTHDBUS cthd = new CTHDBUS();
            int Mahd = 0;
            DateTime ngayhd = DateTime.Now;
            HoaDonBUS hd = new HoaDonBUS();

            HoaDonDTO entity = new HoaDonDTO(mahd,makh,thanhtien,saleoff,ngayhd);

            CTHDBUS cTHDBUS = new CTHDBUS();
            GiaoHangBUS giaoHangBUS = new GiaoHangBUS();
            hd.Add(entity);
            giaoHangBUS.Add(GH);
            cTHDBUS.Add(listCTHD);

        }*/
        /*public static KhachHangDTO GetKH(int sdt)
        {

            List<KhachHangDTO> kh = KhachHangBUS.GetByContact(sdt);
            if (kh.Rows.Count > 0)
            {
                List<KhachHangDTO> lkh = KhachHangBUS.ListKH();
                foreach (var row in lkh)
                {

                    HtmlTableRow row3 = new HtmlTableRow();

                    var cel = new HtmlTableCell();
                    cel.InnerHtml = "<input type='checkbox' runat='server' ID='chkSelected' value='" + row.Makh + "' OnCheckedChanged='addListSelect'/>";
                    row3.Controls.Add(cel);

                    //var cell = new HtmlTableCell();
                    //cell.InnerText = row.Matb.ToString();
                    //row2.Controls.Add(cell);

                    var cell1 = new HtmlTableCell();
                    cell1.InnerText = row.Tenkh.ToString();
                    row3.Controls.Add(cell1);

                    var cell2 = new HtmlTableCell();
                    cell2.InnerText = row.Diachi.ToString();
                    row3.Controls.Add(cell2);

                    var cell3 = new HtmlTableCell();
                    cell3.InnerText = row.Sdt.ToString();
                    row3.Controls.Add(cell3);

                }
                // KhachHangDTO _khachhang = new KhachHangDTO(int.Parse(kh.Rows[0].ItemArray[0].ToString()), kh.Rows[0].ItemArray[1].ToString(), kh.Rows[0].ItemArray[2].ToString(), kh.Rows[0].ItemArray[3].ToString());
                //return _khachhang;
            }
            else
                return null;
        }*/
    }
}