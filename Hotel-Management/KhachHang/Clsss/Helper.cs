using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageHotel.Clsss
{
    public static class Helper
    {
        public static int calculateRoomCapacity(int hinhThuc)
        {
            switch (hinhThuc)
            {
                case 1:
                    return 2;
                case 2:
                    return 1;
                case 3:
                    return 4;
                case 4:
                    return 2;
                default: return 4;
            }
        }
    }
}
