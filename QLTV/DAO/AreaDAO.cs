using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class AreaDAO
    {
        private static AreaDAO instance;
        public static AreaDAO Instance
        {
            get { if (instance == null) instance = new AreaDAO(); return AreaDAO.instance; }
            set { AreaDAO.instance = value; }
        }
        private AreaDAO() { }

        //Lấy danh sách khu vực để sách
        public List<Area> GetListArea()
        {
            List<Area> list = new List<Area>();
            string query = "SELECT * FROM Area";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                Area area = new Area(item);
                list.Add(area);
            }
            return list;
        }

        //Tìm kiếm khu vực để sách
        public List<Area> SearchArea(string name)
        {
            List<Area> list = new List<Area>();
            string query = string.Format("SELECT * FROM Area WHERE AreaName like UPPER(N'%{0}%')",name);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                Area area = new Area(item);
                list.Add(area);
            }
            return list;
        }

        //Thêm khu vực mới
        public bool InsertArea(string name)
        {
            string query = string.Format("INSERT INTO Area VALUES (N'{0}')" , name);
            int insert = DataProvider.Instance.ExecuteNonQuery(query);
            return insert > 0;
        }

        //Sửa khu vực
        public bool UpdateArea(int id , string name)
        {
            string query = string.Format("UPDATE Area SET AreaName = N'{0}' WHERE AreaID = '{1}'", name,id);
            int insert = DataProvider.Instance.ExecuteNonQuery(query);
            return insert > 0;
        }

        //Xóa khu vực
        public bool DeleteArea(int id)
        {
            string query = string.Format("DELETE FROM Area WHERE AreaID = '{0}'", id);
            int insert = DataProvider.Instance.ExecuteNonQuery(query);
            return insert > 0;
        }
        public Area GetAreaByPlaceId(int id)
        {
            Area area = null;
            string query = "SELECT a.AreaID , a.AreaName FROM Area as a INNER JOIN Location as b ON a.AreaID = b.AreaID WHERE b.LocationID =  " + id;
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                area = new Area(item);
                return area;
            }
            return area;
        }

    }
}
