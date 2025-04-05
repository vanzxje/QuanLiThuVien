namespace QLTV
{
    partial class FormStatistics
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
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgvThongKe = new System.Windows.Forms.DataGridView();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChart = new System.Windows.Forms.Button();
            this.rdBtnMember = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.rdbtnQuy4 = new System.Windows.Forms.RadioButton();
            this.rdbtnQuy3 = new System.Windows.Forms.RadioButton();
            this.rdbtnQuy2 = new System.Windows.Forms.RadioButton();
            this.rdbtnQuy1 = new System.Windows.Forms.RadioButton();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.rdbtnTre = new System.Windows.Forms.RadioButton();
            this.rdbtnImportBook = new System.Windows.Forms.RadioButton();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKe)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(411, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 32);
            this.label6.TabIndex = 5;
            this.label6.Text = "THỐNG KÊ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgvThongKe);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 188);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(958, 304);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SỐ LIỆU";
            // 
            // dtgvThongKe
            // 
            this.dtgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvThongKe.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThongKe.Location = new System.Drawing.Point(6, 26);
            this.dtgvThongKe.Name = "dtgvThongKe";
            this.dtgvThongKe.RowHeadersWidth = 51;
            this.dtgvThongKe.RowTemplate.Height = 24;
            this.dtgvThongKe.Size = new System.Drawing.Size(946, 272);
            this.dtgvThongKe.TabIndex = 0;
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(758, 498);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(210, 27);
            this.txtTotal.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(666, 500);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "TỔNG : ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChart);
            this.groupBox1.Controls.Add(this.rdbtnTre);
            this.groupBox1.Controls.Add(this.rdBtnMember);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnThongKe);
            this.groupBox1.Controls.Add(this.rdbtnImportBook);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(956, 135);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lựa Chọn Thống Kê";
            // 
            // btnChart
            // 
            this.btnChart.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChart.Location = new System.Drawing.Point(832, 28);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(101, 46);
            this.btnChart.TabIndex = 10;
            this.btnChart.Text = "Biểu Đồ";
            this.btnChart.UseVisualStyleBackColor = true;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // rdBtnMember
            // 
            this.rdBtnMember.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdBtnMember.Location = new System.Drawing.Point(577, 28);
            this.rdBtnMember.Name = "rdBtnMember";
            this.rdBtnMember.Size = new System.Drawing.Size(187, 24);
            this.rdBtnMember.TabIndex = 9;
            this.rdBtnMember.TabStop = true;
            this.rdBtnMember.Text = "Thành Viên";
            this.rdBtnMember.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cbYear);
            this.groupBox3.Controls.Add(this.rdbtnQuy4);
            this.groupBox3.Controls.Add(this.rdbtnQuy3);
            this.groupBox3.Controls.Add(this.rdbtnQuy2);
            this.groupBox3.Controls.Add(this.rdbtnQuy1);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(6, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(495, 92);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thời gian";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(302, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Năm :";
            // 
            // cbYear
            // 
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(369, 23);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(120, 27);
            this.cbYear.TabIndex = 5;
            // 
            // rdbtnQuy4
            // 
            this.rdbtnQuy4.AutoSize = true;
            this.rdbtnQuy4.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnQuy4.Location = new System.Drawing.Point(197, 62);
            this.rdbtnQuy4.Name = "rdbtnQuy4";
            this.rdbtnQuy4.Size = new System.Drawing.Size(73, 24);
            this.rdbtnQuy4.TabIndex = 8;
            this.rdbtnQuy4.Text = "Quí 4";
            this.rdbtnQuy4.UseVisualStyleBackColor = true;
            // 
            // rdbtnQuy3
            // 
            this.rdbtnQuy3.AutoSize = true;
            this.rdbtnQuy3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnQuy3.Location = new System.Drawing.Point(41, 62);
            this.rdbtnQuy3.Name = "rdbtnQuy3";
            this.rdbtnQuy3.Size = new System.Drawing.Size(73, 24);
            this.rdbtnQuy3.TabIndex = 7;
            this.rdbtnQuy3.Text = "Quí 3";
            this.rdbtnQuy3.UseVisualStyleBackColor = true;
            // 
            // rdbtnQuy2
            // 
            this.rdbtnQuy2.AutoSize = true;
            this.rdbtnQuy2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnQuy2.Location = new System.Drawing.Point(197, 26);
            this.rdbtnQuy2.Name = "rdbtnQuy2";
            this.rdbtnQuy2.Size = new System.Drawing.Size(73, 24);
            this.rdbtnQuy2.TabIndex = 6;
            this.rdbtnQuy2.Text = "Quí 2";
            this.rdbtnQuy2.UseVisualStyleBackColor = true;
            // 
            // rdbtnQuy1
            // 
            this.rdbtnQuy1.AutoSize = true;
            this.rdbtnQuy1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnQuy1.Location = new System.Drawing.Point(41, 26);
            this.rdbtnQuy1.Name = "rdbtnQuy1";
            this.rdbtnQuy1.Size = new System.Drawing.Size(73, 24);
            this.rdbtnQuy1.TabIndex = 2;
            this.rdbtnQuy1.Text = "Quí 1";
            this.rdbtnQuy1.UseVisualStyleBackColor = true;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(832, 80);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(101, 46);
            this.btnThongKe.TabIndex = 2;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // rdbtnTre
            // 
            this.rdbtnTre.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnTre.Location = new System.Drawing.Point(577, 91);
            this.rdbtnTre.Name = "rdbtnTre";
            this.rdbtnTre.Size = new System.Drawing.Size(187, 24);
            this.rdbtnTre.TabIndex = 1;
            this.rdbtnTre.TabStop = true;
            this.rdbtnTre.Text = "Sách Phạt Trễ Hạn";
            this.rdbtnTre.UseVisualStyleBackColor = true;
            // 
            // rdbtnImportBook
            // 
            this.rdbtnImportBook.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnImportBook.Location = new System.Drawing.Point(577, 58);
            this.rdbtnImportBook.Name = "rdbtnImportBook";
            this.rdbtnImportBook.Size = new System.Drawing.Size(120, 24);
            this.rdbtnImportBook.TabIndex = 0;
            this.rdbtnImportBook.TabStop = true;
            this.rdbtnImportBook.Text = "Sách Nhập";
            this.rdbtnImportBook.UseVisualStyleBackColor = true;
            // 
            // FormStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 534);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Name = "FormStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THỐNG KÊ SỐ LIỆU";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongKe)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgvThongKe;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdBtnMember;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.RadioButton rdbtnQuy4;
        private System.Windows.Forms.RadioButton rdbtnQuy3;
        private System.Windows.Forms.RadioButton rdbtnQuy2;
        private System.Windows.Forms.RadioButton rdbtnQuy1;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.RadioButton rdbtnTre;
        private System.Windows.Forms.RadioButton rdbtnImportBook;
        private System.Windows.Forms.Button btnChart;
    }
}