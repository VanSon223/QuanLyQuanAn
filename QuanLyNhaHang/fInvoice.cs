using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using QuanLyNhaHang.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;

using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class fInvoice : Form
    {

        public fInvoice()
        {
            InitializeComponent();
        }

        public void SetInvoiceData(ListView lsvBill, int orderID, string tableName, string customerPhone, decimal totalAmount, DateTime invoiceDate)
        {
            CultureInfo vietnamCulture = CultureInfo.CreateSpecificCulture("vi-VN");
            // Hiển thị thông tin lên các label
            lblOrderID.Text = "Mã Order:" + orderID;
            lblTableName.Text = "Bàn: " + tableName;
            lblCustomerPhone.Text = "SĐT: " + customerPhone;
            lblInvoiceDate.Text = "Ngày: " + invoiceDate.ToString("dd/MM/yyyy HH:mm:ss");
            // Thêm các mục từ ListView lvBill vào ListView trong fInvoice
            foreach (ListViewItem item in lsvBill.Items)
            {
                ListViewItem newItem = new ListViewItem(item.SubItems[0].Text);  // Tên món ăn
                newItem.SubItems.Add(item.SubItems[1].Text);  // Số lượng
                newItem.SubItems.Add(item.SubItems[2].Text);  // Giá tiền
                decimal itemTotalPrice = decimal.Parse(item.SubItems[3].Text); // Thành tiền (giá trị từ lvBill)
                newItem.SubItems.Add(itemTotalPrice.ToString("C0", vietnamCulture));
                lvInvoiceItems.Items.Add(newItem);
            }
            lblTotalAmount.Text = "Tổng tiền: " + totalAmount.ToString("C0", vietnamCulture);
        }


    }

}
