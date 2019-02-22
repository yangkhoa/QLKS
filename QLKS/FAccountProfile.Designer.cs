namespace QLKS
{
    partial class FAccountProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FAccountProfile));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_reenterpass = new DevExpress.XtraEditors.TextEdit();
            this.Btn_Exit = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Approve = new DevExpress.XtraEditors.SimpleButton();
            this.txt_newPass = new DevExpress.XtraEditors.TextEdit();
            this.txt_oldPass = new DevExpress.XtraEditors.TextEdit();
            this.txt_NameDisplay = new DevExpress.XtraEditors.TextEdit();
            this.txt_Name = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem5 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem6 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.txt_Newpass_rewrite = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_reenterpass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_newPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_oldPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_NameDisplay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Newpass_rewrite)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_reenterpass);
            this.layoutControl1.Controls.Add(this.Btn_Exit);
            this.layoutControl1.Controls.Add(this.Btn_Approve);
            this.layoutControl1.Controls.Add(this.txt_newPass);
            this.layoutControl1.Controls.Add(this.txt_oldPass);
            this.layoutControl1.Controls.Add(this.txt_NameDisplay);
            this.layoutControl1.Controls.Add(this.txt_Name);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(761, 67, 812, 500);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(561, 395);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_reenterpass
            // 
            this.txt_reenterpass.Location = new System.Drawing.Point(141, 212);
            this.txt_reenterpass.Name = "txt_reenterpass";
            this.txt_reenterpass.Properties.PasswordChar = '*';
            this.txt_reenterpass.Size = new System.Drawing.Size(396, 28);
            this.txt_reenterpass.StyleController = this.layoutControl1;
            this.txt_reenterpass.TabIndex = 6;
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.Location = new System.Drawing.Point(373, 260);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.Size = new System.Drawing.Size(164, 29);
            this.Btn_Exit.StyleController = this.layoutControl1;
            this.Btn_Exit.TabIndex = 3;
            this.Btn_Exit.Text = "Thoát";
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            // 
            // Btn_Approve
            // 
            this.Btn_Approve.Location = new System.Drawing.Point(197, 260);
            this.Btn_Approve.Name = "Btn_Approve";
            this.Btn_Approve.Size = new System.Drawing.Size(172, 30);
            this.Btn_Approve.StyleController = this.layoutControl1;
            this.Btn_Approve.TabIndex = 2;
            this.Btn_Approve.Text = "Xác nhận";
            this.Btn_Approve.Click += new System.EventHandler(this.Btn_Approve_Click);
            // 
            // txt_newPass
            // 
            this.txt_newPass.Location = new System.Drawing.Point(141, 180);
            this.txt_newPass.Name = "txt_newPass";
            this.txt_newPass.Properties.PasswordChar = '*';
            this.txt_newPass.Size = new System.Drawing.Size(396, 28);
            this.txt_newPass.StyleController = this.layoutControl1;
            this.txt_newPass.TabIndex = 1;
            // 
            // txt_oldPass
            // 
            this.txt_oldPass.Location = new System.Drawing.Point(141, 148);
            this.txt_oldPass.Name = "txt_oldPass";
            this.txt_oldPass.Properties.PasswordChar = '*';
            this.txt_oldPass.Size = new System.Drawing.Size(396, 28);
            this.txt_oldPass.StyleController = this.layoutControl1;
            this.txt_oldPass.TabIndex = 0;
            // 
            // txt_NameDisplay
            // 
            this.txt_NameDisplay.Enabled = false;
            this.txt_NameDisplay.Location = new System.Drawing.Point(141, 116);
            this.txt_NameDisplay.Name = "txt_NameDisplay";
            this.txt_NameDisplay.Properties.ReadOnly = true;
            this.txt_NameDisplay.Size = new System.Drawing.Size(396, 28);
            this.txt_NameDisplay.StyleController = this.layoutControl1;
            this.txt_NameDisplay.TabIndex = 5;
            // 
            // txt_Name
            // 
            this.txt_Name.Enabled = false;
            this.txt_Name.Location = new System.Drawing.Point(141, 84);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Properties.ReadOnly = true;
            this.txt_Name.Size = new System.Drawing.Size(396, 28);
            this.txt_Name.StyleController = this.layoutControl1;
            this.txt_Name.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem2,
            this.emptySpaceItem3,
            this.emptySpaceItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem5,
            this.emptySpaceItem6,
            this.txt_Newpass_rewrite});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(561, 395);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txt_Name;
            this.layoutControlItem1.Location = new System.Drawing.Point(11, 72);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(517, 32);
            this.layoutControlItem1.Text = "Họ và tên";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(114, 23);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(11, 282);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(517, 93);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txt_NameDisplay;
            this.layoutControlItem2.Location = new System.Drawing.Point(11, 104);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(517, 32);
            this.layoutControlItem2.Text = "Tên hiển thị";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(114, 23);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txt_oldPass;
            this.layoutControlItem3.Location = new System.Drawing.Point(11, 136);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(517, 32);
            this.layoutControlItem3.Text = "Mật khẩu cũ";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(114, 23);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txt_newPass;
            this.layoutControlItem4.Location = new System.Drawing.Point(11, 168);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(517, 32);
            this.layoutControlItem4.Text = "Mật khẩu mới";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(114, 23);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(11, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(517, 72);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(528, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(11, 375);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(11, 375);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.Btn_Approve;
            this.layoutControlItem5.Location = new System.Drawing.Point(184, 248);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(176, 34);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.Btn_Exit;
            this.layoutControlItem6.Location = new System.Drawing.Point(360, 248);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(168, 34);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem5
            // 
            this.emptySpaceItem5.AllowHotTrack = false;
            this.emptySpaceItem5.Location = new System.Drawing.Point(11, 248);
            this.emptySpaceItem5.Name = "emptySpaceItem5";
            this.emptySpaceItem5.Size = new System.Drawing.Size(173, 34);
            this.emptySpaceItem5.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem6
            // 
            this.emptySpaceItem6.AllowHotTrack = false;
            this.emptySpaceItem6.Location = new System.Drawing.Point(11, 232);
            this.emptySpaceItem6.Name = "emptySpaceItem6";
            this.emptySpaceItem6.Size = new System.Drawing.Size(517, 16);
            this.emptySpaceItem6.TextSize = new System.Drawing.Size(0, 0);
            // 
            // txt_Newpass_rewrite
            // 
            this.txt_Newpass_rewrite.Control = this.txt_reenterpass;
            this.txt_Newpass_rewrite.Location = new System.Drawing.Point(11, 200);
            this.txt_Newpass_rewrite.Name = "txt_Newpass_rewrite";
            this.txt_Newpass_rewrite.Size = new System.Drawing.Size(517, 32);
            this.txt_Newpass_rewrite.Text = "Nhập lại";
            this.txt_Newpass_rewrite.TextSize = new System.Drawing.Size(114, 23);
            // 
            // FAccountProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 395);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FAccountProfile";
            this.Text = "FAccountProfile";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_reenterpass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_newPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_oldPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_NameDisplay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Newpass_rewrite)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton Btn_Exit;
        private DevExpress.XtraEditors.SimpleButton Btn_Approve;
        private DevExpress.XtraEditors.TextEdit txt_newPass;
        private DevExpress.XtraEditors.TextEdit txt_oldPass;
        private DevExpress.XtraEditors.TextEdit txt_NameDisplay;
        private DevExpress.XtraEditors.TextEdit txt_Name;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem6;
        private DevExpress.XtraEditors.TextEdit txt_reenterpass;
        private DevExpress.XtraLayout.LayoutControlItem txt_Newpass_rewrite;
    }
}