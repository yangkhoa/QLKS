using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BillBLL
    {
        private static BillBLL instance;

        public static BillBLL Instance
        {
            get { if (instance == null) instance = new BillBLL(); return instance; }
            private set => instance = value;
        }
        private BillBLL() { }

        public void InsertBill(string code_employee, string code_room, string code_customer)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_InsertBill @code_employee , @code_room , @code_customer", new object[] { code_employee, code_room, code_customer });
        }

        public void Checkout(int id_bill, string code_room, double deposit, double discount)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_PayBill @id_bill , @code_room , @discount , @deposit", new object[] { id_bill, code_room, discount, deposit });
        }

        public void SwapRoom(string code_room_old, string code_room_new)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC USP_SwapRoom @code_room_old , @code_room_new", new object[] { code_room_old, code_room_new });
        }
    }
}
 