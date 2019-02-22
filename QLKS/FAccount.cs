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
using DTO;
using DevExpress.XtraGrid.Views.Grid;
using BLL;

namespace QLKS
{
    public partial class FAccount : DevExpress.XtraEditors.XtraForm
    {
        private Account loginAccount;

        public Account LoginAccount { get => loginAccount; set => loginAccount = value; }

        //Lấy account đang đăng nhập
        public FAccount(Account acc)
        {
            this.LoginAccount = acc;
            InitializeComponent();
        }

        private void FAccount_Load(object sender, EventArgs e)
        {
            LoadAccount(LoginAccount.Username);
            LoadChucVu();
        }

        private void LoadAccount(string username)
        {
            // Truyền username vào để lấy danh sách Account nhưng loại bỏ đi username đang đăng nhập
            gridControl_Employee.DataSource = AccountDAL.Instance.GetAccountList(username); ;
        }
        private void LoadChucVu()
        {
            string query = "SELECT * FROM EmployeePosition";

            repositoryItemSearchChucVu.DataSource = DataProvider.Instance.ExecuteQuery(query); // Data để chọn

            repositoryItemSearchChucVu.ValueMember = "code_employee_position"; // Giá trị để lookup

            repositoryItemSearchChucVu.DisplayMember = "name_position"; // Giá trị sẽ hiển thị

            // dòng này để gridcontrol trong GridlookupEdit tự động resize các column để không thừa không thiếu nội dung
            repositoryItemSearchChucVu.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            
            // dòng này tự động mở popup khi search có kết quả
            repositoryItemSearchChucVu.ShowPopupShadow = true;

            // Setup dòng này để có thể nhập vào gridlookup
            repositoryItemSearchChucVu.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            gridColumn4.ColumnEdit = repositoryItemSearchChucVu;
        }

        private void GridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            // Kiểm tra xem đây là dòng mới hay cũ e.RowHandle --> trả về thứ tự dòng đang trỏ
            if (view.IsNewItemRow(e.RowHandle))           
            {
                // Thêm mới trực tiếp vào form
                string col_1 = "" + view.GetRowCellValue(e.RowHandle, view.Columns[0]).ToString() + "";
                string col_2 = "" + view.GetRowCellValue(e.RowHandle, view.Columns[1]).ToString() + "";
                string col_3 = "" + view.GetRowCellValue(e.RowHandle, view.Columns[2]).ToString() + "";
                string col_4 = "" + view.GetRowCellValue(e.RowHandle, view.Columns[3]).ToString() + "";

                try
                {
                    AccountBLL.Instance.InsertAccount(col_1, "1", col_3, col_4);
                }
                catch
                {
                    LoadAccount(LoginAccount.Username);
                }
                
            } 
            else
            {
                // Sửa trực tiếp trên formn
                string col_1 = "" + view.GetRowCellValue(e.RowHandle, view.Columns[0]).ToString() + "";
                string col_2 = "" + view.GetRowCellValue(e.RowHandle, view.Columns[1]).ToString() + "";
                string col_3 = "" + view.GetRowCellValue(e.RowHandle, view.Columns[2]).ToString() + "";
                string col_4 = "" + view.GetRowCellValue(e.RowHandle, view.Columns[3]).ToString() + "";


                try
                {
                    AccountBLL.Instance.EditAccount(col_1, col_2, col_3, col_4);
                }
                catch
                {
                    LoadAccount(LoginAccount.Username);
                }  
                
            }
        }

        private void Btn_Approve_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}