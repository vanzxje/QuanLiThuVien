using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            set { CategoryDAO.instance = value; }
        }
        private CategoryDAO() { }

        //Lấy danh sách thể loại
        public List<Category> LoadCategory()
        {
            List<Category> list = new List<Category>();
            string query = "Select * from Category ";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                Category category = new Category(dr);
                list.Add(category);
            }
            return list;
        }

        
        public Category GetCategoryByID(int id)
        {
            Category category = null;
            string query = "Select * from Category where CategoryID = " + id;
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                category = new Category(dr);
                return category;
            }
            return category;
        }

        //Thêm thể loại mới 
        public bool InsertCate(string name)
        {
            string query = string.Format("INSERT INTO Category VALUES (N'{0}')", name);
            int dataTable = DataProvider.Instance.ExecuteNonQuery(query);
            return dataTable > 0;
        }

        //Cập nhật lại thể loại
        public bool UpdateCate(string name, int id)
        {
            string query = string.Format("UPDATE Category SET NameCate = N'{0}' where CategoryID = '{1}'", name, id);
            int dataTable = DataProvider.Instance.ExecuteNonQuery(query);
            return dataTable > 0;
        }

        //Xóa thể loại
        public bool DeleteCate(int id)
        {
            string query = string.Format("Delete from Category where CategoryID = '{0}'", id);
            int dataTable = DataProvider.Instance.ExecuteNonQuery(query);
            return dataTable > 0;
        }

        //Tìm kiếm thể loại
        public List<Category> SearchCateByName(string name)
        {
            List<Category> categories = new List<Category>();
            string query = string.Format("SELECT * FROM Category WHERE NameCate like N'%{0}%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow dr in data.Rows)
            {
                Category category = new Category(dr);
                categories.Add(category);
            }
            return categories;
        }
    }
}
