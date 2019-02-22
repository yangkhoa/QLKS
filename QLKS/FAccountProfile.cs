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
using BLL;

namespace QLKS
{
    public partial class FAccountProfile : DevExpress.XtraEditors.XtraForm
    {
        private Account _loginAccount;

        public Account LoginAccount { get => _loginAccount; set => _loginAccount = value; }

        public FAccountProfile(Account acc)
        {
            this.LoginAccount = acc;
            InitializeComponent();
            txt_Name.Text = acc.Username;
            txt_NameDisplay.Text = acc.Display_name;
        }
        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_Approve_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        void UpdateAccountInfo()
        {
            string username = txt_Name.Text;
            string display_name = txt_NameDisplay.Text;
            string newpass = txt_newPass.Text;
            string renewpass = txt_reenterpass.Text;
            string oldpass = txt_oldPass.Text;

            if (!newpass.Equals(renewpass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu");
            }
            else
            {
                if (AccountBLL.Instance.UpdateAccount(username, display_name, oldpass, newpass))
                {
                    MessageBox.Show("Đổi mật khẩu thành công");
                    this.Close();
                }
                else
                    MessageBox.Show("Đổi mật khẩu không thành công");
            }
        }
    }
}