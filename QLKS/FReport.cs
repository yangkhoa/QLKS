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

namespace QLKS
{
    public partial class FReport : DevExpress.XtraEditors.XtraForm
    {
        public FReport()
        {
            InitializeComponent();
        }

        private void DocumentViewer1_Load(object sender, EventArgs e)
        {
            ReportQLKS report = new ReportQLKS();

            report.DataSource = DataProvider.Instance.ExecuteQuery("SELECT B.id_bill, B.code_room, B.date_checkin, B.date_checkout, B.deposit, B.discount, B.total, GETDATE() as date_created FROM Bill B, Room R WHERE status_bill = 1 AND B.code_room = R.code_room");

            report.BindingData();

            documentViewer1.PrintingSystem = report.PrintingSystem;

            report.CreateDocument();
            
        }
    }
}