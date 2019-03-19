using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;

namespace GUI
{
    public partial class Main : Form
    {
        private object beedit;
        public Main()
        {
            InitializeComponent();
        }
        private void LoadThietBi()
        {
            List<ThietBiDTO> list = ThietBiBUS.ListTB();
            dtgvThietBi.DataSource = list;
            if (list.Count > 0)
            {
                dtgvThietBi.Columns[0].HeaderText = "Mã thiết bị";
                dtgvThietBi.Columns[1].HeaderText = "Tên thiết bị";
                dtgvThietBi.Columns[2].HeaderText = "Loại";
                dtgvThietBi.Columns[3].HeaderText = "Số lượng";
                dtgvThietBi.Columns[4].HeaderText = "Giá";
            }
            else
            {
                dtgvThietBi.DataSource = null;
            }
        }
        private void LoadKhachHang()
        {
            List<KhachHangDTO> list = KhachHangBUS.ListKH();
            dtgvKhachHang.DataSource = list;
            if (list.Count > 0)
            {
                dtgvKhachHang.Columns[0].HeaderText = "Mã Khách hàng";
                dtgvKhachHang.Columns[1].HeaderText = "Tên Khách hàng";
                dtgvKhachHang.Columns[2].HeaderText = "Địa chỉ";
                dtgvKhachHang.Columns[3].HeaderText = "Số điện thoại";
            }
            else
            {
                dtgvKhachHang.DataSource = null;
            }
        }
        
        private void btn_Xem_Click(object sender, EventArgs e)
        {
            LoadThietBi();
            ThietBiBUS bus = new ThietBiBUS();
            cb_LoaiTB.DataSource = bus.LoadLoaiTB();
        }

