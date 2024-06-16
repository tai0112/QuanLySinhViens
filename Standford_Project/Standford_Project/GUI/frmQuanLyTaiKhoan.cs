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
    public partial class frmQuanLyTaiKhoan : Form
    {
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            dtgvTaiKhoan.DataSource = DataProvider.TaiKhoanBus.LayDanhSach();
        }
    }
}
