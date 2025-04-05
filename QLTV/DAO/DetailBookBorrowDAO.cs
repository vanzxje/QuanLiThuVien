using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class DetailBookBorrowDAO
    {
        public DetailBookBorrowDAO() { }
        private static DetailBookBorrowDAO instance;
        public static DetailBookBorrowDAO Instance
        {
            get { if(instance == null) instance = new DetailBookBorrowDAO();return DetailBookBorrowDAO.instance;}
            private set { DetailBookBorrowDAO.instance = value; }
        }

        //Cập nhập lại số lượng sách mượn
        public bool UpdateQuanlityBookBorrow(int id, int number)
        {
            string query = string.Format("UPDATE DetailBookBorrow SET NumBer = NumBer + '{0}' WHERE BorrowID = '{1}'", number, id);
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }

        //Tạo chi tiết mới khi thành viên mượn sách khác
        public bool InsertDetailBookBorrow(int number , int idbook , int idborrow)
        {
            string query = string.Format("INSERT INTO DetailBookBorrow VALUES('{0}','{1}','{2}')" ,number,idbook,idborrow);
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }
        //Lấy số sách mượn để kiểm tra số lượng trả
        public int GetNumberBookBorrow(int idmember, int idBook)
        {
            string query = string.Format("SELECT c.NumBer FROM BookBorrow AS A INNER JOIN DetailBookBorrow AS C ON A.BorrowID  = C.BorrowID INNER JOIN Book AS D ON C.BookID = D.BookID WHERE A.PayDay IS NULL AND A.MemberID = '{0}' AND A.BorrowID = C.BorrowID AND C.BookID = '{1}'", idmember, idBook);
            int number = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
            return number;
        }
        //public bool UpdateDetailBookBorrow(int number , int idbook , int idborrow)
        //{
        //    string query = string.Format("UPDATE DetailBookBorrow SET NumBer = '{0}' , BookID = '{1}' where BorrowID = '{2}'" , number,idbook,idborrow);
        //    int update = DataProvider.Instance.ExecuteNonQuery (query);
        //    return update > 0;
        //}

        //public int GetDetailNumberBookBorrow(int idmember, int idBook)
        //{
        //    string query = string.Format("SELECT c.NumBer FROM BookBorrow AS A INNER JOIN DetailBookBorrow AS C ON A.BorrowID  = C.BorrowID INNER JOIN Book AS D ON C.BookID = D.BookID WHERE  A.MemberID = '{0}' AND A.BorrowID = C.BorrowID AND C.BookID = '{1}'", idmember, idBook);
        //    int number = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
        //    return number;
        //}
        //public bool DeleteDetailBookBorrow(int id)
        //{
        //    string query = "DELETE FROM DetailBookBorrow WHERE BorrowID = " + id;
        //    int dt = DataProvider.Instance.ExecuteNonQuery(query);
        //    return dt > 0;
        //}
        //public bool DeleteDetailBookByIDMember(int id)
        //{
        //    string query = "DELETE DetailBookBorrow FROM DetailBookBorrow as a INNER JOIN BookBorrow as b ON b.BorrowID = a.BorrowID INNER JOIN MemBer as c ON c.MemberID = b.MemberID WHERE c.MemberID = " + id;
        //    int dt = DataProvider.Instance.ExecuteNonQuery(query);
        //    return dt > 0;
        //}
    }
}
