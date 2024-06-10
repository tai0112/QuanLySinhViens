using System;
using Standford_Project.DTO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace Standford_Project.DAO
{
    public class DiemThiBusiness
    {
        public DataTable LayDanhSach()
        {
            string strSQL = "Select sv.MaSV, HoTen, DiaChi, TenMH, DiemThi, ChuyenKhoa from DiemThi dt inner join MonHoc mh on dt.MonHocId = mh.Id inner join SinhVien sv on dt.SinhVienId = sv.Id";
            return DataProvider.LayDanhSach(strSQL);
        }

        public DiemThi LayChiTietTheoId(int id)
        {
            DiemThi diemThi = null;
            string strSQL = "SELECT * FROM DiemThi WHERE SinhVienId ='" + id + "'";
            DataTable dtDiemThi = DataProvider.LayDanhSach(strSQL);

            if(dtDiemThi != null && dtDiemThi.Rows.Count > 0 )
            {
                diemThi = new DiemThi();
                diemThi.SinhVienId = int.Parse("" + dtDiemThi.Rows[0]["SinhVienId"]);
                diemThi.MonHocId = int.Parse("" + dtDiemThi.Rows[0]["MonHocId"]);
                diemThi.NgayThi = DateTime.Parse("" + dtDiemThi.Rows[0]["NgayThi"]);
                diemThi.Diem = Double.Parse("" + dtDiemThi.Rows[0]["DiemThi"]);
                diemThi.PhongHocId = int.Parse("" + dtDiemThi.Rows[0]["PhongHocId"]);
            }
            return diemThi;
        }

        public DataTable TimKiem(string tuKhoa, string chuyenKhoa)
        {
            DataTable dt = new DataTable();
            string sqlTimKiem = "Select sv.Id, sv.MaSV, HoTen, DiaChi, TenMH, DiemThi, ChuyenKhoa from DiemThi dt inner join MonHoc mh on dt.MonHocId = mh.Id inner join SinhVien sv on dt.SinhVienId = sv.Id WHERE 1=1";
            int diemSo = -1;
            if(!string.IsNullOrEmpty(chuyenKhoa))
            {
                sqlTimKiem += string.Format("AND ChuyenKhoa = '{0}'", chuyenKhoa);
            }

            if(!string.IsNullOrEmpty(tuKhoa))
            {
                sqlTimKiem += string.Format("AND (MaSV = '{0}' OR DiaChi like N'%{0}%' OR TenMH like N'%{0}%')", tuKhoa);
            }

            if(int.TryParse(tuKhoa, out diemSo))
            {
                sqlTimKiem += string.Format("OR DiemThi = {0}", diemSo);
            }

            dt = DataProvider.LayDanhSach(sqlTimKiem);

            return dt;
        }

        public SqlParameter[] DiemThiPars(DiemThi diemThi)
        {
            SqlParameter[] pars = new SqlParameter[5];
            pars[0] = new SqlParameter("@SinhVienId", SqlDbType.Int);
            pars[0].Value = diemThi.SinhVienId;
            pars[1] = new SqlParameter("@MonHocId", SqlDbType.Int);
            pars[1].Value = diemThi.MonHocId;
            pars[2] = new SqlParameter("@NgayThi", SqlDbType.DateTime);
            pars[2].Value = diemThi.NgayThi;
            pars[3] = new SqlParameter("@DiemThi", SqlDbType.Float);
            pars[3].Value = diemThi.Diem;
            pars[4] = new SqlParameter("@PhongHocId", SqlDbType.Int);
            pars[4].Value = diemThi.PhongHocId;
            return pars;
        }

        public bool ThemMoi(DiemThi diemThi)
        {
            bool ketQua = false;

            if(diemThi != null)
            {
                string sqlThem = "INSERT INTO DiemThi(SinhVienId, MonHocId, NgayThi, DiemThi, PhongHocId) VALUES(@SinhVienId, @MonHocId, @NgayThi, @DiemThi, @PhongHocId)";
                SqlParameter[] pars = DiemThiPars(diemThi);
                ketQua = DataProvider.ThucHien(sqlThem, pars);
            }

            return ketQua;
        }

        public bool CapNhat(DiemThi diemThi)
        {
            bool ketQua = false;

            if(diemThi != null)
            {
                string sqlSua = "UPDATE DiemThi SET NgayThi = @NgayThi, DiemThi = @DiemThi, PhongHocId = @PhongHocId WHERE SinhVienId = @SinhVienId AND MonHocId = @MonHocId";
                SqlParameter[] pars = DiemThiPars(diemThi);
                ketQua = DataProvider.ThucHien(sqlSua, pars);
            }

            return ketQua;
        }

        public bool Xoa(int maSV)
        {
            bool ketQua = false;

            DiemThi diemThi = LayChiTietTheoId(maSV);

            if(diemThi != null)
            {
                string sqlXoa = "DELETE FROM DiemThi WHERE SinhVienId = @SinhVienId";
                SqlParameter[] pars = DiemThiPars(diemThi);
                ketQua = DataProvider.ThucHien(sqlXoa, pars);
            }

            return ketQua;
        }

        
    }
}
