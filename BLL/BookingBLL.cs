using DAL;
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

        public void InsertBooking(string username, string code_room, string code_customer, DateTime date_checkin, double deposit)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBooking @username , @code_room , @code_customer , @date_checkin , @deposit", new object[] { username, code_room, code_customer, date_checkin, deposit });
        }

        public void ChangeToBill(string username, string code_room, string code_customer, double deposit, int id_booking)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_ChangeBookingToBill @username , @code_room , @code_customer , @deposit , @id_booking", new object[] { username, code_room, code_customer, deposit , id_booking });
        }

        public void DeleteBooking(int id_booking)
        {
            string query = "DELETE BookingInfo WHERE id_booking =" + id_booking;

            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
