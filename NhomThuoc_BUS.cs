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
    public class NhomThuoc_BUS
    {
        public static DataTable LayDanhSach()
        {
            return NhomThuoc_DAO.LayDanhSachNhom();
        }

        public static bool Them(NhomThuoc_DTO nt) => NhomThuoc_DAO.ThemNhom(nt);
        public static bool Sua(NhomThuoc_DTO nt) => NhomThuoc_DAO.SuaNhom(nt);
        public static bool Xoa(string ma) => NhomThuoc_DAO.XoaNhom(ma);
        public static string ThucHienXoaNhom(string ma)
        {
            if (NhomThuoc_DAO.KiemTraCoThuoc(ma))
            {
                return "Không thể xóa nhóm này vì đang có thuốc tham chiếu đến!";
            }

            if (NhomThuoc_DAO.XoaNhom(ma))
            {
                return "Thành công";
            }

            return "Đã xảy ra lỗi khi thực hiện thao tác xóa!";
        }
        public static string LayMaMoi()
        {
            return NhomThuoc_DAO.LayMaNhomMoi();
        }
    }
}
