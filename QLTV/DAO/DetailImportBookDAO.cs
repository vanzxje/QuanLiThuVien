using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class DetailImportBookDAO
    {
        private DetailImportBookDAO() { }
        private static DetailImportBookDAO instance;
        public static DetailImportBookDAO Instance
        {
            get { if (instance == null) instance = new DetailImportBookDAO(); return DetailImportBookDAO.instance; }
            private set { DetailImportBookDAO.instance = value; }
        }

        //Thêm thông tin chi tiết sách nhập vào
        public bool InsertDetailImportBook(int quanlity, decimal price, decimal total, int bookID, int ImportID)
        {
            string query = string.Format("INSERT INTO DetailImportBooks VALUES ('{0}','{1}','{2}','{3}','{4}')",quanlity,price,total,bookID,ImportID);
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }

        //Chỉnh sửa thông tin phiếu chi tiết mượn sách
        public bool EditDetailImportBook(int idimport , int quanlity , decimal price)
        {
            string query = string.Format("UPDATE DetailImportBooks SET QuanlityImport = '{0}' , Price = '{1}' WHERE ImportID = '{2}'",quanlity,price,idimport);
            int dt = DataProvider.Instance.ExecuteNonQuery (query);
            return dt > 0;
        }

        //Lấy số lượng sách nhập vào
        public int GetQuanlityImportBook(int idimport)
        {
            string query = "SELECT QuanlityImport FROM DetailImportBooks WHERE ImportID = " + idimport;
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        //Lấy mã sách từ mã sách  nhập
        public int GetIDBookByDetailImportID(int idimport)
        {
            string query = "SELECT BookID FROM DetailImportBooks WHERE ImportID = " + idimport;
            int dt = (int)DataProvider.Instance.ExecuteScalar (query);
            return dt;
        }
        //public bool DeleteDetailImportBookByIdBook(int id)
        //{
        //    string query = "DELETE FROM DetailImportBooks WHERE BookID = " + id;
        //    int dt = DataProvider.Instance.ExecuteNonQuery(query);
        //    return dt > 0;
        //}
    }
}
