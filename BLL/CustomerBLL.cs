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

        public void EditInfoCustomer(string col_1, string col_2, string col_3, string col_4, string col_5)
        {
            string query = "UPDATE Customer SET name_customer=N'{1}', cmnd_customer=N'{2}', phone_customer=N'{3}', email_customer=N'{4}' WHERE code_customer=N'{0}'";

            query = string.Format(query, col_1, col_2, col_3, col_4, col_5);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void DeleteCustomerByCode(string code_customer)
        {
            string query = "DELETE Customer WHERE code_customer=N'{0}'";

            query = string.Format(query, code_customer);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void InsertCustomer(string col_1, string col_2, string col_3, string col_4, string col_5)
        {
            string query = "INSERT Customer(code_customer,name_customer,phone_customer,cmnd_customer,email_customer) VALUES(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}')";

            query = string.Format(query, col_1, col_2, col_3, col_4,col_5);

            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
