using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class SupplierDAO
    {
        private SupplierDAO() { }
        private static SupplierDAO instance;
        public static SupplierDAO Instance
        {
            get { if (instance == null) instance = new SupplierDAO(); return SupplierDAO.instance; }
            private set { SupplierDAO.instance = value; }
        }

        //Lấy danh sách nhà cung cấp

        public List<Supplier> GetListSuppliers()
        {
            List<Supplier> list = new List<Supplier>();
            string query = "SELECT * FROM Supplier";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                Supplier supplier  = new Supplier(dr);
                list.Add(supplier);
            }
            return list;
        }
        //Tìm tên nhà cung cấp
        public List<Supplier> SearchSuppliers(string name)
        {
            List<Supplier> list = new List<Supplier>();
            string query = string.Format("SELECT * FROM Supplier WHERE SupplierName like UPPER(N'%{0}%')",name);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                Supplier supplier = new Supplier(dr);
                list.Add(supplier);
            }
            return list;
        }
        public Supplier GetSupplierByID(int idSupplier)
        {
            Supplier supplier = null;
            string query = "SELECT * FROM Supplier WHERE SupplierID = " + idSupplier;
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow dr in dt.Rows)
            {
                supplier = new Supplier(dr);
                return supplier;
            }
            return supplier;
        }

        //Thêm nhà cung cấp
        public bool InsertSupplier(string name ,string phone , string address)
        {
            string query = string.Format("INSERT INTO Supplier VALUES (N'{0}',N'{1}',N'{2}')",name,phone,address);
            int insert = DataProvider.Instance.ExecuteNonQuery(query);
            return insert > 0;
        }

        //Sửa nhà cung cấp
        public bool UpdateSupplier(int id , string name , string phone , string address)
        {
            string query = string.Format("UPDATE Supplier SET SupplierName = N'{0}' , Phone = N'{1}' , Address = N'{2}' WHERE SupplierID = '{3}'" , name,phone,address,id);
            int update = DataProvider.Instance.ExecuteNonQuery(query);
            return update > 0;
        }
        //Xóa nhà cung cấp
        public bool DeleteSupplier(int id)
        {
            string query = string.Format("DELETE FROM Supplier WHERE SupplierID = '{0}'",id);
            int delete = DataProvider.Instance.ExecuteNonQuery(query);
            return delete > 0;
        }
        public int GetSupplierIDByImportBook(int id)
        {
            string query = "SELECT COUNT(*) FROM Supplier as a INNER JOIN ImportBooks as b ON b.SupplierID = a.SupplierID where a.SupplierID = " + id;
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        public int GetSupplierIDFromImportBook(int id)
        {
            string query = "SELECT A.SupplierID FROM Supplier AS A INNER JOIN ImportBooks AS B ON A.SupplierID = B.SupplierID WHERE B.ImportID = " + id;
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        public int CheckSuplierIInImportbook(int id)
        {
            string query = "SELECT COUNT(*) FROM Supplier as a INNER JOIN ImportBooks as b ON b.SupplierID = a.SupplierID where b.ImportID = " + id;
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
    }
}
