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
    public class NhanVien_BUS
    {
        public static DataTable LayDanhSach() => NhanVien_DAO.LayDanhSachNV();

        public static bool Them(NhanVien_DTO nv)
        {
            if (string.IsNullOrEmpty(nv.MaNV) || string.IsNullOrEmpty(nv.TenNV)) return false;
            return NhanVien_DAO.ThemNV(nv);
        }

        public static bool Sua(NhanVien_DTO nv) => NhanVien_DAO.SuaNV(nv);

        public static bool Xoa(string ma) => NhanVien_DAO.XoaNV(ma);
    }
}
