using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace WindowsFormsApp3
{
    public partial class UC_BanHang : UserControl
    {
        
        public UC_BanHang()
        {
            InitializeComponent();
            list = QuanLyHangHoa.Intance.getListSanPham();
            AutoCompleteStringCollection arrName = new AutoCompleteStringCollection();
            foreach (Models.HangHoa item in list)
            {
                arrName.Add(item.MaHang);
            }
            cbbMaHang.AutoCompleteCustomSource = arrName;
            cbbMaHang.DataSource = list;
            cbbMaHang.DisplayMember = "MaHang";
            cbbMaHang.ValueMember = "MaHang";

            List<Models.KhachHang> listKH = new List<Models.KhachHang>();
            DataTable data2 = QuanLyKhachHang.Intance.getListKH();
            foreach (DataRow item2 in data2.Rows)
            {
                Models.KhachHang kh = new Models.KhachHang(item2);
                listKH.Add(kh);
            }
            AutoCompleteStringCollection arrName2 = new AutoCompleteStringCollection();
            foreach (Models.KhachHang itemKH in listKH)
            {
               arrName2.Add(itemKH.SDT);
            }
            txtInPutNumberPhone.AutoCompleteCustomSource = arrName2;
            resetInfoProduct();
        }

        private void btnThemDVT_Click(object sender, EventArgs e)
        {
            Form_DVT tdvt = new Form_DVT();
            tdvt.ShowDialog();
        }
        List<Models.HangHoa> list;
 

        Models.KhachHang khachHang = new Models.KhachHang()
        {
            MaKH = null
        };
            
        public Models.KhachHang GetTenBySDT(string id)
        {
            Models.KhachHang item = new Models.KhachHang();

            string query = "select * from KhachHang where SDT ='" + id + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
            {
                item = new Models.KhachHang(data.Rows[0]);
            }
            return item;
        }

        int i;
        private void cbbMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaHang.SelectedIndex >= 0)
            {
                i = cbbMaHang.SelectedIndex;
                txtTenHang.Text = list[i].TenHang;
                txtDonViTinh.Text = list[i].DonVi;
                txtGia.Text = list[i].GiaBan.ToString();
            }
        }

        int tongTien = 0;

        private void btnThemMatHang_Click(object sender, EventArgs e)
        {
            if (cbbMaHang.SelectedIndex >= 0 && txtSoLuong.Value > 0)
            {
                bool check = false;
                foreach (ListViewItem item in lvSanPhamBan.Items)
                {
                    if (item.SubItems[0].Text == cbbMaHang.SelectedValue.ToString())
                    {
                        check = true;
                    }
                    if (check)
                    {
                        int temp = Int32.Parse(item.SubItems[2].Text) + Int32.Parse(txtSoLuong.Value.ToString());
                        item.SubItems[2].Text = temp.ToString();
                        item.SubItems[3].Text = (Int32.Parse(item.SubItems[2].Text)*Int32.Parse(txtGia.Text)).ToString();
                        break;
                    }
                }
                int gia = Int32.Parse(txtGia.Text) * Int32.Parse(txtSoLuong.Value.ToString());
                if (!check)
                {
                    string[] arr = new string[4];
                    arr[0] = cbbMaHang.SelectedValue.ToString();
                    arr[1] = txtTenHang.Text;
                    arr[2] = txtSoLuong.Value.ToString();
                    arr[3] = gia.ToString();
                    ListViewItem listViewItem = new ListViewItem(arr);
                    lvSanPhamBan.Items.Add(listViewItem);
                }
                tongTien += gia;
                lbTienBangSo.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", tongTien) + " VNĐ";
                lbTienBangChu.Text = ConvertMoney.Instance.So_chu(tongTien);
                resetInfoProduct();
            }
        }

        private void resetInfoProduct()
        {
            cbbMaHang.SelectedIndex = -1;
            txtTenHang.Text = "";
            txtSoLuong.Value = 1;
            txtDonViTinh.Text = "";
            txtGia.Text = "";
        }

        private void btnXoaMatHang_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < lvSanPhamBan.Items.Count; i++) //duyệt tất cả các item trong list
            {
                if (lvSanPhamBan.Items[i].Checked)//nếu item đó dc check
                {
                    string tien = lvSanPhamBan.Items[i].SubItems[3].Text.ToString();
                    tongTien -= Int32.Parse(tien);
                    lbTienBangSo.Text = string.Format(new CultureInfo("vi-VN"), "{0:#,##0.00}", tongTien) + " VNĐ";
                    lbTienBangChu.Text = ConvertMoney.Instance.So_chu(tongTien);
                    lvSanPhamBan.Items[i].Remove();//xóa item đó đi
                    i--;
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (lvSanPhamBan.Items.Count > 0)
            {
                Models.HoaDon hoaDon = new Models.HoaDon();
                hoaDon.MaHD = QuanLyHoaDon.Intance.LoadMaDHMoi();
                hoaDon.MaKH = khachHang.MaKH;
                DateTime oDate = DateTime.Now;
                hoaDon.NgayTao = oDate;
                hoaDon.TenDangNhap = "ADMIN";
                hoaDon.TongTien = tongTien;

                if (QuanLyHoaDon.Intance.LuuDonHang(hoaDon))
                {
                    Form_Report rp = new Form_Report(hoaDon.MaHD, ConvertMoney.Instance.So_chu(tongTien), txtTenKH.Text);
                    foreach (ListViewItem item in lvSanPhamBan.Items)
                    {
                        QuanLyCTHD.Intance.LuuDonHang(hoaDon.MaHD, item.SubItems[0].Text, Int32.Parse(item.SubItems[2].Text), Int32.Parse(item.SubItems[3].Text) / Int32.Parse(item.SubItems[2].Text));
                        string query = "update hanghoa set SoLuong = SoLuong - " + Int32.Parse(item.SubItems[2].Text) + "where MaHang ='" + item.SubItems[0].Text + "'";
                        DataProvider.Instance.ExecuteNonQuery(query);
                    }
                    lvSanPhamBan.Items.Clear();
                    lbTienBangSo.Text = "0 VNĐ";
                    lbTienBangChu.Text = "Không đồng";
                    txtInPutNumberPhone.Text = "";
                    khachHang.MaKH = null;
                    txtTenKH.Text = "UNKNOW NAME";
                    tongTien = 0;
                    rp.ShowDialog();
                }
            } else MessageBox.Show("Bạn chưa chọn sản phẩm nào!", "Thông báo");

        }

        private void txtInPutNumberPhone_TextChanged_1(object sender, EventArgs e)
        {
            khachHang = GetTenBySDT(txtInPutNumberPhone.Text);
            txtTenKH.Text = khachHang.TenKH;
            if (txtInPutNumberPhone.Text.Length == 10 && txtTenKH.Text == "")
            {
                txtTenKH.Text = "Không Tìm Thấy";
            }
        }

        private void btnThemMoiKH_Click(object sender, EventArgs e)
        {
            Form_ThemKH form = new Form_ThemKH(QuanLyKhachHang.Intance.loadMaKH(), txtInPutNumberPhone.Text, this);
            form.ShowDialog();
        }
    }
}
