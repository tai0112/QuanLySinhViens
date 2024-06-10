using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standford_Project.DTO
{
    public class MonHoc
    {
        public int Id { get; set; }
        public string MaMH { get; set; }
        public string TenMH { get; set; }
        public MonHoc() { }
        public MonHoc(int id, string maMH, string tenMH)
        {
            Id = id;
            MaMH = maMH;
            TenMH = tenMH;
        }
    }
}
