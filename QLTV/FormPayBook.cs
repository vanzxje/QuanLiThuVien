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
    public partial class FormPayBook : Form
    {
        public FormPayBook()
        {
            InitializeComponent();
            LoadAll();
        }
        void LoadAll()
        {
            LoadMemberIntoCombobox(cbPayMember); 
            LoadPayBook();
        }
        void LoadPayBook()
        {
            //Load danh sách sách đã được trả
            dtgvPayBook.DataSource = InfoBookBorrowDAO.Instance.GetListBookPay();
            dtgvPayBook.DefaultCellStyle.Font = new Font("Times New Roman", 10);
        }
        void LoadMemberIntoCombobox(ComboBox cb)
        {
            //hiển thị danh sách thành viên đang mượn sách 
            cb.DataSource = MemberDAO.Instance.GetLoadMemberBookBorrow();
            cb.DisplayMember = "MemberName";
        }
        void LoadBookByIDMember(ComboBox cb)
        {
            int id = (cbPayMember.SelectedItem as Member).MemberID;
            //kiểm tra có thành viên nào mượn sách k nếu không không load lên (tránh lỗi loadcombobox)
            if (id > 0)
            {
                cb.DataSource = BookDAO.Instance.GetListBookByIdMember(id);
                cb.DisplayMember = "NameBook";
            }

        }

        private void cbPayMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBookByIDMember(cbPayBook);

        }

        private void btnPayBook_Click(object sender, EventArgs e)
        {
            
            if(!string.IsNullOrEmpty(txtBorrowID.Text) && !string.IsNullOrEmpty(cbPayMember.Text) && !string.IsNullOrEmpty(cbPayBook.Text))
            {
                int idBorrow = Convert.ToInt32(txtBorrowID.Text);
                int idMember = (cbPayMember.SelectedItem as Member).MemberID;
                int idBook = (cbPayBook.SelectedItem as Book).BookID;
                DateTime date = dtpkPayDayBook.Value;

                //Lấy ngày thành viên mượn sách
                DateTime borrowDay = InfoBookBorrowDAO.Instance.GetDateTimeBorrowDay(idBorrow);

                int number = Convert.ToInt32(nmPayNumber.Value);
                //Lấy số lượng sách trong kho để cập nhập sau khi trả
                int quanlity = BookDAO.Instance.GetQuanlityBook(idBook);

                //Kiểm tra ngày mượn và trả có phù hợp k 
                if(date > borrowDay)
                {
                    //Kiểm tra số lượng sách trả có phù hợp k
                    if (DetailBookBorrowDAO.Instance.GetNumberBookBorrow(idMember, idBook) == nmPayNumber.Value)
                    {
                        //Cập nhập lại sách sau khi trả (dùng chung hàm với hàm cập nhập mượn sách)
                        if (BookDAO.Instance.UpdateBookAfterBorrow(idBook, number + quanlity))
                        {
                            //Cập nhập thời gian sách trả
                            if (BookBorrowDAO.Instance.UpdateBookBorrowAfterPay(idBorrow, date))
                            {
                                MessageBox.Show("Trả thành công!", "Thông Báo");
                                cbPayMember.ResetText();
                                cbPayBook.ResetText();
                                txtBorrowID.ResetText();
                                nmPayNumber.ResetText();
                                dtpkPayDayBook.ResetText();
                                LoadMemberIntoCombobox(cbPayMember);
                                LoadPayBook();
                                //nmPayNumber.Value = DetailBookBorrowDAO.Instance.GetNumberBookBorrow(idMember, idBook);
                                TimeSpan time = date - borrowDay;
                                int TotalDay = time.Days;
                                int numberday = TotalDay - 14;
                                if (TotalDay > 14)
                                {
                                    //Tạo phiếu phạt khi trả trễ hạn và phạt 1000 nếu trễ 1 ngày
                                    if (DetailPenalizeDAO.Instance.InsertPenalize(idMember, idBorrow, numberday, 1000 * numberday))
                                    {
                                        MessageBox.Show("Thành Viên Bị Phạt Do Trễ Hạn");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Thành Viên Trả Đúng Hẹn");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Thất Bại");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không Lấy được sách");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Số lượng sách trả không đúng?", "Thông Báo");
                    }
                }
                else
                {
                    MessageBox.Show("Ngày trả không thể trước ngày hẹn!");
                }
            }
            else
            {
                MessageBox.Show("Không đủ thông tin trả sách!");
            }

            
        }
        //Khi tên sách có sự thay đổi gán lại số lượng sách và id phiếu mượn
        private void cbPayBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idMember = (cbPayMember.SelectedItem as Member).MemberID;
            int idBook = (cbPayBook.SelectedItem as Book).BookID;

            //Lấy mã phiêu mượn để gán vào mã phiếu trên form
            int id = BookBorrowDAO.Instance.GetBookBorrowByIDMemberandBook(idMember, idBook);
            txtBorrowID.Text = id.ToString();

            //Lấy số sách mượn
            nmPayNumber.Value = DetailBookBorrowDAO.Instance.GetNumberBookBorrow(idMember, idBook);
        }
    }
}
