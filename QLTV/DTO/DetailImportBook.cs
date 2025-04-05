using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace QLTV.DTO
{
    public class DetailImportBook
    {
        private int detailIDImport;
        private int quanlityImport;
        private decimal price;
        private decimal total;
        private int bookID;
        private int importID;

        public DetailImportBook(int detailIDImport, int quanlityImport, decimal price, decimal total, int bookID, int importID)
        {
            this.DetailIDImport = detailIDImport;
            this.QuanlityImport = quanlityImport;
            this.Price = price;
            this.Total = total;
            this.BookID = bookID;
            this.ImportID = importID;
        }
        public DetailImportBook(DataRow row) 
        {
            this.DetailIDImport = (int)row["DetailIDImport"];
            this.QuanlityImport = (int)row["QuanlityImport"];
            this.Price = Convert.ToDecimal(row["Price"]);
            this.Total = Convert.ToDecimal(row["Total"]);
            this.BookID = (int)row["BookID"];
            this.ImportID = (int)row["ImportID"];
        }
        public int DetailIDImport { get => detailIDImport; set => detailIDImport = value; }
        public int QuanlityImport { get => quanlityImport; set => quanlityImport = value; }
        public decimal Price { get => price; set => price = value; }
        public decimal Total { get => total; set => total = value; }
        public int BookID { get => bookID; set => bookID = value; }
        public int ImportID { get => importID; set => importID = value; }
    }
}
