using Standford_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Standford_Project.DAO
{
    public class PhongHocBusiness
    {
        public DataTable LayDanhSach()
        {
            string strSQL = "SELECT * FROM PhongHoc";
            return DataProvider.LayDanhSach(strSQL);
        }

        SqlParameter[] PhongHocPars(PhongHoc ph)
        {
            SqlParameter[] pars = new SqlParameter[5];
            pars[0] = new SqlParameter("@Id", SqlDbType.Int);
            pars[0].Value = ph.Id;
            pars[1] = new SqlParameter("@MaPhong", SqlDbType.NVarChar, 50);
            pars[1].Value = ph.MaPhong;
            pars[2] = new SqlParameter("@TenPhong", SqlDbType.NVarChar, 50);
            pars[2].Value = ph.TenPhong;
            pars[3] = new SqlParameter("@MoTa", SqlDbType.NVarChar, 50);
            pars[3].Value = ph.MoTa;
            pars[4] = new SqlParameter("@SapXep", SqlDbType.NVarChar, 50);
            pars[4].Value = ph.SapXep;

            return pars;
        }

        private int KiemTra(PhongHoc ph)
        {
            int ketQua = 0;

            SqlParameter[] pars = PhongHocPars(ph);
            string sqlKiemTra = "SELECT COUNT(*) FROM PhongHoc Where MaPhong = @MaPhong";
            ketQua = DataProvider.KiemTra(sqlKiemTra, pars);

            return ketQua;
        }

        public bool Them(PhongHoc ph)
        {
            bool ketQua = false;

            if (ph != null && KiemTra(ph) == 0)
            {
                string sqlThem = "INSERT INTO PhongHoc(MaPhong, TenPhong, MoTa, SapXep) VALUES(@MaPhong, @TenPhong, @MoTa, @SapXep)";
                SqlParameter[] pars = PhongHocPars(ph);
                ketQua = DataProvider.ThucHien(sqlThem, pars);
            }else
            {
                MessageBox.Show("Mã phòng bị trùng lặp vui lòng kiểm tra lại !!!", "Thông báo");
                ketQua = false;
            }
            return ketQua;
        }

        public bool Sua(PhongHoc ph)
        {
            bool ketQua = false;

            if (ph != null)
            {
                string sqlSua = "UPDATE PhongHoc SET MaPhong = @MaPhong, TenPhong = @TenPhong, MoTa = @MoTa, SapXep = @SapXep WHERE Id = @Id";
                SqlParameter[] pars = PhongHocPars(ph);
                ketQua = DataProvider.ThucHien(sqlSua, pars);
            }

            return ketQua;
        }

        public bool Xoa(int id)
        {
            bool ketQua = false;
            PhongHoc ph = HienThiChiTietPhongHoc(id);

            if (ph != null)
            {
                string sqlXoa = "DELETE FROM PhongHoc WHERE Id = @Id";
                SqlParameter[] pars = PhongHocPars(ph);
                ketQua = DataProvider.ThucHien(sqlXoa, pars);
            }

            return ketQua;
        }

        public PhongHoc HienThiChiTietPhongHoc(int id)
        {
            PhongHoc ph = null;

            string sqlSQL = "SELECT * FROM PhongHoc WHERE Id = " + id + "";
            DataTable dt = DataProvider.LayDanhSach(sqlSQL);

            if (dt != null && dt.Rows.Count > 0)
            {
                ph = new PhongHoc();
                ph.Id = int.Parse("" + dt.Rows[0]["Id"]);
                ph.MaPhong = "" + dt.Rows[0]["MaPhong"];
                ph.TenPhong = "" + dt.Rows[0]["TenPhong"];
                ph.MoTa = "" + dt.Rows[0]["MoTa"];
                ph.SapXep = int.Parse("" + dt.Rows[0]["SapXep"]);
            }

            return ph;
        }

        public DataTable TimKiemPhongHoc(string tuKhoa)
        {
            int i = 0;
            string strSQL = "SELECT * FROM PhongHoc WHERE 1=1";
            DataTable dt = null;

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                strSQL += string.Format(" AND (TenPhong like N'%{0}%' OR MaPhong like N'%{0}%' OR MoTa like N'%{0}%')", tuKhoa);
            }

            if (int.TryParse(tuKhoa, out i))
            {
                strSQL += string.Format(" OR Id = {0}", i);
            }

            dt = DataProvider.LayDanhSach(strSQL);

            return dt;
        }
    }
}
