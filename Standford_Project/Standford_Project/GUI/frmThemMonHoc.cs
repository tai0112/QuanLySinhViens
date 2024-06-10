using Standford_Project.DAO;
using Standford_Project.DTO;
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
    public partial class frmThemMonHoc : Form
    {
        public int Id { get; set; } = -1;
        public frmThemMonHoc()
        {
            InitializeComponent();
        }

        private void HienThiChiTiet()
        {
            MonHoc mh = DataProvider.MonHocBus.HienThiChiTietMonHoc(Id);

            if(mh != null )
            {
                txtId.Text = "" + mh.Id;
                txtTenMonHoc.Text = mh.TenMH;
                txtMaMonHoc.Text = mh.MaMH;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            bool ketQua = false;
            int id = Id;
            string maMH = "", tenMH = "";


            maMH = txtMaMonHoc.Text.Trim();
            tenMH = txtTenMonHoc.Text.Trim();
            if(maMH.Length <= 0)
            {
                MessageBox.Show("Vui lòng nhập vào trường mã môn học !!!", "Thông tin");
                txtMaMonHoc.Focus();
                return;
            }

            if(tenMH.Length <= 0)
            {
                MessageBox.Show("Vui lòng vào trường tên môn học !!!", "Thông tin");
                txtTenMonHoc.Focus();
                return;
            }

            MonHoc monHoc = new MonHoc();
            monHoc.Id = id;
            monHoc.MaMH = maMH;
            monHoc.TenMH = tenMH;

            if(Id == -1)
            {
                ketQua = DataProvider.MonHocBus.Them(monHoc);
            }else
            {
                ketQua = DataProvider.MonHocBus.Sua(monHoc);
            }

            if(ketQua)
            {
                MessageBox.Show("Cập nhật thông tin môn học thành công !!!", "Thông báo");
            }else
            {
                MessageBox.Show("Cập nhật thông tin môn học không thành công !!!", "Thông báo");
            }
            this.Close();
        }

        private void frmThemMonHoc_Load(object sender, EventArgs e)
        {
            HienThiChiTiet();
        }
    }
}
