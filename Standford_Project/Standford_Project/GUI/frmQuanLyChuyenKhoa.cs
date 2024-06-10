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
    public partial class frmQuanLyChuyenKhoa : Form
    {
        public int LoaiTK { get; set; }
        public frmQuanLyChuyenKhoa()
        {
            InitializeComponent();
        }

        public void An()
        {
            btnSua.Visible = false;
            btnThem.Visible = false;
            btnXoa.Visible = false;
        }

        private void HienThiThongTin()
        {
            string maKhoa = "";

            maKhoa = txtTimKiem.Text.Trim();

            if (!string.IsNullOrEmpty(maKhoa))
            {
                dtgvChuyenNganh.DataSource = DataProvider.ChuyenKhoaBus.TimKiemChuyenKhoa(maKhoa);
            }else
            {
                dtgvChuyenNganh.DataSource = DataProvider.ChuyenKhoaBus.LayDanhSach();
            }

            if(LoaiTK != 1)
            {
                An();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemChuyenKhoa themChuyenKhoa = new frmThemChuyenKhoa();
            themChuyenKhoa.ShowDialog();
            HienThiThongTin();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmThemChuyenKhoa themChuyenKhoa = new frmThemChuyenKhoa();
            themChuyenKhoa.MaKhoa = "" + dtgvChuyenNganh.CurrentRow.Cells[0].Value;
            themChuyenKhoa.ShowDialog();
            HienThiThongTin();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tenChuyenNganh = "" + dtgvChuyenNganh.CurrentRow.Cells[1].Value;
            DialogResult dr = MessageBox.Show($"Bạn có chắc chắn muốn xoá chuyên ngành {tenChuyenNganh} không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                string maChuyenNganh = "";
                maChuyenNganh = "" + dtgvChuyenNganh.CurrentRow.Cells[0].Value;

                bool ketQua = DataProvider.ChuyenKhoaBus.Xoa(maChuyenNganh);

                if (ketQua)
                {
                    MessageBox.Show($"Đã xoá thành công môn học {tenChuyenNganh} !!!", "Thông báo");
                }
            }
            HienThiThongTin();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChuyenKhoa_Load(object sender, EventArgs e)
        {
            HienThiThongTin();
        }

        private void btnTImKiem_Click(object sender, EventArgs e)
        {
            HienThiThongTin();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtgvChuyenNganh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
