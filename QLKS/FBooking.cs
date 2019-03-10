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
using DAL;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DTO;
using BLL;

namespace QLKS
{
    public partial class FBooking : DevExpress.XtraEditors.XtraForm
    {
        public FBooking()
        {
            InitializeComponent();

            LoadListRoom();

            LoadCBKH();
        }

        private void LoadCBKH()
        {
            string query = "SELECT * FROM Customer";

            search_lookup_customer.Properties.DataSource = DataProvider.Instance.ExecuteQuery(query);

            search_lookup_customer.Properties.DisplayMember = "code_customer";

            search_lookup_customer.Properties.ValueMember = "code_customer";
        }

        private void LoadListRoom()
        {
            gridControl_Room.DataSource = RoomDAL.Instance.GetRoomListBooking();
        }

        private void txt_deposit_Leave(object sender, EventArgs e)
        {
            try
            {
                txt_deposit.Text = String.Format("{0:0,0}", double.Parse(txt_deposit.Text)); 
            }
            catch
            {
                MessageBox.Show("Xin hãy nhập lại!!!");
            }
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Add_Customer_Click(object sender, EventArgs e)
        {
            // Ở đây có thể tạo 1 form nhập thông tin khách hàng

            FCustomer f = new FCustomer();
            
            f.ShowDialog();

            LoadCBKH();
        }

        private void Search_lookup_customer_EditValueChanged(object sender, EventArgs e)
        {
            Customer person = CustomerDAL.Instance.FindCustomerByCodeCustomer(search_lookup_customer.Text);

            txt_name_customer.Text = person.Name_customer;
            txt_phone_customer.Text = person.Phone_customer;
            txt_cmnd_passport.Text = person.Cmnd_customer;           
        }

        private void btn_Approve_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}