using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class RowDAO
    {
        private static RowDAO instance;
        public static RowDAO Instance
        {
            get { if (instance == null) instance = new RowDAO(); return RowDAO.instance; }
            set { RowDAO.instance = value; }
        }
        private RowDAO() { }

        //danh sách hàng để sách
        public List<Row> GetListRow()
        {
            List<Row> list = new List<Row>();
            string query = "SELECT * FROM Row";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                Row Row = new Row(item);
                list.Add(Row);
            }
            return list;
        }

        //Tìm kiếm hàng để sách
        public List<Row> SearchRow(string name)
        {
            List<Row> list = new List<Row>();
            string query = string.Format("SELECT * FROM Row WHERE RowName like UPPER(N'%{0}%')",name);
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                Row Row = new Row(item);
                list.Add(Row);
            }
            return list;
        }

        //Thêm hàng mới
        public bool InsertRow(string name)
        {
            string query = string.Format("INSERT INTO Row VALUES (N'{0}')", name);
            int insert = DataProvider.Instance.ExecuteNonQuery(query);
            return insert > 0;
        }

        //Cập nhập hàng
        public bool UpdateRow(int id, string name)
        {
            string query = string.Format("UPDATE Row SET RowName = N'{0}' WHERE RowID = '{1}'", name, id);
            int insert = DataProvider.Instance.ExecuteNonQuery(query);
            return insert > 0;
        }

        //Xóa hàng
        public bool DeleteRow(int id)
        {
            string query = string.Format("DELETE FROM Row WHERE RowID = '{0}'", id);
            int insert = DataProvider.Instance.ExecuteNonQuery(query);
            return insert > 0;
        }
        public Row GetRowByPlaceId(int id)
        {
            Row row = null;
            string query = "SELECT a.RowID , a.RowName FROM Row as a INNER JOIN Location as b ON a.RowID = b.RowID WHERE b.LocationID = " + id;
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                row = new Row(item);
                return row;
            }
            return row;
        }
    }
}
