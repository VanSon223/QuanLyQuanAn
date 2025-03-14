using CrystalDecisions.CrystalReports.Engine;
using QuanLyNhaHang.QLNHTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
           BillTableAdapter bill = new BillTableAdapter();
           DataTable dt = bill.GetData();
           ReportDocument inhoadon = new ReportDocument();
            inhoadon.Load("D:\\Nam hoc 2024 - 2025 HK1\\WinForm\\QuanLyNhaHang\\QuanLyNhaHang\\HoaDon.rpt");
            inhoadon.SetDataSource(dt);
            crystalReportViewer1.ReportSource = inhoadon;   
        }
    }
}
