using Lab04_04.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04_04
{
    public partial class QuanLyBanHang : Form
    {

        private DateTime dauLast, cuoiLast;

        public QuanLyBanHang()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtTongCong.Text = "0";
            dtpCuoi.Value = new DateTime(2024, 10, 31, 23, 0, 0);
            dtpDau.Value = new DateTime(2019, 10, 1, 1, 0, 0);
            dauLast = dtpDau.Value;
            cuoiLast = dtpCuoi.Value;
        }
      

        private void BindGrid(List<Invoice> listInvoice)
        {
            int tongcong = 0;
            dgvDonHang.Rows.Clear();
            foreach (var item in listInvoice)
            {
                int index = dgvDonHang.Rows.Add();
                dgvDonHang.Rows[index].Cells[0].Value = index + 1;
                dgvDonHang.Rows[index].Cells[1].Value = item.InvoiceNo;
                dgvDonHang.Rows[index].Cells[2].Value = item.OrderDate;
                dgvDonHang.Rows[index].Cells[3].Value = item.DeliveryDate;

                decimal ThanhTien = 0;
                foreach(var temp in new QuanLySanPhamDB().Orders.ToList())
                {
                    if (item.InvoiceNo == temp.InvoiceNo) ThanhTien += temp.Price * temp.Quantity;
                }

                dgvDonHang.Rows[index].Cells[4].Value = ThanhTien;

                tongcong += int.Parse(ThanhTien.ToString());
            }
            txtTongCong.Text = tongcong.ToString();
        }

        private void dtpDau_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDau.Value > dtpCuoi.Value)
            {
                MessageBox.Show("Dữ liệu không hợp lệ");
                dtpDau.Value = dtpCuoi.Value;
            }
            else
            {
                UpdateBang();
            }
        }

        private void dtpCuoi_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDau.Value > dtpCuoi.Value)
            {
                MessageBox.Show("Dữ liệu không hợp lệ");
                dtpCuoi.Value = dtpDau.Value;
            }
            else
            {
                UpdateBang();
            }
        }

        private void UpdateBang()
        {
            List<Invoice> list = new List<Invoice>();
            foreach (var temp in new QuanLySanPhamDB().Invoices.ToList())
            {
                if (temp.DeliveryDate.Date >= dtpDau.Value.Date && temp.DeliveryDate.Date <= dtpCuoi.Value.Date) list.Add(temp);
            }
            BindGrid(list);
        }

        private void dgvDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbXemAllThang_CheckedChanged(object sender, EventArgs e)
        {
            if (cbXemAllThang.Checked == true)
            {
                // Lấy tháng và năm từ hóa đơn đầu tiên trong cơ sở dữ liệu
                var firstInvoice = new QuanLySanPhamDB().Invoices.FirstOrDefault();
                if (firstInvoice != null)
                {
                    int year = firstInvoice.OrderDate.Year;
                    int month = firstInvoice.OrderDate.Month;

                    // Thiết lập dtpDau và dtpCuoi theo tháng và năm của hóa đơn
                    dtpDau.Value = new DateTime(year, month, 1);
                    dtpCuoi.Value = new DateTime(year, month, DateTime.DaysInMonth(year, month), 23, 59, 59);
                }
                else
                {
                    // Nếu không có hóa đơn nào, bạn có thể thiết lập ngày mặc định
                    dtpDau.Value = DateTime.Now;
                    dtpCuoi.Value = DateTime.Now;
                }
            }
            else
            {
                dtpDau.Value = dauLast;
                dtpCuoi.Value = cuoiLast;
            }
        }
    }
}
