using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class AuthorDAO
    {
        private AuthorDAO() { }
        private static AuthorDAO instance;
        public static AuthorDAO Instance
        {
            get { if (instance == null) instance = new AuthorDAO(); return AuthorDAO.instance; }
            private set { AuthorDAO.instance = value; }
        }

        //Lấy danh sách tác giả
        public List<Author> GetAuthor()
        {
            List<Author> list = new List<Author>();
            string query = "SELECT * FROM Author";
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                Author author = new Author(row);
                list.Add(author);
            }
            return list;
        }

        //Tìm kiếm tác giả
        public List<Author> SearchAuthorName(string name)
        {
            List<Author> list = new List<Author>();
            string query = string.Format("SELECT * FROM Author WHERE AuthorName like UPPER(N'%{0}%')",name);
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                Author author = new Author(row);
                list.Add(author);
            }
            return list;
        }

        //Lấy thông tin tác giả từ id tác giả (dk load combobox)
        public Author GetAuthorById(int id)
        {
            Author author = null;
            string query = "SELECT * FROM Author where AuthorID = " + id;
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in dataTable.Rows)
            {
                author = new Author(row);
                return author;
            }
            return author;
        }

        //Thêm tác giả
        public bool InsertAuthor(string name, string gender, string homeland)
        {
            string query = string.Format("INSERT INTO Author VALUES (N'{0}',N'{1}' , N'{2}')", name, gender, homeland);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }

        //Sửa tác giả
        public bool EditAuthor(int id, string name, string gender, string homeland)
        {
            string query = string.Format("UPDATE Author SET AuthorName = N'{0}' , Gender = N'{1}' , HomeLand = N'{2}' where AuthorID = '{3}'", name, gender, homeland, id);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }

        //Xóa tác giả
        public bool DeleteAuthor(int id)
        {
            string query = string.Format("Delete from Author where AuthorID = '{0}'", id);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
    }
}
