namespace QLTV
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcQuảnLíToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuMượnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuTrảToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phiếuPhạtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnmain = new System.Windows.Forms.Button();
            this.txtSearchmain = new System.Windows.Forms.TextBox();
            this.rdbtnNamePerson = new System.Windows.Forms.RadioButton();
            this.rdbtnNameBook = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtgvmain = new System.Windows.Forms.DataGridView();
            this.idborrow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvmain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.phiếuMượnToolStripMenuItem,
            this.phiếuTrảToolStripMenuItem,
            this.phiếuNhậpToolStripMenuItem,
            this.phiếuPhạtToolStripMenuItem,
            this.thốngKêToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(982, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcQuảnLíToolStripMenuItem,
            this.đổiMậtKhẩuToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // danhMụcQuảnLíToolStripMenuItem
            // 
            this.danhMụcQuảnLíToolStripMenuItem.Name = "danhMụcQuảnLíToolStripMenuItem";
            this.danhMụcQuảnLíToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.danhMụcQuảnLíToolStripMenuItem.Text = "Danh Mục Quản Lí";
            this.danhMụcQuảnLíToolStripMenuItem.Click += new System.EventHandler(this.danhMụcQuảnLíToolStripMenuItem_Click);
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.đổiMậtKhẩuToolStripMenuItem.Text = "Đổi Mật Khẩu";
            this.đổiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.đổiMậtKhẩuToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(213, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // phiếuMượnToolStripMenuItem
            // 
            this.phiếuMượnToolStripMenuItem.Name = "phiếuMượnToolStripMenuItem";
            this.phiếuMượnToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.phiếuMượnToolStripMenuItem.Text = "Phiếu Mượn";
            this.phiếuMượnToolStripMenuItem.Click += new System.EventHandler(this.phiếuMượnToolStripMenuItem_Click);
            // 
            // phiếuTrảToolStripMenuItem
            // 
            this.phiếuTrảToolStripMenuItem.Name = "phiếuTrảToolStripMenuItem";
            this.phiếuTrảToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
            this.phiếuTrảToolStripMenuItem.Text = "Phiếu Trả";
            this.phiếuTrảToolStripMenuItem.Click += new System.EventHandler(this.phiếuTrảToolStripMenuItem_Click);
            // 
            // phiếuNhậpToolStripMenuItem
            // 
            this.phiếuNhậpToolStripMenuItem.Name = "phiếuNhậpToolStripMenuItem";
            this.phiếuNhậpToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.phiếuNhậpToolStripMenuItem.Text = "Phiếu Nhập";
            this.phiếuNhậpToolStripMenuItem.Click += new System.EventHandler(this.phiếuNhậpToolStripMenuItem_Click);
            // 
            // phiếuPhạtToolStripMenuItem
            // 
            this.phiếuPhạtToolStripMenuItem.Name = "phiếuPhạtToolStripMenuItem";
            this.phiếuPhạtToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
            this.phiếuPhạtToolStripMenuItem.Text = "Phiếu Phạt";
            this.phiếuPhạtToolStripMenuItem.Click += new System.EventHandler(this.phiếuPhạtToolStripMenuItem_Click);
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.thốngKêToolStripMenuItem.Text = "Thống Kê ";
            this.thốngKêToolStripMenuItem.Click += new System.EventHandler(this.thốngKêToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 500);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnmain);
            this.groupBox2.Controls.Add(this.txtSearchmain);
            this.groupBox2.Controls.Add(this.rdbtnNamePerson);
            this.groupBox2.Controls.Add(this.rdbtnNameBook);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 61);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(940, 77);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm Kiếm";
            // 
            // btnmain
            // 
            this.btnmain.Location = new System.Drawing.Point(844, 29);
            this.btnmain.Name = "btnmain";
            this.btnmain.Size = new System.Drawing.Size(75, 32);
            this.btnmain.TabIndex = 3;
            this.btnmain.Text = "Tìm";
            this.btnmain.UseVisualStyleBackColor = true;
            this.btnmain.Click += new System.EventHandler(this.btnmain_Click);
            // 
            // txtSearchmain
            // 
            this.txtSearchmain.Location = new System.Drawing.Point(341, 31);
            this.txtSearchmain.Name = "txtSearchmain";
            this.txtSearchmain.Size = new System.Drawing.Size(497, 28);
            this.txtSearchmain.TabIndex = 2;
            // 
            // rdbtnNamePerson
            // 
            this.rdbtnNamePerson.AutoSize = true;
            this.rdbtnNamePerson.Location = new System.Drawing.Point(140, 32);
            this.rdbtnNamePerson.Name = "rdbtnNamePerson";
            this.rdbtnNamePerson.Size = new System.Drawing.Size(165, 24);
            this.rdbtnNamePerson.TabIndex = 1;
            this.rdbtnNamePerson.TabStop = true;
            this.rdbtnNamePerson.Text = "Tên Người Mượn";
            this.rdbtnNamePerson.UseVisualStyleBackColor = true;
            // 
            // rdbtnNameBook
            // 
            this.rdbtnNameBook.AutoSize = true;
            this.rdbtnNameBook.Location = new System.Drawing.Point(18, 32);
            this.rdbtnNameBook.Name = "rdbtnNameBook";
            this.rdbtnNameBook.Size = new System.Drawing.Size(101, 24);
            this.rdbtnNameBook.TabIndex = 0;
            this.rdbtnNameBook.TabStop = true;
            this.rdbtnNameBook.Text = "Tên Sách";
            this.rdbtnNameBook.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtgvmain);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(952, 344);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Mượn Trả";
            // 
            // dtgvmain
            // 
            this.dtgvmain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvmain.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dtgvmain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvmain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idborrow,
            this.Column1,
            this.col2,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dtgvmain.Location = new System.Drawing.Point(6, 27);
            this.dtgvmain.Name = "dtgvmain";
            this.dtgvmain.RowHeadersWidth = 51;
            this.dtgvmain.RowTemplate.Height = 24;
            this.dtgvmain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvmain.Size = new System.Drawing.Size(940, 311);
            this.dtgvmain.TabIndex = 0;
            this.dtgvmain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvmain_CellContentClick);
            // 
            // idborrow
            // 
            this.idborrow.DataPropertyName = "BorrowID";
            this.idborrow.FillWeight = 68.98866F;
            this.idborrow.HeaderText = "Mã Mượn";
            this.idborrow.MinimumWidth = 6;
            this.idborrow.Name = "idborrow";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "NameBook";
            this.Column1.FillWeight = 121.9251F;
            this.Column1.HeaderText = "Tên Sách";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // col2
            // 
            this.col2.DataPropertyName = "NameMember";
            this.col2.FillWeight = 115.2111F;
            this.col2.HeaderText = "Người Mượn";
            this.col2.MinimumWidth = 6;
            this.col2.Name = "col2";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Number";
            this.Column2.FillWeight = 63.45304F;
            this.Column2.HeaderText = "Số Lượng";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "BorrowDay";
            this.Column3.FillWeight = 115.2111F;
            this.Column3.HeaderText = "Ngày Mượn";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "PayDay";
            this.Column4.FillWeight = 115.2111F;
            this.Column4.HeaderText = "Ngày Trả";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(326, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(333, 32);
            this.label6.TabIndex = 4;
            this.label6.Text = "THÔNG TIN MƯỢN TRẢ";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 534);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PHẦN MỀM QUẢN LÍ THƯ VIỆN";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvmain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcQuảnLíToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuMượnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuTrảToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phiếuNhậpToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dtgvmain;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbtnNamePerson;
        private System.Windows.Forms.RadioButton rdbtnNameBook;
        private System.Windows.Forms.Button btnmain;
        private System.Windows.Forms.TextBox txtSearchmain;
        private System.Windows.Forms.DataGridViewTextBoxColumn idborrow;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.ToolStripMenuItem phiếuPhạtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
    }
}