using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class LocationDAO
    {
        private static LocationDAO instance;
        public static LocationDAO Instance
        {
            get { if (instance == null) instance = new LocationDAO(); return LocationDAO.instance; }
            set { LocationDAO.instance = value; }
        }
        private LocationDAO() { }

        public bool UpdateLocation(int idlocation, int idArea , int idRow , int idCom)
        {
            string query = string.Format("UPDATE Location SET AreaID = '{0}' , RowID = '{1}' , CompartmentID = '{2}' WHERE LocationID = '{3}'", idArea,idRow,idCom, idlocation);
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }
        //public List<LocationDetail> GetListLocationDetail()
        //{
        //    List<LocationDetail> list = new List<LocationDetail>();
        //    string query = "SELECT a.LocationID,b.AreaName,c.RowName,d.CompartmentName FROM Location as a INNER JOIN Area as b ON a.AreaID =b.AreaID INNER JOIN Row as c ON c.RowID = a.RowID INNER JOIN Compartment as d ON a.CompartmentID = d.CompartmentID";
        //    DataTable data = DataProvider.Instance.ExecuteQuery(query);
        //    foreach (DataRow row in data.Rows) 
        //    {
        //        LocationDetail placePutDetail = new LocationDetail(row);
        //        list.Add(placePutDetail);
        //    }
        //    return list;
        //}
        public bool DeleteLocationDetail(int id)
        {
            string query = "DELETE FROM Location WHERE LocationID = " + id;
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }
        //Lấy vị trí mới vừa chèn vào
        public int GetIDMaxLoaction()
        {
            string query = "SELECT LocationID FROM Location ORDER BY LocationID Desc";
            int id = (int)DataProvider.Instance.ExecuteScalar(query);
            return id;
        }
        //Chèn vị trí mới sau khi nhập sách
        public bool InsertLocation(int idArea , int idRow , int idCompartment)
        {
            string query = string.Format("INSERT INTO Location VALUES ('{0}','{1}','{2}')",idArea,idRow,idCompartment);
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }
        #region Xóa Vị Khu Ngăn Hàng Khi không còn sách
        public int CheckAreaInLocation(int id)
        {
            string query = "SELECT COUNT(*) FROM Location WHERE AreaID = " + id;
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        public int CheckRowInLocation(int id)
        {
            string query = "SELECT COUNT(*) FROM Location WHERE RowID = " + id;
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        public int CheckCompartmentInLocation(int id)
        {
            string query = "SELECT COUNT(*) FROM Location WHERE CompartmentID = " + id;
            int dt = (int)DataProvider.Instance.ExecuteScalar(query);
            return dt;
        }
        public bool DeleteAllLocationHaveArea(int idArea)
        {
            string query = "DELETE FROM Location WHERE AreaID = " + idArea;
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }
        public bool DeleteAllLocationHaveRow(int id)
        {
            string query = "DELETE FROM Location WHERE RowID = " + id;
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }
        public bool DeleteAllLocationHaveCompartment(int id)
        {
            string query = "DELETE FROM Location WHERE CompartmentID = " + id;
            int dt = DataProvider.Instance.ExecuteNonQuery(query);
            return dt > 0;
        }
        #endregion
    }
}
