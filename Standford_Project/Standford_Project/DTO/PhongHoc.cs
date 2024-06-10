using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standford_Project.DTO
{
    public class PhongHoc
    {
        public int Id { get; set; }
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }
        public string MoTa { get; set; }
        public decimal SapXep { get; set; }
        public PhongHoc() { }
        public PhongHoc(int id, string maPhong, string tenPhong, string moTa, decimal sapXep)
        {
            Id = id;
            MaPhong = maPhong;
            TenPhong = tenPhong;
            MoTa = moTa;
            SapXep = sapXep;
        }
    }
}
