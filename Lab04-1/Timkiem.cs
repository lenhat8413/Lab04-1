using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab04_1.Model;

namespace Lab04_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        StudentContextDB1 contextDB = new StudentContextDB1();
        List<Student> listStudent = new List<Student>();
        List<Faculty> listFaculty = new List<Faculty>();

        private void btnThemSua_Click(object sender, EventArgs e)
        {
          
        }

        private void Timkiem_Load(object sender, EventArgs e)
        {
            txtFindAnswer.Text = "0";

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

            // Đóng chương trình : Yes : Đóng , No: Không đóng
            DialogResult status = MessageBox.Show("Bạn có muốn thoát không?", "Thoát",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (status == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvTableSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listStudent = contextDB.Students.ToList();
            listFaculty = contextDB.Faculties.ToList();
            fillDGVStudent(listStudent);
        }

        private void fillDGVStudent(List<Student> listStudent)
        {
            // Clear existing rows
            dgvTableSV.Rows.Clear();

            // Loop through the student list to populate the DataGridView
            foreach (var student in listStudent)
            {
                int newRow = dgvTableSV.Rows.Add();
                dgvTableSV.Rows[newRow].Cells[0].Value = student.StudentID;
                dgvTableSV.Rows[newRow].Cells[1].Value = student.StudentName;
                dgvTableSV.Rows[newRow].Cells[2].Value = student.AverageScore;
                dgvTableSV.Rows[newRow].Cells[3].Value = student.Faculty.FacultyName;
            }
            txtFindAnswer.Text = listStudent.Count.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var studentDel = contextDB.Students.FirstOrDefault(sv => sv.StudentID == txtMSSV.Text.Trim());
            DialogResult status = MessageBox.Show($"Bạn có đồng ý xóa thông tin sinh viên ({txtHoten.Text}) không?", "thông báo",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (status == DialogResult.OK)
            {
                contextDB.Students.Remove(studentDel);
                contextDB.SaveChanges();
                List<Student> listStudent = contextDB.Students.ToList();
                fillDGVStudent(listStudent);
                MessageBox.Show($"Xoá sinh viên ({txtHoten.Text}) thành công!");
            }
        }

        private void txtFindAnswer_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbbChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin nhập vào từ các ô tìm kiếm
                string mssv = txtMSSV.Text.Trim();
                string hoTen = txtHoten.Text.Trim();
                string chuyenNganh = cbbChuyenNganh.SelectedItem?.ToString() ?? "";

                // Tìm kiếm theo các tiêu chí nhập vào
                var result = contextDB.Students
                    .Where(s =>
                        (string.IsNullOrEmpty(mssv) || s.StudentID.Contains(mssv)) &&
                        (string.IsNullOrEmpty(hoTen) || s.StudentName.Contains(hoTen)) &&
                        (string.IsNullOrEmpty(chuyenNganh) || s.Faculty.FacultyName.Contains(chuyenNganh))
                    ).ToList();
                // Cập nhật DataGridView với kết quả tìm kiếm
                fillDGVStudent(result);
                // Nếu không tìm thấy kết quả, hiển thị thông báo
                if (result.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sinh viên nào phù hợp!", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Cập nhật DataGridView với kết quả tìm kiếm
                fillDGVStudent(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
