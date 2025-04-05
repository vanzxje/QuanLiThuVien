using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class LoadImportBooksDAO
    {
        private LoadImportBooksDAO() { }
        private static LoadImportBooksDAO instance;
        public static LoadImportBooksDAO Instance
        {
            get { if (instance == null) instance = new LoadImportBooksDAO(); return LoadImportBooksDAO.instance; }
            private set { LoadImportBooksDAO.instance = value; }
        }
        public List<LoadImportBooks> GetListImportBook()
        {
            List<LoadImportBooks > list = new List<LoadImportBooks>();
            string q = "SELECT a.ImportID,c.NameBook ,e.AuthorName,f.NameCate,c.PublishYear ,b.QuanlityImport,b.Price,b.Total,a.ImportDay,d.SupplierName,h.AreaName,l.RowName,j.CompartmentName FROM ImportBooks as a INNER JOIN DetailImportBooks as b ON a.ImportID = b.ImportID INNER JOIN Book as c ON c.BookID = b.BookID INNER JOIN Supplier as d ON d.SupplierID = a.SupplierID INNER JOIN Author as e ON e.AuthorID = c.AuthorID  INNER JOIN Category as f ON f.CategoryID = c.CategoryID INNER JOIN Location as g ON g.LocationID = c.LocationID INNER JOIN Area as h ON h.AreaID = g.AreaID INNER JOIN Row as l ON l.RowID = g.RowID INNER JOIN Compartment as j ON j.CompartmentID = g.CompartmentID";
            DataTable dt = DataProvider.Instance.ExecuteQuery(q);
            foreach (DataRow row in dt.Rows)
            {
                LoadImportBooks loadImportBooks = new LoadImportBooks(row);
                list.Add(loadImportBooks);
            }
            return list;
        }
        public List<LoadImportBooks> SearchImportBookByNameBook(string name)
        {
            List<LoadImportBooks> list = new List<LoadImportBooks>();
            string q = string.Format("SELECT a.ImportID,c.NameBook ,e.AuthorName,f.NameCate,c.PublishYear ,b.QuanlityImport,b.Price,b.Total,a.ImportDay,d.SupplierName,h.AreaName,l.RowName,j.CompartmentName FROM ImportBooks as a INNER JOIN DetailImportBooks as b ON a.ImportID = b.ImportID INNER JOIN Book as c ON c.BookID = b.BookID INNER JOIN Supplier as d ON d.SupplierID = a.SupplierID INNER JOIN Author as e ON e.AuthorID = c.AuthorID  INNER JOIN Category as f ON f.CategoryID = c.CategoryID INNER JOIN Location as g ON g.LocationID = c.LocationID INNER JOIN Area as h ON h.AreaID = g.AreaID INNER JOIN Row as l ON l.RowID = g.RowID INNER JOIN Compartment as j ON j.CompartmentID = g.CompartmentID WHERE c.NameBook like N'%{0}%'",name);
            DataTable dt = DataProvider.Instance.ExecuteQuery(q);
            foreach (DataRow row in dt.Rows)
            {
                LoadImportBooks loadImportBooks = new LoadImportBooks(row);
                list.Add(loadImportBooks);
            }
            return list;
        }
        public List<LoadImportBooks> SearchImportBookBySupplier(string name)
        {
            List<LoadImportBooks> list = new List<LoadImportBooks>();
            string q = string.Format("SELECT a.ImportID,c.NameBook ,e.AuthorName,f.NameCate,c.PublishYear ,b.QuanlityImport,b.Price,b.Total,a.ImportDay,d.SupplierName,h.AreaName,l.RowName,j.CompartmentName FROM ImportBooks as a INNER JOIN DetailImportBooks as b ON a.ImportID = b.ImportID INNER JOIN Book as c ON c.BookID = b.BookID INNER JOIN Supplier as d ON d.SupplierID = a.SupplierID INNER JOIN Author as e ON e.AuthorID = c.AuthorID  INNER JOIN Category as f ON f.CategoryID = c.CategoryID INNER JOIN Location as g ON g.LocationID = c.LocationID INNER JOIN Area as h ON h.AreaID = g.AreaID INNER JOIN Row as l ON l.RowID = g.RowID INNER JOIN Compartment as j ON j.CompartmentID = g.CompartmentID WHERE d.SupplierName like N'%{0}%'", name);
            DataTable dt = DataProvider.Instance.ExecuteQuery(q);
            foreach (DataRow row in dt.Rows)
            {
                LoadImportBooks loadImportBooks = new LoadImportBooks(row);
                list.Add(loadImportBooks);
            }
            return list;
        }
        
    }
}
