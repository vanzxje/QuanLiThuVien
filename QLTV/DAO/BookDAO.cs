using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace QLTV.DAO
{
    public class BookDAO
    {
        private BookDAO() { }
        private static BookDAO instance;
        public static BookDAO Instance
        {
            get { if (instance == null) instance = new BookDAO(); return BookDAO.instance; }
            private set { BookDAO.instance = value; }
        }
        //Tìm kiếm sách theo tên thể loại
        public List<Book> SearchBookByNameBook(string name)
        {
            List<Book> list = new List<Book>();
            string query = string.Format("SELECT * FROM Book WHERE NameBook like UPPER(N'%{0}%')", name);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                Book book = new Book(dr);
                list.Add(book);
            }
            return list;
        }
        //Đếm số lượng sách tìm kiếm theo tên sách (check lỗi combobox)
        public int CountSearchBookByNameBook(string name)
        {
            string query = string.Format("SELECT COUNT(*) FROM Book WHERE NameBook like UPPER(N'%{0}%')", name);
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        //Đếm số lượng sách tìm kiếm theo tên tác giả (check lỗi combobox)
        public int CountSearchBookByNameAuthor(string name)
        {
            string query = string.Format("SELECT COUNT(*) FROM Book as a INNER JOIN Author as b ON a.AuthorID = b.AuthorID WHERE b.AuthorName like UPPER(N'%{0}%')", name);
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        //Tìm kiếm sách theo tên tác giả
        public List<Book> SearchBookByNameAuthor(string name)
        {
            List<Book> list = new List<Book>();
            string query = string.Format("SELECT a.BookID, a.NameBook,a.Quanlity,a.AuthorID,a.CategoryID,a.PublishYear,a.LocationID FROM Book as a INNER JOIN Author as b ON a.AuthorID = b.AuthorID WHERE b.AuthorName like UPPER(N'%{0}%')", name);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                Book book = new Book(dr);
                list.Add(book);
            }
            return list;
        }

        //Lấy tất cả sách trong kho
        public List<Book> GetListBook()
        {
            List<Book> list = new List<Book>();
            string query = "SELECT * FROM Book";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                Book book = new Book(dr);
                list.Add(book);
            }
            return list;
        }

        #region Lấy Thông Tin Sách Chưa Trả Load Lên Phiếu Mượn

        public List<Book> GetListBookByIdMember(int idMember)
        {
            List<Book> books = new List<Book>();
            string query = string.Format("SELECT a.BookID,a.NameBook,a.Quanlity,a.AuthorID,a.CategoryID,a.PublishYear,a.LocationID FROM Book as a INNER JOIN DetailBookBorrow as b  ON a.BookID = b.BookID \r\nINNER JOIN BookBorrow as c ON B.BorrowID = C.BorrowID where a.BookID = b.BookID AND b.BorrowID = c.BorrowID and c.MemberID = '{0}' and c.PayDay IS NULL", idMember);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow dr in dt.Rows)
            {
                Book book = new Book(dr);
                books.Add(book);
            }
            return books;
        }
        #endregion

        //Lấy id sách khi nhập vào có thông tin sách trùng vs sách đã có
        public int GetIDBookByNameBook(string bookName , int idAuthor,int idcate , int publishyear)
        {
            string query = string.Format("SELECT a.BookID FROM Book as a Where UPPER(a.NameBook) = UPPER(N'{0}') and a.AuthorID = '{1}' and a.CategoryID = '{2}' and a.PublishYear = '{3}'", bookName , idAuthor , idcate,publishyear);
            int id = (int)DataProvider.Instance.ExecuteScalar(query);
            return id;
        }

        public Book GetIDBookByName(string bookName, int idAuthor, int idcate, int publishyear)
        {
            Book book = null;
            string query = string.Format("SELECT * FROM Book as a Where UPPER(a.NameBook) = UPPER(N'{0}') and a.AuthorID = '{1}' and a.CategoryID = '{2}' and a.PublishYear = '{3}'", bookName, idAuthor, idcate, publishyear);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow row in dt.Rows)
            {
                book = new Book(row);
                return book;
            }
            return book;
        }

        //Cập nhập số lượng sách nhập vào
        public bool UpdateQuanlityImportBook(int id , int quanlity)
        {
            string query = string.Format("UPDATE Book SET Quanlity = '{0}' WHERE BookID = '{1}'",quanlity,id);
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }

        //Lấy mã sách mới vừa chèn vào để gắn mã vào chi tiết phiếu nhập
        public int GetMaxIdBook()
        {
            string query = "SELECT BookID FROM Book ORDER BY BookID Desc";
            int maxid = (int)DataProvider.Instance.ExecuteScalar(query);
            return maxid;
        }

        public int CountALLBook()
        {
            string query = "SELECT COUNT(*) FROM Book  ";
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }

        //Lấy số lượng sách trong kho
        public int GetQuanlityBook(int id)
        {
            string query = string.Format("SELECT Quanlity FROM Book WHERE BookID = '{0}'" , id);
            int quanlity = (int)DataProvider.Instance.ExecuteScalar(query);
            return quanlity;
        }

        //Cập nhập lại số lượng sách sau khi cho mượn hoặc trả
        public bool UpdateBookAfterBorrow(int id , int number)
        {
            string query = string.Format("UPDATE Book SET Quanlity = '{0}' WHERE BookID = {1}", number,id);
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }

        //Thêm sách mới vào
        public bool InsertBook(string name ,int quanlity , int idauthor ,int idcategory , int publishYear , int locationID)
        {
            string query = string.Format("INSERT INTO Book VALUES(N'{0}' , '{1}', '{2}' , '{3}', '{4}','{5}')",name,quanlity,idauthor,idcategory,locationID,publishYear);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0; 
        }
        public bool UpdateBook(int idBook, string name, int quanlity, int idauthor, int idcategory, int publishYear)
        {
            string query = string.Format("UPDATE Book SET NameBook = N'{0}' , Quanlity = '{1}' , AuthorID = '{2}' , CategoryID = '{3}' , PublishYear = '{4}' WHERE BookID = '{5}'",name,quanlity,idauthor,idcategory,publishYear,idBook);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteBook(int idBook)
        {
            string query = "DELETE FROM Book WHERE BookID = " + idBook;
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }
        
        #region Điều kiện xóa từ sách
        public int GetAllBookByIdCate(int id)
        {
            string query = "SELECT COUNT(*) FROM Book WHERE CategoryID = " + id;
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;

        }
        public int GetAllBookByIdAuthor(int id)
        {
            string query = "SELECT COUNT(*) FROM Book WHERE AuthorID = " + id;
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }

        public int GetAllBookByIdArea(int id)
        {
            string query = "SELECT COUNT(*) FROM Book as a INNER JOIN Location as b ON a.LocationID = b.LocationID INNER JOIN Area as c ON c.AreaID = b.AreaID Where c.AreaID = " + id;
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        public int GetAllBookByIdRow(int id)
        {
            string query = "SELECT COUNT(*) FROM Book as a INNER JOIN Location as b ON a.LocationID = b.LocationID INNER JOIN Row as c ON c.RowID = b.RowID Where c.RowID =  " + id;
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        public int GetAllBookByIdCompartment(int id)
        {
            string query = "SELECT COUNT(*) FROM Book as a INNER JOIN Location as b ON a.LocationID = b.LocationID INNER JOIN Compartment as c ON c.CompartmentID = b.CompartmentID Where c.CompartmentID = " + id;
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        #endregion
    }
}
