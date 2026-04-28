using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DoanhThu_BUS
    {
        public static DataTable LayDuLieuDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            return DoanhThu_DAO.LayDuLieuDoanhThu(tuNgay, denNgay);
        }
        public static decimal LayTongDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            // Gọi hàm tính tổng tiền từ tầng DAO
            return DoanhThu_DAO.LayTongDoanhThu(tuNgay, denNgay);
        }
    }
}
