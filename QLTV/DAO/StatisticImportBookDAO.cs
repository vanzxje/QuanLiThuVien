using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class StatisticImportBookDAO
    {
        private StatisticImportBookDAO() { }
        private static StatisticImportBookDAO instance;
        public static StatisticImportBookDAO Instance
        {
            get { if (instance == null) instance = new StatisticImportBookDAO(); return StatisticImportBookDAO.instance; }
            private set { StatisticImportBookDAO.instance = value; }
        }
        public List<StatisticImportBook> GetStatictisImportBookListBYDate(DateTime start, DateTime end)
        {
            List<StatisticImportBook> list = new List<StatisticImportBook>();
            string query = string.Format("SELECT c.NameBook , SUM(b.QuanlityImport) as Quanlity , SUM(b.Total) as Total FROM ImportBooks as a INNER JOIN DetailImportBooks as b ON a.ImportID = b.ImportID INNER JOIN Book as c ON c.BookID = b.BookID WHERE a.ImportDay BETWEEN '{0}' AND '{1}' GROUP BY c.NameBook", start, end);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                StatisticImportBook statisticImportBook = new StatisticImportBook(item);
                list.Add(statisticImportBook);
            }
            return list;
        }
    }
}
