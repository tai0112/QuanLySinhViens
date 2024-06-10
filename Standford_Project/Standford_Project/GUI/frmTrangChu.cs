using Standford_Project.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Standford_Project
{
    public partial class frmTrangChu : Form
    {
        public int LoaiTK { get; set; }
        public frmTrangChu()
        {
            InitializeComponent();
        }

        private void menuItemMonHoc_Click(object sender, EventArgs e)
        {
            frmQuanLyMonHoc quanLyMonHoc = new frmQuanLyMonHoc();
            quanLyMonHoc.LoaiTK = LoaiTK;
            quanLyMonHoc.MdiParent = this;
            quanLyMonHoc.Show();
        }

        private void menuItemChuyenKhoa_Click(object sender, EventArgs e)
        {
            frmQuanLyChuyenKhoa chuyenKhoa = new frmQuanLyChuyenKhoa();
            chuyenKhoa.LoaiTK = LoaiTK;
            chuyenKhoa.MdiParent = this;
            chuyenKhoa.Show();
        }

        private void menuItemPhongThi_Click(object sender, EventArgs e)
        {
            frmQuanLyPhongHoc phongHoc = new frmQuanLyPhongHoc();
            phongHoc.LoaiTK = LoaiTK;
            phongHoc.MdiParent = this;
            phongHoc.Show();
        }

        private void menuItemQuanLySinhVien_Click(object sender, EventArgs e)
        {
            frmQuanLySinhVien quanLySinhVien = new frmQuanLySinhVien();
            quanLySinhVien.LoaiTK = LoaiTK;
            quanLySinhVien.MdiParent = this;
            quanLySinhVien.Show();
        }

        private void menuItemThemDiemThi_Click(object sender, EventArgs e)
        {
            frmThemDiemThi themDiemThi = new frmThemDiemThi();
            themDiemThi.LoaiTK = LoaiTK;
            themDiemThi.MdiParent = this;
            themDiemThi.Show();
        }

        private void menuItemTraCuu_Click(object sender, EventArgs e)
        {
            frmTraCuuDiemThi traCuu = new frmTraCuuDiemThi();
            traCuu.LoaiTK = LoaiTK;
            traCuu.MdiParent = this;
            traCuu.Show();
        }

        private void frmTrangChu_Load(object sender, EventArgs e)
        {
            if(LoaiTK != 1)
            {
                menuItemThemDiemThi.Visible = false;
            }
        }
    }
}
