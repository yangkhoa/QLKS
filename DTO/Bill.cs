using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Bill
    {
        private int _id_bill;
	    private string _username;
        private string _code_room;
        private string _code_customer;
        private DateTime? _date_checkin;
        private DateTime? _date_checkout;
        private double _deposit;
	    private double _discount;
	    private int _status_bill; 
	    private DateTime? _date_created;

        public int Id_bill { get => _id_bill; set => _id_bill = value; }
        public string Username { get => _username; set => _username = value; }
        public string Code_room { get => _code_room; set => _code_room = value; }
        public string Code_customer { get => _code_customer; set => _code_customer = value; }
        public DateTime? Date_checkin { get => _date_checkin; set => _date_checkin = value; }
        public DateTime? Date_checkout { get => _date_checkout; set => _date_checkout = value; }
        public double Deposit { get => _deposit; set => _deposit = value; }
        public double Discount { get => _discount; set => _discount = value; }
        public int Status_bill { get => _status_bill; set => _status_bill = value; }
        public DateTime? Date_created { get => _date_created; set => _date_created = value; }

        public Bill(int id,string username,string code_room,string code_customer, DateTime? dateCheckin, DateTime? dateCheckout, double deposit, double discount, int status, DateTime? dateCreate)
        {
            this.Id_bill = id;
            this.Username = username;
            this.Code_customer = code_customer;
            this.Code_room = code_room;
            this.Date_checkin = dateCheckin;
            this.Date_checkout = dateCheckout;
            this.Deposit = deposit;
            this.Discount = discount;
            this.Status_bill = status;
            this.Date_created = dateCreate;
        }

        public Bill(DataRow row)
        {
            this.Id_bill = (int)row["id_bill"];
            this.Username = row["username"].ToString();
            this.Code_customer = row["code_customer"].ToString();
            this.Code_room = row["code_room"].ToString();
            this.Date_checkin = (DateTime?)row["date_checkin"];

            var dateCheckout_Temp = row["date_checkout"];
            if (dateCheckout_Temp.ToString() != "")
                this.Date_checkout = (DateTime?)dateCheckout_Temp;
            
            this.Deposit = (double)row["deposit"];
            this.Discount = (double)row["discount"];
            this.Status_bill = (int)row["status_bill"];
            this.Date_created = (DateTime?)row["date_created"];
        }
    }
}
