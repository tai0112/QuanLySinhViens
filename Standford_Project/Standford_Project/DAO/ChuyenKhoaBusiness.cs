using Standford_Project.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Standford_Project.DAO
{
    public class ChuyenKhoaBusiness
    {
        public DataTable LayDanhSach()
        {
            string strSQL = "SELECT * FROM ChuyenKhoa";
            return DataProvider.LayDanhSach(strSQL);
        }

        SqlParameter[] ChuyenKhoaPars(ChuyenKhoa ck)
        {
            SqlParameter[] pars = new SqlParameter[3];
            pars[0] = new SqlParameter("@MaKhoa", SqlDbType.NVarChar, 10);
            pars[0].Value = ck.MaKhoa;
            pars[1] = new SqlParameter("@TenKhoa", SqlDbType.NVarChar, 50);
            pars[1].Value = ck.TenKhoa;
            pars[2] = new SqlParameter("@OrderNumber", SqlDbType.Int);
            pars[2].Value = ck.OrderNumber;

            return pars;
        }

        private bool KiemTra(ChuyenKhoa ck)
        {
            bool ketQua = true;

            SqlParameter[] pars = ChuyenKhoaPars(ck);
            string sqlKiemTra = "SELECT COUNT(*) FROM ChuyenKhoa WHERE MaKhoa = @MaKhoa";

            if (DataProvider.KiemTra(sqlKiemTra, pars) > 0)
            {
                MessageBox.Show("Mã chuyên khoa đã tồn tại vui lòng kiểm tra lại !!!", "Thông báo");
                ketQua = false;
            }

            return ketQua;
        }

        public bool Them(ChuyenKhoa ck)
        {
            bool ketQua = false;
            if (ck != null && KiemTra(ck))
            {
                string sqlThem = "INSERT INTO ChuyenKhoa(MaKhoa, TenKhoa, OrderNumber) VALUES(@MaKhoa, @TenKhoa, @OrderNumber)";
                SqlParameter[] pars = ChuyenKhoaPars(ck);
                ketQua = DataProvider.ThucHien(sqlThem, pars);
            }
            return ketQua;
        }

        public bool Sua(ChuyenKhoa ck, string maKhoa)
        {
            bool ketQua = false;

            if (ck != null)
            {
                string sqlSua = "UPDATE ChuyenKhoa SET MaKhoa = @MaKhoa, TenKhoa = @TenKhoa, OrderNumber = @OrderNumber WHERE MaKhoa = '" + maKhoa + "'";
                SqlParameter[] pars = ChuyenKhoaPars(ck);
                ketQua = DataProvider.ThucHien(sqlSua, pars);
            }

            return ketQua;
        }

        public bool Xoa(string maKhoa)
        {
            bool ketQua = false;
            ChuyenKhoa ck = HienThiChiTietChuyenKhoa(maKhoa);

            if (ck != null)
            {
                string sqlXoa = "DELETE FROM ChuyenKhoa WHERE MaKhoa = @MaKhoa";
                SqlParameter[] pars = ChuyenKhoaPars(ck);
                ketQua = DataProvider.ThucHien(sqlXoa, pars);
            }

            return ketQua;
        }

        public ChuyenKhoa HienThiChiTietChuyenKhoa(string maKhoa)
        {
            ChuyenKhoa ck = null;

            string sqlSQL = "SELECT * FROM ChuyenKhoa WHERE MaKhoa = '" + maKhoa + "'";
            Debug.WriteLine(sqlSQL);
            DataTable dt = DataProvider.LayDanhSach(sqlSQL);

            if (dt != null && dt.Rows.Count > 0)
            {
                ck = new ChuyenKhoa();
                ck.MaKhoa = "" + dt.Rows[0]["MaKhoa"];
                ck.TenKhoa = "" + dt.Rows[0]["TenKhoa"];
                ck.OrderNumber = int.Parse("" + dt.Rows[0]["OrderNumber"]);
            }

            return ck;
        }

        public DataTable TimKiemChuyenKhoa(string tuKhoa)
        {
            int i = 0;
            string strSQL = "SELECT * FROM ChuyenKhoa WHERE 1=1";
            DataTable dt = null;

            if (!string.IsNullOrEmpty(tuKhoa))
            {
                strSQL += string.Format(" AND (MaKhoa like N'%{0}%' OR TenKhoa like N'%{0}%')", tuKhoa);
            }

            if (int.TryParse(tuKhoa, out i))
            {
                strSQL += string.Format(" OR OrderNumber = {0}", i);
            }

            dt = DataProvider.LayDanhSach(strSQL);

            return dt;
        }
    }
}
