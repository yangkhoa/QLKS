using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BookingBLL
    {
        private static BookingBLL instance;

        public static BookingBLL Instance
        {
            get { if (instance == null) instance = new BookingBLL(); return instance; }
            private set => instance = value;
        }
        private BookingBLL() { }

        public void InsertBooking()
        {

        }
    }
}
