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
    public partial class UC_ThongKe : UserControl
    {
        public UC_ThongKe()
        {
            InitializeComponent();
            loadDatePicker();
            fillChart();
        }

        private void loadDatePicker()
        {
            DateTime today = DateTime.Now;
            ngayBD.Value = new DateTime(today.Year, today.Month, 1);
            toDate.Value = ngayBD.Value.AddMonths(1).AddDays(-1);
        }

        private void fillChart()
        {
            chartThongKeHD.Titles.Clear();
            string query = "EXEC USP_ThongKe7Ngay @ngaybd , @ngaykt";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] {ngayBD.Value, toDate.Value});
            chartThongKeHD.DataSource = data;
            chartThongKeHD.Series["Doanh Thu"].XValueMember = "NGAY";
            chartThongKeHD.Series["Doanh Thu"].YValueMembers = "TONGTIEN";
            chartThongKeHD.Titles.Add("THỐNG KÊ DOANH THU");
        }

        private void UC_ThongKe_Load(object sender, EventArgs e)
        {
         //   fillChart();
        }
        private void addControlsToPanel1(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls1.Controls.Clear();
            panelControls1.Controls.Add(c);
        }

        private void btnTKHangHoa_Click(object sender, EventArgs e)
        {
            UC_ThongKeHangHoa.check = 1;
            UC_ThongKeHangHoa nv = new UC_ThongKeHangHoa();
            addControlsToPanel1(nv);
        }

        private void btnTKPhieuNhap_Click(object sender, EventArgs e)
        {
            UC_ThongKeHangHoa.check = 2;
            UC_ThongKeHangHoa nv = new UC_ThongKeHangHoa();
            addControlsToPanel1(nv);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            fillChart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Thong Ke Hoa Don
            UC_ThongKeHangHoa.check = 3;
            UC_ThongKeHangHoa nv = new UC_ThongKeHangHoa();
            addControlsToPanel1(nv);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UC_ThongKeHangHoa.check = 4;
            UC_ThongKeHangHoa nv = new UC_ThongKeHangHoa();
            addControlsToPanel1(nv);
        }
    }
}
