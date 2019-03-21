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
using BLL;
using DevExpress.XtraGrid.Views.Grid;

namespace QLKS
{
    public partial class FEmployee : DevExpress.XtraEditors.XtraForm
    {
        public FEmployee()
        {
            InitializeComponent();

            LoadListEmployee();
        }
        private void LoadListEmployee()
        {
            gridControl_Employee.DataSource = EmployeeDAL.Instance.GetListEmployee();
        }

        private void Btn_Approve_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!gridView1.IsNewItemRow(gridView1.FocusedRowHandle))
            {
                string code_employee = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString().Trim() + "";
                string name_employee = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString() + "";
                string date_birth = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString() + "";
                string phone = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString() + "";
                try
                {
                    EmployeeBLL.Instance.EditInfoEmployee(code_employee, name_employee, date_birth, phone);
                }
                catch
                {
                    LoadListEmployee();
                }
            }
            this.Close();
        }

        private void Btn_Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string code_employee = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString().Trim();
                try
                {
                    EmployeeBLL.Instance.DeleteEmployeeByCode(code_employee);

                    LoadListEmployee();
                }
                catch
                {
                    MessageBox.Show("Lỗi do có phát sinh dữ liệu");
                }
            }
        }

        private void GridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.IsNewItemRow(e.RowHandle))
            {
                string code_employee = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString().Trim() + "";
                string name_employee = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString() + "";
                string date_birth = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString() + "";
                string phone = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString() + "";
                try
                {
                    EmployeeBLL.Instance.InsertEmployee(code_employee, name_employee, date_birth, phone);
                }
                catch
                {
                    LoadListEmployee();
                }
            }
            else
            {
                string code_employee = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString().Trim() + "";
                string name_employee = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString() + "";
                string date_birth = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString() + "";
                string phone = "" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[3]).ToString() + "";

                try
                {
                    EmployeeBLL.Instance.EditInfoEmployee(code_employee, name_employee, date_birth, phone);
                }
                catch
                {
                    LoadListEmployee();
                }
            }
        }
    }
}