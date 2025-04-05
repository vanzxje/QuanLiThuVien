using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class BookBorrowDAO
    {
        private static BookBorrowDAO instance;
        public static BookBorrowDAO Instance
        {
            get { if (instance == null) instance = new BookBorrowDAO(); return BookBorrowDAO.instance; }
            private set { BookBorrowDAO.instance = value; }
        }
        public BookBorrowDAO() { }
        //Lấy phiếu vừa mới được tạo
        public int MaxIdBookBorrow()
        {
            string query = "Select BorrowID from BookBorrow ORDER BY BorrowID Desc";
            int maxid = (int)DataProvider.Instance.ExecuteScalar(query);
            return maxid;
        }

        //Tạo phiếu mượn sách mới
        public bool InsertBookBorrow(DateTime borrowday , int idMember)
        {
            string query = string.Format("INSERT INTO BookBorrow VALUES(N'{0}' ,null ,N'{1}')", borrowday, idMember);
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }

        //Lấy Id phiếu mượn khi thành viên mượn lại cuốn sách đã mượn mà chưa trả
        public int GetBookBorrowByIDMemberandBook(int idmember ,int idbook)
        {
            string query = string.Format("SELECT a.BorrowID FROM BookBorrow as a INNER JOIN DetailBookBorrow AS b ON a.BorrowID = b.BorrowID INNER JOIN Book AS c ON b.BookID = c.BookID WHERE a.PayDay is null AND a.MemberID = '{0}' and c.BookID = '{1}'", idmember,idbook);
            int idborrow = (int)DataProvider.Instance.ExecuteScalar(query);
            return idborrow;
        }

        //Đếm số lượng sách kiểm tra sách thành viên mượn có mượn mà chưa trả hay k
        public int GetCountBookBorrowByIDMemberandBook(int idmember, int idbook)
        {
            string query = string.Format("SELECT Count(*) FROM BookBorrow as a INNER JOIN DetailBookBorrow AS b ON a.BorrowID = b.BorrowID INNER JOIN Book AS c ON b.BookID = c.BookID WHERE a.PayDay is null AND a.MemberID = '{0}' and c.BookID = '{1}'", idmember, idbook);
            int idborrow = (int)DataProvider.Instance.ExecuteScalar(query);
            return idborrow;
        }

        //Cập nhập ngày trả sách
        public bool UpdateBookBorrowAfterPay(int id , DateTime datepay)
        {
            string query = string.Format("UPDATE BookBorrow SET PayDay = '{0}' WHERE BorrowID = '{1}'" , datepay , id);
            int update = DataProvider.Instance.ExecuteNonQuery(query);
            return update > 0;
        }
        //public bool UpdateBookBorrow(int idborrow , DateTime borrowday , DateTime payday , int idmember)
        //{
        //    string query = string.Format("UPDATE BookBorrow SET BorrowDay = '{0}' , PayDay = '{1}' , MemberID = '{2}' WHERE BorrowID = '{3}'" ,borrowday,payday,idmember,idborrow);
        //    int update = DataProvider.Instance.ExecuteNonQuery (query);
        //    return update > 0;
        //}
        public bool DeleteBookBorrow(int id)
        {
            string query = "DELETE FROM BookBorrow WHERE BorrowID = " + id;
            int dt = (int)DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }
        //public bool UpdatePayDay(int id, DateTime payday)
        //{
        //    string query = string.Format("UPDATE BookBorrow SET PayDay = '{0}' WHERE BorrowID = '{1}'", payday, id);
        //    int dt = DataProvider.Instance.ExecuteNonQuery(query);
        //    return dt > 0;
        //}
        public int CheckPayBook(int id)
        {
            string query = string.Format("SELECT COUNT(*) FROM BookBorrow WHERE BorrowID = '{0}' and PayDay IS NULL", id);
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        //public int CheckBookBorrowByIDMember(int id)
        //{
        //    string query = string.Format("SELECT COUNT(*) FROM BookBorrow WHERE MemberID = '{0}' and PayDay is null", id);
        //    int dt = (int)DataProvider.Instance.ExecuteScalar(query);
        //    return dt;
        //}
        public int CheckMemberHaveBookBorrow(int id)
        {
            string query = string.Format("SELECT COUNT(*) FROM BookBorrow WHERE MemberID = '{0}'", id);
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        //public bool DeleteBookBorrowByIDMemberID(int id)
        //{
        //    string query = "DELETE FROM BookBorrow WHERE MemberID = " + id;
        //    int dt = DataProvider.Instance.ExecuteNonQuery(query);
        //    return dt > 0;
        //}
        public bool DeleteBookBorrowByIDBook(int id)
        {
            string query = "DELETE BookBorrow FROM BookBorrow as a INNER JOIN DetailBookBorrow as b ON b.BorrowID = a.BorrowID INNER JOIN Book as c ON c.BookID = b.BookID WHERE c.BookID = " + id;
            int dt = (int)DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }
        public int CountAllBookBorrow()
        {
            string query = string.Format("SELECT COUNT(*) FROM BookBorrow");
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        public int CountAllBookBorrowDate(DateTime start, DateTime end)
        {
            string query = string.Format("SELECT COUNT(*) FROM BookBorrow WHERE BorrowDay BETWEEN '{0}' AND '{1}'", start, end);
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
    }
}
