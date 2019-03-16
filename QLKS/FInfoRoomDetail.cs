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
using BLL;

namespace QLKS
{
    public partial class FInfoRoomDetail : DevExpress.XtraEditors.XtraForm
    {
        private Account _loginAccount;
        private string _code_room;

        private int _quatity =0;
        private double _price =0;
        private double _total = 0;

        public Account LoginAccount { get => _loginAccount; set => _loginAccount = value; }
        public string Code_room { get => _code_room; set => _code_room = value; }

        public FInfoRoomDetail(Account acc, string code_room)
        {
            this.LoginAccount = acc;

            this.Code_room = code_room;

            InitializeComponent();

            int id_bill = BillDAL.Instance.GetUnCheckBillByCodeRoom(Code_room);

            if (id_bill != -1)
            {
                LoadInfoBill(id_bill);

                LoadInfoCustomer(id_bill);

                LoadServiceUsing(id_bill);
            }
            LoadCBKH();

            LoadInfoService();

            LoadInfoRoom(Code_room);
        }

        private void LoadInfoBill(int id_bill)
        {
            Bill bill = BillDAL.Instance.GetInfoBillByIdBill(id_bill);
            date_customer_checkin.Text = bill.Date_checkin.ToString();

            txt_sum_service_using.Text = String.Format("{0:0,0}", BillDetailDAL.Instance.GetSumUpTotalServiceById(id_bill));
            txt_deposit.Text = bill.Deposit.ToString();
            txt_discount.Text = (bill.Discount * 100).ToString();
        }

        private void LoadInfoCustomer(int id_bill)
        {
            barStatic_id_bill.Caption = id_bill.ToString();

            Customer customer = BillDAL.Instance.GetCustomerByIdBill(id_bill);

            search_customer.Text = customer.Code_customer;
            txt_name_customer.Text = customer.Name_customer;
            txt_phone_customer.Text = customer.Phone_customer;
            txt_cmnd_customer.Text = customer.Cmnd_customer;
            txt_email_customer.Text = customer.Email_customer;
        }

        private void LoadCBKH()
        {
            string query = "SELECT * FROM Customer";

            search_customer.Properties.DataSource = DataProvider.Instance.ExecuteQuery(query);

            search_customer.Properties.DisplayMember = "code_customer";

            search_customer.Properties.ValueMember = "code_customer";
        }

        private void LoadInfoRoom(string code_room)
        {
            DataRow row = RoomDAL.Instance.GetDetailRoom(code_room);

            txt_name_room.Text = row["code_room"].ToString();
            txt_type_room.Text = row["name_type"].ToString();
            txt_price_room.Text = row["price"].ToString();
        }

