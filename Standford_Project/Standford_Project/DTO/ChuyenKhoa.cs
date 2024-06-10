using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standford_Project.DTO
{
    public class ChuyenKhoa
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public decimal OrderNumber { get; set; }
        public ChuyenKhoa() { }
        public ChuyenKhoa(string maKhoa, string tenKhoa, decimal orderNumber)
        {
            MaKhoa = maKhoa;
            TenKhoa = tenKhoa;
            OrderNumber = orderNumber;
        }
    }
}
