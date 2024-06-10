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
    public class MonHocBusiness
    {
        public DataTable LayDanhSach()
        {
            string strSQL = "SELECT * FROM MonHoc";
            return DataProvider.LayDanhSach(strSQL);
        }


        SqlParameter[] MonHocPars(MonHoc mh)
        {
            SqlParameter[] pars = new SqlParameter[3];
            pars[0] = new SqlParameter("@Id", SqlDbType.Int);
            pars[0].Value = mh.Id;
            pars[1] = new SqlParameter("@MaMH", SqlDbType.NVarChar, 10);
            pars[1].Value = mh.MaMH;
            pars[2] = new SqlParameter("@TenMH", SqlDbType.NVarChar, 50);
            pars[2].Value = mh.TenMH;

            return pars;
        }

        private bool KiemTra(MonHoc mh)
        {
            bool ketQua = true;

            SqlParameter[] pars = MonHocPars(mh);
            string sqlKiemTra = "SELECT COUNT(*) FROM MonHoc Where MaMH = @MaMH";

            if (DataProvider.KiemTra(sqlKiemTra, pars) > 0)
            {
                MessageBox.Show($"Mã môn học đã tồn tại vui lòng kiểm tra lại !!!", "Thông báo");
                ketQua = false;
            }

            return ketQua;
        }

        public bool Them(MonHoc mh)
        {
            bool ketQua = false;
            if(mh != null && KiemTra(mh))
            {
                SqlParameter[] pars = MonHocPars(mh);
                string sqlThem = "INSERT INTO MonHoc(MaMH, TenMH) VALUES(@MaMH, @TenMH)";
                ketQua = DataProvider.ThucHien(sqlThem, pars);
            }
            return ketQua;
        }

        public bool Sua(MonHoc mh)
        {
            bool ketQua = false;

            if(mh != null && KiemTra(mh))
            {
                string sqlSua = "UPDATE MonHoc SET MaMH = @MaMH, TenMH = @TenMH WHERE Id = @Id";
                SqlParameter[] pars = MonHocPars(mh);
                ketQua = DataProvider.ThucHien(sqlSua, pars);
            }

            return ketQua;
        }

        public bool Xoa(int id)
        {
            bool ketQua = false;
            MonHoc mh = HienThiChiTietMonHoc(id);

            if( mh != null )
            {
                string sqlXoa = "DELETE FROM MonHoc WHERE Id = @Id";
                SqlParameter[] pars = MonHocPars(mh);
                ketQua = DataProvider.ThucHien(sqlXoa, pars);
            }

            return ketQua;
        }

        public MonHoc HienThiChiTietMonHoc(int id)
        {
            MonHoc monHoc = null;

            string sqlSQL = "SELECT * FROM MonHoc WHERE Id = " + id + "";
            DataTable dt = DataProvider.LayDanhSach(sqlSQL);

            if(dt != null && dt.Rows.Count > 0)
            {
                monHoc = new MonHoc();
                monHoc.Id = int.Parse("" + dt.Rows[0]["Id"]);
                monHoc.TenMH = "" + dt.Rows[0]["TenMH"];
                monHoc.MaMH = "" + dt.Rows[0]["MaMH"];
            }

            return monHoc;
        }

        public DataTable TimKiemMonHoc(string tuKhoa)
        {
            int i = 0;
            string strSQL = "SELECT * FROM MonHoc WHERE 1=1";
            DataTable dt = null;

            if(!string.IsNullOrEmpty(tuKhoa))
            {
                strSQL += string.Format(" AND (TenMH like N'%{0}%' OR MaMH like N'%{0}%')", tuKhoa);
            }

            if(int.TryParse(tuKhoa, out i))
            {
                strSQL += string.Format(" OR Id = {0}", i);
            }

            dt = DataProvider.LayDanhSach(strSQL);

            return dt;
        }
    }
}
