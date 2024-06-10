using Standford_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Standford_Project.DAO
{
    public class SinhVienBusiness
    {
        public DataTable LayDanhSach()
        {
            string strSQL = "SELECT * FROM SinhVien";
            return DataProvider.LayDanhSach(strSQL);
        }

        SqlParameter[] SinhVienPars(SinhVien sv)
        {
            SqlParameter[] pars = new SqlParameter[8];
            pars[0] = new SqlParameter("@Id", SqlDbType.Int);
            pars[0].Value = sv.Id;
            pars[1] = new SqlParameter("@MaSV", SqlDbType.NChar, 50);
            pars[1].Value = sv.MaSV;
            pars[2] = new SqlParameter("@HoTen", SqlDbType.NVarChar, 50);
            pars[2].Value = sv.HoTen;
            pars[3] = new SqlParameter("@GioiTinh", SqlDbType.TinyInt);
            pars[3].Value = sv.GioiTinh;
            pars[4] = new SqlParameter("@DienThoai", SqlDbType.NChar, 15);
            pars[4].Value = sv.DienThoai;
            pars[5] = new SqlParameter("@Email", SqlDbType.NChar, 100);
            pars[5].Value = sv.Email;
            pars[6] = new SqlParameter("@ChuyenKhoa", SqlDbType.NVarChar, 50);
            pars[6].Value = sv.ChuyenKhoaId;
            pars[7] = new SqlParameter("@DiaChi", SqlDbType.NVarChar, 50);
            pars[7].Value = sv.DiaChi;
            return pars;
        }

        private bool KiemTra(SinhVien sv)
        {
            bool ketQua = true;

            SqlParameter[] pars = SinhVienPars(sv);
            string sqlKiemTra = "SELECT COUNT(*) FROM SinhVien Where MaSV = @MaSV";

            if (DataProvider.KiemTra(sqlKiemTra, pars) > 0)
            {
                MessageBox.Show($"Mã sinh viên đã tồn tại vui lòng kiểm tra lại !!!", "Thông báo");
                ketQua = false;
            }

            return ketQua;
        }

        public bool Them(SinhVien sv)
        {
            bool ketQua = false;

            if (sv != null && KiemTra(sv))
            {
                string sqlThem = "INSERT INTO SinhVien(MaSV, HoTen, GioiTinh, DienThoai, Email, ChuyenKhoa, DiaChi) VALUES(@MaSV, @HoTen, @GioiTinh, @DienThoai, @Email, @ChuyenKhoa, @DiaChi)";
                SqlParameter[] pars = SinhVienPars(sv);
                ketQua = DataProvider.ThucHien(sqlThem, pars);
            }
            return ketQua;
        }

        public bool Sua(SinhVien sv)
        {
            bool ketQua = false;

            if (sv != null)
            {
                string sqlSua = "UPDATE SinhVien SET MaSV = @MaSV, HoTen = @HoTen, GioiTinh = @GioiTinh, DienThoai = @DienThoai, Email = @Email, ChuyenKhoa = @ChuyenKhoa, DiaChi = @DiaChi WHERE Id = @Id";
                SqlParameter[] pars = SinhVienPars(sv);
                ketQua = DataProvider.ThucHien(sqlSua, pars);
            }

            return ketQua;
        }

        public bool Xoa(int id)
        {
            bool ketQua = false;
            SinhVien sv = HienThiChiTietSinhVien(id);

            if (sv != null)
            {
                string sqlXoa = "DELETE FROM SinhVien WHERE Id = @Id";
                SqlParameter[] pars = SinhVienPars(sv);
                ketQua = DataProvider.ThucHien(sqlXoa, pars);
            }

            return ketQua;
        }

        public SinhVien HienThiChiTietSinhVien(int id)
        {
            SinhVien sv = null;

            string sqlSQL = "SELECT * FROM SinhVien WHERE Id = " + id + "";
            DataTable dt = DataProvider.LayDanhSach(sqlSQL);

            if (dt != null && dt.Rows.Count > 0)
            {
                sv = new SinhVien();
                sv.Id = int.Parse("" + dt.Rows[0]["Id"]);
                sv.MaSV = "" + dt.Rows[0]["MaSV"];
                sv.HoTen = "" + dt.Rows[0]["HoTen"];
                sv.GioiTinh = int.Parse("" + dt.Rows[0]["GioiTinh"]);
                sv.DienThoai = "" + dt.Rows[0]["DienThoai"];
                sv.Email = "" + dt.Rows[0]["Email"];
                sv.ChuyenKhoaId = "" + dt.Rows[0]["ChuyenKhoa"];
                sv.DiaChi = "" + dt.Rows[0]["DiaChi"];
            }

            return sv;
        }

        public DataTable TimKiemSinhVien(string tuKhoa, string maKhoa)
        {
            int i = 0;
            string strSQL = "SELECT * FROM SinhVien WHERE 1=1";
            DataTable dt = null;

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                strSQL += string.Format(" AND (MaSV like N'%{0}%' OR HoTen like N'%{0}%' OR DienThoai like N'%{0}%' OR Email like N'%{0}%')", tuKhoa);
            }

            if (int.TryParse(tuKhoa, out i))
            {
                strSQL += string.Format(" OR Id = {0}", i);
            }

            if(!string.IsNullOrEmpty(maKhoa))
            {
                strSQL += string.Format("AND ChuyenKhoa = '{0}'", maKhoa);
            }

            dt = DataProvider.LayDanhSach(strSQL);

            return dt;
        }
    }
}
