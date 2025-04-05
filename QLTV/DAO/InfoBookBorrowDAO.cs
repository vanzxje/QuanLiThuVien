using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class InfoBookBorrowDAO
    {
        public InfoBookBorrowDAO() { }
        private static InfoBookBorrowDAO instance;
        public static InfoBookBorrowDAO Instance
        {
            get { if (instance == null) instance = new InfoBookBorrowDAO(); return InfoBookBorrowDAO.instance; }
            private set {InfoBookBorrowDAO.instance = value; }
        }

        // Lấy danh sách sách đã và đang mượn
        public List<InfoBookBorrow> GetALLBookBorrow()
        {
            List<InfoBookBorrow> list = new List<InfoBookBorrow>();
            string query = "SELECT a.BorrowID , d.NameBook,c.MemberName,b.NumBer,a.BorrowDay,a.PayDay FROM BookBorrow as a INNER JOIN DetailBookBorrow as b ON a.BorrowID = b.BorrowID\r\nINNER JOIN MemBer as c ON a.MemberID = c.MemberID INNER JOIN Book  as d ON d.BookID = b.BookID where a.BorrowID = b.BorrowID and b.BookID = d.BookID and a.MemberID = c.MemberID";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                InfoBookBorrow infoBookBorrow = new InfoBookBorrow(dr);
                list.Add(infoBookBorrow);
            }
            return list;
        }

        //Tìm kiếm sách mượn theo tên sách
        public List<InfoBookBorrow> SearchBookBorrowByNameBook(string name)
        {
            List<InfoBookBorrow> list = new List<InfoBookBorrow>();
            string query = string.Format("SELECT a.BorrowID , d.NameBook,c.MemberName,b.NumBer,a.BorrowDay,a.PayDay FROM BookBorrow as a INNER JOIN DetailBookBorrow as b ON a.BorrowID = b.BorrowID INNER JOIN MemBer as c ON a.MemberID = c.MemberID INNER JOIN Book  as d ON d.BookID = b.BookID where a.BorrowID = b.BorrowID and b.BookID = d.BookID AND d.NameBook like UPPER(N'%{0}%') and a.MemberID = c.MemberID ", name);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                InfoBookBorrow infoBookBorrow = new InfoBookBorrow(dr);
                list.Add(infoBookBorrow);
            }
            return list;
        }
        public List<InfoBookBorrow> GetListBookPayDate(DateTime start, DateTime end)
        {
            List<InfoBookBorrow> list = new List<InfoBookBorrow>();
            string query = string.Format("SELECT a.BorrowID , d.NameBook,c.MemberName,b.NumBer,a.BorrowDay,a.PayDay FROM BookBorrow as a INNER JOIN DetailBookBorrow as b ON a.BorrowID = b.BorrowID\r\nINNER JOIN MemBer as c ON a.MemberID = c.MemberID INNER JOIN Book  as d ON d.BookID = b.BookID where a.PayDay IS NOT NUll And a.BorrowDay BETWEEN '{0}' AND '{1}'", start, end);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                InfoBookBorrow infoBookBorrow = new InfoBookBorrow(dr);
                list.Add(infoBookBorrow);
            }
            return list;
        }

        //Tìm kiếm sách mượn theo tên thành viên
        public List<InfoBookBorrow> SearchBookBorrowByNameMember(string name)
        {
            List<InfoBookBorrow> list = new List<InfoBookBorrow>();
            string query = string.Format("SELECT a.BorrowID , d.NameBook,c.MemberName,b.NumBer,a.BorrowDay,a.PayDay FROM BookBorrow as a INNER JOIN DetailBookBorrow as b ON a.BorrowID = b.BorrowID INNER JOIN MemBer as c ON a.MemberID = c.MemberID INNER JOIN Book  as d ON d.BookID = b.BookID where a.BorrowID = b.BorrowID and b.BookID = d.BookID AND c.MemberName like UPPER(N'%{0}%') and a.MemberID = c.MemberID ", name);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                InfoBookBorrow infoBookBorrow = new InfoBookBorrow(dr);
                list.Add(infoBookBorrow);
            }
            return list;
        }

        //Lấy danh sách sách mượn chưa trả (load lên form mượn sách)
        public List<InfoBookBorrow> GetListBookBorrow()
        {
            List<InfoBookBorrow> list = new List<InfoBookBorrow>();
            string query = "SELECT a.BorrowID , d.NameBook,c.MemberName,b.NumBer,a.BorrowDay,a.PayDay FROM BookBorrow as a INNER JOIN DetailBookBorrow as b ON a.BorrowID = b.BorrowID\r\nINNER JOIN MemBer as c ON a.MemberID = c.MemberID INNER JOIN Book  as d ON d.BookID = b.BookID where a.BorrowID = b.BorrowID and b.BookID = d.BookID and a.MemberID = c.MemberID and a.PayDay is null";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                InfoBookBorrow infoBookBorrow = new InfoBookBorrow(dr);
                list.Add(infoBookBorrow);
            }
            return list;
        }

        //Lấy danh sách sách mượn đã trả (load lên form trả sách)
        public List<InfoBookBorrow> GetListBookPay()
        {
            List<InfoBookBorrow> list = new List<InfoBookBorrow>();
            string query = "SELECT a.BorrowID , d.NameBook,c.MemberName,b.NumBer,a.BorrowDay,a.PayDay FROM BookBorrow as a INNER JOIN DetailBookBorrow as b ON a.BorrowID = b.BorrowID\r\nINNER JOIN MemBer as c ON a.MemberID = c.MemberID INNER JOIN Book  as d ON d.BookID = b.BookID where a.BorrowID = b.BorrowID and b.BookID = d.BookID and a.MemberID = c.MemberID and a.PayDay IS NOT NUll";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                InfoBookBorrow infoBookBorrow = new InfoBookBorrow(dr);
                list.Add(infoBookBorrow);
            }
            return list;
        }

        //Lấy ngày sách mượn theo mã phiếu mượn
        public DateTime GetDateTimeBorrowDay(int idborrow) 
        {
            string query = "SELECT BorrowDay FROM BookBorrow Where BorrowID = " + idborrow;
            DateTime date = (DateTime)DataProvider.Instance.ExecuteScalar(query);
            return date;
        }
    }
}
