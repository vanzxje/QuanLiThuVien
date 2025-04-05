using QLTV.DAO;
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
    public partial class FormStatistics : Form
    {
        public FormStatistics()
        {
            InitializeComponent();
            LoadYear();
        }
        void LoadYear()
        {
            DateTime today = DateTime.Now;
            int year = today.Year;
            int i = ImportBooksDAO.Instance.GetMinYearImportBook();
            while (i <= year)
            {
                cbYear.Items.Add(i);
                i++;
            }
        }
        //Chỉnh sửa giao diện danh sách load thống kê
        void EditColumn()
        {
            dtgvThongKe.DefaultCellStyle.Font = new Font("Times New Roman", 9);
            dtgvThongKe.Columns[0].HeaderText = "Mã Nhập";
            dtgvThongKe.Columns[0].DataPropertyName = "ImportID";

            dtgvThongKe.Columns[1].HeaderText = "Tên Sách";
            dtgvThongKe.Columns[1].DataPropertyName = "NameBook";

            dtgvThongKe.Columns[2].HeaderText = "Tác Giả";
            dtgvThongKe.Columns[2].DataPropertyName = "AuthorName";

            dtgvThongKe.Columns[3].HeaderText = "Thể Loại";
            dtgvThongKe.Columns[3].DataPropertyName = "NameCate";

            dtgvThongKe.Columns[4].HeaderText = "Năm Xuất Bản";
            dtgvThongKe.Columns[4].DataPropertyName = "PublishYear";

            dtgvThongKe.Columns[5].HeaderText = "Số Lượng";
            dtgvThongKe.Columns[5].DataPropertyName = "QuanlityImport";

            dtgvThongKe.Columns[6].HeaderText = "Đơn Giá";
            dtgvThongKe.Columns[6].DataPropertyName = "Price";

            dtgvThongKe.Columns[7].HeaderText = "Thành Tiền";
            dtgvThongKe.Columns[7].DataPropertyName = "Total";

            dtgvThongKe.Columns[8].HeaderText = "Ngày Nhập";
            dtgvThongKe.Columns[8].DataPropertyName = "ImportDay";

            dtgvThongKe.Columns[9].HeaderText = "NCC";
            dtgvThongKe.Columns[9].DataPropertyName = "SupplierName";
        }
        void EditPenalize()
        {
            dtgvThongKe.DefaultCellStyle.Font = new Font("Times New Roman", 9);
            dtgvThongKe.Columns[0].HeaderText = "Mã Phạt";
            dtgvThongKe.Columns[0].DataPropertyName = "PenalizeID";

            dtgvThongKe.Columns[1].HeaderText = "Tên Thành Viên";
            dtgvThongKe.Columns[1].DataPropertyName = "MemberName";

            dtgvThongKe.Columns[2].HeaderText = "Tên Sách";
            dtgvThongKe.Columns[2].DataPropertyName = "NameBook";

            dtgvThongKe.Columns[3].HeaderText = "Số Ngày Trễ";
            dtgvThongKe.Columns[3].DataPropertyName = "NumberDay";

            dtgvThongKe.Columns[4].HeaderText = "Ngày Nộp";
            dtgvThongKe.Columns[4].DataPropertyName = "Date";

            dtgvThongKe.Columns[5].HeaderText = "Tiền Phạt";
            dtgvThongKe.Columns[5].DataPropertyName = "PricePenalize";

        }
        void Member()
        {
            dtgvThongKe.DefaultCellStyle.Font = new Font("Times New Roman", 9);
            dtgvThongKe.Columns[0].HeaderText = "Mã Mượn";
            dtgvThongKe.Columns[0].DataPropertyName = "BorrowID";

            dtgvThongKe.Columns[1].HeaderText = "Tên Sách";
            dtgvThongKe.Columns[1].DataPropertyName = "NameBook";

            dtgvThongKe.Columns[2].HeaderText = "Tên Thành Viên";
            dtgvThongKe.Columns[2].DataPropertyName = "NameMember";

            dtgvThongKe.Columns[3].HeaderText = "Số Lượng";
            dtgvThongKe.Columns[3].DataPropertyName = "Number";

            dtgvThongKe.Columns[4].HeaderText = "Ngày Mượn";
            dtgvThongKe.Columns[4].DataPropertyName = "BorrowDay";

            dtgvThongKe.Columns[5].HeaderText = "Ngày Trả";
            dtgvThongKe.Columns[5].DataPropertyName = "PayDay";

        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            string Squi1 = "1/1/" + cbYear.Text;
            string Equi1 = "3/31/" + cbYear.Text;

            string Squi2 = "4/1/" + cbYear.Text;
            string Equi2 = "6/30/" + cbYear.Text;

            string Squi3 = "7/1/" + cbYear.Text;
            string Equi3 = "9/30/" + cbYear.Text;

            string Squi4 = "10/1/" + cbYear.Text;
            string Equi4 = "12/31/" + cbYear.Text;

            if (rdbtnQuy1.Checked == true || rdbtnQuy2.Checked == true || rdbtnQuy3.Checked == true || rdbtnQuy4.Checked == true)
            {
                if (!string.IsNullOrEmpty(cbYear.Text))
                {
                    if (rdbtnImportBook.Checked)
                    {
                        if (ImportBooksDAO.Instance.CountAllImportBook() > 0)
                        {

                            txtTotal.ResetText();
                            if (rdbtnQuy1.Checked)
                            {
                                dtgvThongKe.DataSource = LoadStatisticsDAO.Instance.GetListStatisticsMonth(Convert.ToDateTime(Squi1), Convert.ToDateTime(Equi1));
                                if (LoadStatisticsDAO.Instance.CountImportBookHaveDate(Convert.ToDateTime(Squi1), Convert.ToDateTime(Equi1)) > 0)
                                {
                                    txtTotal.Text = LoadStatisticsDAO.Instance.SumTotalDate(Convert.ToDateTime(Squi1), Convert.ToDateTime(Equi1)).ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Không có sách nhập trong quí này");
                                }
                            }
                            else if (rdbtnQuy2.Checked)
                            {
                                dtgvThongKe.DataSource = LoadStatisticsDAO.Instance.GetListStatisticsMonth(Convert.ToDateTime(Squi2), Convert.ToDateTime(Equi2));
                                if (LoadStatisticsDAO.Instance.CountImportBookHaveDate(Convert.ToDateTime(Squi2), Convert.ToDateTime(Equi2)) > 0)
                                {
                                    txtTotal.Text = LoadStatisticsDAO.Instance.SumTotalDate(Convert.ToDateTime(Squi2), Convert.ToDateTime(Equi2)).ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Không có sách nhập trong quí này");
                                }
                            }
                            else if (rdbtnQuy3.Checked)
                            {
                                dtgvThongKe.DataSource = LoadStatisticsDAO.Instance.GetListStatisticsMonth(Convert.ToDateTime(Squi3), Convert.ToDateTime(Equi3));
                                if (LoadStatisticsDAO.Instance.CountImportBookHaveDate(Convert.ToDateTime(Squi3), Convert.ToDateTime(Equi3)) > 0)
                                {
                                    txtTotal.Text = LoadStatisticsDAO.Instance.SumTotalDate(Convert.ToDateTime(Squi3), Convert.ToDateTime(Equi3)).ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Không có sách nhập trong quí này");
                                }
                            }
                            else if (rdbtnQuy4.Checked)
                            {
                                dtgvThongKe.DataSource = LoadStatisticsDAO.Instance.GetListStatisticsMonth(Convert.ToDateTime(Squi4), Convert.ToDateTime(Equi4));
                                if (LoadStatisticsDAO.Instance.CountImportBookHaveDate(Convert.ToDateTime(Squi4), Convert.ToDateTime(Equi4)) > 0)
                                {
                                    txtTotal.Text = LoadStatisticsDAO.Instance.SumTotalDate(Convert.ToDateTime(Squi4), Convert.ToDateTime(Equi4)).ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Không có sách nhập trong quí này");
                                }
                            }
                            EditColumn();
                        }
                        else
                        {
                            MessageBox.Show("Hiện vẫn chưa có sách nhập ");
                        }
                    }
                    if (rdbtnTre.Checked)
                    {
                        if (DetailPenalizeDAO.Instance.CountAllPenalize() > 0)
                        {
                            txtTotal.ResetText();
                            dtgvThongKe.DataSource = "";
                            if (rdbtnQuy1.Checked)
                            {
                                dtgvThongKe.DataSource = DetailPenalizeDAO.Instance.GetListPenalizeNotNullByDateFrom(Convert.ToDateTime(Squi1), Convert.ToDateTime(Equi1));
                                if (DetailPenalizeDAO.Instance.CountPenalizeHaveDate(Convert.ToDateTime(Squi1), Convert.ToDateTime(Equi1)) > 0)
                                {
                                    //Tổng giá tiền phạt theo thời hạn
                                    txtTotal.Text = DetailPenalizeDAO.Instance.SumTotalDate(Convert.ToDateTime(Squi1), Convert.ToDateTime(Equi1)).ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Không có thành viên phạt trong quí này!");
                                }
                            }
                            else if (rdbtnQuy2.Checked)
                            {
                                dtgvThongKe.DataSource = DetailPenalizeDAO.Instance.GetListPenalizeNotNullByDateFrom(Convert.ToDateTime(Squi2), Convert.ToDateTime(Equi2));
                                if (DetailPenalizeDAO.Instance.CountPenalizeHaveDate(Convert.ToDateTime(Squi2), Convert.ToDateTime(Equi2)) > 0)
                                {
                                    //Tổng giá tiền phạt theo thời hạn
                                    txtTotal.Text = DetailPenalizeDAO.Instance.SumTotalDate(Convert.ToDateTime(Squi2), Convert.ToDateTime(Equi2)).ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Không có thành viên phạt trong quí này!");
                                }
                            }
                            else if (rdbtnQuy3.Checked)
                            {
                                dtgvThongKe.DataSource = DetailPenalizeDAO.Instance.GetListPenalizeNotNullByDateFrom(Convert.ToDateTime(Squi3), Convert.ToDateTime(Equi3));
                                if (DetailPenalizeDAO.Instance.CountPenalizeHaveDate(Convert.ToDateTime(Squi3), Convert.ToDateTime(Equi3)) > 0)
                                {
                                    //Tổng giá tiền phạt theo thời hạn
                                    txtTotal.Text = DetailPenalizeDAO.Instance.SumTotalDate(Convert.ToDateTime(Squi3), Convert.ToDateTime(Equi3)).ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Không có thành viên phạt trong quí này!");
                                }
                            }
                            else if (rdbtnQuy4.Checked)
                            {
                                dtgvThongKe.DataSource = DetailPenalizeDAO.Instance.GetListPenalizeNotNullByDateFrom(Convert.ToDateTime(Squi4), Convert.ToDateTime(Equi4));
                                if (DetailPenalizeDAO.Instance.CountPenalizeHaveDate(Convert.ToDateTime(Squi4), Convert.ToDateTime(Equi4)) > 0)
                                {
                                    //Tổng giá tiền phạt theo thời hạn
                                    txtTotal.Text = DetailPenalizeDAO.Instance.SumTotalDate(Convert.ToDateTime(Squi4), Convert.ToDateTime(Equi4)).ToString();
                                }
                                else
                                {
                                    MessageBox.Show("Không có thành viên phạt trong quí này!");
                                }
                            }
                            EditPenalize();
                        }
                        else
                        {
                            MessageBox.Show("Hiện vẫn chưa có ai bị phạt");
                        }
                    }
                    if (rdBtnMember.Checked)
                    {
                        if (BookBorrowDAO.Instance.CountAllBookBorrow() > 0)
                        {
                            txtTotal.Text = "0" +
                                "";
                            if (rdbtnQuy1.Checked)
                            {

                                dtgvThongKe.DataSource = InfoBookBorrowDAO.Instance.GetListBookPayDate(Convert.ToDateTime(Squi1), Convert.ToDateTime(Equi1));
                                if (BookBorrowDAO.Instance.CountAllBookBorrowDate(Convert.ToDateTime(Squi1), Convert.ToDateTime(Equi1)) == 0)
                                {
                                    MessageBox.Show("Không có thành viên mượn trong quí này");
                                }

                            }
                            else if (rdbtnQuy2.Checked)
                            {

                                dtgvThongKe.DataSource = InfoBookBorrowDAO.Instance.GetListBookPayDate(Convert.ToDateTime(Squi2), Convert.ToDateTime(Equi2));
                                if (BookBorrowDAO.Instance.CountAllBookBorrowDate(Convert.ToDateTime(Squi2), Convert.ToDateTime(Equi2)) == 0)
                                {
                                    MessageBox.Show("Không có thành viên mượn trong quí này");
                                }
                            }
                            else if (rdbtnQuy3.Checked)
                            {

                                dtgvThongKe.DataSource = InfoBookBorrowDAO.Instance.GetListBookPayDate(Convert.ToDateTime(Squi3), Convert.ToDateTime(Equi3));
                                if (BookBorrowDAO.Instance.CountAllBookBorrowDate(Convert.ToDateTime(Squi3), Convert.ToDateTime(Equi3)) == 0)
                                {
                                    MessageBox.Show("Không có thành viên mượn trong quí này");
                                }
                            }
                            else if (rdbtnQuy4.Checked)
                            {

                                dtgvThongKe.DataSource = InfoBookBorrowDAO.Instance.GetListBookPayDate(Convert.ToDateTime(Squi4), Convert.ToDateTime(Equi4));
                                if (BookBorrowDAO.Instance.CountAllBookBorrowDate(Convert.ToDateTime(Squi4), Convert.ToDateTime(Equi4)) == 0)
                                {
                                    MessageBox.Show("Không có thành viên mượn trong quí này");
                                }
                            }
                            Member();
                        }
                        else
                        {
                            MessageBox.Show("Hiện vẫn chưa có thành viên mượn sách ");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Vui Lòng chọn năm thống kê");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thời gian thống kê");
            }
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            string Squi1 = "1/1/" + cbYear.Text;
            string Equi1 = "3/31/" + cbYear.Text;

            string Squi2 = "4/1/" + cbYear.Text;
            string Equi2 = "6/30/" + cbYear.Text;

            string Squi3 = "7/1/" + cbYear.Text;
            string Equi3 = "9/30/" + cbYear.Text;

            string Squi4 = "10/1/" + cbYear.Text;
            string Equi4 = "12/31/" + cbYear.Text;
            int tmp = 0;
            if(rdbtnQuy1.Checked == true || rdbtnQuy2.Checked == true || rdbtnQuy3.Checked == true || rdbtnQuy4.Checked == true)
            {
                if(!string.IsNullOrEmpty(cbYear.Text))
                {
                    if (rdbtnTre.Checked)
                    {
                        int check = 3;
                        if(rdbtnQuy1.Checked)
                        {
                            if (DetailPenalizeDAO.Instance.CountPenalizeHaveDate(Convert.ToDateTime(Squi1), Convert.ToDateTime(Equi1)) > 0)
                            {
                                tmp = 1;
                            }
                                
                        }else if(rdbtnQuy2.Checked)
                        {
                            if (DetailPenalizeDAO.Instance.CountPenalizeHaveDate(Convert.ToDateTime(Squi2), Convert.ToDateTime(Equi2)) > 0)
                            {
                                tmp = 2;
                            }
                        }
                        else if (rdbtnQuy3.Checked)
                        {
                            if (DetailPenalizeDAO.Instance.CountPenalizeHaveDate(Convert.ToDateTime(Squi3), Convert.ToDateTime(Equi3)) > 0)
                            {
                                tmp = 3;
                            }
                        }
                        else if (rdbtnQuy4.Checked)
                        {
                            if (DetailPenalizeDAO.Instance.CountPenalizeHaveDate(Convert.ToDateTime(Squi4), Convert.ToDateTime(Equi4)) > 0)
                            {
                                tmp = 4;
                            }
                        }
                        if(tmp > 0)
                        {
                            FormStatisticChart formStatisticChart = new FormStatisticChart(tmp,Convert.ToInt32(cbYear.Text),check);
                            formStatisticChart.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Không có thành viên phạt trong quí này");
                        }
                    }
                    if(rdbtnImportBook.Checked)
                    {
                        int check = 2;
                        if (rdbtnQuy1.Checked)
                        {
                            if (LoadStatisticsDAO.Instance.CountImportBookHaveDate(Convert.ToDateTime(Squi1), Convert.ToDateTime(Equi1)) > 0)
                            {
                                tmp = 1;
                            }    
                        }
                        else if (rdbtnQuy2.Checked)
                        {
                            if (LoadStatisticsDAO.Instance.CountImportBookHaveDate(Convert.ToDateTime(Squi2), Convert.ToDateTime(Equi2)) > 0)
                            {
                                tmp = 2;
                            }
                        }
                        else if (rdbtnQuy3.Checked)
                        {
                            if (LoadStatisticsDAO.Instance.CountImportBookHaveDate(Convert.ToDateTime(Squi3), Convert.ToDateTime(Equi3)) > 0)
                            {
                                tmp = 3;
                            }
                        }
                        else if (rdbtnQuy4.Checked)
                        {
                            if (LoadStatisticsDAO.Instance.CountImportBookHaveDate(Convert.ToDateTime(Squi4), Convert.ToDateTime(Equi4)) > 0)
                            {
                                tmp = 4;
                            }
                        }
                        if (tmp > 0)
                        {
                            FormStatisticChart formStatisticChart = new FormStatisticChart(tmp, Convert.ToInt32(cbYear.Text), check);
                            formStatisticChart.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Không có sách nhập trong quí này!");
                        }
                    }
                    if (rdBtnMember.Checked)
                    {
                        int check = 1;
                        if (rdbtnQuy1.Checked)
                        {
                            if (BookBorrowDAO.Instance.CountAllBookBorrowDate(Convert.ToDateTime(Squi1), Convert.ToDateTime(Equi1)) > 0)
                            {
                                tmp = 1;
                            }
                                
                        }
                        else if (rdbtnQuy2.Checked)
                        {
                            if (BookBorrowDAO.Instance.CountAllBookBorrowDate(Convert.ToDateTime(Squi2), Convert.ToDateTime(Equi2)) > 0)
                            {
                                tmp = 2;
                            }
                        }
                        else if (rdbtnQuy3.Checked)
                        {
                            if (BookBorrowDAO.Instance.CountAllBookBorrowDate(Convert.ToDateTime(Squi3), Convert.ToDateTime(Equi3)) > 0)
                            {
                                tmp = 3;
                            }
                        }
                        else if (rdbtnQuy4.Checked)
                        {
                            if (BookBorrowDAO.Instance.CountAllBookBorrowDate(Convert.ToDateTime(Squi4), Convert.ToDateTime(Equi4)) > 0)
                            {
                                tmp = 4;
                            }
                        }
                        if (tmp > 0)
                        {
                            FormStatisticChart formStatisticChart = new FormStatisticChart(tmp, Convert.ToInt32(cbYear.Text), check);
                            formStatisticChart.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Không có thành viên mượn trong quí này!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hãy chọn năm thống kê");
                }
            }
            else
            {
                MessageBox.Show("Chọn khoảng thời gian trước khi thống kê biểu đồ");
            }
        }
    }
}
