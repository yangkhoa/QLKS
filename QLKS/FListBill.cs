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
    public partial class FListBill : DevExpress.XtraEditors.XtraForm
    {
        public FListBill()
        {
            InitializeComponent();
        }

        public void LoadListBill(DateTime checkin, DateTime checkout)
        {
            gridControl_ListBill.DataSource = BillDAL.Instance.GetListBillByDate(checkin, checkout);
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            LoadListBill(Convert.ToDateTime(from_date.EditValue), Convert.ToDateTime(to_date.EditValue));
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}