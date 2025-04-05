using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class LoadImportBooks
    {
        private int importID;
        private string nameBook;
        private string authorName;
        private string nameCate;
        private int publishYear;
        private int quanlityImport;
        private decimal price;
        private decimal total;
        private DateTime importDay;
        private string supplierName;
        private string areaName;
        private string rowName;
        private string compartmentName;

        public LoadImportBooks(int importID, string nameBook, string authorName, string nameCate, int publishYear,int quanlity, decimal price , decimal total, DateTime importDay, string supplierName, string areaName, string rowName, string compartmentName)
        {
            this.ImportID = importID;
            this.NameBook = nameBook;
            this.AuthorName = authorName;
            this.NameCate = nameCate;
            this.PublishYear = publishYear;
            this.QuanlityImport = quanlity;
            this.Price = price;
            this.Total = total;
            this.ImportDay = importDay;
            this.SupplierName = supplierName;
            this.AreaName = areaName;
            this.RowName = rowName;
            this.CompartmentName = compartmentName;
        }
        public LoadImportBooks(DataRow row) 
        {
            this.ImportID = (int)row["ImportID"];
            this.NameBook = (string)row["NameBook"];
            this.AuthorName = (string)row["AuthorName"];
            this.NameCate = (string)row["NameCate"];
            this.PublishYear = (int)row["PublishYear"];
            this.QuanlityImport = (int)row["QuanlityImport"];
            this.Price = Convert.ToDecimal((row["Price"].ToString()));
            this.Total = Convert.ToDecimal((row["Total"].ToString()));
            this.ImportDay = (DateTime)row["ImportDay"];
            this.SupplierName = (string)row["SupplierName"];
            this.AreaName = (string)row["AreaName"];
            this.RowName = (string)row["RowName"];
            this.CompartmentName = (string)row["CompartmentName"];
        }
        public int ImportID { get => importID; set => importID = value; }
        public string NameBook { get => nameBook; set => nameBook = value; }
        public string AuthorName { get => authorName; set => authorName = value; }
        public string NameCate { get => nameCate; set => nameCate = value; }
        public int PublishYear { get => publishYear; set => publishYear = value; }
        public decimal Price { get => price; set => price = value; }
        public decimal Total { get => total; set => total = value; }
        public DateTime ImportDay { get => importDay; set => importDay = value; }
        public string SupplierName { get => supplierName; set => supplierName = value; }
        public string AreaName { get => areaName; set => areaName = value; }
        public string RowName { get => rowName; set => rowName = value; }
        public string CompartmentName { get => compartmentName; set => compartmentName = value; }
        public int QuanlityImport { get => quanlityImport; set => quanlityImport = value; }
    }
}
