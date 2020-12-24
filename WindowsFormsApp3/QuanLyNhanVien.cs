using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class QuanLyNhanVien
    {
        private static QuanLyNhanVien instance;

        public QuanLyNhanVien()
        {
        }

        public static QuanLyNhanVien Intance
        {
            get { if (instance == null) instance = new QuanLyNhanVien(); return instance; }
            set => instance = value;
        }

        public bool Login(string userName, string passWord)
        {
            string query = "SELECT * FROM NhanVien WHERE TenDangNhap = N'" + userName + "' AND MatKhau = N'" + passWord + "' ";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }

        public Models.NhanVien getNVByID(string id)
        {
            string query = "SELECT * FROM NhanVien WHERE TenDangNhap = N'" + id + "'";
            DataRow a = DataProvider.Instance.ExecuteQuery(query).Rows[0];
            return new Models.NhanVien(a);
        }

        public DataTable getListNV()
        {
            string query = "select * from NhanVien";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
