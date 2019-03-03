using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerDAL
    {
        private static CustomerDAL instance;

        public static CustomerDAL Instance
        {
            get { if (instance == null) instance = new CustomerDAL(); return instance; }
            private set => instance = value;
        }

        private CustomerDAL() { }

        public DataTable GetListCustomer()
        {
            string query = "SELECT * FROM Customer";

            return DataProvider.Instance.ExecuteQuery(query);
        }

        public Customer FindCustomerByCodeCustomer(string code_cus)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("SELECT * FROM Customer WHERE code_customer = N'" + code_cus + "'");

            foreach (DataRow item in result.Rows)
            {
                return new Customer(item);   
            }
            return null;
        }
    }
}
