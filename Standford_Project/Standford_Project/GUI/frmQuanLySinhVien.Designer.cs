namespace Standford_Project.GUI
{
    partial class frmQuanLySinhVien
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
            this.dtgvSinhVien = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbChuyenKhoa = new System.Windows.Forms.ComboBox();
            this.btnTImKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSinhVien)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvSinhVien
            // 
            this.dtgvSinhVien.AllowUserToAddRows = false;
            this.dtgvSinhVien.AllowUserToDeleteRows = false;
            this.dtgvSinhVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column1,
            this.Column2,
            this.Column4,
            this.Column6,
            this.Column7,
            this.Column5,
            this.Column8});
            this.dtgvSinhVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvSinhVien.Location = new System.Drawing.Point(0, 110);
            this.dtgvSinhVien.Margin = new System.Windows.Forms.Padding(4);
            this.dtgvSinhVien.Name = "dtgvSinhVien";
            this.dtgvSinhVien.ReadOnly = true;
            this.dtgvSinhVien.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dtgvSinhVien.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dtgvSinhVien.Size = new System.Drawing.Size(971, 354);
            this.dtgvSinhVien.TabIndex = 9;
            this.dtgvSinhVien.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvSinhVien_CellContentClick);
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Id";
            this.Column3.HeaderText = "Id";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaSV";
            this.Column1.HeaderText = "Mã sinh viên";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "HoTen";
            this.Column2.HeaderText = "Họ và tên";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 200;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "GioiTinh";
            this.Column4.HeaderText = "Giới tính";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "DienThoai";
            this.Column6.HeaderText = "Điện thoại";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Email";
            this.Column7.HeaderText = "Email";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ChuyenKhoa";
            this.Column5.HeaderText = "Chuyên khoa";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "DiaChi";
            this.Column8.HeaderText = "Địa chỉ";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbChuyenKhoa);
            this.groupBox1.Controls.Add(this.btnTImKiem);
            this.groupBox1.Controls.Add(this.txtTimKiem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(971, 110);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm thông tin chuyên khoa";
            // 
            // cbbChuyenKhoa
            // 
            this.cbbChuyenKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbChuyenKhoa.FormattingEnabled = true;
            this.cbbChuyenKhoa.Location = new System.Drawing.Point(424, 46);
            this.cbbChuyenKhoa.Margin = new System.Windows.Forms.Padding(4);
            this.cbbChuyenKhoa.Name = "cbbChuyenKhoa";
            this.cbbChuyenKhoa.Size = new System.Drawing.Size(228, 24);
            this.cbbChuyenKhoa.TabIndex = 2;
            // 
            // btnTImKiem
            // 
            this.btnTImKiem.Image = global::Standford_Project.Properties.Resources.search;
            this.btnTImKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTImKiem.Location = new System.Drawing.Point(681, 46);
            this.btnTImKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTImKiem.Name = "btnTImKiem";
            this.btnTImKiem.Size = new System.Drawing.Size(122, 24);
            this.btnTImKiem.TabIndex = 1;
            this.btnTImKiem.Text = "Tìm kiếm";
            this.btnTImKiem.UseVisualStyleBackColor = true;
            this.btnTImKiem.Click += new System.EventHandler(this.btnTImKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(16, 48);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(400, 22);
            this.txtTimKiem.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnThoat);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 464);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 90);
            this.panel1.TabIndex = 8;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = global::Standford_Project.Properties.Resources._103;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(519, 31);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(100, 28);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = global::Standford_Project.Properties.Resources.edit;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(627, 31);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 28);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = global::Standford_Project.Properties.Resources.cancel;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(843, 31);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(100, 28);
            this.btnThoat.TabIndex = 1;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = global::Standford_Project.Properties.Resources.cross;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(735, 31);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 28);
            this.btnXoa.TabIndex = 0;
            this.btnXoa.Text = "Xoá";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // frmQuanLySinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 554);
            this.Controls.Add(this.dtgvSinhVien);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQuanLySinhVien";
            this.Text = "Quản lý sinh viên";
            this.Load += new System.EventHandler(this.frmQuanLySinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSinhVien)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvSinhVien;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTImKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ComboBox cbbChuyenKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}