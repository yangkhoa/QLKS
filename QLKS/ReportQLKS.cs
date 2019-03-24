using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DAL;

namespace QLKS
{
    public partial class ReportQLKS : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportQLKS()
        {
            InitializeComponent();
        }

        public void BindingData()
        {
            col_date_created.DataBindings.Add("Text", DataSource, "date_created").FormatString = "{0:dd/MM/yyyy}";
            col_id_bill.DataBindings.Add("Text", DataSource, "id_bill");
            col_name_room.DataBindings.Add("Text", DataSource, "code_room");
            col_date_check_in.DataBindings.Add("Text", DataSource, "date_checkin").FormatString = "{0:dd/MM/yyyy}";
            col_date_check_out.DataBindings.Add("Text", DataSource, "date_checkout").FormatString = "{0:dd/MM/yyyy}";
            col_deposit.DataBindings.Add("Text", DataSource, "deposit");
            col_discount.DataBindings.Add("Text", DataSource, "discount");
            col_total.DataBindings.Add("Text", DataSource, "total");
            total.DataBindings.Add("Text", DataSource, "total");
            total.Summary = new DevExpress.XtraReports.UI.XRSummary(DevExpress.XtraReports.UI.SummaryRunning.Report, DevExpress.XtraReports.UI.SummaryFunc.Sum, "{0:00,0 VNĐ}");
        }
    }
}
