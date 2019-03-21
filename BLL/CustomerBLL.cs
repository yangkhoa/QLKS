using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CustomerBLL
    {
        private static CustomerBLL instance;

        public static CustomerBLL Instance
        {
            get { if (instance == null) instance = new CustomerBLL(); return instance; }
            private set => instance = value;
        }

        private CustomerBLL() { }

        public void EditInfoCustomer(string code_customer, string name_customer, string phone_customer, string cmnd_customer, string email_customer)
        {
            string query = "UPDATE Customer SET name_customer=N'{1}', cmnd_customer=N'{2}', phone_customer=N'{3}', email_customer=N'{4}' WHERE code_customer=N'{0}'";

            query = string.Format(query, code_customer, name_customer, phone_customer, cmnd_customer, email_customer);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void DeleteCustomerByCode(string code_customer)
        {
            string query = "DELETE Customer WHERE code_customer=N'{0}'";

            query = string.Format(query, code_customer);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void InsertCustomer(string code_customer, string name_customer, string phone_customer, string cmnd_customer, string email_customer)
        {
            string query = "INSERT Customer(code_customer,name_customer,phone_customer,cmnd_customer,email_customer) VALUES(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}')";

            query = string.Format(query, code_customer, name_customer, phone_customer, cmnd_customer, email_customer);

            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
