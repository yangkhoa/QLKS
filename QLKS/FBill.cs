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
using BLL;
using DAL;

namespace QLKS
{
    public partial class FBill : DevExpress.XtraEditors.XtraForm
    {
        private int _id_bill;
        private double _total_service_using;
        private double _price_room;
        private double _deposit;
        private double _discount;
        private string _code_room;

        public int Id_bill { get => _id_bill; set => _id_bill = value; }
        public double Total_service_using { get => _total_service_using; set => _total_service_using = value; }
        public double Price_room { get => _price_room; set => _price_room = value; }
        public double Deposit { get => _deposit; set => _deposit = value; }
        public double Discount { get => _discount; set => _discount = value; }
        public string Code_room { get => _code_room; set => _code_room = value; }

        public FBill(int id_bill, string txt_sum_service_using, string txt_price_room,string txt_deposit,string txt_discount, string code_room)
        {
            this.Id_bill = id_bill;
            this.Total_service_using = Convert.ToDouble(txt_sum_service_using);
            this.Price_room = Convert.ToDouble(txt_price_room);
            this.Deposit = Convert.ToDouble(txt_deposit);
            this.Discount = Convert.ToDouble(txt_discount);
            this.Code_room = code_room;

            InitializeComponent();

            LoadBill();
        }

        private void LoadBill()
        {
            string query = "SELECT date_checkin, date_checkout,DATEDIFF(hh, date_checkin, date_checkout) as count_day FROM Bill WHERE id_bill = " + Id_bill;

            DataRow row = DataProvider.Instance.ExecuteQuery(query).Rows[0];

            txt_date_check_in.Text = row["date_checkin"].ToString();
            txt_date_check_out.Text = row["date_checkout"].ToString();
            txt_date_count.Text = row["count_day"].ToString();

            txt_price_room.Text = String.Format("{0:0,0} VNĐ", Price_room);
            int date_count = Convert.ToInt32(txt_date_count.Text);
            double total = date_count * Price_room;

            txt_total_rent.Text = String.Format("{0:0,0} VNĐ", total);
            txt_total_service.Text = String.Format("{0:0,0} VNĐ", Total_service_using);
            txt_deposit.Text = String.Format("{0:0,0} VNĐ", Deposit);
            txt_discount.Text = Discount.ToString();
            txt_total_final.Text = String.Format("{0:0,0}", ( (total * (1 - (Discount*0.01))) + Total_service_using - Deposit) );
        }

        private void Btn_Approve_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thanh toán cho phòng " + Code_room, "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                BillBLL.Instance.Checkout(Id_bill, Code_room, Deposit, Discount);

                this.Close();
            }
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}