using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ServiceBLL
    {
        private static ServiceBLL instance;

        public static ServiceBLL Instance
        {
            get { if (instance == null) instance = new ServiceBLL(); return instance; }
            private set => instance = value;
        }

        private ServiceBLL() { }

        public void InsertService(string code_service, string name_service, string unit, string price_service, string code_category)
        {
            string query = "INSERT Service(code_service,name_service,unit,price_service,code_category) VALUES(N'{0}', N'{1}', N'{2}', {3}, N'{4}')";

            query = string.Format(query, code_service, name_service, unit, price_service, code_category);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void EditService(string code_service, string name_service, string unit, string price_service, string code_category)
        {
            string query = "UPDATE Service SET name_service=N'{1}', unit = N'{2}', price_service = {3}, code_category = N'{4}' WHERE code_service = N'{0}'";

            query = string.Format(query, code_service, name_service, unit, price_service, code_category);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void DeleteService(string code_service)
        {
            string query = "DELETE Service WHERE code_service = N'{0}'";

            query = string.Format(query, code_service);

            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
