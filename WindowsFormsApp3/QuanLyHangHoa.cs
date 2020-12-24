using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class QuanLyHangHoa
    {
        private static QuanLyHangHoa instance;

        public QuanLyHangHoa()
        {
        }

        public static QuanLyHangHoa Intance
        {
            get { if (instance == null) instance = new QuanLyHangHoa(); return instance; }
            set => instance = value;
        }

        public List<Models.HangHoa> getListSanPham()
        {
            List<Models.HangHoa> list = new List<Models.HangHoa>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from HangHoa");
            foreach (DataRow item in data.Rows)
            {
                Models.HangHoa hangHoa = new Models.HangHoa(item);
                list.Add(hangHoa);
            }
            return list;
        }
    }
}
