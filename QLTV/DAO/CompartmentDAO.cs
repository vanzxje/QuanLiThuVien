using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class CompartmentDAO
    {
        private static CompartmentDAO instance;
        public static CompartmentDAO Instance
        {
            get { if (instance == null) instance = new CompartmentDAO(); return CompartmentDAO.instance; }
            set { CompartmentDAO.instance = value; }
        }
        private CompartmentDAO() { }

        //Danh sách ngăn để sách
        public List<Compartment> GetListCompartment()
        {
            List<Compartment> list = new List<Compartment>();
            string query = "SELECT * FROM Compartment";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                Compartment Compartment = new Compartment(item);
                list.Add(Compartment);
            }
            return list;
        }

        //Tìm kiếm ngăn sách
        public List<Compartment> SearchCompartment(string name)
        {
            List<Compartment> list = new List<Compartment>();
            string query = string.Format("SELECT * FROM Compartment WHERE CompartmentName like N'%{0}%'",name);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                Compartment Compartment = new Compartment(item);
                list.Add(Compartment);
            }
            return list;
        }

        //Thêm ngăn sách mới
        public bool InsertCompartment(string name)
        {
            string query = string.Format("INSERT INTO Compartment VALUES (N'{0}')", name);
            int insert = DataProvider.Instance.ExecuteNonQuery(query);
            return insert > 0;
        }

        //Sửa ngăn sách
        public bool UpdateCompartment(int id, string name)
        {
            string query = string.Format("UPDATE Compartment SET CompartmentName = N'{0}' WHERE CompartmentID = '{1}'", name, id);
            int insert = DataProvider.Instance.ExecuteNonQuery(query);
            return insert > 0;
        }

        //Xóa ngăn sách
        public bool DeleteCompartment(int id)
        {
            string query = string.Format("DELETE FROM Compartment WHERE CompartmentID = '{0}'", id);
            int insert = DataProvider.Instance.ExecuteNonQuery(query);
            return insert > 0;
        }
        public Compartment GetCompartmentById(int id)
        {
            Compartment compartment = null;
            string query = "SELECT a.CompartmentID,a.CompartmentName FROM Compartment as a INNER JOIN Location as b ON a.CompartmentID= b.CompartmentID WHERE b.LocationID = " + id;
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                compartment = new Compartment(item);
                return compartment;
            }
            return compartment;
        }
    }
}
