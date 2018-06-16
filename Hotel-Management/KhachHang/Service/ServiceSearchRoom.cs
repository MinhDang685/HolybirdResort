using ManageHotel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageHotel.Service
{
    class ServiceSearchRoom
    {
        public List<sp_SearchAvailableRoom_Result> SearchAvailableRoom(int floor, int state, int level, int numberSlot, String dateFrom, String dateTo)
        {
            using (var db = new ManageHotelEntities())
            {
                    return db.sp_SearchAvailableRoom(floor, state, level, numberSlot, dateFrom, dateTo).ToList();
              
            }
            
        }
    }
}
