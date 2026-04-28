using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BUS
{
    public class NguoiDung_BUS 
    {
        public static bool DangNhap(string tk, string mk)
        {
            return DAO.NguoiDung_DAO.KiemTraDangNhap(tk, mk);
        }
        public static string ThucHienDoiMatKhau(string tenDN, string mkCu, string mkMoi, string xacNhanMK)
        {
            if (!DangNhap(tenDN, mkCu))
                return "Mật khẩu cũ không chính xác!";

            if (mkMoi != xacNhanMK)
                return "Mật khẩu mới và xác nhận không trùng khớp!";

            if (NguoiDung_DAO.DoiMatKhau(tenDN, mkMoi))
                return "Thành công";

            return "Đã xảy ra lỗi khi cập nhật mật khẩu!";
        }
    }
}
