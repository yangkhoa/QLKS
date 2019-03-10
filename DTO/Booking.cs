using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Booking
    {
        private string _id_booking;
        private string _code_room;
        private string _code_customer;
        private DateTime? _date_book;
        private DateTime? _date_checkin;
        private DateTime? _date_checkout;
        private double _deposit;

        public string Id_booking { get => _id_booking; set => _id_booking = value; }
        public string Code_room { get => _code_room; set => _code_room = value; }
        public string Code_customer { get => _code_customer; set => _code_customer = value; }
        public DateTime? Date_book { get => _date_book; set => _date_book = value; }
        public DateTime? Date_checkin { get => _date_checkin; set => _date_checkin = value; }
        public DateTime? Date_checkout { get => _date_checkout; set => _date_checkout = value; }
        public double Deposit { get => _deposit; set => _deposit = value; }

        public Booking(string id, string code_room, string code_customer,DateTime? date_checkin, DateTime? date_checkout, string deposit, DateTime? date_book)
        {
            this.Id_booking = id;
            this.Code_room = code_room;
            this.Code_customer = code_customer;
            this.Date_checkin = date_checkin;
            this.Date_checkout = date_checkout;
            this.Deposit = double.Parse(deposit);
            this.Date_book = date_book;
        }
    }
}
