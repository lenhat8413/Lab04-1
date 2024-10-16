namespace Lab04_04
{
    partial class QuanLyBanHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpCuoi = new System.Windows.Forms.DateTimePicker();
            this.dtpDau = new System.Windows.Forms.DateTimePicker();
            this.cbXemAllThang = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.dgvDonHang = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDatHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaoHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTongCong = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpCuoi);
            this.groupBox1.Controls.Add(this.dtpDau);
            this.groupBox1.Controls.Add(this.cbXemAllThang);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 99);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Đơn Hàng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "~";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thời Gian Đặt Hàng";
            // 
            // dtpCuoi
            // 
            this.dtpCuoi.CustomFormat = "dd/MM/yyyy";
            this.dtpCuoi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCuoi.Location = new System.Drawing.Point(407, 59);
            this.dtpCuoi.Name = "dtpCuoi";
            this.dtpCuoi.Size = new System.Drawing.Size(200, 22);
            this.dtpCuoi.TabIndex = 1;
            this.dtpCuoi.Value = new System.DateTime(2019, 10, 31, 0, 0, 0, 0);
            this.dtpCuoi.ValueChanged += new System.EventHandler(this.dtpCuoi_ValueChanged);
            // 
            // dtpDau
            // 
            this.dtpDau.Checked = false;
            this.dtpDau.CustomFormat = "dd/MM/yyyy";
            this.dtpDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDau.Location = new System.Drawing.Point(164, 59);
            this.dtpDau.Name = "dtpDau";
            this.dtpDau.Size = new System.Drawing.Size(200, 22);
            this.dtpDau.TabIndex = 1;
            this.dtpDau.Value = new System.DateTime(2019, 10, 1, 0, 0, 0, 0);
            this.dtpDau.ValueChanged += new System.EventHandler(this.dtpDau_ValueChanged);
            // 
            // cbXemAllThang
            // 
            this.cbXemAllThang.AutoSize = true;
            this.cbXemAllThang.Location = new System.Drawing.Point(48, 27);
            this.cbXemAllThang.Name = "cbXemAllThang";
            this.cbXemAllThang.Size = new System.Drawing.Size(148, 19);
            this.cbXemAllThang.TabIndex = 0;
            this.cbXemAllThang.Text = "Xem tất cả trong tháng";
            this.cbXemAllThang.UseVisualStyleBackColor = true;
            this.cbXemAllThang.CheckedChanged += new System.EventHandler(this.cbXemAllThang_CheckedChanged);
            // 
            // dgvDonHang
            // 
            this.dgvDonHang.AllowUserToAddRows = false;
            this.dgvDonHang.AllowUserToDeleteRows = false;
            this.dgvDonHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.SoHD,
            this.NgayDatHang,
            this.NgayGiaoHang,
            this.ThanhTien});
            this.dgvDonHang.Location = new System.Drawing.Point(12, 113);
            this.dgvDonHang.Name = "dgvDonHang";
            this.dgvDonHang.ReadOnly = true;
            this.dgvDonHang.Size = new System.Drawing.Size(775, 230);
            this.dgvDonHang.TabIndex = 7;
            this.dgvDonHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDonHang_CellContentClick);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // SoHD
            // 
            this.SoHD.HeaderText = "Số HĐ";
            this.SoHD.Name = "SoHD";
            this.SoHD.ReadOnly = true;
            this.SoHD.Width = 200;
            // 
            // NgayDatHang
            // 
            this.NgayDatHang.HeaderText = "Ngày Đặt Hàng";
            this.NgayDatHang.Name = "NgayDatHang";
            this.NgayDatHang.ReadOnly = true;
            this.NgayDatHang.Width = 150;
            // 
            // NgayGiaoHang
            // 
            this.NgayGiaoHang.FillWeight = 150F;
            this.NgayGiaoHang.HeaderText = "Ngay Giao Hàng";
            this.NgayGiaoHang.Name = "NgayGiaoHang";
            this.NgayGiaoHang.ReadOnly = true;
            this.NgayGiaoHang.Width = 150;
            // 
            // ThanhTien
            // 
            this.ThanhTien.HeaderText = "Thành Tiền";
            this.ThanhTien.Name = "ThanhTien";
            this.ThanhTien.ReadOnly = true;
            this.ThanhTien.Width = 130;
            // 
            // txtTongCong
            // 
            this.txtTongCong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong.Location = new System.Drawing.Point(687, 349);
            this.txtTongCong.Name = "txtTongCong";
            this.txtTongCong.ReadOnly = true;
            this.txtTongCong.Size = new System.Drawing.Size(100, 22);
            this.txtTongCong.TabIndex = 9;
            this.txtTongCong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(609, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tổng Cộng:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 377);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDonHang);
            this.Controls.Add(this.txtTongCong);
            this.Controls.Add(this.label3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpCuoi;
        private System.Windows.Forms.DateTimePicker dtpDau;
        private System.Windows.Forms.CheckBox cbXemAllThang;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView dgvDonHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDatHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaoHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThanhTien;
        private System.Windows.Forms.TextBox txtTongCong;
        private System.Windows.Forms.Label label3;
    }
}