        private void LoadServiceUsing(int id_bill)
        {
            DataTable listdetail = BillDetailDAL.Instance.GetDetailBillById(id_bill);

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
            if (barStatic_id_bill.Caption != null)
            {
                int id_bill = BillDAL.Instance.GetUnCheckBillByCodeRoom(Code_room);
                GridView view = sender as GridView;
                if (view.IsNewItemRow(e.RowHandle))
                {
                    // Thêm mới trực tiếp vào form
                    string code_service = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString().Trim();
                    int quatity = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]);
                    try
                    {
                        BillDetailBLL.Instance.InsertServiceUsing(id_bill, code_service, quatity);

                        LoadInfoBill(id_bill);
                    }
                    catch
                    {
                        LoadServiceUsing(id_bill);
                    }
                }
                else
                {
                    //Sửa trực tiếp trên form
                    int id_bill_detail = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]);
                    string code_service = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString().Trim();
                    int quatity = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]);
                    try
                    {
                        BillDetailBLL.Instance.EditServiceUsing(id_bill_detail, code_service, quatity);

                        LoadInfoBill(id_bill);
                    }
                    catch
                    {
                        LoadServiceUsing(id_bill);
                    }
                }
            }
        }

        private void btn_Approve_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (BillDAL.Instance.GetUnCheckBillByCodeRoom(Code_room) == -1 && txt_name_customer.Text != null)
            {
                if (MessageBox.Show("Bạn có muốn tạo hóa đơn mới?", "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        string code_employee = "E001";

                        BillBLL.Instance.InsertBill(code_employee, txt_name_room.Text, search_customer.Text);
                    }
                    catch{}
                }
            }

            this.Close();
        }

        private void btn_DeleteServiceUsing_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                int id_bill_detail = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]);
                int id_bill = (int)gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]);
                try
                {
                    BillDetailBLL.Instance.DeleteServiceUsing(id_bill_detail);

                    LoadServiceUsing(id_bill);
                }
                catch
                {
                    MessageBox.Show("Lỗi do có phát sinh dữ liệu");
                }
            }
        }

        private void search_customer_Properties_EditValueChanged(object sender, EventArgs e)
        {
            Customer person = CustomerDAL.Instance.FindCustomerByCodeCustomer(search_customer.Text);
            try
            {
                txt_name_customer.Text = person.Name_customer;
                txt_phone_customer.Text = person.Phone_customer;
                txt_cmnd_customer.Text = person.Cmnd_customer;
                txt_email_customer.Text = person.Email_customer;
            }
            catch { }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "code_service")
            {
                string code_service = gridView1.GetRowCellValue(e.RowHandle, e.Column).ToString().Trim();
                Service sp = ServiceDAL.Instance.GetServiceByCodeService(code_service);
                if (code_service != null)
                {
                    gridView1.SetRowCellValue(e.RowHandle, "price_service", sp.Price_service);
                    if (gridView1.GetFocusedRowCellValue(col_quantity).ToString() =="")
                    {
                        _quatity = 0;
                    }
                    else
                    {
                        _quatity = Convert.ToInt32(gridView1.GetFocusedRowCellValue(col_quantity));
                        _price = Convert.ToDouble(gridView1.GetFocusedRowCellValue(col_price));
                        _total = _quatity * _price;
                        gridView1.SetFocusedRowCellValue(col_total, _total);
                    }
                }
            }
            if (e.Column == col_quantity)
            {
                _quatity = Convert.ToInt32(gridView1.GetFocusedRowCellValue(col_quantity));
                _price = Convert.ToDouble(gridView1.GetFocusedRowCellValue(col_price));
                _total = _quatity * _price;
                gridView1.SetFocusedRowCellValue(col_total, _total);
            }
        }

        private void btn_SwapRoom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btn_Payment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int id_bill = BillDAL.Instance.GetUnCheckBillByCodeRoom(Code_room);

            if (id_bill!=-1)
            {
                string query = "UPDATE Bill SET date_checkout = GETDATE() WHERE id_bill =" + id_bill;

                DataProvider.Instance.ExecuteNonQuery(query);

                FBill f = new FBill(id_bill,txt_sum_service_using.Text,txt_price_room.Text, txt_deposit.Text, txt_discount.Text,Code_room);
                f.ShowDialog();

                this.Close();
            }          
        }

        private void txt_discount_Leave(object sender, EventArgs e)
        {
            int id_bill = BillDAL.Instance.GetUnCheckBillByCodeRoom(Code_room);
            double discount = Convert.ToDouble(txt_discount.Text);
            DataProvider.Instance.ExecuteNonQuery("UPDATE Bill SET discount = " + discount * 0.01 + " WHERE id_bill =" + id_bill);
        }

        private void txt_deposit_Leave(object sender, EventArgs e)
        {
            int id_bill = BillDAL.Instance.GetUnCheckBillByCodeRoom(Code_room);
            double deposit = Convert.ToDouble(txt_deposit.Text);
            DataProvider.Instance.ExecuteNonQuery("UPDATE Bill SET deposit = " + deposit + " WHERE id_bill =" + id_bill);
        }
    }
}