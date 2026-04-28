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
    public class Thuoc_BUS
    {
        public static DataTable LayDanhSach()
        {
            return Thuoc_DAO.LayDanhSachThuoc();
        }

        public static bool Them(Thuoc_DTO th)
        {
            // Có thể thêm kiểm tra nghiệp vụ ở đây (ví dụ mã đã tồn tại chưa)
            return Thuoc_DAO.ThemThuoc(th);
        }

        public static bool Sua(Thuoc_DTO th)
        {
            return Thuoc_DAO.SuaThuoc(th);
        }

        public static bool Xoa(string ma)
        {
            return Thuoc_DAO.XoaThuoc(ma);
        }
        public static bool TruSoLuongTon(string maThuoc, int soLuongBan)
        {
            return Thuoc_DAO.TruSoLuongTon(maThuoc, soLuongBan);
        }
    }
}
