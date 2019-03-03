using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Customer
    {
        private string _code_customer;
        private string _name_customer;
        private string _cmnd_customer;
        private string _phone_customer;
        private string _email_customer;

        public string Code_customer { get => _code_customer; set => _code_customer = value; }
        public string Name_customer { get => _name_customer; set => _name_customer = value; }
        public string Cmnd_customer { get => _cmnd_customer; set => _cmnd_customer = value; }
        public string Email_customer { get => _email_customer; set => _email_customer = value; }
        public string Phone_customer { get => _phone_customer; set => _phone_customer = value; }


        public Customer()
        {

        }

        //HÀM DỰNG TRẢ VỀ TỪNG ROW TRONG DATATABLE
        public Customer(DataRow row)
        {
            this.Code_customer = row["code_customer"].ToString();
            this.Name_customer = row["name_customer"].ToString();
            this.Cmnd_customer = row["cmnd_customer"].ToString();
            this.Email_customer = row["email_customer"].ToString();
            this.Phone_customer = row["phone_customer"].ToString();
        }
    }
}
