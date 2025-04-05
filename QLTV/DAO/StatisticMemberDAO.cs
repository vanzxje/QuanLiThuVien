using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class StatisticMemberDAO
    {
        private StatisticMemberDAO() { }
        private static StatisticMemberDAO instance;
        public static StatisticMemberDAO Instance
        {
            get { if (instance == null) instance = new StatisticMemberDAO(); return StatisticMemberDAO.instance; }
            private set { StatisticMemberDAO.instance = value; }
        }
        public List<StatisticMember> GetStatictisMemberList()
        {
            List<StatisticMember> list = new List<StatisticMember>();
            string query = "SELECT Distinct c.MemberName , Sum(b.NumBer) as Number ,COUNT(c.MemberName) as Count FROM BookBorrow as a INNER JOIN DetailBookBorrow AS b ON a.BorrowID = b.BookID INNER JOIN MemBer as c ON c.MemberID = a.MemberID GROUP BY c.MemberName";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                StatisticMember statictisMember = new StatisticMember(item);
                list.Add(statictisMember);
            }
            return list;
        }
        public List<StatisticMember> GetStatictisMemberListBYDate(DateTime start, DateTime end)
        {
            List<StatisticMember> list = new List<StatisticMember>();
            string query = string.Format("SELECT Distinct c.MemberName , Sum(b.NumBer) as Number ,COUNT(c.MemberName) as Count FROM BookBorrow as a INNER JOIN DetailBookBorrow AS b ON a.BorrowID = b.BookID INNER JOIN MemBer as c ON c.MemberID = a.MemberID Where a.BorrowDay BETWEEN '{0}' AND '{1}' GROUP BY c.MemberName", start, end);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                StatisticMember statictisMember = new StatisticMember(item);
                list.Add(statictisMember);
            }
            return list;
        }
    }
}
