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
    public partial class frmQuanLyMonHoc : Form
    {
        public frmQuanLyMonHoc()
        {
            InitializeComponent();
        }

        public void An()
        {
            btnSua.Visible = false;
            btnThem.Visible = false;
            btnXoa.Visible = false;
        }

        public void HienThiDanhSach()
        {
            string data = "";
            data = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(data))
            {
                dtgvDiemThi.DataSource = DataProvider.MonHocBus.TimKiemMonHoc(data);
            }
            else
            {
                dtgvDiemThi.DataSource = DataProvider.MonHocBus.LayDanhSach();
            }

            if(frmTrangChu.LoaiTK != 1)
            {
                An();
            }
        }

        private void frmQuanLyDiemThi_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemMonHoc themMonHoc = new frmThemMonHoc();
            themMonHoc.ShowDialog();
            HienThiDanhSach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmThemMonHoc themMonHoc = new frmThemMonHoc();
            int id = int.Parse("" + dtgvDiemThi.CurrentRow.Cells[0].Value);
            themMonHoc.Id = id;
            themMonHoc.ShowDialog();
            HienThiDanhSach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tenMH = "" + dtgvDiemThi.CurrentRow.Cells[2].Value;
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xoá môn {tenMH} không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(dr == DialogResult.Yes)
            {
                int id;
                id = int.Parse("" + dtgvDiemThi.CurrentRow.Cells[0].Value);

                bool ketQua = DataProvider.MonHocBus.Xoa(id);

                if(ketQua)
                {
                    MessageBox.Show($"Đã xoá thành công môn học {tenMH} !!!", "Thông báo");
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTImKiem_Click(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }
    }
}
