using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class ImportBooks
    {
        private int importID;
        private DateTime importDay;
        private int supplierID;

        public ImportBooks(int importID, DateTime importDay, int supplierID)
        {
            this.ImportID = importID;
            this.ImportDay = importDay;
            this.SupplierID = supplierID;
        }
        public ImportBooks(DataRow row) 
        {
            this.ImportID = (int)row["ImportID"];
            this.ImportDay = (DateTime)row["ImportDay"];
            this.SupplierID = (int)row["SupplierID"];
        }
        public int ImportID { get => importID; set => importID = value; }
        public DateTime ImportDay { get => importDay; set => importDay = value; }
        public int SupplierID { get => supplierID; set => supplierID = value; }
    }
}
