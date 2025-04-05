using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class ImportBooksDAO
    {
        private static ImportBooksDAO instance;
        public static ImportBooksDAO Instance
        {
            get { if (instance == null) instance = new ImportBooksDAO(); return ImportBooksDAO.instance; }
            set { ImportBooksDAO.instance = value; }
        }
        private ImportBooksDAO() { }

        //Chèn sách nhập mới vào
        public bool InsertImportBooks(DateTime date , int idSupplier)
        {
            string query = string.Format("INSERT INTO ImportBooks VALUES ('{0}','{1}')",date,idSupplier);
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }

        //Đếm sách đã được nhập
        public int CountAllImportBook()
        {
            string query = string.Format("SELECT COUNT(*) FROM ImportBooks ");
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        //Lấy mã phiếu chèn mới nhất
        public int GetIDMaxImportBook()
        {
            string query = "SELECT ImportID FROM ImportBooks ORDER BY ImportID Desc";
            int maxid = (int)DataProvider.Instance.ExecuteScalar(query);
            return maxid;
        }
        public int GetMinYearImportBook()
        {
            string query = "SELECT Year(Min(ImportDay)) FROM ImportBooks";
            int min = (int)DataProvider.Instance.ExecuteScalar(query);
            return min;
        }
        public bool EditImportBook(int idImport , DateTime date , int supplierid)
        {
            string query = string.Format("UPDATE ImportBooks SET ImportDay = '{0}' , SupplierID ='{1}' WHERE ImportID = '{2}'",date,supplierid,idImport);
            int dt = DataProvider.Instance.ExecuteNonQuery (query);
            return dt > 0;
        }
        public bool DeleteImportBookByBookID(int id)
        {
            string query = "DELETE ImportBooks FROM ImportBooks as a INNER JOIN DetailImportBooks as b ON b.ImportID= a.ImportID INNER JOIN Book as c ON c.BookID = b.BookID WHERE c.BookID = " + id;
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }
    }
    
}
