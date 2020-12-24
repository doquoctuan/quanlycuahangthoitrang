using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class UC_ThongKeHangHoa : UserControl
    {
        public static int check = 0;
        DateTimePicker ngayBD = new DateTimePicker();
        DateTimePicker ngayKT = new DateTimePicker();
        public UC_ThongKeHangHoa()
        {
            DateTime today = DateTime.Now;

            ngayBD.Value = new DateTime(today.Year, today.Month, 1);
            ngayBD.Location = new Point(142, 34);


            ngayKT.Value = ngayBD.Value.AddMonths(1).AddDays(-1);
            ngayKT.Location = new Point(630, 34);

            ngayBD.Format = DateTimePickerFormat.Short;
            ngayKT.Format = DateTimePickerFormat.Short;
            InitializeComponent();
            if (check == 1)
            {
                txtThongKe.Text = "THỐNG KÊ HÀNG HÓA";
                string query = "EXEC USP_GetSLTon";
                DataTable dt = new DataTable();
                dt = DataProvider.Instance.ExecuteQuery(query);
                dtThongKe.DataSource = dt;
            } else if (check == 2)
            {
                txtThongKe.Text = "THỐNG KÊ KHÁCH HÀNG";
                string query = "EXEC USP_TKKH";
                DataTable dt = new DataTable();
                dt = DataProvider.Instance.ExecuteQuery(query);
                dtThongKe.DataSource = dt;
            }
            else if (check == 3)
            {
                txtThongKe.Text = "THỐNG KÊ HÓA ĐƠN";
                txtThongKe.Location = new Point(386, 34);
             
                this.Controls.Add(ngayBD);
                this.Controls.Add(ngayKT);

                Button btnTKHD = new Button();
                btnTKHD.Location = new Point(874, 34);
                btnTKHD.Text = "Xem";
                btnTKHD.AutoSize = true;
                this.Controls.Add(btnTKHD);
                btnTKHD.Click += BtnTKHD_Click;
                loadDataTkHD();
            } else{
                txtThongKe.Text = "THỐNG KÊ PHIẾU NHẬP";
                txtThongKe.Location = new Point(365, 34);
                this.Controls.Add(ngayBD);
                this.Controls.Add(ngayKT);

                Button btnTKHD2 = new Button();
                btnTKHD2.Location = new Point(874, 34);
                btnTKHD2.Text = "Xem";
                btnTKHD2.AutoSize = true;
                this.Controls.Add(btnTKHD2);
                btnTKHD2.Click += BtnTKHD2_Click;
                loadDataTkPN();
            }
        }

        private void BtnTKHD2_Click(object sender, EventArgs e)
        {
            loadDataTkPN();
        }

        private void loadDataTkPN()
        {
            string query = "EXEC USP_TKPN @ngaybd , @ngaykt";
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery(query, new object[] { ngayBD.Value, ngayKT.Value });
            dtThongKe.DataSource = dt;
        }

        private void loadDataTkHD()
        {
            string query = "EXEC USP_TKHD @ngaybd , @ngaykt";
            DataTable dt = new DataTable();
            dt = DataProvider.Instance.ExecuteQuery(query, new object[] { ngayBD.Value, ngayKT.Value });
            dtThongKe.DataSource = dt;
        }

        private void BtnTKHD_Click(object sender, EventArgs e)
        {
            loadDataTkHD();
        }
    }
}
