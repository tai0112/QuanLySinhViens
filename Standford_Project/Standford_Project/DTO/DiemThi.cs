using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standford_Project.DTO
{
    public class DiemThi
    {
        public int SinhVienId { get; set; }
        public int MonHocId { get; set; }
        public DateTime NgayThi { get; set; }
        public double Diem { get; set; }
        public int PhongHocId { get; set; }
        public DiemThi() { }
        public DiemThi(int sinhVienId, int monHocId, DateTime ngayThi, double diem, int phongHocId)
        {
            SinhVienId = sinhVienId;
            MonHocId = monHocId;
            NgayThi = ngayThi;
            Diem = diem;
            PhongHocId = phongHocId;
        }
    }
}
