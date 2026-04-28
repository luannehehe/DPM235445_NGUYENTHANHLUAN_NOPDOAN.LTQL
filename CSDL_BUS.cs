using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class CSDL_BUS
    {
        public static bool SaoLuu(string sDuongDan)
        {
            return CSDL_DAO.SaoLuuDuLieu(sDuongDan);
        }
        public static bool PhucHoi(string sDuongDan)
        {
            return CSDL_DAO.PhucHoiDuLieu(sDuongDan);
        }
    }
}
