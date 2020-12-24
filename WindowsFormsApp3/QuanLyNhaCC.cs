using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class QuanLyNhaCC
    {
        private static QuanLyNhaCC instance;

        public QuanLyNhaCC()
        {
        }

        public static QuanLyNhaCC Intance
        {
            get { if (instance == null) instance = new QuanLyNhaCC(); return instance; }
            set => instance = value;
        }

        public DataTable getListNCC()
        {
            string query = "select * from NhaCungCap";
            return DataProvider.Instance.ExecuteQuery(query);
        }
    }
}
