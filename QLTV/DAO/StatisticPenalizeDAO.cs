using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class StatisticPenalizeDAO
    {
        private StatisticPenalizeDAO() { }
        private static StatisticPenalizeDAO instance;
        public static StatisticPenalizeDAO Instance
        {
            get { if (instance == null) instance = new StatisticPenalizeDAO(); return StatisticPenalizeDAO.instance; }
            private set { StatisticPenalizeDAO.instance = value; }
        }
        public List<StatisticPenalize> GetStatictisPenalizeListBYDate(DateTime start, DateTime end)
        {
            List<StatisticPenalize> list = new List<StatisticPenalize>();
            string query = string.Format("SELECT b.MemberName , SUM(a.PricePenalize) as PricePenalize ,Count(a.PricePenalize) as Count FROM Penalize as a INNER JOIN MemBer as b ON a.MemberID = b.MemberID  WHERE a.Date BETWEEN '{0}' AND '{1}' GROUP BY b.MemberName", start, end);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                StatisticPenalize statisticPenalize = new StatisticPenalize(item);
                list.Add(statisticPenalize);
            }
            return list;
        }
    }
}
