using Standford_Project.DAO;
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
    public partial class frmQuanLySinhVien : Form
    {
        public int MaSV { get; set; } = -1;
        public bool ThemDiem { get; set; } = false;   
        public frmQuanLySinhVien()
        {
            InitializeComponent();
        }
        public void An()
        {
            btnSua.Visible = false;
            btnThem.Visible = false;
            btnXoa.Visible = false;
        }
        private void LayDanhSachChuyenKhoa()
        {
            DataTable ck = DataProvider.ChuyenKhoaBus.LayDanhSach();
            DataRow root = ck.NewRow();
            root[0] = "";
            root[1] = "---Chuyên khoa---";
            ck.Rows.InsertAt(root, 0);
            cbbChuyenKhoa.DisplayMember = "TenKhoa";
            cbbChuyenKhoa.ValueMember = "MaKhoa";
            cbbChuyenKhoa.DataSource = ck;

            if(frmTrangChu.LoaiTK != 1)
            {
                An();
            }
        }

        private void HienThiThongTinSinhVien()
        {
            string data = "", chuyenKhoa = "";
            chuyenKhoa = "" + cbbChuyenKhoa.SelectedValue;
            data = txtTimKiem.Text.Trim();
            dtgvSinhVien.DataSource = DataProvider.SinhVienBus.TimKiemSinhVien(data, chuyenKhoa);
        }

        private void frmQuanLySinhVien_Load(object sender, EventArgs e)
        {
            LayDanhSachChuyenKhoa();    
            HienThiThongTinSinhVien();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemSinhVien themSinhVien = new frmThemSinhVien();
            themSinhVien.ShowDialog();
            HienThiThongTinSinhVien();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmThemSinhVien quanLySinhVien = new frmThemSinhVien();
            quanLySinhVien.Id = int.Parse("" + dtgvSinhVien.CurrentRow.Cells[0].Value);
            quanLySinhVien.ShowDialog();
            HienThiThongTinSinhVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int id = int.Parse("" + dtgvSinhVien.CurrentRow.Cells[0].Value);
            string maSinhVien = "" + dtgvSinhVien.CurrentRow.Cells[1].Value;
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xoá sinh viên mã {maSinhVien} không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                bool ketQua = DataProvider.SinhVienBus.Xoa(id);

                if (ketQua)
                {
                    MessageBox.Show($"Đã xoá thành sinh viên có mã {maSinhVien} !!!", "Thông báo");
                }
            }
            HienThiThongTinSinhVien();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTImKiem_Click(object sender, EventArgs e)
        {
            HienThiThongTinSinhVien();
        }

        private void dtgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(ThemDiem == true)
            {
                frmThemDiemThi.MaSV = int.Parse("" + dtgvSinhVien.CurrentRow.Cells[0].Value);
            }
        }
    }
}
