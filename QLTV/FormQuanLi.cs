using QLTV.DAO;
using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace QLTV
{
    public partial class FormQuanLi : Form
    {
        BindingSource CateList = new BindingSource();
        BindingSource AuthorList = new BindingSource();
        BindingSource MemberList = new BindingSource();
        BindingSource BookList = new BindingSource();
        BindingSource BorrowList = new BindingSource();
        BindingSource AreaList = new BindingSource();
        BindingSource RowList = new BindingSource();
        BindingSource CompartmentList = new BindingSource();
        BindingSource SupplierList = new BindingSource();
        BindingSource PayBook = new BindingSource();
        BindingSource ImportBook = new BindingSource();
        BindingSource PenalizeList = new BindingSource();
        public FormQuanLi()
        {
            InitializeComponent();
            LoadAll();
            
        }
        void LoadAll()
        {
            dtgvCate.DataSource = CateList;
            dtgvAuthor.DataSource = AuthorList;
            dtgvMember.DataSource = MemberList;
            dtgvBook.DataSource = BookList;
            dtgvBorrowBook.DataSource = BorrowList;
            dtgvAreaBook.DataSource = AreaList;
            dtgvCompartment.DataSource = CompartmentList;
            dtgvRowBook.DataSource = RowList;
            dtgvSupplier.DataSource = SupplierList;
            //dtgvBookPay.DataSource = PayBook;
            dtgvImportBooks.DataSource = ImportBook;
            DateTime today = DateTime.Now;
            dtpStartMember.Value =today;
            dtpEndMember.Value = today.AddDays(30);
            dtgvPenalize.DataSource = PenalizeList;
            LoadCate();
            CategoryBinding();

            LoadAuthor();
            AuthorBinding();

            LoadMember();
            MemberBinding();

            LoadCategoryIntoCombobox(cbCateName);
            LoadAuthorIntoCombobox(cbNameAuthor);
            LoadAreaIntoCombobox(cbAreaBook);
            LoadRowIntoCombobox(cbRowBook);
            LoadCompartmentIntoCombobox(cbCompartment);

            LoadListBook();
            BindingBookList();

            LoadALLBorrowBook();
            BindingBorrowBookList();

            LoadArea();
            BindingArea();

            LoadRow();
            BindingRow();

            LoadCompartment();
            BindingCompartment();

            //LoadPlacePutDetal();

            LoadSupplier();
            BindingSupplier();

            //LoadAllPayBook();
            LoadALLImportBook();

            LoadAllPenalize();
        }
        #region Category
        List<Category> SearchCateByName(string name)
        {
            List<Category> list = CategoryDAO.Instance.SearchCateByName(name);
            return list;
        }
        void LoadCate()
        {
            CateList.DataSource = CategoryDAO.Instance.LoadCategory();
            dtgvCate.DefaultCellStyle.Font = new Font("Times New Roman", 10);

        }
        void CategoryBinding()
        {
            txtCate.DataBindings.Add(new Binding("Text", CateList, "NameCate", true, DataSourceUpdateMode.Never));
        }

        private void btnAddCate_Click(object sender, EventArgs e)
        {
            string name = txtCate.Text;

            if (MessageBox.Show("Bạn có chắc chắn muốn thêm ", "Thông báo!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if(name != "")
                {
                    if (CategoryDAO.Instance.InsertCate(name))
                    {
                        MessageBox.Show("Thêm dữ liệu thành công!");
                        LoadCate();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Tên Loại Không Được Trống");
                }
            }
        }

        private void btnUpdateCate_Click(object sender, EventArgs e)
        {
            string name = txtCate.Text;
            int id = Convert.ToInt32(dtgvCate.SelectedCells[0].Value.ToString());
            if (MessageBox.Show("Bạn có chắc chắn muốn sửa ", "Thông báo!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if(name != "")
                {
                    if (CategoryDAO.Instance.UpdateCate(name, id))
                    {
                        MessageBox.Show("Cập nhập thành công!");
                        LoadCate();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhập thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Tên thể loại không được để trống");
                }
            }
        }

        private void btnDeleteCate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dtgvCate.SelectedCells[0].Value.ToString());
            if (MessageBox.Show("Bạn có chắc chắn xóa ", "Thông báo!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                if (BookDAO.Instance.GetAllBookByIdCate(id) == 0)
                {
                    if (CategoryDAO.Instance.DeleteCate(id))
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadCate();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Vẫn còn sách có thể loại này!Không thể xóa.");
                }
            }
        }
        private void btnSearchCate_Click_1(object sender, EventArgs e)
        {
            dtgvCate.DataSource = SearchCateByName(txtSearchCate.Text.ToString());
        }

        #endregion
        #region Author
        void LoadAuthor ()
        {
            AuthorList.DataSource = AuthorDAO.Instance.GetAuthor();
            dtgvAuthor.DefaultCellStyle.Font = new Font("Times New Roman", 10);
        }
        void AuthorBinding()
        {
            txtNameAuthor.DataBindings.Add(new Binding("Text", AuthorList, "AuthorName", true, DataSourceUpdateMode.Never));
            txtGender.DataBindings.Add(new Binding("Text", AuthorList, "Gender", true, DataSourceUpdateMode.Never));
            txtHomeLand.DataBindings.Add(new Binding("Text", AuthorList, "HomeLand", true, DataSourceUpdateMode.Never));
        }
        private void btnAddAuthor_Click(object sender, EventArgs e)
        {
            string nameauthor = txtNameAuthor.Text;
            string gender = txtGender.Text;
            string homeland = txtHomeLand.Text;

            if (MessageBox.Show("Bạn có muốn thêm tác giả?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if(nameauthor != "" && gender !="" && homeland != "")
                {
                    if (AuthorDAO.Instance.InsertAuthor(nameauthor, gender, homeland))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo");
                        LoadAuthor();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo");
                    }
                }
                else
                {
                    MessageBox.Show("Không đủ thông tin để thêm tác giả");
                }
            }
            
        }
        private void btnEditAuthor_Click(object sender, EventArgs e)
        {
            string nameauthor = txtNameAuthor.Text;
            string gender = txtGender.Text;
            string homeland = txtHomeLand.Text;
            int id = Convert.ToInt32(dtgvAuthor.SelectedCells[0].Value.ToString());
            if (MessageBox.Show("Bạn có muốn sửa tác giả?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if(nameauthor != "" && gender !="" && homeland != "")
                {
                    if (AuthorDAO.Instance.EditAuthor(id, nameauthor, gender, homeland))
                    {
                        MessageBox.Show("Cập nhập thành công!", "Thông báo");
                        LoadAuthor();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhập thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Không đủ thông tin để sửa tác giả");
                }
            }
        }

        private void btnDeleteAuthor_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dtgvAuthor.SelectedCells[0].Value.ToString());
            if (MessageBox.Show("Bạn có xóa tác giả?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if(BookDAO.Instance.GetAllBookByIdAuthor(id) == 0)
                {
                    if (AuthorDAO.Instance.DeleteAuthor(id))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadAuthor();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Vẫn còn sách của tác giả này");
                }
            }
        }
        private void btnSearchAuthor_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchAuthor.Text))
            {
                AuthorList.DataSource = AuthorDAO.Instance.SearchAuthorName(txtSearchAuthor.Text);
            }
            else
            {
                LoadAuthor();
            }
        }
        #endregion
        #region Member
        void LoadMember()
        {
           MemberList.DataSource = MemberDAO.Instance.GetLoadMember();
           dtgvMember.DefaultCellStyle.Font = new Font("Times New Roman", 10);
        }
        void MemberBinding()
        {
            txtNameMember.DataBindings.Add(new Binding("Text", MemberList, "MemberName", true, DataSourceUpdateMode.Never));
            txtPhoneMember.DataBindings.Add(new Binding("Text", MemberList, "PhoneNumber", true, DataSourceUpdateMode.Never));
            txtIdCard.DataBindings.Add(new Binding("Text", MemberList, "IDCard", true, DataSourceUpdateMode.Never));
            dtpStartMember.DataBindings.Add(new Binding("Value", MemberList, "StartDay", true, DataSourceUpdateMode.Never));
            dtpEndMember.DataBindings.Add(new Binding("Value", MemberList, "EndDay", true, DataSourceUpdateMode.Never));
        }
        private void btnSearchMember_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchMember.Text))
            {
                MemberList.DataSource = MemberDAO.Instance.SearchMember(txtSearchMember.Text);
            }
            else
            {
                
                LoadMember();
            }
        }
        private void btnAddMember_Click(object sender, EventArgs e)
        {
            string name = txtNameMember.Text;
            string phone = txtPhoneMember.Text;
            string idcard = txtIdCard.Text;
            DateTime start = dtpStartMember.Value;
            DateTime end = dtpEndMember.Value;
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(phone) &&!string.IsNullOrEmpty(idcard) )
            {
                if (MessageBox.Show("Bạn có muốn thêm thành viên!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if(start < end)
                    {
                        if (MemberDAO.Instance.AddMember(name, phone, idcard, start, end))
                        {
                            MessageBox.Show("Thêm thành công!");
                            LoadMember();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kiểm tra lại ngày của thẻ trước khi thêm");
                    }
                }
            }
            else
            {
                MessageBox.Show("Không đủ thông tin để thêm!");
            }
        }

        private void btnEditMember_Click(object sender, EventArgs e)
        {
            string name = txtNameMember.Text;
            string phone = txtPhoneMember.Text;
            string idcard = txtIdCard.Text;
            DateTime start = dtpStartMember.Value;
            DateTime end = dtpEndMember.Value;
            int id = Convert.ToInt32(dtgvMember.SelectedCells[0].Value.ToString());
            if(!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(idcard))
            {
                if (MessageBox.Show("Bạn có muốn sửa thành viên!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if(start < end)
                    {
                        if (MemberDAO.Instance.EditMember(id, name, phone, idcard, start, end))
                        {
                            MessageBox.Show("Sửa thành công!");
                            LoadMember();
                        }
                        else
                        {
                            MessageBox.Show("Sửa thất bại!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kiểm tra lại ngày của thẻ thành viên!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Không đủ thông tin để sửa");
            }
        }

        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dtgvMember.SelectedCells[0].Value.ToString());
            if (MessageBox.Show("Bạn có muốn xóa thành viên!", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (MemberDAO.Instance.DeleteMember(id))
                {
                    MessageBox.Show("Xóa thành công!");
                    LoadMember();
                    LoadALLBorrowBook();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void btnAddEndDay_Click(object sender, EventArgs e)
        {
            DateTime endDay = (DateTime)dtgvMember.SelectedCells[5].Value;
            int id = (int)dtgvMember.SelectedCells[0].Value;
            if(MessageBox.Show("Bạn có chắc muốn gia hạn 30 ngày cho thành viên này","Thông báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (endDay.Date < DateTime.Today.Date)
                {
                    if (MemberDAO.Instance.UpdateEndDay(id, DateTime.Today.AddDays(30)))
                    {
                        MessageBox.Show("Gia hạn thành công!");
                        LoadMember() ;
                    }
                    else
                    {
                        MessageBox.Show("Gia hạn thất bại!");
                    }
                }
                else
                {
                    if (MemberDAO.Instance.UpdateEndDay(id, endDay.AddDays(30)))
                    {
                        MessageBox.Show("Gia hạn thành công");
                        LoadMember() ;
                    }
                    else
                    {
                        MessageBox.Show("Gia hạn thất bại");
                    }
                }
            }
            
        }
        #endregion
        #region Book
        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.LoadCategory();
            cb.DisplayMember = "NameCate";
        }
        void LoadAuthorIntoCombobox(ComboBox comboBox)
        {
            comboBox.DataSource = AuthorDAO.Instance.GetAuthor();
            comboBox.DisplayMember = "AuthorName";
        }
        void LoadAreaIntoCombobox(ComboBox cb)
        {
            cb.DataSource = AreaDAO.Instance.GetListArea();
            cb.DisplayMember = "AreaName";
        }
        void LoadRowIntoCombobox(ComboBox cb)
        {
            cb.DataSource = RowDAO.Instance.GetListRow();
            cb.DisplayMember = "RowName";
        }
        void LoadCompartmentIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CompartmentDAO.Instance.GetListCompartment();
            cb.DisplayMember = "CompartmentName";
        }
        void LoadListBook()
        {
            BookList.DataSource = BookDAO.Instance.GetListBook();
            dtgvBook.DefaultCellStyle.Font = new Font("Times New Roman", 10);
        }
        void BindingBookList()
        {
            txtIdBook.DataBindings.Add("Text", BookList, "BookID", true, DataSourceUpdateMode.Never);
            txtBook.DataBindings.Add("Text", BookList, "NameBook", true, DataSourceUpdateMode.Never);
            nmNumber.DataBindings.Add("Value", BookList, "Quanlity", true, DataSourceUpdateMode.Never);
            txtYearPublish.DataBindings.Add("Text",BookList,"PublishYear",true,DataSourceUpdateMode.Never);
            txtIDPlacePut.DataBindings.Add("Text" ,BookList,"LocationID" , true, DataSourceUpdateMode.Never);
        }
        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchBook.Text))
            {
                if (rdbtnNameBook.Checked)
                {
                    BookList.DataSource = BookDAO.Instance.SearchBookByNameBook(txtSearchBook.Text);
                }
                if (rdbtnNameAuthor.Checked)
                {
                    BookList.DataSource = BookDAO.Instance.SearchBookByNameAuthor(txtSearchBook.Text);
                }
            }
            else
            {
                LoadListBook();
            }
        }
        private void txtIdBook_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtIdBook.Text))
                {
                    if (BookDAO.Instance.CountALLBook() > 0)
                    {
                        if (dtgvBook.SelectedCells.Count > 0)
                        {
                            if (BookDAO.Instance.CountSearchBookByNameBook(txtSearchBook.Text) > 0 || BookDAO.Instance.CountSearchBookByNameAuthor(txtSearchBook.Text) > 0)
                            {
                                int idCate = (int)dtgvBook.SelectedCells[0].OwningRow.Cells["Column12"].Value;
                                int idAuthor = (int)dtgvBook.SelectedCells[0].OwningRow.Cells["Column11"].Value;
                                Category category = CategoryDAO.Instance.GetCategoryByID(idCate);
                                Author author = AuthorDAO.Instance.GetAuthorById(idAuthor);
                                cbNameAuthor.SelectedItem = author;
                                cbCateName.SelectedItem = category;
                                int index1 = -1;
                                int i1 = 0;
                                int index2 = -1;
                                int i2 = 0;
                                foreach (Category item in cbCateName.Items)
                                {
                                    if (item.Cateid == category.Cateid)
                                    {
                                        index1 = i1;
                                        break;
                                    }
                                    i1++;
                                }
                                foreach (Author item in cbNameAuthor.Items)
                                {
                                    if (item.AuthorId == author.AuthorId)
                                    {
                                        index2 = i2;
                                        break;
                                    }
                                    i2++;
                                }
                                cbCateName.SelectedIndex = index1;
                                cbNameAuthor.SelectedIndex = index2;
                            }
                        }
                    }
                }
            }
            catch { }
        }
        private void txtIDPlacePut_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
               if(!string.IsNullOrEmpty(txtIDPlacePut.Text))
                {
                    if (BookDAO.Instance.CountALLBook() > 0)
                    {
                        if (dtgvBook.SelectedCells.Count > 0)
                        {
                            int idplace = Convert.ToInt32(txtIDPlacePut.Text);
                            Area area = AreaDAO.Instance.GetAreaByPlaceId(idplace);
                            Row row = RowDAO.Instance.GetRowByPlaceId(idplace);
                            Compartment compartment = CompartmentDAO.Instance.GetCompartmentById(idplace);
                            cbAreaBook.SelectedItem = area;
                            cbRowBook.SelectedItem = row;
                            cbCompartment.SelectedItem = compartment;
                            int index3 = -1;
                            int i3 = 0;
                            int index1 = -1;
                            int i1 = 0;
                            int index2 = -1;
                            int i2 = 0;
                            foreach (Area item in cbAreaBook.Items)
                            {
                                if (item.AreaID == area.AreaID)
                                {
                                    index1 = i1;
                                    break;
                                }
                                i1++;
                            }
                            foreach (Row item in cbRowBook.Items)
                            {
                                if (item.RowID == row.RowID)
                                {
                                    index2 = i2;
                                    break;
                                }
                                i2++;
                            }
                            foreach (Compartment item in cbCompartment.Items)
                            {
                                if (item.CompartmentID == compartment.CompartmentID)
                                {
                                    index3 = i3;
                                    break;
                                }
                                i3++;
                            }
                            cbAreaBook.SelectedIndex = index1;
                            cbRowBook.SelectedIndex = index2;
                            cbCompartment.SelectedIndex = index3;
                        }
                    }
                }
            }
            catch { }
        }
        private void btnEditBook_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBook.Text) && !string.IsNullOrEmpty(cbNameAuthor.Text) && !string.IsNullOrEmpty(cbCateName.Text) &&!string.IsNullOrEmpty(txtYearPublish.Text))
            {
                int id = Convert.ToInt32(txtIdBook.Text);
                string name = txtBook.Text;
                int quanlity = (int)nmNumber.Value;
                int idcate = (cbCateName.SelectedItem as Category).Cateid;
                int idauthor = (cbNameAuthor.SelectedItem as Author).AuthorId;
                int publishyear = Convert.ToInt32(txtYearPublish.Text);
                int idArea = (cbAreaBook.SelectedItem as Area).AreaID;
                int idRow = (cbRowBook.SelectedItem as Row).RowID;
                int idCom = (cbCompartment.SelectedItem as Compartment).CompartmentID;
                int idplace = (int)dtgvBook.SelectedCells[0].OwningRow.Cells["Column13"].Value;
                if (MessageBox.Show("Bạn có muốn sửa sách?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (BookDAO.Instance.UpdateBook(id, name, quanlity, idauthor, idcate, publishyear) && LocationDAO.Instance.UpdateLocation(idplace, idArea, idRow, idCom))
                    {
                        MessageBox.Show("Sửa thành công");
                        LoadListBook();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại");
                    }
                }
            }
            else
            {
                MessageBox.Show("Thiếu thông tin để sửa sách.");
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            int idbook = Convert.ToInt32(txtIdBook.Text);
            int idLocation = Convert.ToInt32(txtIDPlacePut.Text);
            if(MessageBox.Show("Bạn có chắc muốn xóa sách này?" + "\n"
                                +"Toàn bộ thông tin liên quan tới sách sẽ bị xóa!", "Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if(ImportBooksDAO.Instance.DeleteImportBookByBookID(idbook))
                {
                    if (BookBorrowDAO.Instance.CheckMemberHaveBookBorrow(idbook) > 0)
                    {
                        if (BookBorrowDAO.Instance.DeleteBookBorrowByIDBook(idbook))
                        {
                            if (BookDAO.Instance.DeleteBook(idbook))
                            {
                                if (LocationDAO.Instance.DeleteLocationDetail(idLocation))
                                {
                                    MessageBox.Show("Xóa Sách Thành Công");
                                    LoadListBook();
                                }
                                else
                                {
                                    MessageBox.Show("Xóa vị trí thất bại");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Xóa Sách Thất Bại");
                            }
                        }
                    }
                    else
                    {
                        if (BookDAO.Instance.DeleteBook(idbook))
                        {
                            if (LocationDAO.Instance.DeleteLocationDetail(idLocation))
                            {
                                MessageBox.Show("Xóa Sách Thành Công");
                                LoadListBook();
                            }
                            else
                            {
                                MessageBox.Show("Xóa vị trí thất bại");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Xóa Sách Thất Bại");
                        }
                    }
                }
            }
        }
        #endregion
        #region BookBorrow
        void LoadALLBorrowBook()
        {
            BorrowList.DataSource = InfoBookBorrowDAO.Instance.GetALLBookBorrow();
            dtgvBorrowBook.DefaultCellStyle.Font = new Font("Times New Roman", 10);
        }
        void LoadMemberBorrowIntoCb(ComboBox cb)
        {
            cb.DataSource = MemberDAO.Instance.GetLoadMember();
            cb.DisplayMember = "MemberName";
        }
        void LoadBookBorrowIntoCb(ComboBox cb)
        {
            cb.DataSource = BookDAO.Instance.GetListBook();
            cb.DisplayMember = "NameBook";
        }
        void BindingBorrowBookList()
        {
            txtNameBookBorrow.DataBindings.Add(new Binding("Text", BorrowList, "NameBook", true, DataSourceUpdateMode.Never));
            txtNameMemberBorrow.DataBindings.Add(new Binding("Text", BorrowList, "NameMember", true, DataSourceUpdateMode.Never));
            txtIDBorrow.DataBindings.Add(new Binding("Text", BorrowList, "BorrowID", true, DataSourceUpdateMode.Never));
            dateBookBorrow.DataBindings.Add(new Binding( "Text" , BorrowList , "BorrowDay",true, DataSourceUpdateMode.Never));
            datePayBook.DataBindings.Add(new Binding("Text" , BorrowList,"PayDay",true, DataSourceUpdateMode.Never));
            nmNumberBorrow.DataBindings.Add(new Binding("Value" , BorrowList , "NumBer" , true, DataSourceUpdateMode.Never));   
        }
        private void txtIDBorrow_TextChanged(object sender, EventArgs e)
        {
        }
        

        private void btnDeleteBorrowBook_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDBorrow.Text);
            if(MessageBox.Show("Bạn có chắc xóa phiếu này?","Thông Báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if(BookBorrowDAO.Instance.CheckPayBook(id) == 0)
                {
                    if (BookBorrowDAO.Instance.DeleteBookBorrow(id))
                    {
                        MessageBox.Show("Xóa thành công");
                        LoadALLBorrowBook();
                    }
                    else
                    {
                        MessageBox.Show("Xóa phiếu thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Sách vẫn chưa được trả");
                }
            }
        }
        private void btnSearchBookBorrow_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchBookBorrow.Text))
            {
                if (rdbtnSearchNameBookBorrow.Checked)
                {
                    BorrowList.DataSource = InfoBookBorrowDAO.Instance.SearchBookBorrowByNameBook(txtSearchBookBorrow.Text);
                }
                if (rdbtnSearchMemberBorrow.Checked)
                {
                    BorrowList.DataSource = InfoBookBorrowDAO.Instance.SearchBookBorrowByNameMember(txtSearchBookBorrow.Text);
                }

            }
            else
            {
                LoadALLBorrowBook();
            }
        }

        #endregion
        #region Area
        void LoadArea()
        {
            AreaList.DataSource = AreaDAO.Instance.GetListArea();
            dtgvAreaBook.DefaultCellStyle.Font = new Font("Times New Roman", 10);
        }
        void BindingArea()
        {
            txtAreaBook.DataBindings.Add(new Binding("Text", AreaList, "AreaName", true, DataSourceUpdateMode.Never));
        }
        private void btnDeleteArea_Click_1(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dtgvAreaBook.SelectedCells[0].Value);
            if (MessageBox.Show("Bạn có muốn xóa khu này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if(BookDAO.Instance.GetAllBookByIdArea(id) == 0)
                {
                    if(LocationDAO.Instance.CheckAreaInLocation(id) == 0)
                    {
                        if (AreaDAO.Instance.DeleteArea(id))
                        {
                            MessageBox.Show("Xóa Thành Công");
                            LoadArea();
                        }
                        else
                        {
                            MessageBox.Show("Xóa Thất Bại");
                        }
                    }
                    else
                    {
                        if (LocationDAO.Instance.DeleteAllLocationHaveArea(id))
                        {
                            if (AreaDAO.Instance.DeleteArea(id))
                            {
                                MessageBox.Show("Xóa Thành Công");
                                LoadArea();
                            }
                            else
                            {
                                MessageBox.Show("Xóa Thất Bại");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Khu này vẫn còn sách");
                }
            }
        }

        private void btnEditArea_Click_1(object sender, EventArgs e)
        {
            string name = txtAreaBook.Text;
            int id = Convert.ToInt32(dtgvAreaBook.SelectedCells[0].Value);
            if (MessageBox.Show("Bạn có muốn sửa khu này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (name != "")
                {
                    if (AreaDAO.Instance.UpdateArea(id, name))
                    {
                        MessageBox.Show("Sửa Thành Công");
                        LoadArea();
                    }
                    else
                    {
                        MessageBox.Show("Sửa Thất Bại");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy nhâp tên khu vực để sách!");
                }

            }
        }

        private void btnAddArea_Click_1(object sender, EventArgs e)
        {
            string name = txtAreaBook.Text;
           
            if (MessageBox.Show("Bạn có muốn thêm khu này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (name != "")
                {
                    if (AreaDAO.Instance.InsertArea(name))
                    {
                        MessageBox.Show("Thêm Thành Công");
                        LoadArea();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Thất Bại");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy nhâp tên khu vực để sách!");
                }


            }
        }
        #endregion
        #region Row
        void LoadRow()
        {
            RowList.DataSource = RowDAO.Instance.GetListRow();
            dtgvRowBook.DefaultCellStyle.Font = new Font("Times New Roman", 10);
        }
        void BindingRow()
        {
            txtRowBook.DataBindings.Add(new Binding("Text", RowList, "RowName", true, DataSourceUpdateMode.Never));
        }
        private void btnAddRowBook_Click(object sender, EventArgs e)
        {
            string name = txtRowBook.Text;
           
            if (MessageBox.Show("Bạn có muốn thêm hàng này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (name != "")
                {
                    if (RowDAO.Instance.InsertRow(name))
                    {
                        MessageBox.Show("Thêm Thành Công");
                        LoadRow();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Thất Bại");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy nhập tên hàng để sách!");
                }
                
            }
        }

        private void btnEditRowBook_Click(object sender, EventArgs e)
        {
            string name = txtRowBook.Text;
            int id = Convert.ToInt32(dtgvRowBook.SelectedCells[0].Value);
            if (MessageBox.Show("Bạn có muốn sửa hàng này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if(name != "")
                {
                    if (RowDAO.Instance.UpdateRow(id, name))
                    {
                        MessageBox.Show("Sửa Thành Công");
                        LoadRow();
                    }
                    else
                    {
                        MessageBox.Show("Sửa Thất Bại");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy nhập tên hàng để sách!");
                }
                
            }
        }

        private void btnDeleteRowBook_Click(object sender, EventArgs e)
        {
            string name = txtRowBook.Text;
            int id = Convert.ToInt32(dtgvRowBook.SelectedCells[0].Value);
            if (MessageBox.Show("Bạn có muốn xóa hàng này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (BookDAO.Instance.GetAllBookByIdRow(id) == 0)
                {
                    if (LocationDAO.Instance.CheckRowInLocation(id) == 0)
                    {
                        if (RowDAO.Instance.DeleteRow(id))
                        {
                            MessageBox.Show("Xóa Thành Công");
                            LoadRow();
                        }
                        else
                        {
                            MessageBox.Show("Xóa Thất Bại");
                        }
                    }
                    else
                    {
                        if (LocationDAO.Instance.DeleteAllLocationHaveRow(id))
                        {
                            if (RowDAO.Instance.DeleteRow(id))
                            {
                                MessageBox.Show("Xóa Thành Công");
                                LoadRow();
                            }
                            else
                            {
                                MessageBox.Show("Xóa Thất Bại");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hàng này vẫn còn sách");
                }
            }
        }
        #endregion
        #region Compartment
        void LoadCompartment()
        {
            CompartmentList.DataSource = CompartmentDAO.Instance.GetListCompartment();
            dtgvCompartment.DefaultCellStyle.Font = new Font("Times New Roman", 10);
        }
        void BindingCompartment()
        {
            txtCompartment.DataBindings.Add(new Binding("Text", CompartmentList, "CompartmentName", true, DataSourceUpdateMode.Never));
        }
        private void btnAddCompartment_Click(object sender, EventArgs e)
        {
            string name = txtCompartment.Text;
            
            if (MessageBox.Show("Bạn có muốn thêm ngăn này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (name != "")
                {
                    if (CompartmentDAO.Instance.InsertCompartment(name))
                    {
                        MessageBox.Show("Thêm Thành Công");
                        LoadCompartment();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Thất Bại");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy nhập tên ngăn vào");
                }
                
            }
        }

        private void btnEditCompartment_Click(object sender, EventArgs e)
        {
            string name = txtCompartment.Text;
            int id = Convert.ToInt32(dtgvCompartment.SelectedCells[0].Value);
            if (MessageBox.Show("Bạn có muốn sửa ngăn này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if(name != "")
                {
                    if (CompartmentDAO.Instance.UpdateCompartment(id, name))
                    {
                        MessageBox.Show("Sửa Thành Công");
                        LoadCompartment();
                    }
                    else
                    {
                        MessageBox.Show("Sửa Thất Bại");
                    }
                }
                else
                {
                    MessageBox.Show("Hãy nhập tên ngăn vào");
                }
                
            }
        }

        private void btnDeleteCompartment_Click(object sender, EventArgs e)
        {
            string name = txtCompartment.Text;
            int id = Convert.ToInt32(dtgvCompartment.SelectedCells[0].Value);
            if (MessageBox.Show("Bạn có muốn xóa ngăn này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if(BookDAO.Instance.GetAllBookByIdCompartment(id) == 0)
                {
                    if (LocationDAO.Instance.CheckCompartmentInLocation(id) == 0)
                    {
                        if (CompartmentDAO.Instance.DeleteCompartment(id))
                        {
                            MessageBox.Show("Xóa Thành Công");
                            LoadCompartment();
                        }
                        else
                        {
                            MessageBox.Show("Xóa Thất Bại");
                        }
                    }
                    else
                    {
                        if (LocationDAO.Instance.DeleteAllLocationHaveCompartment(id))
                        {
                            if (CompartmentDAO.Instance.DeleteCompartment(id))
                            {
                                MessageBox.Show("Xóa Thành Công");
                                LoadCompartment();
                            }
                            else
                            {
                                MessageBox.Show("Xóa Thất Bại");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ngăn này vẫn còn sách");
                }
            }
        }
        #endregion
        #region Supplier
        void LoadSupplier()
        {
            SupplierList.DataSource = SupplierDAO.Instance.GetListSuppliers();
            dtgvSupplier.DefaultCellStyle.Font = new Font("Times New Roman", 10);
        }
        void BindingSupplier()
        {
            txtNameSupplier.DataBindings.Add(new Binding("Text" , SupplierList , "SupplierName",true,DataSourceUpdateMode.Never));
            txtPhoneSupplier.DataBindings.Add(new Binding("Text", SupplierList, "Phone", true, DataSourceUpdateMode.Never));
            txtAddressSupplier.DataBindings.Add(new Binding("Text", SupplierList, "Address", true, DataSourceUpdateMode.Never));
        }
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            string name = txtNameSupplier.Text;
            string phone = txtPhoneSupplier.Text;
            string address = txtAddressSupplier.Text;
            if (MessageBox.Show("Bạn có muốn thêm nhà cung cấp này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if(name != "")
                {
                    if (SupplierDAO.Instance.InsertSupplier(name, phone, address))
                    {
                        MessageBox.Show("Thêm Thành Công");
                        LoadSupplier();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Thất Bại");
                    }
                }
                else
                {
                    MessageBox.Show("Tên không được trống");
                }
                
            }
        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            string name = txtNameSupplier.Text;
            string phone = txtPhoneSupplier.Text;
            string address = txtAddressSupplier.Text;
            int id = (int)dtgvSupplier.SelectedCells[0].Value;
            if (MessageBox.Show("Bạn có muốn sửa nhà cung cấp này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (name != "")
                {
                    if (SupplierDAO.Instance.UpdateSupplier(id, name, phone, address))
                    {
                        MessageBox.Show("Sửa Thành Công");
                        LoadSupplier();
                    }
                    else
                    {
                        MessageBox.Show("Sửa Thất Bại");
                    }
                }
                else
                {
                    MessageBox.Show("Tên không được trống");
                }
                
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            int id = (int)dtgvSupplier.SelectedCells[0].Value;
            if (MessageBox.Show("Bạn có muốn xóa nhà cung cấp này?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if(SupplierDAO.Instance.GetSupplierIDByImportBook(id) == 0)
                {
                    if (SupplierDAO.Instance.DeleteSupplier(id))
                    {
                        MessageBox.Show("Xóa Thành Công");
                        LoadSupplier();
                    }
                    else
                    {
                        MessageBox.Show("Xóa Thất Bại");
                    }
                }
                else
                {
                    MessageBox.Show("Nhà cung cấp đang được dùng");
                }
                
            }
        }
        private void btnSearchSupplier_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchSupplier.Text))
            {
                SupplierList.DataSource =  SupplierDAO.Instance.SearchSuppliers(txtSearchSupplier.Text);
            }
            else
            {
                LoadSupplier();
            }
        }
        #endregion
        #region ImportBook
        void LoadALLImportBook()
        {
            LoadImportBook();
            LoadListSupplier(cbSupplierImport);
            BindingImportBook();
        }
        void LoadImportBook()
        {
            ImportBook.DataSource = LoadImportBooksDAO.Instance.GetListImportBook();
            dtgvImportBooks.DefaultCellStyle.Font = new Font("Times New Roman", 10);
        }
        void LoadListSupplier(ComboBox cb)
        {
            cb.DataSource = SupplierDAO.Instance.GetListSuppliers();
            cb.DisplayMember = "SupplierName";
        }
        void BindingImportBook()
        {
            txtNameImportBook.DataBindings.Add(new Binding("Text" , ImportBook , "NameBook" ,true , DataSourceUpdateMode.Never));
            txtImportID.DataBindings.Add(new Binding("Text", ImportBook, "ImportID", true, DataSourceUpdateMode.Never));
            txtAuthorImport.DataBindings.Add(new Binding("Text", ImportBook, "AuthorName", true, DataSourceUpdateMode.Never));
            txtCategoryImport.DataBindings.Add(new Binding("Text", ImportBook, "NameCate", true, DataSourceUpdateMode.Never));
            txtYearPublishImport.DataBindings.Add(new Binding("Text", ImportBook, "PublishYear", true, DataSourceUpdateMode.Never));
            nmImportBooks.DataBindings.Add(new Binding("Value", ImportBook, "QuanlityImport", true, DataSourceUpdateMode.Never));
            nmPriceImport.DataBindings.Add(new Binding("Value", ImportBook, "Price", true, DataSourceUpdateMode.Never));
            dtpkImportBook.DataBindings.Add(new Binding("Value", ImportBook, "ImportDay", true, DataSourceUpdateMode.Never));

        }
        private void txtImportID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ImportBooksDAO.Instance.CountAllImportBook()> 0)
                {
                    if (dtgvImportBooks.SelectedCells.Count > 0)
                    {
                        int idimport = Convert.ToInt32(txtImportID.Text);
                        if (SupplierDAO.Instance.CheckSuplierIInImportbook(idimport) > 0)
                        {
                            int idSupplier = SupplierDAO.Instance.GetSupplierIDFromImportBook(idimport);
                            Supplier supplier = SupplierDAO.Instance.GetSupplierByID(idSupplier);
                            cbSupplierImport.SelectedItem = supplier;
                            int index = -1;
                            int i = 0;

                            foreach (Supplier item in cbSupplierImport.Items)
                            {
                                if (item.SupplierID == supplier.SupplierID)
                                {
                                    index = i;
                                    break;
                                }
                                i++;
                            }

                            cbSupplierImport.SelectedIndex = index;
                        }
                    }
                }
            }
            catch { }
        }
        private void btnAddImportBook_Click(object sender, EventArgs e)
        {
            int quanlity = (int)nmImportBooks.Value;
            int idImportBook = Convert.ToInt32(txtImportID.Text);
            //Lấy số lượng sách đã nhập vào trước đó
            int quanlityold = DetailImportBookDAO.Instance.GetQuanlityImportBook(idImportBook);
            int idSupplier = (cbSupplierImport.SelectedItem as Supplier).SupplierID;
            decimal price = (decimal)nmPriceImport.Value;
            DateTime date = dtpkImportBook.Value;
            if (MessageBox.Show("Bạn có chắc muốn sửa phiếu nhập này","Thông báo" , MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (quanlity > 0 && price > 0)
                {
                    //Trường hợp số lượng sách nhập vào tăng
                    if (quanlity > quanlityold)
                    {
                        //Số lượng sách mới bằng sách hiện tại trừ sach cũ
                        int quanlitynew = quanlity - quanlityold;
                        //Lấy mã sách từ mã sách nhập
                        int idbook = DetailImportBookDAO.Instance.GetIDBookByDetailImportID(idImportBook);
                        //Lấy số lượng sách hiện tại có trong kho
                        int quanlityBook = BookDAO.Instance.GetQuanlityBook(idbook);
                        //Chỉnh sửa lại thông tin phiếu nhập
                        if (ImportBooksDAO.Instance.EditImportBook(idImportBook, date, idSupplier))
                        {
                            //Chỉnh sửa lại chi tiết phiếu nhập
                            if (DetailImportBookDAO.Instance.EditDetailImportBook(idImportBook, quanlity, price))
                            {
                                //Cập nhập lại số lượng sách sao khi nhập
                                if (BookDAO.Instance.UpdateBookAfterBorrow(idbook, quanlityBook + quanlitynew))
                                {
                                    MessageBox.Show("Sửa Thành Công");
                                    LoadImportBook();
                                }
                                else
                                {
                                    MessageBox.Show("Sửa Thất Bại");
                                }
                            }
                        }
                    }

                    //Trường họp số lượng sách nhập vào giảm
                    if (quanlity < quanlityold)
                    {
                        if (quanlityold - quanlity > 0)
                        {
                            int quanlitynew = quanlityold - quanlity;

                            int idbook = DetailImportBookDAO.Instance.GetIDBookByDetailImportID(idImportBook);
                            int quanlityBook = BookDAO.Instance.GetQuanlityBook(idbook);
                            if (quanlityBook - quanlitynew > 0)
                            {
                                if (ImportBooksDAO.Instance.EditImportBook(idImportBook, date, idSupplier))
                                {
                                    if (DetailImportBookDAO.Instance.EditDetailImportBook(idImportBook, quanlity, price))
                                    {
                                        if (BookDAO.Instance.UpdateBookAfterBorrow(idbook, quanlityBook - quanlitynew))
                                        {
                                            MessageBox.Show("Sửa Thành Công");
                                            LoadImportBook();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Sửa Thất Bại");
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //Trường họp số lượng sách nhập không thay đổi chỉ đổi đơn giá hoặc nhà cung cấp
                    if (quanlity == quanlityold)
                    {
                        if (ImportBooksDAO.Instance.EditImportBook(idImportBook, date, idSupplier))
                        {
                            if (DetailImportBookDAO.Instance.EditDetailImportBook(idImportBook, quanlity, price))
                            {
                                MessageBox.Show("Sửa Thành Công");
                                LoadImportBook();
                            }
                            else
                            {
                                MessageBox.Show("Sửa Thất Bại");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Số Lượng Phải Hơn 0");
                }
            }
        }
        private void btnSearchImportBook_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtSearchImportBook.Text))
            {
                if(rdbtnSearchNameImportBook.Checked)
                {
                    ImportBook.DataSource = LoadImportBooksDAO.Instance.SearchImportBookByNameBook(txtSearchImportBook.Text);
                }
                if (rdbtnSearchSupplierImportBook.Checked)
                {
                    ImportBook.DataSource = LoadImportBooksDAO.Instance.SearchImportBookBySupplier(txtSearchImportBook.Text);
                    
                }
            }
            else
            {
                LoadImportBook();
            }
        }
        #endregion
        #region Penalize
        void LoadAllPenalize()
        {
            LoadPenalize();
            BindingPenalize();
        }
        void LoadPenalize()
        {
            PenalizeList.DataSource = DetailPenalizeDAO.Instance.GetAllPenalize();
            dtgvPenalize.DefaultCellStyle.Font = new Font("Times New Roman", 10);
        }
        void BindingPenalize()
        {
            txtPenalizeID.DataBindings.Add(new Binding("Text", PenalizeList, "PenalizeID", true, DataSourceUpdateMode.Never));
            txtPenalizeName.DataBindings.Add(new Binding("Text", PenalizeList, "MemberName", true, DataSourceUpdateMode.Never));
            txtPenalizeNameBook.DataBindings.Add(new Binding("Text", PenalizeList, "NameBook", true, DataSourceUpdateMode.Never));
            txtDayNumber.DataBindings.Add(new Binding("Text", PenalizeList, "NumberDay", true, DataSourceUpdateMode.Never));
            txtPricePenalize.DataBindings.Add(new Binding("Text", PenalizeList, "PricePenalize", true, DataSourceUpdateMode.Never));
            datePenalize.DataBindings.Add(new Binding("Text",PenalizeList,"Date",true, DataSourceUpdateMode.Never));
        }

        private void btnDeletePenalize_Click(object sender, EventArgs e)
        {
            if (txtPenalizeID.Text != "")
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu phạt này?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    int id = Convert.ToInt32(txtPenalizeID.Text);
                    if (DetailPenalizeDAO.Instance.DeletePenalize(id))
                    {
                        MessageBox.Show("Xóa thành công");
                        LoadPenalize();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }
            }
            else
            {
                MessageBox.Show("Không có thông tin phạt để xóa");
            }
            
        }
        private void btnSearcgPenalize_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(txtSearchPenalize.Text))
            {
                if (rdbtnNamePenalize.Checked)
                {
                    PenalizeList.DataSource = DetailPenalizeDAO.Instance.SearchAllPenalizeByNameMember(txtSearchPenalize.Text);
                }
                if (rdbtnNameBookPenalize.Checked)
                {
                    PenalizeList.DataSource = DetailPenalizeDAO.Instance.SearchAllPenalizeByNameBook(txtSearchPenalize.Text);
                }
            }
            else
            {
                LoadPenalize();
            }
        }
        #endregion
        private void btnSearchArea_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearchArea.Text))
            {
                if (rdbtnSearchArea.Checked)
                {
                    AreaList.DataSource = AreaDAO.Instance.SearchArea(txtSearchArea.Text);
                }
                if (rdbtnSearchRow.Checked)
                {
                    RowList.DataSource = RowDAO.Instance.SearchRow(txtSearchArea.Text);
                }
                if (rdbtnSearchCompartment.Checked)
                {
                    CompartmentList.DataSource = CompartmentDAO.Instance.SearchCompartment(txtSearchArea.Text);
                }
            }
            else
            {
                MessageBox.Show("Hãy Nhập Tên Và Nơi Bạn Muốn Tìm Kiếm!", "Thông Báo");
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 2){
                LoadCategoryIntoCombobox(cbCateName);
                LoadAuthorIntoCombobox(cbNameAuthor);
                LoadListBook();
                LoadAreaIntoCombobox(cbAreaBook);
                LoadRowIntoCombobox(cbRowBook);
                LoadCompartmentIntoCombobox(cbCompartment);

            }else if(tabControl1.SelectedIndex == 4)
            {
                LoadArea();
                LoadRow();
                LoadCompartment();
            }
            else if(tabControl1.SelectedIndex == 6)
            {
                
                if(BookBorrowDAO.Instance.CountAllBookBorrow() > 0)
                {
                    LoadALLBorrowBook();
                }
            }else if(tabControl1.SelectedIndex == 7)
            {
                LoadImportBook();
                LoadListSupplier(cbSupplierImport);
            }else if(tabControl1.SelectedIndex == 8)
            {
                LoadPenalize();
            }
        }

    }
}
