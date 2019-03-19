using BUS;
using DTO.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace quanlybanhang
{
    public partial class _Default : Page
    {
        ThietBiBUS tbBus = new ThietBiBUS();
        LoaiThietBiBUS ltbBus = new LoaiThietBiBUS();
        static KhachHangBUS khBus = new KhachHangBUS();
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
                DataTable tb = tbBus.GetAll();
                DataTable ltb = ltbBus.GetAll();
                //DataTable kh = khBus.GetByContact();
                List<LoaiThietBiDTO> LoaiThietBiDTOs = new List<LoaiThietBiDTO>();


                foreach (DataRow ltb_row in ltb.Rows)
                {

                    LoaiThietBiDTO _LoaiThietBiDTO = new LoaiThietBiDTO(int.Parse(ltb_row.ItemArray[0].ToString()), ltb_row.ItemArray[1].ToString());
                    LoaiThietBiDTOs.Add(_LoaiThietBiDTO);

                }
                foreach (DataRow row in tb.Rows)
                {
                    HtmlTableRow row2 = new HtmlTableRow();
                    foreach (var item in row.ItemArray)
                    {

                        var cell = new HtmlTableCell();

                        //var loai = this.
                        cell.InnerText = item.ToString();
                        if (row2.Cells.Count == 0)
                        {
                            cell.InnerHtml = "<input type='checkbox' runat='server' ID='chkSelected' value='" + item + "' OnCheckedChanged='addListSelect'/>";
                        }
                        if (row2.Cells.Count == 2)
                        {
                            LoaiThietBiDTO loaiThietBiDTO = ltbBus.GetById(Convert.ToInt32(item));
                            cell.InnerText = loaiThietBiDTO.TypeName;
                        }

                        row2.Cells.Add(cell);

                    }
                    tbl_ThietBi.Controls.Add(row2);
                }
            //MaintainScrollPositionOnPostBack = false;
            //findKH.Attributes.Add("AutoPostback", "false");
            //btnFindKH.Attributes.Add("onclick", "return false");
        }



        //btnLap.Attributes.Add("OnClick", "SaveInvoice");

        [WebMethod]
        public static void SaveInvoice(int KhId,int total)
            {
                int Mahd = 0;
                DateTime DateCreate = DateTime.Now;
                HoaDonBUS hd = new HoaDonBUS();
                HoaDonDTO entity = new HoaDonDTO(Mahd, KhId, DateCreate, total);
                hd.Add(entity);
            }
        
            //public void LoadKH(object sender, EventArgs e)
            //{
            //    string contact = txtPhoneNumber.Value;
            //    DataTable kh = khBus.GetByContact(contact);
            //    txtCustomerID.Value = kh.Rows[0].ItemArray[0].ToString();
            //    txtAddress.Value = kh.Rows[0].ItemArray[3].ToString();
            //    txtCustomerName.Value = kh.Rows[0].ItemArray[1].ToString();

            //}
        [WebMethod]
        public static KhachHangDTO GetKH(string contact)
        {
            
            DataTable kh = khBus.GetByContact(contact);
            if (kh.Rows.Count > 0)
            {
                KhachHangDTO _khachhang = new KhachHangDTO(int.Parse(kh.Rows[0].ItemArray[0].ToString()), kh.Rows[0].ItemArray[1].ToString(), kh.Rows[0].ItemArray[2].ToString(), kh.Rows[0].ItemArray[3].ToString());
                return _khachhang;
            }
            else
                return null;
        }

        [WebMethod]
        public static void SaveCTHD()
        {
            
            
        }

    }
}