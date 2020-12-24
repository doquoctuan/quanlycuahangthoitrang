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
    public partial class UC_NhaCungCap : UserControl
    {
        public UC_NhaCungCap()
        {
            InitializeComponent();
            LoadData();
        }
        void loadBinding()
        {
            txtMaNCC.DataBindings.Add(new Binding("Text", dgvNCC.DataSource, "MaNCC", true, DataSourceUpdateMode.Never));
            txtTenNCC.DataBindings.Add(new Binding("Text", dgvNCC.DataSource, "TenNCC", true, DataSourceUpdateMode.Never));
            txtEmailNCC.DataBindings.Add(new Binding("Text", dgvNCC.DataSource, "Email", true, DataSourceUpdateMode.Never));
            txtDienThoaiNCC.DataBindings.Add(new Binding("Text", dgvNCC.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            rtbDiaChiKhachNCC.DataBindings.Add(new Binding("Text", dgvNCC.DataSource, "DiaChi", true, DataSourceUpdateMode.Never));
        }
        void LoadData()
        {
            ClearBinding();
            dgvNCC.DataSource = QuanLyNhaCC.Intance.getListNCC();
            loadBinding();
        }

        void ClearBinding()
        {
            txtMaNCC.DataBindings.Clear();
            txtTenNCC.DataBindings.Clear();
            txtEmailNCC.DataBindings.Clear();
            txtDienThoaiNCC.DataBindings.Clear();
            rtbDiaChiKhachNCC.DataBindings.Clear();
        }
    }
}
