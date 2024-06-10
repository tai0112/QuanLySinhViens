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
    public partial class frmThemPhongHoc : Form
    {
        public int Id { get; set; } = -1;
        public frmThemPhongHoc()
        {
            InitializeComponent();
            nudSapXep.Controls[0].Visible = false;
        }

        private void HienThiChiTiet()
        {
            PhongHoc ph = DataProvider.PhongHocBus.HienThiChiTietPhongHoc(Id);

            if(ph != null)
            {
                txtId.Text = "" + ph.Id;
                txtMaPhong.Text = "" + ph.MaPhong;
                txtTenPhong.Text = "" + ph.TenPhong;
                txtMoTa.Text = "" + ph.MoTa;
                nudSapXep.Value = ph.SapXep;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            bool ketQua = false;
            PhongHoc ph = new PhongHoc();
            string maPhong = "", tenPhong = "", moTa = "";
            decimal sapXep;
            maPhong = txtMaPhong.Text.Trim();
            tenPhong = txtTenPhong.Text.Trim();
            sapXep = nudSapXep.Value;
            moTa = txtMoTa.Text.Trim();
            ph.MaPhong = maPhong;
            ph.Id = Id;
            ph.TenPhong = tenPhong;
            ph.MoTa = moTa;
            ph.SapXep = sapXep;

            if(Id == -1)
            {
                ketQua = DataProvider.PhongHocBus.Them(ph);
            }else
            {
                ketQua = DataProvider.PhongHocBus.Sua(ph);
            }

            if(ketQua)
            {
                MessageBox.Show("Cập nhật thông tin thành công !!!", "Thông báo");
            }else
            {
                MessageBox.Show("Cập nhật thông tin không thành công !!!", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThemPhongHoc_Load(object sender, EventArgs e)
        {
            HienThiChiTiet();
        }
    }
}
