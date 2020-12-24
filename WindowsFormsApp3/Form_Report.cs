using Microsoft.Reporting.WinForms;
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
    public partial class Form_Report : Form
    {
        private string maHD;
        private string Tien;
        private string TenKH;
        public Form_Report(string maHD, string Tien, string TenKH)
        {
            this.maHD = maHD;
            this.Tien = Tien;
            this.TenKH = TenKH;
            InitializeComponent();
        }

        private void Form_Report_Load(object sender, EventArgs e)
        {
            this.uSP_GetHoaDonTableAdapter.Fill(this.quanLyCuaHangThoiTrangDataSet1.USP_GetHoaDon, maHD);
            ReportParameter[] rptParams = new ReportParameter[]
            {
                new ReportParameter("TienBangChu", Tien),
                new ReportParameter("TenKH", TenKH)
            };
            this.reportViewer1.LocalReport.SetParameters(rptParams);
            this.reportViewer1.RefreshReport();
        }
    }
}
