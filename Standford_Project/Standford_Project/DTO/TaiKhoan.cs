using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Standford_Project.DTO
{
    public class TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }

        public int LoaiTK { get; set; }
        public TaiKhoan() { }
        public TaiKhoan(string tenDangNhap, string matKhau, int loaiTK)
        {
            TenDangNhap = tenDangNhap;
            MatKhau = matKhau;
            LoaiTK = loaiTK;
        }
    }
}