        private void btn_AddNewTB_Click(object sender, EventArgs e)
        {
            //check empty
            if (!CheckEmptyTB()) { MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo"); return; }
            // Thực hiện thêm thiết bị
            string matb = txt_Matb.Text;
            string tentb = txt_Tentb.Text;
            string loai = txt_Loai.Text;
            string soluong = txt_Loai.Text;
            string dongia = txt_Gia.Text;
            AddTB(matb, tentb, loai, soluong, dongia);
        }

        private void btn_AddCustomer_Click(object sender, EventArgs e)
        {
            //check empty
            if (!CheckEmptyKH()) { MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo"); return; }
            // Thực hiện thêm thiết bị
            string makh = txt_Makh.Text;
            string tenkh = txt_Tenkh.Text;
            string diachi = txt_Diachi.Text;
            string sdt = txt_sdt.Text;
            AddKH(makh,tenkh,diachi,sdt);
        }

        private void btn_LapHoaDon_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            this.Hide();
            hd.Show();
        }

        void AddTB(string matb, string tentb, string loai, string soluong, string dongia)
        {
            ThietBiBUS tb = new ThietBiBUS();
            if (tb.AddThietBi(matb, tentb, loai, soluong, dongia))
            {
                MessageBox.Show("Thêm thiết bị thành công!");
            }
            else
            {
                MessageBox.Show("Thêm thiết bị thât bại!");
            }
            LoadThietBi();
            cb_LoaiTB.DataSource = tb.LoadLoaiTB();
        }
        
        void AddKH(string makh, string tenkh, string diachi, string sdt)
        {
            KhachHangBUS kh = new KhachHangBUS();
            if(kh.AddKhachHang(makh,tenkh,diachi,sdt))
            {
                MessageBox.Show("Thêm Khách hàng thành công!");
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại!");
            }
            LoadKhachHang();
        }

        private bool CheckEmptyTB()
        {
            if (txt_Matb.Text == String.Empty) return false;
            if (txt_Tentb.Text == String.Empty) return false;
            if (txt_Loai.Text == String.Empty) return false;
            if (txt_Loai.Text == String.Empty) return false;
            if (txt_Gia.Text == String.Empty) return false;
            return true;
        }
        
        private bool CheckEmptyKH()
        {
            if (txt_Makh.Text == String.Empty) return false;
            if (txt_Tenkh.Text == String.Empty) return false;
            if (txt_sdt.Text == String.Empty) return false;
            if (txt_Diachi.Text == String.Empty) return false;
            return true;
        }

        private void btn_ViewKH_Click(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        void DelThietBi(ThietBiDTO tb)
        {
            ThietBiBUS bus = new ThietBiBUS();
            if (bus.DelThietBi(tb))
            {
                DialogResult re = MessageBox.Show("Bạn có muốn xóa thiết bị này không không?", "Thông báo", MessageBoxButtons.YesNo);
                if (re == DialogResult.Yes)
                {
                    MessageBox.Show("Xóa Thiết bị thành công");

                }
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
            LoadThietBi();

        }

        private void btn_XoaTB_Click(object sender, EventArgs e)
        {
            int index = dtgvThietBi.CurrentRow.Index;
            ThietBiDTO tb = (dtgvThietBi.DataSource as List<ThietBiDTO>)[index];
            DelThietBi(tb);
        }

        

        private void dtgvKhachHang_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có muốn lưu thông tin không?", "Thông báo", MessageBoxButtons.YesNo);
            if (re == DialogResult.Yes)
            {
                KhachHangDTO kh = (dtgvKhachHang.DataSource as List<KhachHangDTO>)[e.RowIndex];
                KhachHangBUS kh1 = new KhachHangBUS();
                if (kh1.EditKhachHang(kh) == false)
                {
                    MessageBox.Show("kết nối lỗi", "Thông báo");
                    LoadKhachHang();
                }
            }
            else
            {
                dtgvKhachHang[e.ColumnIndex, e.RowIndex].Value = beedit;
            }
        }

        private void dtgvThietBi_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có muốn lưu thông tin không?", "Thông báo", MessageBoxButtons.YesNo);
            if (re == DialogResult.Yes)
            {
                ThietBiDTO tb = (dtgvThietBi.DataSource as List<ThietBiDTO>)[e.RowIndex];
                ThietBiBUS bus = new ThietBiBUS();
                if (bus.FixThietbi(tb) == false)
                {
                    MessageBox.Show("kết nối lỗi", "Thông báo");
                    LoadKhachHang();
                }
            }
            else
            {
                dtgvThietBi[e.ColumnIndex, e.RowIndex].Value = beedit;
            }
        }

        private void cb_LoaiTB_SelectedValueChanged(object sender, EventArgs e)
        {
            dtgvThietBi.DataSource = ThietBiBUS.GetThietbiTheoLoai(cb_LoaiTB.SelectedValue.ToString());
        }
        /* ------------------------------HoaDon-------------------------------------------------------------*/
       
        private bool CheckEmptyHD()
        {
            if (txt_MaHD.Text == String.Empty) return false;
            if (txt_MaKHHD.Text == String.Empty) return false;
            if (txt_DiaChi1.Text == String.Empty) return false;
            if (txt_DiaChi1.Text == String.Empty) return false;
            if (txt_ThanhTien.Text == String.Empty) return false;
            //if (txt_NgayHD.Text == String.Empty) return false;
            return true;
        }
        void AddHD(string mahd, string makh, string diachigiao,int giaohang,float thanhtien, DateTime ngayhd)
        {
            HoaDonBUS hd = new HoaDonBUS();
            if (hd.AddHoaDon(mahd,makh,diachigiao,giaohang,thanhtien,ngayhd))
            {
                MessageBox.Show("Thêm hóa đơn thành công!");
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn thất bại!");
            }
            LoadHoaDon();
        }
        private void btnXemHD_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
        }
        private void dtgvHoaDon_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có muốn lưu thông tin không?", "Thông báo", MessageBoxButtons.YesNo);
            if (re == DialogResult.Yes)
            {
                HoaDonDTO hd = (dtgvHoaDon.DataSource as List<HoaDonDTO>)[e.RowIndex];
                HoaDonBUS bus = new HoaDonBUS();
                if (bus.FixHoaDon(hd) == false)
                {
                    MessageBox.Show("kết nối lỗi", "Thông báo");
                    LoadHoaDon();
                }
            }
            else
            {
                dtgvHoaDon[e.ColumnIndex, e.RowIndex].Value = beedit;
            }
        }
        void DelHoaDon(HoaDonDTO hd)
        {
            HoaDonBUS bus = new HoaDonBUS();
            if (bus.DelHoaDon(hd))
            {
                DialogResult re = MessageBox.Show("Bạn có muốn xóa thiết bị này không không?", "Thông báo", MessageBoxButtons.YesNo);
                if (re == DialogResult.Yes)
                {
                    MessageBox.Show("Xóa Thiết bị thành công");

                }
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
            LoadHoaDon();

        }


        private void btn_ThemHD_Click_1(object sender, EventArgs e)
        {
            //check empty
            if (!CheckEmptyHD()) { MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo"); return; }
            // Thực hiện thêm thiết bị
            string mahd = txt_MaHD.Text;
            string makh = txt_MaKHHD.Text;
            string diachigiao = txt_DiaChi1.Text;
            int giaohang = int.Parse(txt_GiaoHang.Text);
            float thanhtien = float.Parse(txt_ThanhTien.Text);
            DateTime ngayhd = DateTime.Now;
            //DateTime ngayhd = DateTime.ParseExact(txt_ThanhTien.Text, "yyyy-MM-dd HH:mm:ss,fff",
                                       //System.Globalization.CultureInfo.InvariantCulture);
            //DateTime ngayhd = ToLocalTime(txt_NgayHD.Text);
            AddHD(mahd, makh, diachigiao,giaohang,thanhtien, ngayhd);

        }

        private void btnXoaHD_Click_1(object sender, EventArgs e)
        {
            int index = dtgvHoaDon.CurrentRow.Index;
            HoaDonDTO hd = (dtgvHoaDon.DataSource as List<HoaDonDTO>)[index];
            DelHoaDon(hd);
        }
        private void LoadHoaDon()
        {
            List<HoaDonDTO> list = HoaDonBUS.ListHD();
            dtgvHoaDon.DataSource = list;
            if (list.Count > 0)
            {
                dtgvHoaDon.Columns[0].HeaderText = "Mã Hóa Đơn";
                dtgvHoaDon.Columns[1].HeaderText = "Mã Khách hàng";
                dtgvHoaDon.Columns[2].HeaderText = "Địa chỉ giao";
                dtgvHoaDon.Columns[3].HeaderText = "Giao Hàng";
                dtgvHoaDon.Columns[4].HeaderText = "Thành Tiền";
                dtgvHoaDon.Columns[5].HeaderText = "Ngày Hóa Đơn";

            }
            else
            {
                dtgvKhachHang.DataSource = null;
            }
        }
    }
    
}
