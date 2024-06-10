using System;
using Standford_Project.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace Standford_Project.DAO
{
    public class DataProvider
    {
        private static string _ConnectionString = @"Data Source=DESKTOP-0UQBJGA;Initial Catalog=Standford_QlySinhVien;Integrated Security=True";
        private static DiemThiBusiness _DiemThiBus = null;
        private static ChuyenKhoaBusiness _ChuyenKhoaBus = null;
        private static MonHocBusiness _MonHocBus = null;
        private static SinhVienBusiness _SinhVienBus = null;
        private static PhongHocBusiness _PhongHocBus = null;
        private static TaiKhoanBusiness _TaiKhoanBus = null;
        public static string ConnectionString { get { return _ConnectionString; } }
        public static DataTable LayDanhSach(string strSQL)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConnectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(strSQL);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;

                //Khai báo đối tượng chứa dữ liệu

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }   
            finally
            {
                conn.Close();
            }

            return dt;
        }
        
        public static bool ThucHien(string strSQL, SqlParameter[] pars)
        {
            bool ketQua = false;

            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConnectionString);

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;

                //Thực hiện công việc thêm sửa xoá
                if (pars != null && pars.Length > 0)
                {
                    cmd.Parameters.AddRange(pars);
                }
                 
                ketQua = cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            finally
            {
                conn.Close();
            }

            return ketQua;
        }

        public static int KiemTra(string strSQL, SqlParameter[] pars)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            int ketQua = 0;
            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;

                if (pars != null && pars.Length > 0)
                {
                    cmd.Parameters.AddRange(pars);
                }

                ketQua = (int)cmd.ExecuteScalar();
            }catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }finally
            {
                conn.Close();
            }

            return ketQua;
        }

        public static DiemThiBusiness DiemThiBus
        {
            get
            {
                if(_DiemThiBus == null)
                {
                    _DiemThiBus = new DiemThiBusiness();
                }
                return _DiemThiBus;
            }
        }

        public static ChuyenKhoaBusiness ChuyenKhoaBus
        {
            get
            {
                if(_ChuyenKhoaBus == null)
                {
                    _ChuyenKhoaBus = new ChuyenKhoaBusiness();
                }
                return _ChuyenKhoaBus;
            }
        }

        public static MonHocBusiness MonHocBus
        {
            get
            {
                if (_MonHocBus == null)
                {
                    _MonHocBus = new MonHocBusiness();
                }
                return _MonHocBus;
            }
        }

        public static SinhVienBusiness SinhVienBus
        {
            get
            {
                if (_SinhVienBus == null)
                {
                    _SinhVienBus = new SinhVienBusiness();
                }
                return _SinhVienBus;
            }
        }

        public static PhongHocBusiness PhongHocBus
        {
            get
            {
                if (_PhongHocBus == null)
                {
                    _PhongHocBus = new PhongHocBusiness();
                }
                return _PhongHocBus;
            }
        }

        public static TaiKhoanBusiness TaiKhoanBus
        {
            get
            {
                if(_TaiKhoanBus == null)
                {
                    _TaiKhoanBus = new TaiKhoanBusiness();
                }
                return _TaiKhoanBus;
            }
        }
    }
}
