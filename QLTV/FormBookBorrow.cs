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
    public partial class FormBookBorrow : Form
    {
        BindingSource  BorrowList = new BindingSource();
        public FormBookBorrow()
        {
            InitializeComponent();
            LoadAll();
        }
        void LoadAll()
        {
            dtgvBookBorrow.DataSource = BorrowList;
            LoadListBookBorrow();
            LoadBookIntoCombobox(cbNameBook);
            LoadMemberIntoCombobox(cbMemberBorrow);
        }
        void LoadBookIntoCombobox(ComboBox cb)
        {
            //Lấy danh sách sách
            cb.DataSource = BookDAO.Instance.GetListBook();
            cb.DisplayMember = "NameBook";
        }
        void LoadMemberIntoCombobox(ComboBox cb)
        {
            //Lấy danh sách thàn viên
            cb.DataSource = MemberDAO.Instance.GetLoadMember();
            cb.DisplayMember = "MemberName";
        }
        void LoadListBookBorrow()
        {
            //Lấy danh sách sách muợn
            BorrowList.DataSource = InfoBookBorrowDAO.Instance.GetListBookBorrow();
            dtgvBookBorrow.DefaultCellStyle.Font = new Font("Times New Roman", 10);
        }

        private void btnAddBookBorrow_Click(object sender, EventArgs e)
        {
            //Kiểm tra thông tin mượn có thiếu không
            if(!string.IsNullOrEmpty(cbMemberBorrow.Text) && !string.IsNullOrEmpty(cbNameBook.Text) && !string.IsNullOrEmpty(nmNumberBorrow.Value.ToString()))
            {
                int idMember = (cbMemberBorrow.SelectedItem as Member).MemberID;
                int idBook = (cbNameBook.SelectedItem as Book).BookID;
                int number = (int)nmNumberBorrow.Value;
                DateTime dateborrow = dtpkBorrowDay.Value;

                //Lấy số lượng sách trong kho 
                int quanlity = BookDAO.Instance.GetQuanlityBook(idBook);

                //Tính số sách còn lại sau khi mượn
                int remaining = quanlity - number;

                //kiểm tra thành viên còn hạn hay ko
                if (MemberDAO.Instance.CheckMemberDate(idMember) > 0)
                {
                    //Kiểm tra thành viên đã nộp phạt đầy đủ chưa
                    if (DetailPenalizeDAO.Instance.CheackMember(idMember) == 0)
                    {
                        //Xét sách trong kho còn đủ k và số sách còn lại khi cho mượn có đúng k
                        if (quanlity > 0 && remaining >= 0)
                        {
                            if (MessageBox.Show("Bạn có chắc muốn cho mượn?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                //Kiểm tra xem người dung đã mượn sách này chưa 
                                if (BookBorrowDAO.Instance.GetCountBookBorrowByIDMemberandBook(idMember, idBook) > 0)
                                {
                                    //Lấy Id phiếu mượn mà thành viên đã mượn để cập nhập thêm số lượng
                                    int a = BookBorrowDAO.Instance.GetBookBorrowByIDMemberandBook(idMember, idBook);
                                    //Cập nhập số lượng sách mượn và cập nhập số sách trong kho sau khi cho mượn
                                    if (DetailBookBorrowDAO.Instance.UpdateQuanlityBookBorrow(a, number) && BookDAO.Instance.UpdateBookAfterBorrow(idBook, remaining))
                                    {
                                        MessageBox.Show("Mượn Thành Công");
                                        LoadListBookBorrow();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Mượn Thất Bại");
                                    }
                                }
                                else
                                {
                                    //Nếu thành viên chưa mượn sách thì tạo phiếu mượn mới
                                    if (BookBorrowDAO.Instance.InsertBookBorrow(dateborrow, idMember))
                                    {
                                        //Lấy id phiếu mượn vừa tạo
                                        int idBorrow = BookBorrowDAO.Instance.MaxIdBookBorrow();

                                        //Tạo chi tiết mượn mới và cập nhập lại sách sau khi mượn
                                        if (DetailBookBorrowDAO.Instance.InsertDetailBookBorrow(number, idBook, idBorrow) && BookDAO.Instance.UpdateBookAfterBorrow(idBook, remaining))
                                        {
                                            MessageBox.Show("Mượn Thành Công");
                                            LoadListBookBorrow();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Mượn Thất Bại");
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Số lượng sách không đủ!", "Thông Báo", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thành viên vẫn chưa nộp phạt");
                    }
                }
                else
                {
                    MessageBox.Show("Thành viên đã hết hạn.Hãy gia hạn thẻ!");
                }
            }
            else
            {
                MessageBox.Show("Không đủ thông tin để mượn sách");
            }
        }
    }
}
