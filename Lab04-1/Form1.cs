using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Reflection;
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
        StudentContextDB contextDB = new StudentContextDB();
        List<Student> listStudent = new List<Student>();
        List<Faculty> listFaculty = new List<Faculty>();
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
        }
        private void LoadFacultyComboBox()
        {
            listFaculty = contextDB.Faculties.ToList();
            cbbChuyenNganh.DataSource = listFaculty;  // Assign the list of faculties
            cbbChuyenNganh.DisplayMember = "FacultyName";  // Display faculty name in the ComboBox
            cbbChuyenNganh.ValueMember = "FacultyID";  // Keep faculty ID as the value
        }
        private void cbbChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ensure the selected item is treated as a Faculty object
            var selectedFaculty = cbbChuyenNganh.SelectedItem as Faculty;

            if (selectedFaculty != null)
            {
                // Filter students by the selected faculty
                var filteredStudents = contextDB.Students
                    .Where(s => s.FacultyID == selectedFaculty.FacultyID)
                    .ToList();

                fillDGVStudent(filteredStudents);  // Display the filtered students
            }
        }

        private void txtMSSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHoten_TextChanged(object sender, EventArgs e)
        {

        }
        // LoadStudentData
        private void LoadStudentData()
        {
            listStudent = contextDB.Students.ToList();
            fillDGVStudent(listStudent);
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

        private void btnThemSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Mục Mssv bắt buộc nhập 5 kí tự , nếu không hiển thị thông báo nhập lại

                // Validate input fields
                if (string.IsNullOrWhiteSpace(txtMSSV.Text) ||
                    string.IsNullOrWhiteSpace(txtHoten.Text) ||
                    string.IsNullOrWhiteSpace(txtDTB.Text))
                {
                    throw new Exception("Vui lòng điền đầy đủ thông tin.");
                }
                if (txtMSSV.Text.Length != 5)
                {
                    MessageBox.Show("Mã số sinh viên phải có 5 ký tự!");
                    return;
                }


                // Validate average score input
                if (!float.TryParse(txtDTB.Text.Trim(), out float averageScore))
                {
                    throw new Exception("Điểm trung bình phải là số hợp lệ.");
                }

                // Validate if faculty is selected
                int facultyID = cbbChuyenNganh.SelectedIndex + 1;
                if (facultyID <= 0)
                {
                    throw new Exception("Vui lòng chọn khoa.");
                }

                // Check if student already exists
                var student = contextDB.Students
                    .FirstOrDefault(sv => sv.StudentID == txtMSSV.Text.Trim());

                if (student != null)
                {
                    // Update existing student
                    student.StudentName = txtHoten.Text.Trim();
                    student.AverageScore = averageScore;
                    student.FacultyID = facultyID;

                    MessageBox.Show("Cập nhật sinh viên thành công!");
                }
                else
                {
                    // Add new student
                    var newStudent = new Student
                    {
                        StudentID = txtMSSV.Text.Trim(),
                        StudentName = txtHoten.Text.Trim(),
                        AverageScore = averageScore,
                        FacultyID = facultyID
                    };

                    contextDB.Students.Add(newStudent);
                    MessageBox.Show("Thêm mới sinh viên thành công!");
                }

                // Save changes to the database
                contextDB.SaveChanges();

                // Reload the student list
                fillDGVStudent(contextDB.Students.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dgvTableSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            // Display a confirmation dialog
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // If the user clicks No, cancel the close operation
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
