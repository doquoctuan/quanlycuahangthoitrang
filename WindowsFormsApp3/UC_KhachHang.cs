using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class UC_KhachHang : UserControl
    {
        public UC_KhachHang()
        {
            InitializeComponent();
            LoadListKH();
        }

        public void LoadListKH()
        {
            DataTable dt = QuanLyKhachHang.Intance.getListKH();
            dgvKhachHang.DataSource = dt;
            loadBinding();
        }
           
        void loadBinding()
        {
            txtMaKH.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "MaKH", true, DataSourceUpdateMode.Never));
            txtTenKH.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "TenKH", true, DataSourceUpdateMode.Never));
            txtDienThoaiKH.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            txtEmailKH.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "Email", true, DataSourceUpdateMode.Never));
            rtbDiaChiKhachHang.DataBindings.Add(new Binding("Text", dgvKhachHang.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
        }

        void ClearBinding()
        {
            txtMaKH.DataBindings.Clear();
            txtTenKH.DataBindings.Clear();
            txtDienThoaiKH.DataBindings.Clear();
            txtEmailKH.DataBindings.Clear();
            rtbDiaChiKhachHang.DataBindings.Clear();
        }

        private void btnLamMoiKhachHang_Click(object sender, EventArgs e)
        {
            ClearBinding();
            LoadListKH();
        }
        public bool check = false;
        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            check = !check;
            if (check == true)
            {
                txtMaKH.Text = "";
                txtTenKH.Text = "";
                txtDienThoaiKH.Text = "";
                txtEmailKH.Text = "";
                rtbDiaChiKhachHang.Text = "";
                txtMaKH.Enabled = true;
                txtTenKH.Enabled = true;
                txtDienThoaiKH.Enabled = true;
                txtEmailKH.Enabled = true;
                rtbDiaChiKhachHang.Enabled = true;
                dgvKhachHang.Enabled = false;
                btnThemKhachHang.Text = "Xác nhận";
            }
            else
            {
                btnThemKhachHang.Text = "Thêm Mới";
                txtMaKH.Enabled = false;
                txtTenKH.Enabled = false;
                txtDienThoaiKH.Enabled = false;
                txtEmailKH.Enabled = false;
                rtbDiaChiKhachHang.Enabled = false;
                dgvKhachHang.Enabled = true;
                if (txtMaKH.Text == "")
                {
                    MessageBox.Show("Nhập thiếu thông tin! Vui lòng thử lại");
                }
                else
                {
                    if (QuanLyKhachHang.Intance.themKH(txtMaKH.Text, txtTenKH.Text, rtbDiaChiKhachHang.Text, txtDienThoaiKH.Text, txtEmailKH.Text))
                    {
                        MessageBox.Show("Thêm khách hàng thành công!", "Thông báo");
                        ClearBinding();
                        LoadListKH();
                    }
                    else MessageBox.Show("Thất bại!", "Thông báo");
                }
            }
        }

        private void btnSuaKhachHang_Click(object sender, EventArgs e)
        {
            check = !check;
            if (check == true)
            {
                txtTenKH.Enabled = true;
                txtDienThoaiKH.Enabled = true;
                txtEmailKH.Enabled = true;
                rtbDiaChiKhachHang.Enabled = true;
                btnThemKhachHang.Enabled = false;
            }
            else
            {
                txtMaKH.Enabled = false;
                txtTenKH.Enabled = false;
                txtDienThoaiKH.Enabled = false;
                txtEmailKH.Enabled = false;
                rtbDiaChiKhachHang.Enabled = false;
                if (QuanLyKhachHang.Intance.suaKH(txtMaKH.Text, txtTenKH.Text, rtbDiaChiKhachHang.Text, Convert.ToInt32(txtDienThoaiKH.Text), txtEmailKH.Text))
                {
                     MessageBox.Show("Sửa thành công!", "Thông báo");
                    btnThemKhachHang.Enabled = true;
                    ClearBinding();
                    LoadListKH();
                }
            }
        }

        private void btnXoaKhachHang_Click(object sender, EventArgs e)
        {
            if (QuanLyKhachHang.Intance.xoaKH(txtMaKH.Text))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo");
                ClearBinding();
                LoadListKH();
            }
        }

        private void txtTimKiemKhachHang_TextChanged(object sender, EventArgs e)
        {
            dgvKhachHang.DataSource = QuanLyKhachHang.Intance.TimKiemKH(txtTimKiemKhachHang.Text);
            ClearBinding();
            loadBinding();
        }
    }
}
