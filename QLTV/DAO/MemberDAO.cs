using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class MemberDAO
    {
        private static MemberDAO instance;
        public static MemberDAO Instance
        {
            get { if (instance == null) instance = new MemberDAO(); return MemberDAO.instance; }
            private set { MemberDAO.instance = value; }
        }
        public MemberDAO() { }
        public List<Member> SearchMember(string name)
        {
            List<Member> list = new List<Member>();
            string query = string.Format("SELECT * FROM Member WHERE MemberName like N'%{0}%'",name);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                Member memBer = new Member(item);
                list.Add(memBer);
            }
            return list;
        }

        //Lấy tất cả thành viên đã đăng kí
        public List<Member> GetLoadMember()
        {
            List<Member> list = new List<Member>();
            string query = "SELECT * FROM Member";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                Member memBer = new Member(item);
                list.Add(memBer);
            }
            return list;
        }

        //Danh sách thành viên đang mượn sách
        public List<Member> GetLoadMemberBookBorrow()
        {
            List<Member> list = new List<Member>();
            string query = "SELECT DISTINCT b.MemberID , b.MemberName , b.PhoneNumber,b.IDCard,b.StartDay,b.EndDay FROM BookBorrow as a INNER JOIN MemBer as b ON a.MemberID = b.MemberID where a.PayDay is null";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                Member memBer = new Member(item);
                list.Add(memBer);
            }
            return list;
        }
        //public int GetIDMemberByBookBorrow(int idborrow)
        //{
        //    string query = string.Format("SELECT MemberID FROM BookBorrow WHERE BorrowID = '{0}'", idborrow);
        //    int id = (int)DataProvider.Instance.ExecuteScalar(query);
        //    return id;
        //}
        //public Member GetMemberByID(int id)
        //{
        //    Member member = null;
        //    string query = "SELECT * FROM MemBer WHERE MemberID = " + id;
        //    DataTable dt = DataProvider.Instance.ExecuteQuery(query);
        //    foreach(DataRow item in dt.Rows)
        //    {
        //        member = new Member(item);
        //        return member;
        //    }
        //    return member;
        //}
        public bool AddMember(string name, string sdt, string idcard, DateTime start, DateTime end)
        {
            string query = string.Format("INSERT INTO MemBer VALUES (N'{0}' , N'{1}' , N'{2}' , '{3}' , '{4}')", name, sdt, idcard, start, end);
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }
        public bool EditMember(int id, string name, string sdt, string idcard, DateTime start, DateTime end)
        {
            string query = string.Format("UPDATE MemBer SET MemberName = N'{0}' , PhoneNumber =N'{1}' , IDCard = N'{2}' , StartDay ='{3}' , EndDay ='{4}' WHERE MemberID = '{5}'", name, sdt, idcard, start, end, id);
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }
        public bool DeleteMember(int id)
        {
            string query = string.Format("DELETE FROM MemBer where MemberID = '{0}'", id);
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }
        public bool UpdateEndDay(int id , DateTime end) 
        {
            string query = string.Format("UPDATE MemBer SET EndDay = '{0}' Where MemberID = '{1}'",end,id);
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }

        //Kiểm tra thời hạn thẻ của thành viên
        public int CheckMemberDate(int id)
        {
            //kiểm tra thời hạn của thành viên
            string query = string.Format("SELECT COUNT(*) FROM MemBer Where GETDATE() < EndDay AND MemberID = '{0}'", id);
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        //public int CountMemberIsBorrowing(int id)
        //{
        //    string query = "SELECT COUNT(*) FROM MemBer as a INNER JOIN BookBorrow as b ON b.MemberID = a.MemberID Where a.MemberID = " + id;
        //    int dt = (int)DataProvider.Instance.ExecuteScalar(query);
        //    return dt;
        //}

    }
}
