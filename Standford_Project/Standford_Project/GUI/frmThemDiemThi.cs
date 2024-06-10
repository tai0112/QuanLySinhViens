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
    public partial class frmThemDiemThi : Form
    {
        public int LoaiTK { get; set; }
        public int MaSV { get; set; } = -1;
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
            cbbMonHoc.ValueMember = "MaMH";

            cbbPhongThi.DataSource = phongThi;
            cbbPhongThi.DisplayMember = "TenPhong";
            cbbPhongThi.ValueMember = "Id";
        }
        private void HienThiThongTin()
        {
            if(MaSV != -1)
            {
                DiemThi sv = DataProvider.DiemThiBus.TimKiem(MaSV);
                cbbMonHoc.SelectedValue = sv.MonHocId;
                
            }
        }

        private void btnSinhVien_Click(object sender, EventArgs e)
        {
            frmQuanLySinhVien quanLySinhVien = new frmQuanLySinhVien();
            quanLySinhVien.LoaiTK = 0;
            quanLySinhVien.ThemDiem = true;
            quanLySinhVien.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

        }

        private void frmThemDiemThi_Load(object sender, EventArgs e)
        {
            HienThiThongTin();
            HienThiCB();
        }
    }
}
