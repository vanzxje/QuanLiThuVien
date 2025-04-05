using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class StatisticImportBook
    {
        private string nameBook;
        private int quanlity;
        private Decimal total;
        public StatisticImportBook(string nameBook, int quanlity, decimal price)
        {
            this.NameBook = nameBook;
            this.Quanlity = quanlity;
            this.Total = price;
        }
        public StatisticImportBook(DataRow row)
        {
            this.NameBook = row["NameBook"].ToString();
            this.quanlity = (int)row["Quanlity"];
            this.total = Convert.ToDecimal(row["Total"]);
        }
        public string NameBook { get => nameBook; set => nameBook = value; }
        public int Quanlity { get => quanlity; set => quanlity = value; }
        public Decimal Total { get => total; set => total = value; }
    }
}
