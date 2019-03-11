﻿using DAL;
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
            DataProvider.Instance.ExecuteQuery("EXEC USP_InsertBill @code_employee , @code_room , @code_customer", new object[] { code_employee, code_room, code_customer });
        }

    }
}
 