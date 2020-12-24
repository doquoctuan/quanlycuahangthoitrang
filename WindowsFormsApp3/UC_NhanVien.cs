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
    public partial class UC_NhanVien : UserControl
    {
        public UC_NhanVien()
        {
            InitializeComponent();
            LoadData();
        }

        void loadBinding()
        {
            txtTaiKhoanNV.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "TenDangNhap", true, DataSourceUpdateMode.Never));
            txtTenNV.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "TenNguoiDung", true, DataSourceUpdateMode.Never));
            txtMatKhauNV.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "MatKhau", true, DataSourceUpdateMode.Never));
            txtChucVu.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "Quyen", true, DataSourceUpdateMode.Never));
        }
        void LoadData()
        {
            ClearBinding();
            dgvNhanVien.DataSource = QuanLyNhanVien.Intance.getListNV();
            loadBinding();
        }

        void ClearBinding()
        {
            txtTaiKhoanNV.DataBindings.Clear();
            txtTenNV.DataBindings.Clear();
            txtMatKhauNV.DataBindings.Clear();
            txtChucVu.DataBindings.Clear();
        }
    }
}
