using QLTV.DAO;
using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLTV
{
    public partial class FormImportBook : Form
    {
        public FormImportBook()
        {
            InitializeComponent();
            LoadALL();
        }
        void LoadALL()
        {
            LoadSupplierIntoCb(cbSupplierImport);
            LoadAuthorIntocb(cbAuthorImport);
            LoadCategoryIntocb(cbCategoryImport);
            LoadAreaIntocb(cbAreaImport);
            LoadRowIntocb(cbRowImport);
            LoadCompartmentIntocb(cbCompartmentImport);
            LoadImportBooks();
        }
        void LoadSupplierIntoCb(ComboBox cb)
        {
            //Lấy danh sách nhà cung cấp
            cb.DataSource = SupplierDAO.Instance.GetListSuppliers();
            cb.DisplayMember = "SupplierName";
        }
        void LoadCategoryIntocb(ComboBox cb)
        {
            //lấy danh sách thể loại
            cb.DataSource = CategoryDAO.Instance.LoadCategory();
            cb.DisplayMember = "NameCate";
        }
        void LoadAuthorIntocb(ComboBox cb)
        {
            //lấy danh sách tác giả
            cb.DataSource = AuthorDAO.Instance.GetAuthor();
            cb.DisplayMember = "AuthorName";
        }
        void LoadAreaIntocb(ComboBox cb)
        {
            //lấy danh sách khu vực để sách
            cb.DataSource = AreaDAO.Instance.GetListArea();
            cb.DisplayMember = "AreaName";
        }
        void LoadRowIntocb(ComboBox cb)
        {
            //lấy danh sách hàng để sách
            cb.DataSource = RowDAO.Instance.GetListRow();
            cb.DisplayMember = "RowName";
        }
        void LoadCompartmentIntocb(ComboBox cb)
        {
            //lấy danh sách ngăn để sách
            cb.DataSource = CompartmentDAO.Instance.GetListCompartment();
            cb.DisplayMember = "CompartmentName";
        }
        void LoadImportBooks()
        {
            //lấy danh sách sách đã nhập
            dtgvImportBooks.DataSource = LoadImportBooksDAO.Instance.GetListImportBook();
            dtgvImportBooks.DefaultCellStyle.Font = new Font("Times New Roman", 10);
        }
        private void btnAddImportBook_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtNameImportBook.Text) && !string.IsNullOrEmpty(cbCategoryImport.Text) && !string.IsNullOrEmpty(cbAuthorImport.Text)
                && !string.IsNullOrEmpty(cbSupplierImport.Text) && !string.IsNullOrEmpty(cbAreaImport.Text) && !string.IsNullOrEmpty(cbRowImport.Text)
                && !string.IsNullOrEmpty(cbCompartmentImport.Text) && !string.IsNullOrEmpty(txtYearPublishImport.Text)
                )
            {
                string nameBook = txtNameImportBook.Text;
                int idSupplier = (cbSupplierImport.SelectedItem as Supplier).SupplierID;
                int idcate = (cbCategoryImport.SelectedItem as Category).Cateid;
                int idauthor = (cbAuthorImport.SelectedItem as Author).AuthorId;
                int idArea = (cbAreaImport.SelectedItem as Area).AreaID;
                int idRow = (cbRowImport.SelectedItem as Row).RowID;
                int idCompartment = (cbCompartmentImport.SelectedItem as Compartment).CompartmentID;
                int publishyear = Convert.ToInt32(txtYearPublishImport.Text);
                decimal price = (decimal)nmPriceImport.Value;
                int quanlity = (int)nmImportBooks.Value;
                DateTime date = (DateTime)dtpkImportBook.Value;
                decimal total = quanlity * price;
                int resultSelectIdboook = -1;
                int numberBookOld = 0;
                //Lấy id sách khi nhập vào có thông tin sách trùng vs sách đã có
                if (BookDAO.Instance.GetIDBookByName(nameBook, idauthor, idcate, publishyear) != null)
                {
                    resultSelectIdboook = BookDAO.Instance.GetIDBookByNameBook(nameBook, idauthor, idcate, publishyear);
                    //Lấy số lượng sách trong kho
                    numberBookOld = BookDAO.Instance.GetQuanlityBook(resultSelectIdboook);
                }

                if (MessageBox.Show("Bạn có muốn nhập sách", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    //Nếu sách nhập vào trùng thông tin sách đã có trong kho
                    if (resultSelectIdboook > 0)
                    {
                        //Chèn sách nhập mới
                        if (ImportBooksDAO.Instance.InsertImportBooks(date, idSupplier))
                        {
                            //Lấy mã phiếu vừa chèn vào
                            int idImport = ImportBooksDAO.Instance.GetIDMaxImportBook();
                            //Chèn thông tin chi tiết sách nhập 
                            if (DetailImportBookDAO.Instance.InsertDetailImportBook(quanlity, price, total, resultSelectIdboook, idImport))
                            {
                                //Cập nhập số lượng sách nhập vào
                                if (BookDAO.Instance.UpdateQuanlityImportBook(resultSelectIdboook, numberBookOld + quanlity))
                                {
                                    MessageBox.Show("Thêm Thành Công");
                                    LoadImportBooks();
                                }
                                else
                                {
                                    MessageBox.Show("Thêm Thất Bại");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Thêm chi tiết phiếu nhập thất bại!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Thêm phiếu nhập thất bại!");
                        }
                    }
                    //Nếu sách hoàn toàn mới thông tin
                    else
                    {
                        //Chèn sách nhập mới
                        if (ImportBooksDAO.Instance.InsertImportBooks(date, idSupplier))
                        {
                            //Lấy mã phiếu vừa chèn vào
                            int idImport = ImportBooksDAO.Instance.GetIDMaxImportBook();
                            //Tạo vị trí mới để lưu trữ sách
                            if (LocationDAO.Instance.InsertLocation(idArea, idRow, idCompartment))
                            {
                                //lấy vị trí vừa tạo
                                int idlocation = LocationDAO.Instance.GetIDMaxLoaction();
                                //Chèn sách mới nhập vào 
                                if (BookDAO.Instance.InsertBook(nameBook, quanlity, idauthor, idcate, publishyear, idlocation))
                                {
                                    //Lấy mã sách vừa chèn vào
                                    int idBook = BookDAO.Instance.GetMaxIdBook();
                                    //Chèn chi tiết phiếu nhập mới
                                    if (DetailImportBookDAO.Instance.InsertDetailImportBook(quanlity, price, total, idBook, idImport))
                                    {
                                        MessageBox.Show("Thêm Thành Công");
                                        LoadImportBooks();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Thêm sách thất bại");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Thêm vị trí thất bại");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Thêm phiếu nhập thất bại!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Không đủ dữ liệu nhập sách");
            }
        }
    }
}
