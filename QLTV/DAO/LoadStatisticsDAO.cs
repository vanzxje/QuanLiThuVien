using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class LoadStatisticsDAO
    {
        private LoadStatisticsDAO() { }
        private static LoadStatisticsDAO instance;
        public static LoadStatisticsDAO Instance
        {
            get { if (instance == null) instance = new LoadStatisticsDAO(); return LoadStatisticsDAO.instance; }
            private set { LoadStatisticsDAO.instance = value; }
        }

        //Hiển thị thống kê danh sách phiếu nhập
        public List<LoadStatistics> GetListStatistics()
        {
            List<LoadStatistics> list = new List<LoadStatistics>();
            string q = "SELECT a.ImportID,d.NameBook,g.AuthorName,z.NameCate ,d.PublishYear,c.QuanlityImport, c.Price, c.Total,a.ImportDay, b.SupplierName\r\nFROM ImportBooks as a INNER JOIN Supplier as b ON b.SupplierID = a.SupplierID\r\nINNER JOIN DetailImportBooks as c ON c.ImportID = a.ImportID\r\nINNER JOIN Book as d ON d.BookID = c.BookID\r\nINNER JOIN Author as g ON g.AuthorID = d.AuthorID\r\nINNER JOIN Category as z ON z.CategoryID = d.CategoryID";
            DataTable dt = DataProvider.Instance.ExecuteQuery(q);
            foreach (DataRow row in dt.Rows)
            {
                LoadStatistics loadStatistics = new LoadStatistics(row);
                list.Add(loadStatistics);
            }
            return list;
        }

        //Hiển thị thống kê danh sách phiếu nhập theo ngày
        public List<LoadStatistics> GetListStatisticsMonth(DateTime start , DateTime end)
        {
            List<LoadStatistics> list = new List<LoadStatistics>();
            string q = string.Format("SELECT a.ImportID,d.NameBook,g.AuthorName,z.NameCate ,d.PublishYear,c.QuanlityImport, c.Price, c.Total,a.ImportDay, b.SupplierName FROM ImportBooks as a INNER JOIN Supplier as b ON b.SupplierID = a.SupplierID INNER JOIN DetailImportBooks as c ON c.ImportID = a.ImportID INNER JOIN Book as d ON d.BookID = c.BookID INNER JOIN Author as g ON g.AuthorID = d.AuthorID INNER JOIN Category as z ON z.CategoryID = d.CategoryID WHERE a.ImportDay BETWEEN  '{0}' and '{1}'",start,end);
            DataTable dt = DataProvider.Instance.ExecuteQuery(q);
            foreach (DataRow row in dt.Rows)
            {
                LoadStatistics loadStatistics = new LoadStatistics(row);
                list.Add(loadStatistics);
            }
            return list;
        }

        //Tổng tiền nhập sách
        public decimal SumTotal()
        {
            string query = "SELECT SUM(c.Total) FROM ImportBooks as a INNER JOIN Supplier as b ON b.SupplierID = a.SupplierID INNER JOIN DetailImportBooks as c ON c.ImportID = a.ImportID";
            decimal total =  Convert.ToDecimal(DataProvider.Instance.ExecuteScalar(query));
            return total;
        }

        //Tổng tiền nhập sách theo ngày
        public decimal SumTotalDate(DateTime start, DateTime end)
        {
            string query = string.Format("SELECT SUM(c.Total) FROM ImportBooks as a INNER JOIN Supplier as b ON b.SupplierID = a.SupplierID INNER JOIN DetailImportBooks as c ON c.ImportID = a.ImportID WHERE a.ImportDay BETWEEN  '{0}' and '{1}'",start,end);
            decimal total = Convert.ToDecimal(DataProvider.Instance.ExecuteScalar(query));
            return total;
        }

        //Số lượng sách nhập theo ngày (check lỗi khi gán tổng tiền)
        public int CountImportBookHaveDate(DateTime start, DateTime end)
        {
            string query = string.Format("SELECT COUNT(*) FROM ImportBooks as a INNER JOIN Supplier as b ON b.SupplierID = a.SupplierID INNER JOIN DetailImportBooks as c ON c.ImportID = a.ImportID WHERE a.ImportDay BETWEEN  '{0}' and '{1}'",start,end);
            int total = Convert.ToInt32(DataProvider.Instance.ExecuteScalar(query));
            return total;
        }
    }
}
