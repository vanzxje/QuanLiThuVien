using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class DetailPenalizeDAO
    {
        private static DetailPenalizeDAO instance;
        public static DetailPenalizeDAO Instance
        {
            get { if (instance == null) instance = new DetailPenalizeDAO(); return DetailPenalizeDAO.instance; }
            set { DetailPenalizeDAO.instance = value; }
        }
        private DetailPenalizeDAO() { }

        //Tạo phiếu phạt khi trả trễ hạn
        public bool InsertPenalize(int idmember,int idborrow , int numberday , float price)
        {
            string query = string.Format("INSERT INTO Penalize VALUES ('{0} ','{1}' ,'{2}' ,null ,'{3}' )" , idmember,idborrow,numberday,price);
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }

        //Lấy danh sách chưa nộp phạt
        public List<DetailPenalize> GetListPenalize()
        {
            string query = "SELECT a.PenalizeID , b.MemberName , d.NameBook , a.NumberDay, a.Date , a.PricePenalize FROM Penalize as a  INNER JOIN MemBer as b ON b.MemberID = a.MemberID  INNER JOIN DetailBookBorrow as c ON c.BorrowID = a.BorrowID  INNER JOIN Book as d ON d.BookID = c.BookID WHERE Date is null";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            List<DetailPenalize> list = new List<DetailPenalize>();
            foreach (DataRow dr in dt.Rows)
            {
                DetailPenalize detailPenalize = new DetailPenalize(dr);
                list.Add(detailPenalize);
            }
            return list;
        }

        //Lấy danh sách bị phạt
        public List<DetailPenalize> GetAllPenalize()
        {
            string query = "SELECT a.PenalizeID , b.MemberName , d.NameBook , a.NumberDay, a.Date , a.PricePenalize FROM Penalize as a  INNER JOIN MemBer as b ON b.MemberID = a.MemberID  INNER JOIN DetailBookBorrow as c ON c.BorrowID = a.BorrowID  INNER JOIN Book as d ON d.BookID = c.BookID";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            List<DetailPenalize> list = new List<DetailPenalize>();
            foreach (DataRow dr in dt.Rows)
            {
                DetailPenalize detailPenalize = new DetailPenalize(dr);
                list.Add(detailPenalize);
            }
            return list;
        }

        //Tìm phiếu phạt theo tên thành viên
        public List<DetailPenalize> SearchPenalizeByNameMember(string name)
        {
            string query = string.Format("SELECT a.PenalizeID , b.MemberName , d.NameBook , a.NumberDay, a.Date , a.PricePenalize FROM Penalize as a  INNER JOIN MemBer as b ON b.MemberID = a.MemberID  INNER JOIN DetailBookBorrow as c ON c.BorrowID = a.BorrowID  INNER JOIN Book as d ON d.BookID = c.BookID WHERE Date is null AND b.MemberName like UPPER(N'%{0}%')", name);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            List<DetailPenalize> list = new List<DetailPenalize>();
            foreach (DataRow dr in dt.Rows)
            {
                DetailPenalize detailPenalize = new DetailPenalize(dr);
                list.Add(detailPenalize);
            }
            return list;
        }
        public List<DetailPenalize> SearchAllPenalizeByNameMember(string name)
        {
            string query = string.Format("SELECT a.PenalizeID , b.MemberName , d.NameBook , a.NumberDay, a.Date , a.PricePenalize FROM Penalize as a  INNER JOIN MemBer as b ON b.MemberID = a.MemberID  INNER JOIN DetailBookBorrow as c ON c.BorrowID = a.BorrowID  INNER JOIN Book as d ON d.BookID = c.BookID WHERE b.MemberName like UPPER(N'%{0}%')", name);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            List<DetailPenalize> list = new List<DetailPenalize>();
            foreach (DataRow dr in dt.Rows)
            {
                DetailPenalize detailPenalize = new DetailPenalize(dr);
                list.Add(detailPenalize);
            }
            return list;
        }

        //Đếm số lượng phiếu phạt đẫ nộp phạt(check lỗi thống kê khi gán tổng phạt)
        public int CountPenalize()
        {
            string query = "SELECT COUNT(*) FROM Penalize WHERE Date IS NOT NULL";
            int check = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
            return check;
        }


        //Đếm số lượng phiếu phạt đẫ nộp phạt theo ngày (check lỗi thống kê khi gán tổng phạt)
        public int CountPenalizeHaveDate(DateTime start, DateTime end)
        {
            string query = string.Format("SELECT COUNT(*) FROM Penalize WHERE  Date BETWEEN '{0}' AND'{1}'  AND Date IS NOT NULL",start,end);
            int check = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
            return check;
        }
        //Tìm phiếu phạt theo tên sách
        public List<DetailPenalize> SearchPenalizeByNameBook(string name)
        {
            string query = string.Format("SELECT a.PenalizeID , b.MemberName , d.NameBook , a.NumberDay, a.Date , a.PricePenalize FROM Penalize as a  INNER JOIN MemBer as b ON b.MemberID = a.MemberID  INNER JOIN DetailBookBorrow as c ON c.BorrowID = a.BorrowID  INNER JOIN Book as d ON d.BookID = c.BookID WHERE Date is null AND d.NameBook like UPPER(N'%{0}%')", name);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            List<DetailPenalize> list = new List<DetailPenalize>();
            foreach (DataRow dr in dt.Rows)
            {
                DetailPenalize detailPenalize = new DetailPenalize(dr);
                list.Add(detailPenalize);
            }
            return list;
        }
        public List<DetailPenalize> SearchAllPenalizeByNameBook(string name)
        {
            string query = string.Format("SELECT a.PenalizeID , b.MemberName , d.NameBook , a.NumberDay, a.Date , a.PricePenalize FROM Penalize as a  INNER JOIN MemBer as b ON b.MemberID = a.MemberID  INNER JOIN DetailBookBorrow as c ON c.BorrowID = a.BorrowID  INNER JOIN Book as d ON d.BookID = c.BookID WHERE d.NameBook like UPPER(N'%{0}%')", name);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            List<DetailPenalize> list = new List<DetailPenalize>();
            foreach (DataRow dr in dt.Rows)
            {
                DetailPenalize detailPenalize = new DetailPenalize(dr);
                list.Add(detailPenalize);
            }
            return list;
        }
        //Tổng tất cả tiền phạt
        public decimal SumTotal()
        {
            string query = string.Format("SELECT SUM(PricePenalize) FROM Penalize WHERE Date IS NOT NULL");
            decimal total =Convert.ToDecimal(DataProvider.Instance.ExecuteScalar(query));
            return total;
        }

        //Tổng tiền phạt theo ngày
        public decimal SumTotalDate(DateTime start, DateTime end)
        {
            string query = string.Format("SELECT SUM(PricePenalize) FROM Penalize WHERE  Date BETWEEN '{0}' AND'{1}'  AND Date IS NOT NULL", start, end);
            decimal total = Convert.ToDecimal(DataProvider.Instance.ExecuteScalar(query));
            return total;
        }

        //Hiển thị danh sách sách phạt đã nộp phạt
        public List<DetailPenalize> GetListPenalizeNotNull()
        {
            string query = "SELECT a.PenalizeID , b.MemberName , d.NameBook , a.NumberDay, a.Date , a.PricePenalize FROM Penalize as a  INNER JOIN MemBer as b ON b.MemberID = a.MemberID  INNER JOIN DetailBookBorrow as c ON c.BorrowID = a.BorrowID  INNER JOIN Book as d ON d.BookID = c.BookID WHERE Date is not null";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            List<DetailPenalize> list = new List<DetailPenalize>();
            foreach (DataRow dr in dt.Rows)
            {
                DetailPenalize detailPenalize = new DetailPenalize(dr);
                list.Add(detailPenalize);
            }
            return list;
        }

        //Hiển thị danh sách sách phạt đã nộp phạt theo ngày
        public List<DetailPenalize> GetListPenalizeNotNullByDateFrom(DateTime datestart , DateTime dateend)
        {
            string query = string.Format("SELECT a.PenalizeID , b.MemberName , d.NameBook , a.NumberDay, a.Date , a.PricePenalize FROM Penalize as a  INNER JOIN MemBer as b ON b.MemberID = a.MemberID  INNER JOIN DetailBookBorrow as c ON c.BorrowID = a.BorrowID  INNER JOIN Book as d ON d.BookID = c.BookID WHERE Date is not null AND Date BETWEEN '{0}' and '{1}'",datestart,dateend);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            List<DetailPenalize> list = new List<DetailPenalize>();
            foreach (DataRow dr in dt.Rows)
            {
                DetailPenalize detailPenalize = new DetailPenalize(dr);
                list.Add(detailPenalize);
            }
            return list;
        }

        //Cập nhập ngày phạt khi thành viên nộp phạt
        public bool UpdateDate(int id , DateTime date)
        {
            string query = string.Format("UPDATE Penalize Set Date = '{0}' WHERE PenalizeID = '{1}'" , date,id);
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }

        //Kiểm tra thành viên đã nộp phạt chưa
        public int CheackMember(int idmember)
        {
            string query = string.Format("SELECT COUNT(*) FROM Penalize Where MemberID = '{0}' and Date is null", idmember);
            int dt =(int) DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        //Đếm số lượng phiếu phạt trc khi thống kê
        public int CountAllPenalize()
        {
            
            string query = string.Format("SELECT COUNT(*) FROM Penalize");
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }

        public bool DeletePenalize(int id)
        {
            string query = "DELETE  FROM Penalize WHERE PenalizeID = " + id;
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }
        //public bool DeletePenalizeByIDBookBorrow(int id)
        //{
        //    string query = "DELETE  FROM Penalize WHERE BorrowID = " + id;
        //    int dt = DataProvider.Instance.ExecuteNonQuery(query);
        //    return dt > 0;
        //}

        //Xóa phiếu phạt
        //public int CheackAllMember(int idmember)
        //{
        //    string query = string.Format("SELECT COUNT(*) FROM Penalize Where MemberID = '{0}'", idmember);
        //    int dt = (int)DataProvider.Instance.ExecuteScalar(query);
        //    return dt;
        //}
    }
}
