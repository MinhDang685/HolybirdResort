using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageHotel.Service
{
    class ComboboxItemService
    {
        public List<Hang> getAllHang() {
            using (var db = new ManageHotelEntities())
            {
                List<Hang> hangphong = db.Hangs.ToList();
                return hangphong;
            }
        }

        public List<String> getAllTang()
        {
            using (var db = new ManageHotelEntities())
            {
                List<String> hangphong = db.Phongs.Select(x=>x.ViTriTang).Distinct().ToList();
                return hangphong;
            }
        }
    }
}
