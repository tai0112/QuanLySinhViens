using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standford_Project.DTO
{
    public class SinhVien
    {
        public int Id { get; set; }
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public int GioiTinh { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string ChuyenKhoaId { get; set; }

        public SinhVien() { }   
        public SinhVien(int id, string maSV, string hoTen, int gioiTinh, string dienThoai, string email, string diaChi, string chuyenKhoaId)
        {
            Id = id;
            MaSV = maSV;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            DienThoai = dienThoai;
            Email = email;
            DiaChi = diaChi;
            ChuyenKhoaId = chuyenKhoaId;
        }
    }
}
