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
    public partial class frmTaoTK : Form
    {
        public frmTaoTK()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = "", matKhau = "", nhapLai = "", hoTen = "";
            bool ketQua = false;
            hoTen = txtChuTaiKhoan.Text.Trim();
            taiKhoan = txtTenDangNhap.Text.Trim();
            matKhau = DataProvider.MD5Hash(txtMatKhau.Text.Trim());
            nhapLai = DataProvider.MD5Hash(txtNhapLaiMK.Text.Trim());

            if(string.IsNullOrEmpty(taiKhoan))
            {
                MessageBox.Show("Chưa nhập vào tên đăng nhập !!!", "Thông báo");
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Chưa nhập vào mật khẩu !!!", "Thông báo");
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrEmpty(nhapLai))
            {
                MessageBox.Show("Chưa nhập lại mật khẩu !!!", "Thông báo");
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrEmpty(hoTen))
            {
                MessageBox.Show("Chưa nhập họ tên chủ tài khoản !!!", "Thông báo");
                txtChuTaiKhoan.Focus();
                return;
            }

            bool check = DataProvider.TaiKhoanBus.KiemTra(null, taiKhoan);
            if(check)
            {
                MessageBox.Show("Tên đăng nhập đã được sử dụng vui lòng thử lại tên đăng nhập khác ", "Thông báo");
                txtTenDangNhap.Clear();
                txtTenDangNhap.Focus();
                return;
            }
            TaiKhoan tk = new TaiKhoan();
            tk.TenDangNhap = taiKhoan;
            tk.MatKhau = matKhau;
            tk.HoTen = hoTen;
            ketQua = DataProvider.TaiKhoanBus.Them(tk);
            if(ketQua)
            {
                MessageBox.Show("Tạo tài khoản thành công", "Thông báo");
            }
            this.Close();
        }
    }
}
