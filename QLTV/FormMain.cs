using QLTV.DAO;
using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLTV
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            
            LoadBookBorrow();
        }
        private void LoadBookBorrow()
        {
            //hiển thị danh sách sách mượn
            dtgvmain.DataSource = InfoBookBorrowDAO.Instance.GetALLBookBorrow();
            dtgvmain.DefaultCellStyle.Font = new Font("Times New Roman", 10);
        }
        private void btnmain_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchmain.Text))
            {
                if (rdbtnNameBook.Checked)
                {
                    //Tìm kiếm sách mượn theo tên sách
                    dtgvmain.DataSource = InfoBookBorrowDAO.Instance.SearchBookBorrowByNameBook(txtSearchmain.Text);
                    dtgvmain.DefaultCellStyle.Font = new Font("Times New Roman", 10);
                }
                if (rdbtnNamePerson.Checked)
                {
                    //Tìm kiếm sách mượn theo tên thành viên
                    dtgvmain.DataSource = InfoBookBorrowDAO.Instance.SearchBookBorrowByNameMember(txtSearchmain.Text);
                    dtgvmain.DefaultCellStyle.Font = new Font("Times New Roman", 10);
                }
            }
            else
            {
                LoadBookBorrow();
            }
        }
        private void danhMụcQuảnLíToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQuanLi formQuanLi = new FormQuanLi();
            formQuanLi.ShowDialog();
            LoadBookBorrow();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEditAccount formEditAccount = new FormEditAccount();
            formEditAccount.ShowDialog();
        }

        private void phiếuMượnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBookBorrow  formBookBorrow = new FormBookBorrow();
            formBookBorrow.ShowDialog();
            LoadBookBorrow();
        }

        private void phiếuTrảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPayBook formPayBook = new FormPayBook();
            formPayBook.ShowDialog();
            LoadBookBorrow();
        }

        private void phiếuNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormImportBook formImportBook = new FormImportBook();
            formImportBook.ShowDialog();
        }

        private void dtgvmain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void phiếuPhạtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPenalize formPenalize = new FormPenalize();
            formPenalize.ShowDialog();
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStatistics formStatistics = new FormStatistics();
            formStatistics.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    
    }
}
