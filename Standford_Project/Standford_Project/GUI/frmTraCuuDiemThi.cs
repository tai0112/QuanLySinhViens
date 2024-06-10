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
        public int LoaiTK { get; set; }
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

        private void HienThiDiemThi()
        {
            string data = "", chuyenKhoa = "";
            data = txtTimKiem.Text.Trim();
            chuyenKhoa = "" + cbbChuyenKhoa.SelectedValue;
            DataTable dt = DataProvider.DiemThiBus.TimKiem(data, chuyenKhoa);
            dtgvDiemThi.DataSource = dt;

            if(LoaiTK != 1)
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
        private void frmTraCuuDiemThi_Load(object sender, EventArgs e)
        {
            HienThiDiemThi();
            HienThiChuyenKhoa();
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
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            frmThemDiemThi suaDiemThi = new frmThemDiemThi();
            int id = int.Parse("" + dtgvDiemThi.CurrentRow.Cells[0].Value);
            suaDiemThi.MaSV = id;
            suaDiemThi.ShowDialog();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }
    }
}
