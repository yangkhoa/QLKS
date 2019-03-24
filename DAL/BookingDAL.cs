using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BookingDAL
    {
        private static BookingDAL instance;

        public static BookingDAL Instance
        {
            get { if (instance == null) instance = new BookingDAL(); return instance; }
            private set => instance = value;
        }

        private BookingDAL() { }

        public int GetBookingIdByCodeRoom(string code_room)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BookingInfo WHERE code_room = N'" + code_room + "'");

            if (data.Rows.Count > 0)
            {
                Booking booking = new Booking(data.Rows[0]);
                return booking.Id_booking;
            }
            return -1;
        }

        public Customer GetCustomerByIdBooking(int id_booking)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT b.code_customer,b.name_customer,b.phone_customer,b.cmnd_customer,b.email_customer FROM BookingInfo a, Customer b Where a.code_customer = b.code_customer AND a.id_booking =" + id_booking);

            if (data.Rows.Count > 0)
            {
                Customer customer = new Customer(data.Rows[0]);
                return customer;
            }
            return null;
        }

        public Booking GetInfoBookingByIdBooking(int id_booking)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BookingInfo WHERE id_booking =" + id_booking);
            if (data.Rows.Count > 0)
            {
                Booking booking = new Booking(data.Rows[0]);
                return booking;
            }
            return null;
        }
    }
}
