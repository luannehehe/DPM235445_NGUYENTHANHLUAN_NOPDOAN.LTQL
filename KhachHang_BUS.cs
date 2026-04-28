using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class KhachHang_BUS
    {
        public static DataTable LayDanhSach() => KhachHang_DAO.LayDanhSachKH();

        public static bool Them(KhachHang_DTO kh)
        {
            if (string.IsNullOrEmpty(kh.MaKH) || string.IsNullOrEmpty(kh.TenKH)) return false;
            return KhachHang_DAO.ThemKH(kh);
        }

        public static bool Sua(KhachHang_DTO kh) => KhachHang_DAO.SuaKH(kh);

        public static bool Xoa(string ma) => KhachHang_DAO.XoaKH(ma);
        public static KhachHang_DTO TimTheoSDT(string sdt)
        {
            DataTable dt = KhachHang_DAO.TimKhachHangTheoSDT(sdt);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                return new KhachHang_DTO(dr["MaKH"].ToString(), dr["TenKH"].ToString(), dr["SoDienThoai"].ToString(), dr["DiaChi"].ToString());
            }
            return null;
        }
    }
}
