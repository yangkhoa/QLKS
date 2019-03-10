using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BillDetail
    {
        private int _id_bill_detail;
        private int _id_bill;
        private string _code_service;
        private int _quatity_service;

        public int Id_bill_detail { get => _id_bill_detail; set => _id_bill_detail = value; }
        public int Id_bill { get => _id_bill; set => _id_bill = value; }
        public string Code_service { get => _code_service; set => _code_service = value; }
        public int Quatity_service { get => _quatity_service; set => _quatity_service = value; }

        public BillDetail(int id, int id_bill, string code_service, int quatity)
        {
            this.Id_bill_detail = id;
            this.Id_bill = id_bill;
            this.Code_service = code_service;
            this.Quatity_service = quatity;
        }

        public BillDetail(DataRow row)
        {
            this.Id_bill_detail = (int)row["id_bill_detail"];
            this.Id_bill = (int)row["id_bill"];
            this.Code_service = row["code_service"].ToString();
            this.Quatity_service = (int)row["quatity_service"];
        }
    }
}
