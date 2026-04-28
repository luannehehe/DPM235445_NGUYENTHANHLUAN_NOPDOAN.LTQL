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
    public class NhaCungCap_BUS
    {
        public static DataTable LayDanhSach()
        {
            return NhaCungCap_DAO.LayDanhSachNCC();
        }

        public static bool Them(NhaCungCap_DTO ncc)
        {
            if (string.IsNullOrEmpty(ncc.TenNCC)) return false;
            return NhaCungCap_DAO.ThemNCC(ncc);
        }

        public static bool Sua(NhaCungCap_DTO ncc)
        {
            return NhaCungCap_DAO.SuaNCC(ncc);
        }

        public static bool Xoa(string ma)
        {
            return NhaCungCap_DAO.XoaNCC(ma);
        }
        public static string ThucHienXoa(string ma)
        {
            if (NhaCungCap_DAO.KiemTraCoThuoc(ma))
            {
                return "Không thể xóa! Nhà cung cấp này hiện đang có các loại thuốc liên kết trong hệ thống.";
            }

            if (NhaCungCap_DAO.XoaNCC(ma))
            {
                return "Thành công";
            }

            return "Đã xảy ra lỗi không xác định khi thực hiện xóa!";
        }
        public static string LayMaMoi()
        {
            return NhaCungCap_DAO.LayMaNCCMoi();
        }
    }
}