using DAL;
using DevExpress.XtraBars;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLKS
{
    public partial class FMain: DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Account _loginAccount;

        public Account LoginAccount { get => _loginAccount; set => _loginAccount = value; }

        public FMain(Account acc)
        {
            this.LoginAccount = acc;
            InitializeComponent();
            Permisson(LoginAccount.Code_position);
            LoadRoom();
        }
        void Permisson(string code_position)
        {
            BarButton_Account.Enabled = code_position == "001";
            BarButton_Room.Enabled = code_position == "001";
            BarButton_Employee.Enabled = code_position == "001";
            BarButton_ReportRevenue.Enabled = code_position == "001";
            BarButton_RoomStatus.Enabled = code_position == "001";
            BarButton_RoomType.Enabled = code_position == "001";
            BarButton_Service.Enabled = code_position == "001";
            BarButton_ServiceCategory.Enabled = code_position == "001";
        }
        private void LoadRoom()
        {
            // Clear Panel trước khi sử dụng
            flowLayoutPanel_Room.Controls.Clear();

            List<Room> listroom = RoomDAL.Instance.LoadRoomList();

            foreach (Room item in listroom)
            {
                Button btn = new Button() { Width = 150, Height = 100 };

                // Chỉnh chữ cho button
                btn.Text = item.Name_room + Environment.NewLine + item.Code_status;
                // Chỉnh hình trên chữ
                btn.TextImageRelation = TextImageRelation.ImageAboveText;

                btn.TabStop = false;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;

                btn.Click += Btn_Click; 
                switch (item.Code_status)
                {
                    case ("Trống"):
                        // Chỉnh màu cho button
                        btn.BackColor = Color.Aqua;
                        // Thêm hình cho button
                        btn.Image = global::QLKS.Properties.Resources.home_32x32;
                        break;
                    case ("Đã được đặt"):
                        btn.BackColor = Color.Yellow;
                        btn.Image = global::QLKS.Properties.Resources.home_32x32;
                        break;
                    case ("Đang sử dụng"):
                        btn.BackColor = Color.Red;
                        btn.Image = global::QLKS.Properties.Resources.usergroup_32x32;
                        break;
                    default:
                        break;
                }

                flowLayoutPanel_Room.Controls.Add(btn);
            }

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đang xây dựng ");
        }

        private void BarButton_Employee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FAccount f = new FAccount(LoginAccount);
            f.ShowDialog();
        }

        private void BarButton_Logout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void Barbutton_ResetPassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            FAccountProfile f = new FAccountProfile(LoginAccount);
            f.ShowDialog();
        }

        private void BarButton_Room_ItemClick(object sender, ItemClickEventArgs e)
        {
            FRoom f = new FRoom();

            f.ShowDialog();

            LoadRoom();
        }

        private void BarButton_RoomType_ItemClick(object sender, ItemClickEventArgs e)
        {
            FRoomType f = new FRoomType();
            f.ShowDialog();
        }

        private void BarButton_RoomStatus_ItemClick(object sender, ItemClickEventArgs e)
        {
            FRoomStatus f = new FRoomStatus();
            f.ShowDialog();
        }

        private void BarButton_ServiceCategory_ItemClick(object sender, ItemClickEventArgs e)
        {
            FServiceCategory f = new FServiceCategory();
            f.ShowDialog();
        }

        private void BarButton_Service_ItemClick(object sender, ItemClickEventArgs e)
        {
            FService f = new FService();
            f.ShowDialog();
        }
    }
}
