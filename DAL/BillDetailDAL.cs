using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BillDetailDAL
    {
        private static BillDetailDAL instance;

        public static BillDetailDAL Instance
        {
            get { if (instance == null) instance = new BillDetailDAL(); return instance; }
            private set => instance = value;
        }

        private BillDetailDAL() { }

        public DataTable GetDetailBillById(int id_bill)
        {
            string query = "SELECT b.id_bill_detail , b.id_bill, b.code_service , b.quatity_service, c.price_service, b.quatity_service * c.price_service AS total FROM Bill a, BillDetail b, Service c WHERE a.id_bill = b.id_bill AND b.code_service = c.code_service AND b.id_bill =" + id_bill;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;

        }

        public double GetSumUpTotalServiceById(int id_bill)
        {
            string query = "SELECT Sum(t.total) AS sum_total FROM(SELECT b.quatity_service * c.price_service AS total FROM BillDetail b, Service c WHERE b.code_service = c.code_service AND b.id_bill = "+id_bill+") t";

            DataRow row = DataProvider.Instance.ExecuteQuery(query).Rows[0];

            return (double)row["sum_total"];

        }
    }
}
