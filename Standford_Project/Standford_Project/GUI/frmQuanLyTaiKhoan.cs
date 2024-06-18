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
    public partial class frmQuanLyTaiKhoan : Form
    {
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void HienThiTaiKhoan()
        {
            string data = "";
            data = txtTimKiem.Text.Trim();
            dtgvTaiKhoan.DataSource = DataProvider.TaiKhoanBus.TimKiemChiTietTaiKhoan(data);
        }
        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            HienThiTaiKhoan();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmTaoTK taoTK = new frmTaoTK();
            taoTK.ShowDialog();
            HienThiTaiKhoan();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string tenDangNhap = "" + dtgvTaiKhoan.CurrentRow.Cells[0].Value;
            frmTaoTK taoTK = new frmTaoTK();
            taoTK.tenDangNhap = tenDangNhap;
            taoTK.ShowDialog();
            HienThiTaiKhoan();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tenDangNhap = "" + dtgvTaiKhoan.CurrentRow.Cells[0].Value;
            DialogResult rs = MessageBox.Show($"Bạn có muốn xoá tài khoản {tenDangNhap} không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(rs == DialogResult.Yes)
            {
                bool ketQua = DataProvider.TaiKhoanBus.Xoa(tenDangNhap);
                if(ketQua)
                {
                    MessageBox.Show("Đã xoá thành công tài khoản", "Thông báo");
                }else 
                {
                    MessageBox.Show("Xoá tài khoản thất bại", "Thông báo");
                }
            }
            HienThiTaiKhoan();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTImKiem_Click(object sender, EventArgs e)
        {
            HienThiTaiKhoan();
        }
    }
}
