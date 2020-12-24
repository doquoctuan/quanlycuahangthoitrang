using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class QuanLyCTHD
    {
        private static QuanLyCTHD instance;

        public QuanLyCTHD()
        {
        }

        public static QuanLyCTHD Intance
        {
            get { if (instance == null) instance = new QuanLyCTHD(); return instance; }
            set => instance = value;
        }

        public bool LuuDonHang(string madh, string masp, int sl, int gia)
        {

            string query = String.Format("insert into ChiTietHD values('{0}','{1}','{2}','{3}')", madh, masp, sl, gia);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
