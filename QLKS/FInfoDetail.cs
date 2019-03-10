using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DTO;
using DAL;
using DevExpress.XtraGrid.Views.Grid;

namespace QLKS
{
    public partial class FInfoDetail : DevExpress.XtraEditors.XtraForm
    {
        private Account _loginAccount;

        public Account LoginAccount { get => _loginAccount; set => _loginAccount = value; }

        public FInfoDetail(Account acc,string code_room)
        {
            this.LoginAccount = acc;

            InitializeComponent();

            LoadInfoBill(BillDAL.Instance.GetUnCheckBillByCodeRoom(code_room));

            LoadInfoCustomer(BillDAL.Instance.GetUnCheckBillByCodeRoom(code_room));

            LoadInfoRoom(code_room);

            LoadServiceUsing(code_room);

            LoadInfoService();

        }
        private void LoadInfoBill(int id_bill)
        {
            if (id_bill!=-1)
            {
                Bill bill = BillDAL.Instance.GetInfoBillByIdBill(id_bill);
                txt_date_checkin.Text = bill.Date_checkin.ToString();
            }
        }

        private void LoadInfoCustomer(int id_bill)
        {
            if (id_bill != -1)
            {
                barStaticItem_id_bill.Caption = id_bill.ToString();
                Customer cus = BillDAL.Instance.GetCustomerByIdBill(id_bill);
                txt_name_customer.Text = cus.Name_customer;
                txt_phone_customer.Text = cus.Phone_customer;
                txt_cmnd_customer.Text = cus.Cmnd_customer;
                txt_email_customer.Text = cus.Email_customer;              
            }
        }

        private void LoadInfoRoom(string code_room)
        {
            DataRow row = RoomDAL.Instance.GetDetailRoom(code_room);

            txt_name_room.Text = row["code_room"].ToString();
            txt_type_room.Text = row["name_type"].ToString();
            txt_price_room.Text = row["price"].ToString();
        }

        private void LoadServiceUsing(string code_room)
        {
            DataTable listdetail = BillDetailDAL.Instance.GetDetailBillById(BillDAL.Instance.GetUnCheckBillByCodeRoom(code_room));

            gridControl_BillDetail.DataSource = listdetail;
        }
        private void LoadInfoService()
        {
            string query = "SELECT code_service, name_service, unit,price_service, name_category FROM Service a,ServiceCategory b WHERE a.code_category = b.code_service_category";

            repositoryItemSearchLookUp_Service.DataSource = DataProvider.Instance.ExecuteQuery(query);

            repositoryItemSearchLookUp_Service.ValueMember = "code_service";

            repositoryItemSearchLookUp_Service.DisplayMember = "name_service";

        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {

        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}