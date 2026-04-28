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
    public class HoaDon_BUS
    {
        public static bool Luu(HoaDon_DTO hd) => HoaDon_DAO.LuuHoaDon(hd);
        public static string LayMaMoi() => HoaDon_DAO.LayMaHDMoi();
        public static DataTable LayDuLieuInHoaDon(string maHD)
        {
            return HoaDon_DAO.LayDuLieuIn(maHD);
        }
    }
}
