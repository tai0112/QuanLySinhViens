using Standford_Project.DAO;
using Standford_Project.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Standford_Project.GUI
{
    public partial class frmThemSinhVien : Form
    {
        public int Id { get; set; } = -1;
        public frmThemSinhVien()
        {
            InitializeComponent();
        }
        private void HienThiChuyenKhoa()
        {
            DataTable dtCK = DataProvider.ChuyenKhoaBus.LayDanhSach();
            DataRow root = dtCK.NewRow();
            root[0] = "";
            root[1] = "---Chọn chuyên khoa---";
            dtCK.Rows.InsertAt(root, 0);
            cbbChuyenKhoa.DataSource = dtCK;
            cbbChuyenKhoa.DisplayMember = "TenKhoa";
            cbbChuyenKhoa.ValueMember = "MaKhoa";
        }
        private void HienThiThongTin()
        {
            HienThiChuyenKhoa();
            SinhVien sv = DataProvider.SinhVienBus.HienThiChiTietSinhVien(Id);

            if(sv != null)
            {
                txtId.Text = "" + sv.Id;
                txtMaSV.Text = sv.MaSV;
                txtHoTen.Text = sv.HoTen;
                txtEmail.Text = sv.Email;
                txtDienThoai.Text = sv.DienThoai;
                if(sv.GioiTinh == 0)
                {
                    rdbNam.Checked = true;
                }else
                {
                    rdbNu.Checked = true;
                }
                txtDiaChi.Text = sv.DiaChi;
                cbbChuyenKhoa.SelectedValue = sv.ChuyenKhoaId;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            bool ketQua = false;
            string maSV = "", hoTen = "", dienThoai = "", email = "", chuyenNganh = "", diaChi = "";
            int gioiTinh;
            SinhVien sv = new SinhVien();
            diaChi = txtDiaChi.Text.Trim();
            maSV = txtMaSV.Text.Trim();
            hoTen = txtHoTen.Text.Trim();
            dienThoai = txtDienThoai.Text.Trim();
            email = txtEmail.Text.Trim();
            chuyenNganh = "" + cbbChuyenKhoa.SelectedValue;

            if (rdbNam.Checked == true)
            {
                gioiTinh = 0;
            }else
            {
                gioiTinh = 1;
            }

            if(string.IsNullOrEmpty(maSV))
            {
                MessageBox.Show("Bạn chưa nhập vào trường mã sinh viên !!!", "Thông báo");
                txtMaSV.Focus();
                return;
            }

            if(string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Bạn chưa nhập vào trường họ tên !!!", "Thông báo");
                txtHoTen.Focus();
                return;
            }

            if(string.IsNullOrEmpty(chuyenNganh))
            {
                MessageBox.Show("Bạn chưa chọn trường chuyên ngành !!!", "Thông báo");
                cbbChuyenKhoa.Focus();
                return;
            }

            if(rdbNam.Checked == false && rdbNu.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn trường giới tính cho sinh viên !!!", "Thông báo");
                return;
            }

            sv.Id = Id;
            sv.Email = email;
            sv.HoTen = hoTen;
            sv.DienThoai = dienThoai;
            sv.MaSV = maSV;
            sv.GioiTinh = gioiTinh;
            sv.ChuyenKhoaId = chuyenNganh;
            sv.DiaChi = diaChi;

            if(Id == -1)
            {
                ketQua = DataProvider.SinhVienBus.Them(sv);
            }else
            {
                ketQua = DataProvider.SinhVienBus.Sua(sv);
            }

            if(ketQua)
            {
                MessageBox.Show("Cập nhật thông tin thành công !!!", "Thông báo");
            }else
            {
                MessageBox.Show("Cập nhật thông tin không thành công !!!", "Thông báo");
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThemSinhVien_Load(object sender, EventArgs e)
        {
            HienThiThongTin();
        }
    }
}
