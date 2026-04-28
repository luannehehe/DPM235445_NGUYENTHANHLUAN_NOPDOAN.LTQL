using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChiTietHoaDon_BUS
    {
        public static bool Luu(ChiTietHoaDon_DTO ct)
        {
            return ChiTietHoaDon_DAO.LuuChiTiet(ct);
        }
    }
}
