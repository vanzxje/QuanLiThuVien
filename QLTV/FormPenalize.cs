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
    public partial class FormPenalize : Form
    {
        BindingSource bindingSource = new BindingSource();
        public FormPenalize()
        {
            InitializeComponent();
            LoadPenalize();
            BindingPenalize();
        }
        void LoadPenalize()
        {
            dtgvPenalize.DataSource = bindingSource;
            //Lấy danh sách thành viên chưa nộp phạt
            bindingSource.DataSource = DetailPenalizeDAO.Instance.GetListPenalize();
            dtgvPenalize.DefaultCellStyle.Font = new Font("Times New Roman", 10);
        }
        void BindingPenalize()
        {
            txtNamePenalize.DataBindings.Add(new Binding("Text", bindingSource, "MemberName", true, DataSourceUpdateMode.Never));
            txtBookPenalize.DataBindings.Add(new Binding("Text", bindingSource, "NameBook", true, DataSourceUpdateMode.Never));
            txtNumberDay.DataBindings.Add(new Binding("Text", bindingSource, "NumberDay", true, DataSourceUpdateMode.Never));
            txtPricePenalize.DataBindings.Add(new Binding("Text", bindingSource, "PricePenalize", true, DataSourceUpdateMode.Never));
        }

        private void btnNopphat_Click(object sender, EventArgs e)
        {
            DateTime date = dtpkDay.Value;
            
            if(!string.IsNullOrEmpty(txtNamePenalize.Text))
            {
                if (MessageBox.Show("Bạn có chắc đã thu tiền phạt?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int id = (int)dtgvPenalize.SelectedCells[0].Value;

                    //Cập nhập phiếu phạt khi thành viên nộp phạt
                    if (DetailPenalizeDAO.Instance.UpdateDate(id, date))
                    {
                        MessageBox.Show("Nộp phạt thành công!");
                        LoadPenalize();
                    }
                    else
                    {
                        MessageBox.Show("Nộp phạt thất bại.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Không Có Thành Viên Nộp Phạt.");
            }
        }

        private void btnSearchPenalize_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtSearchPenalize.Text))
            {
                if (rdbtnNameMember.Checked)
                {
                    //Tìm kiếm thông tin phiếu phạt theo tên thành viên
                    bindingSource.DataSource = DetailPenalizeDAO.Instance.SearchPenalizeByNameMember(txtSearchPenalize.Text);
                }
                if (rdbtnNameBook.Checked)
                {
                    //Tìm kiếm thông tin phiếu phạt theo tên sách
                    bindingSource.DataSource = DetailPenalizeDAO.Instance.SearchPenalizeByNameBook(txtSearchPenalize.Text);
                }
            }
            else
            {
                LoadPenalize();
            }
        }
    }
}
