using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BillDetailBLL
    {
        private static BillDetailBLL instance;

        public static BillDetailBLL Instance
        {
            get { if (instance == null) instance = new BillDetailBLL(); return instance; }
            private set => instance = value;
        }
        private BillDetailBLL() { }

        public void DeleteServiceUsing(int id_bill_detail)
        {
            string query = "DELETE BillDetail WHERE id_bill_detail = {0}";

            query = string.Format(query, id_bill_detail);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void InsertServiceUsing(int id_bill, string code_service, int quatity)
        {
            string query = "INSERT BillDetail(id_bill,code_service,quatity_service) VALUES({0}, N'{1}', {2})";

            query = string.Format(query, id_bill, code_service, quatity);

            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void EditServiceUsing(int id_bill_detail, string code_service, int quatity)
        {
            string query = "UPDATE BillDetail SET code_service=N'{1}', quatity_service={2} WHERE id_bill_detail = {0}";

            query = string.Format(query, id_bill_detail, code_service, quatity);

            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
