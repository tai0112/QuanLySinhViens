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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            bool ketQua = false;
            string tenDangNhap = "", matKhau = "";
            TaiKhoan tk = new TaiKhoan();
            matKhau = txtMatKhau.Text;
            tenDangNhap = txtTenDangNhap.Text;

            if(string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Bạn chưa nhập vào tên đăng nhập !!!", "Thông báo");
                txtTenDangNhap.Focus();
                return;
            }

            if(string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Bạn chưa nhập vào mật khẩu !!!", "Thông báo");
                txtMatKhau.Focus();
                return;
            }

            tk.TenDangNhap = tenDangNhap;
            tk.MatKhau = matKhau;

            ketQua = DataProvider.TaiKhoanBus.KiemTra(tk);
            if(ketQua)
            {
                MessageBox.Show("Đăng nhập thành công !!!", "Thông báo");
                tk = DataProvider.TaiKhoanBus.HienThiChiTietTaiKhoan(tenDangNhap);
                frmTrangChu trangChu = new frmTrangChu();
                trangChu.LoaiTK = tk.LoaiTK;
                trangChu.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại vui lòng kiểm tra lại thông tin đăng nhập !!!", "Thông báo");
                return;
            }
        }

        private void cbHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if(cbHienMK.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTaoTK taoTK = new frmTaoTK();
            taoTK.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
