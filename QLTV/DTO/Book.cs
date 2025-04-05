using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class Book
    {
        private int bookID;
        private string nameBook;
        private int quanlity;
        private int authorID;
        private int categoryID;
        private int publishYear;
        private int locationID;

        public Book(int bookID, string nameBook, int quanlity, int authorID, int categoryID, int publish , int locationID)
        {
            this.BookID = bookID;
            this.NameBook = nameBook;
            this.Quanlity = quanlity;
            this.AuthorID = authorID;
            this.CategoryID = categoryID;
            this.LocationID = locationID;
            this.PublishYear = publish;
            
        }
        public Book(DataRow row)
        {
            this.BookID = (int)row["BookID"];
            this.NameBook = (string)row["NameBook"];
            this.Quanlity = (int)row["Quanlity"];
            this.AuthorID = (int)row["AuthorID"];
            this.CategoryID = (int)row["CategoryID"];
            this.LocationID = (int)row["LocationID"];
            this.PublishYear = (int)row["PublishYear"];
            
        }
        public int BookID { get => bookID; set => bookID = value; }
        public string NameBook { get => nameBook; set => nameBook = value; }
        public int Quanlity { get => quanlity; set => quanlity = value; }
        public int AuthorID { get => authorID; set => authorID = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public int PublishYear { get => publishYear; set => publishYear = value; }
        public int LocationID { get => locationID; set => locationID = value; }
    }
}
