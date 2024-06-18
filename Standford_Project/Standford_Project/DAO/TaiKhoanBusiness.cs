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
    public class TaiKhoanBusiness
    {
        public DataTable LayDanhSach()
        {
            string strSQL = "SELECT * FROM TaiKhoan";
            return DataProvider.LayDanhSach(strSQL);
        }
        public TaiKhoan HienThiChiTietTaiKhoan(string tenDangNhap)
        {
            TaiKhoan tk = null;
            string strSQL = "SELECT * FROM TaiKhoan WHERE TenDangNhap = '" + tenDangNhap + "'";
            DataTable dt = DataProvider.LayDanhSach(strSQL);
            if(dt != null)
            {
                tk = new TaiKhoan();
                tk.TenDangNhap = "" + dt.Rows[0]["TenDangNhap"];
                tk.MatKhau = "" + dt.Rows[0]["MatKhau"];
                tk.LoaiTK = int.Parse("" + dt.Rows[0]["LoaiTK"]);
                tk.HoTen = "" + dt.Rows[0]["HoTen"];
            }
            return tk;
        }

        public DataTable TimKiemChiTietTaiKhoan(string data)
        {
            DataTable dt = null;
            string sqlTimKiem = "SELECT * FROM TaiKhoan";
            if (!string.IsNullOrEmpty(data))
            {
                sqlTimKiem += string.Format(" WHERE TenDangNhap = '{0}'", data);
            }
            dt = DataProvider.LayDanhSach(sqlTimKiem);
            return dt;
        } 
        public SqlParameter[] TaiKhoanPars(TaiKhoan tk)
        {
            SqlParameter[] pars = new SqlParameter[4];
            pars[0] = new SqlParameter("@TenDangNhap", SqlDbType.NChar, 20);
            pars[0].Value = tk.TenDangNhap;
            pars[1] = new SqlParameter("@MatKhau", SqlDbType.NChar, 20);
            pars[1].Value = tk.MatKhau;
            pars[2] = new SqlParameter("@LoaiTK", SqlDbType.TinyInt);
            pars[2].Value = tk.LoaiTK;
            pars[3] = new SqlParameter("@HoTen", SqlDbType.NVarChar, 50);
            pars[3].Value = tk.HoTen;
            return pars;
        }
        public bool KiemTra(TaiKhoan tk = null, string taiKhoan = null)
        {
            bool ketQua = false;
            string strSQL = "";
            SqlParameter[] pars = null;
            if (tk != null)
            {
                strSQL = "SELECT COUNT(*) FROM TaiKhoan WHERE 1=1 AND (TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau)";
                pars = TaiKhoanPars(tk);
            }
            else
            {
                if (taiKhoan != null)
                {
                    strSQL = "SELECT COUNT(*) FROM TaiKhoan WHERE 1=1 AND TenDangNhap = '" + taiKhoan + "'";
                }
            }
            ketQua = DataProvider.KiemTra(strSQL, pars) > 0;
            return ketQua;
        }
        public bool Them(TaiKhoan tk, bool isAdmin)
        {
            bool ketQua = false;
            if (tk != null)
            {
                bool check = DataProvider.TaiKhoanBus.KiemTra(null, tk.TenDangNhap);
                string sqlThem = "";
                if (!check)
                {
                    if (isAdmin)
                    {
                        sqlThem = "INSERT INTO TaiKhoan(HoTen ,TenDangNhap, MatKhau, LoaiTK) VALUES(@HoTen, @TenDangNhap, @MatKhau, 1)";
                    }
                    else
                    {
                        sqlThem = "INSERT INTO TaiKhoan(HoTen ,TenDangNhap, MatKhau, LoaiTK) VALUES(@HoTen, @TenDangNhap, @MatKhau, 0)";
                    }
                }else
                {
                    MessageBox.Show("Tên tài khoản bị trùng vui lòng thử lại", "Thông báo");
                    return false;
                }
                SqlParameter[] pars = TaiKhoanPars(tk);
                ketQua = DataProvider.ThucHien(sqlThem, pars);
            }
            return ketQua;
        }
        public bool Sua(TaiKhoan tk, bool isAdmin)
        {
            bool ketQua = false;
            if(tk != null)
            {
                string sqlSua = "";
                if (isAdmin)
                {
                    sqlSua = "UPDATE TaiKhoan SET MatKhau = @MatKhau, HoTen = @HoTen, LoaiTK = 1 WHERE TenDangNhap = @TenDangNhap";
                }else
                {
                    sqlSua = "UPDATE TaiKhoan SET MatKhau = @MatKhau, HoTen = @HoTen, LoaiTK = 0 WHERE TenDangNhap = @TenDangNhap";
                }
                SqlParameter[] pars = TaiKhoanPars(tk);
                ketQua = DataProvider.ThucHien(sqlSua, pars);
            }
            return ketQua;
        }
        public bool Xoa(string tenDangNhap)
        {
            bool ketQua = false;
            TaiKhoan tk = DataProvider.TaiKhoanBus.HienThiChiTietTaiKhoan(tenDangNhap);
            if(tk != null)
            {
                string sqlXoa = "DELETE FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                SqlParameter[] pars = TaiKhoanPars(tk);
                ketQua = DataProvider.ThucHien(sqlXoa, pars);
            }
            return ketQua;
        }
    }
}
