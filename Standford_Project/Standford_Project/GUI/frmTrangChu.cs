using Standford_Project.GUI;
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

namespace Standford_Project
{
    public partial class frmTrangChu : Form
    {
        public static int LoaiTK { get; set; }
        public static string HoTen { get; set; } = "";
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void KiemTraDangNhap()
        {

        }

        private void DangNhapHeThong()
        {
            frmDangNhap dangNhap = new frmDangNhap();
            dangNhap.ShowDialog();
        }

        private void menuItemMonHoc_Click(object sender, EventArgs e)
        {
            frmQuanLyMonHoc quanLyMonHoc = new frmQuanLyMonHoc();
            quanLyMonHoc.MdiParent = this;
            quanLyMonHoc.Show();
        }

        private void menuItemChuyenKhoa_Click(object sender, EventArgs e)
        {
            frmQuanLyChuyenKhoa chuyenKhoa = new frmQuanLyChuyenKhoa();
            chuyenKhoa.MdiParent = this;
            chuyenKhoa.Show();
        }

        private void menuItemPhongThi_Click(object sender, EventArgs e)
        {
            frmQuanLyPhongHoc phongHoc = new frmQuanLyPhongHoc();
            phongHoc.MdiParent = this;
            phongHoc.Show();
        }

        private void menuItemQuanLySinhVien_Click(object sender, EventArgs e)
        {
            frmQuanLySinhVien quanLySinhVien = new frmQuanLySinhVien();
            quanLySinhVien.MdiParent = this;
            quanLySinhVien.Show();
        }

        private void menuItemThemDiemThi_Click(object sender, EventArgs e)
        {
            frmThemDiemThi themDiemThi = new frmThemDiemThi();
            themDiemThi.MdiParent = this;
            themDiemThi.Show();
        }

        private void menuItemTraCuu_Click(object sender, EventArgs e)
        {
            frmTraCuuDiemThi traCuu = new frmTraCuuDiemThi();
            traCuu.MdiParent = this;
            traCuu.Show();
        }

        private void KiemTraDangNhap(bool isLogin)
        {
            menuNghiepVu.Enabled = isLogin;
            menuDanhMuc.Enabled = isLogin;
            menuBaoCao.Enabled = isLogin;
            menuTroGiup.Enabled = isLogin;
            menuItemDangNhap.Visible = !isLogin;
            tsmenuDangXuat.Visible = isLogin;
            if(isLogin)
            {
                lblTrangThaiDangNhap.Text = "Đang đăng nhập";
            }else
            {
                lblTrangThaiDangNhap.Text = "Chưa đăng nhập";
            }
        }
        private void PhanQuyen(bool isAdmin)
        {
            menuItemQltk.Visible = isAdmin;
            menuItemThemDiemThi.Visible = isAdmin;
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            DangNhapHeThong();
            PhanQuyen(LoaiTK == 1);
            KiemTraDangNhap(frmDangNhap.isLogin);
        }

        private void tsmenuDangXuat_Click(object sender, EventArgs e)
        {
            frmDangNhap.isLogin = false;
            DangNhapHeThong();
            KiemTraDangNhap(frmDangNhap.isLogin);
        }

        private void menuItemDangNhap_Click(object sender, EventArgs e)
        {
            DangNhapHeThong();
        }

        private void menuItemQltk_Click(object sender, EventArgs e)
        {
            frmQuanLyTaiKhoan qltk = new frmQuanLyTaiKhoan();
            qltk.MdiParent = this;
            qltk.Show();
        }
    }
}
