using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BillDAL
    {
        private static BillDAL instance;

        public static BillDAL Instance
        {
            get { if (instance == null) instance = new BillDAL(); return instance; }
            private set => instance = value;
        }

        private BillDAL() { }

        /// <summary>
        /// Thành công: id_bill
        /// Thất bại: -1
        /// </summary>
        /// <param name="code_room"></param>
        /// <returns></returns>

        public int GetUnCheckBillByCodeRoom(string code_room)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE code_room =N'"+code_room+"' AND status_bill = 0");

            if (data.Rows.Count>0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id_bill;
            }
            return -1;
        }

        public Customer GetCustomerByIdBill(int id_bill)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT b.code_customer,b.name_customer,b.phone_customer,b.cmnd_customer,b.email_customer FROM Bill a, Customer b Where a.code_customer = b.code_customer AND a.id_bill ="+id_bill);

            if (data.Rows.Count>0)
            {
                Customer customer = new Customer(data.Rows[0]);
                return customer;
            }
            return null;
        }

        public Bill GetInfoBillByIdBill(int id_bill)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Bill WHERE id_bill =" + id_bill);
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill;
            }
            return null;
        }
    }
}
