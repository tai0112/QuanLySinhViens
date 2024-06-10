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
    public partial class frmThemChuyenKhoa : Form
    {
        public string MaKhoa { get; set; } = "";
        public frmThemChuyenKhoa()
        {
            InitializeComponent();
        }

        private void HienThiThongTin()
        {
            ChuyenKhoa ck = DataProvider.ChuyenKhoaBus.HienThiChiTietChuyenKhoa(MaKhoa);

            if(ck != null)
            {
                nudSTT.Value = ck.OrderNumber;
                txtMaKhoa.Text = ck.MaKhoa;
                txtTenKhoa.Text = ck.TenKhoa;
            }

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            bool ketQua = false;
            ChuyenKhoa ck = new ChuyenKhoa();
            string maKhoa = "", tenKhoa = "";
            decimal orderNumber;

            maKhoa = txtMaKhoa.Text.Trim();
            tenKhoa = txtTenKhoa.Text.Trim();
            orderNumber = nudSTT.Value;
            if(maKhoa.Length <= 0)
            {
                MessageBox.Show("Vui lòng nhập vào mã khoa !!!", "Thông báo");
                txtMaKhoa.Focus();
                return;
            }

            if(tenKhoa.Length <= 0)
            {
                MessageBox.Show("Vui lòng nhập vào tên khoa !!!", "Thông báo");
                txtTenKhoa.Focus();
                return;
            }

            ck.TenKhoa = tenKhoa;
            ck.OrderNumber = orderNumber;
            ck.MaKhoa = maKhoa;


            //ck.OrderNumber = orderNumber;
            if (string.IsNullOrEmpty(MaKhoa))
            {
                ketQua = DataProvider.ChuyenKhoaBus.Them(ck);
            }else
            {
                ketQua = DataProvider.ChuyenKhoaBus.Sua(ck, MaKhoa);
            }

            if(ketQua)
            {
                MessageBox.Show("Cập nhật thông tin chuyên khoa thành công !!!", "Thông báo");
            }else
            {
                MessageBox.Show("Cập nhật thông tin chuyên khoa không thành công !!!", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThemChuyenKhoa_Load(object sender, EventArgs e)
        {
            HienThiThongTin();
            Debug.WriteLine(MaKhoa);
        }
    }
}
