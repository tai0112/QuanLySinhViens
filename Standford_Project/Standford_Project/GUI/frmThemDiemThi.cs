using Standford_Project.DAO;
using Standford_Project.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Standford_Project.GUI
{
    public partial class frmThemDiemThi : Form
    {
        public static int MaSV { get; set; } = -1;
        public static int IdMonHoc { get; set; } = -1;
        public static bool Sua = false;
        public frmThemDiemThi()
        {
            InitializeComponent();
        }

        private void HienThiCB()
        {
            DataTable monHoc = DataProvider.MonHocBus.LayDanhSach();
            DataTable phongThi = DataProvider.PhongHocBus.LayDanhSach();

            cbbMonHoc.DataSource = monHoc;
            cbbMonHoc.DisplayMember = "TenMH";
            cbbMonHoc.ValueMember = "Id";

            cbbPhongThi.DataSource = phongThi;
            cbbPhongThi.DisplayMember = "TenPhong";
            cbbPhongThi.ValueMember = "Id";
        }
        private void HienThiThongTin()
        {
            if(IdMonHoc != -1)
            {
                DiemThi dt = DataProvider.DiemThiBus.LayChiTietTheoId(MaSV, IdMonHoc);
                cbbMonHoc.SelectedValue = dt.MonHocId;
                cbbPhongThi.SelectedValue = dt.PhongHocId;
                txtDiemThi.Text = "" + dt.Diem;
            }
            if (MaSV != -1)
            {
                SinhVien sv = DataProvider.SinhVienBus.HienThiChiTietSinhVien(MaSV);
                txtTenSV.Text = sv.HoTen;
                txtMaSV.Text = sv.MaSV;
                Debug.WriteLine("Id môn học: " + IdMonHoc);
            }
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            frmQuanLySinhVien quanLySinhVien = new frmQuanLySinhVien();
            quanLySinhVien.ThemDiem = true;
            quanLySinhVien.ShowDialog();
            HienThiThongTin();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            MaSV = -1;
            IdMonHoc = -1;
            txtDiemThi.Text = "";
            txtTenSV.Text = "";
            txtMaSV.Text = "";
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMaSV.Text.Trim()))
            {
                MessageBox.Show("Chưa có mã sinh viên", "Thông báo");
                return;
            }

            if(string.IsNullOrEmpty(txtTenSV.Text.Trim()))
            {
                MessageBox.Show("Chưa có họ tên sinh viên", "Thông báo");
                return;
            }

            string hoTen = "";
            int id, idMonHoc, idPhongThi;
            double diemSo = 0;
            DateTime ngayThi;
            ngayThi = dtpNgayThi.Value;
            hoTen = txtTenSV.Text.Trim();
            id = MaSV;
            idMonHoc = int.Parse("" + cbbMonHoc.SelectedValue);
            idPhongThi = int.Parse("" + cbbPhongThi.SelectedValue);
            diemSo = double.Parse(txtDiemThi.Text.Trim());
            DiemThi dt = new DiemThi(id, idMonHoc, ngayThi, diemSo, idPhongThi);
            bool ketQua = false;
            if (Sua)
            {
                Debug.WriteLine("a");
                ketQua = DataProvider.DiemThiBus.CapNhat(dt);
            }
            else
            {
                ketQua = DataProvider.DiemThiBus.ThemMoi(dt);
            }
            if(ketQua)
            {
                MessageBox.Show("Thêm thành công điểm cho sinh viên", "Thông báo");
            }else
            {
                MessageBox.Show("Cập nhật sinh viên không thành công", "Thông báo");
            }
            
        }

        private void frmThemDiemThi_Load(object sender, EventArgs e)
        {
            HienThiCB();
            HienThiThongTin();
        }
    }
}
