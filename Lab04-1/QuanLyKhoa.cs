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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab04_1
{
    public partial class QuanLyKhoa : Form
    {
        public QuanLyKhoa()
        {
            InitializeComponent();
        }
        StudentContextDB1 contextDB = new StudentContextDB1();
        List<Student> listStudent = new List<Student>();
        List<Faculty> listFaculty = new List<Faculty>();
  
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
        private void fillDGVFaculty(List<Faculty> listFaculty)
        {
            // Xóa các hàng hiện tại
            dgvTableKhoa.Rows.Clear();

            // Duyệt qua danh sách Faculty để thêm vào DataGridView
            foreach (Faculty faculty in listFaculty)
            {
                int newRow = dgvTableKhoa.Rows.Add();
                dgvTableKhoa.Rows[newRow].Cells[0].Value = faculty.FacultyID;
                dgvTableKhoa.Rows[newRow].Cells[1].Value = faculty.FacultyName;
                dgvTableKhoa.Rows[newRow].Cells[2].Value = faculty.TotalProfessor;
            }
        }
        private void QuanLyKhoa_Load(object sender, EventArgs e)
        {       
                listStudent = contextDB.Students.ToList();
                listFaculty = contextDB.Faculties.ToList();
                fillDGVFaculty(listFaculty);
          
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng đã nhập mã khoa hay chưa
                if (string.IsNullOrWhiteSpace(txtMaKhoa.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã khoa cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi mã khoa sang kiểu int
                int maKhoa = int.Parse(txtMaKhoa.Text);
                Faculty facultyToDelete = contextDB.Faculties.FirstOrDefault(f => f.FacultyID == maKhoa);

                if (facultyToDelete != null)
                {
                    // Xóa khoa khỏi cơ sở dữ liệu
                    contextDB.Faculties.Remove(facultyToDelete);
                    contextDB.SaveChanges();
                    MessageBox.Show("Xóa khoa thành công!");

                    // Tải lại dữ liệu lên DataGridView
                    listFaculty = contextDB.Faculties.ToList();
                    fillDGVFaculty(listFaculty);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khoa cần xóa!");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Mã khoa phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem người dùng có nhập đủ dữ liệu không
                if (string.IsNullOrWhiteSpace(txtTenKhoa.Text) ||
                    string.IsNullOrWhiteSpace(txtTongGS.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Chuyển đổi mã khoa từ string sang int
                int maKhoa = int.Parse(txtMaKhoa.Text);
                Faculty existingFaculty = contextDB.Faculties
                                                   .FirstOrDefault(f => f.FacultyID == maKhoa);

                if (existingFaculty == null) // Thêm mới
                {
                    Faculty newFaculty = new Faculty()
                    {
                        FacultyID = maKhoa,
                        FacultyName = txtTenKhoa.Text,
                        TotalProfessor = int.Parse(txtTongGS.Text)
                    };

                    contextDB.Faculties.Add(newFaculty);
                    MessageBox.Show("Thêm khoa thành công!");
                }
                else // Cập nhật thông tin khoa
                {
                    existingFaculty.FacultyName = txtTenKhoa.Text;
                    existingFaculty.TotalProfessor = int.Parse(txtTongGS.Text);
                    MessageBox.Show("Cập nhật thông tin khoa thành công!");
                }

                // Lưu thay đổi vào cơ sở dữ liệu
                contextDB.SaveChanges();

                // Tải lại dữ liệu lên DataGridView
                listFaculty = contextDB.Faculties.ToList();
                fillDGVFaculty(listFaculty);
            }
            catch (FormatException)
            {
                MessageBox.Show("Mã khoa và Tổng số GS phải là số nguyên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void dgvTableKhoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
