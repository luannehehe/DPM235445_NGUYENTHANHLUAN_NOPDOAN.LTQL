using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class TaiKhoan_BUS
    {
        public static DataTable LayDS() => TaiKhoan_DAO.LayDSTaiKhoan();

        // Xử lý logic Thêm
        public static bool Them(string tk, string ten, string mk, int loai)
        {
            // Kiểm tra không được để trống Tên đăng nhập, Tên hiển thị hoặc Mật khẩu
            if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(mk))
                return false;
            return TaiKhoan_DAO.Them(tk, ten, mk, loai);
        }

        // Xử lý logic Sửa
        public static bool Sua(string tk, string ten, int loai)
        {
            // Phải có tên đăng nhập và tên hiển thị mới cho sửa
            if (string.IsNullOrEmpty(tk) || string.IsNullOrEmpty(ten))
                return false;
            return TaiKhoan_DAO.Sua(tk, ten, loai);
        }

        // Xử lý logic Xóa
        public static bool Xoa(string tk)
        {
            if (string.IsNullOrEmpty(tk)) return false;
            return TaiKhoan_DAO.Xoa(tk);
        }
        public static bool ResetMatKhau(string tk)
        {
            // Không cho phép reset nếu không có tên đăng nhập
            if (string.IsNullOrEmpty(tk)) return false;
            return TaiKhoan_DAO.ResetMatKhau(tk);
        }
    }
}
