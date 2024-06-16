using Standford_Project.DAO;
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
    public partial class frmTraCuuDiemThi : Form
    {
        public frmTraCuuDiemThi()
        {
            InitializeComponent();
        }

        public void An()
        {
            btnSua.Visible = false;
            btnThem.Visible = false;
            btnXoa.Visible = false;
        }

        public void HienThi()
        {
            dtgvDiemThi.DataSource = DataProvider.DiemThiBus.LayDanhSach();
        }

        private void HienThiDiemThi()
        {
            string data = "", chuyenKhoa = "", monThi = "";
            data = txtTimKiem.Text.Trim();
            monThi = "" + cbbMonHoc.SelectedValue;
            chuyenKhoa = "" + cbbChuyenKhoa.SelectedValue;
            DataTable dt = DataProvider.DiemThiBus.TimKiem(data, chuyenKhoa, monThi);
            dtgvDiemThi.DataSource = dt;

            if(frmTrangChu.LoaiTK != 1)
            {
                An();
            }
        }
        private void HienThiChuyenKhoa()
        {
            DataTable ck = DataProvider.ChuyenKhoaBus.LayDanhSach();
            DataRow root = ck.NewRow();
            root[0] = "";
            root[1] = "---Chuyên khoa---";
            ck.Rows.InsertAt(root, 0);
            cbbChuyenKhoa.DataSource = ck;
            cbbChuyenKhoa.DisplayMember = "TenKhoa";
            cbbChuyenKhoa.ValueMember = "MaKhoa";
        }

        private void HienThiMonHoc()
        {
            DataTable mh = DataProvider.MonHocBus.LayDanhSach();
            DataRow root1 = mh.NewRow();
            root1[0] = 0;
            root1[1] = "---Môn học---";
            mh.Rows.InsertAt(root1, 0);
            cbbMonHoc.DataSource = mh;
            cbbMonHoc.DisplayMember = "TenMH";
            cbbMonHoc.ValueMember = "Id";
        }
        private void frmTraCuuDiemThi_Load(object sender, EventArgs e)
        {
            HienThiDiemThi();
            HienThiChuyenKhoa();
            HienThiMonHoc();
        }

        private void btnTImKiem_Click(object sender, EventArgs e)
        {
            HienThiDiemThi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemDiemThi themDiemThi = new frmThemDiemThi();
            themDiemThi.ShowDialog();
            HienThiDiemThi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmThemDiemThi suaDiemThi = new frmThemDiemThi();
            frmThemDiemThi.MaSV = int.Parse("" + dtgvDiemThi.CurrentRow.Cells[0].Value);
            frmThemDiemThi.IdMonHoc = int.Parse("" + dtgvDiemThi.CurrentRow.Cells[4].Value);
            frmThemDiemThi.Sua = true;
            suaDiemThi.ShowDialog();
            HienThi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string monThi = "" + dtgvDiemThi.CurrentRow.Cells[5].Value;
            string tenSinhVien = "" + dtgvDiemThi.CurrentRow.Cells[3].Value;
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xoá điểm thi {monThi} của {tenSinhVien} không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                int maSV, maMonHoc;
                maSV = int.Parse("" + dtgvDiemThi.CurrentRow.Cells[0].Value);
                maMonHoc = int.Parse("" + dtgvDiemThi.CurrentRow.Cells[4].Value);
                bool ketQua = DataProvider.DiemThiBus.Xoa(maSV, maMonHoc);
                if (ketQua)
                {
                    MessageBox.Show($"Đã xoá thành công điểm thi {monThi} của {tenSinhVien} !!!", "Thông báo");
                }
            }
            HienThiDiemThi();
        }

        private void dtgvDiemThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
