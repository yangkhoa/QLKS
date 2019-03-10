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
            string query = "SELECT* FROM BillDetail WHERE id_bill = " + id_bill;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            return data;

        }
    }
}
