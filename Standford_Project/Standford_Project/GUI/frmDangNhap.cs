using Standford_Project.DAO;
using Standford_Project.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Standford_Project.GUI
{
    public partial class frmDangNhap : Form
    {
        static string hash { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        public static bool isLogin { get; set; } = false;
        public static int loaiTK { get; set; }
        public frmDangNhap()
        {
            InitializeComponent();
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            bool ketQua = false;
            string tenDangNhap = "", matKhau = "";
            TaiKhoan tk = new TaiKhoan();
            matKhau = DataProvider.MD5Hash(txtMatKhau.Text);
            tenDangNhap = txtTenDangNhap.Text;

            if (string.IsNullOrEmpty(tenDangNhap))
            {
                MessageBox.Show("Bạn chưa nhập vào tên đăng nhập !!!", "Thông báo");
                txtTenDangNhap.Focus();
                return;
            }

            if (string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Bạn chưa nhập vào mật khẩu !!!", "Thông báo");
                txtMatKhau.Focus();
                return;
            }

            tk.TenDangNhap = tenDangNhap;
            tk.MatKhau = matKhau;
            tk.HoTen = "";
            ketQua = DataProvider.TaiKhoanBus.KiemTra(tk);
            if (ketQua)
            {
                MessageBox.Show("Đăng nhập thành công !!!", "Thông báo");
                tk = DataProvider.TaiKhoanBus.HienThiChiTietTaiKhoan(tenDangNhap);
                frmTrangChu.LoaiTK = tk.LoaiTK;
                frmTrangChu.HoTen = tk.HoTen;
                isLogin = true;
                this.Hide();
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại vui lòng kiểm tra lại thông tin đăng nhập !!!", "Thông báo");
                return;
            }
        }
    }
}
