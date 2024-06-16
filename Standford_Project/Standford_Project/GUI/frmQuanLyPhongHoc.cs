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
    public partial class frmQuanLyPhongHoc : Form
    {
        public frmQuanLyPhongHoc()
        {
            InitializeComponent();
        }

        public void An()
        {
            btnSua.Visible = false;
            btnThem.Visible = false;
            btnXoa.Visible = false;
        }

        private void HienThiDanhSach()
        {
            string data = "";
            data = txtTimKiem.Text.Trim();
            if (!string.IsNullOrEmpty(data))
            {
                dtgvPhongHoc.DataSource = DataProvider.PhongHocBus.TimKiemPhongHoc(data);
            }
            else
            {
                dtgvPhongHoc.DataSource = DataProvider.PhongHocBus.LayDanhSach();
            }

            if(frmTrangChu.LoaiTK != 1)
            {
                An();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemPhongHoc themPhongHoc = new frmThemPhongHoc();
            themPhongHoc.ShowDialog();
            HienThiDanhSach();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmThemPhongHoc themPhongHoc = new frmThemPhongHoc();
            themPhongHoc.Id = int.Parse("" + dtgvPhongHoc.CurrentRow.Cells[0].Value);
            themPhongHoc.ShowDialog();
            HienThiDanhSach();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tenPhongHoc = "" + dtgvPhongHoc.CurrentRow.Cells[2].Value;
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xoá {tenPhongHoc} không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                int maPhongHoc;
                maPhongHoc = int.Parse("" + dtgvPhongHoc.CurrentRow.Cells[0].Value);

                bool ketQua = DataProvider.PhongHocBus.Xoa(maPhongHoc);

                if (ketQua)
                {
                    MessageBox.Show($"Đã xoá thành công phòng học {tenPhongHoc} !!!", "Thông báo");
                }
            }
            HienThiDanhSach();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQuanLyPhongHoc_Load(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }

        private void btnTImKiem_Click(object sender, EventArgs e)
        {
            HienThiDanhSach();
        }
    }
}
