using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.UI;

namespace QuanLyBanHang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private DateTime dauLast, cuoiLast;
        private void BindGrid(List<casd> listcasd)
        {
            int tongCong = 0;
            dgvDonHang.Rows.Clear();

            foreach (var invoice in listcasd)
            {
                int index = dgvDonHang.Rows.Add();
                dgvDonHang.Rows[index].Cells[0].Value = index + 1;
                dgvDonHang.Rows[index].Cells[1].Value = invoice.InvoiceNo;
                dgvDonHang.Rows[index].Cells[2].Value = invoice.OrderDate.ToShortDateString();
                dgvDonHang.Rows[index].Cells[3].Value = invoice.DeliveryDate.ToShortDateString();

                // Tính tổng tiền cho từng hóa đơn dựa vào Orders
                decimal thanhTien = invoice.Orders.Sum(o => o.Price * o.Quantity);
                dgvDonHang.Rows[index].Cells[4].Value = thanhTien;

                tongCong += (int)thanhTien;
            }

            txtTongCong.Text = tongCong.ToString();
        }
        private void dtpDau_ValueChanged(object sender, EventArgs e)
        {
            if (dtpDau.Value > dtpCuoi.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.");
                dtpDau.Value = dtpCuoi.Value;
            }
            else
            {
                UpdateBang();
            }
        }

        private void cbXemAllThang_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dtpCuoi_ValueChanged(object sender, EventArgs e)
        {

            if (dtpDau.Value > dtpCuoi.Value)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.");
                dtpCuoi.Value = dtpDau.Value;
            }
            else
            {
                UpdateBang();
            }
        }
        private void UpdateBang()
        {
            using (var context = new QuanLyBanHangEntities())
            {
                var filteredcasd = context.casd
                    .Where(i => i.DeliveryDate >= dtpDau.Value && i.DeliveryDate <= dtpCuoi.Value)
                    .Include(i => i.Orders)  // Include các Order liên quan
                    .ToList();

                BindGrid(filteredcasd);
            }
        }

        private void dgvDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtTongCong_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtTongCong.Text = "0";
            dtpCuoi.Value = DateTime.Now;
            dtpDau.Value = DateTime.Now.AddYears(-1);  // Ví dụ: Lấy dữ liệu của 1 năm gần nhất

            using (var context = new QuanLyBanHangEntities())
            {
                var casd = context.casd.Include(i => i.Orders).ToList();
                BindGrid(casd);
            }
        }
    }
}
