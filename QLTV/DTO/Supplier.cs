using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class Supplier
    {
        private int supplierID;
        private string supplierName;
        private string phone;
        private string address;

        public Supplier(int supplierID, string supplierName, string phone, string address)
        {
            this.SupplierID = supplierID;
            this.SupplierName = supplierName;
            this.Phone = phone;
            this.Address = address;
        }
        public Supplier(DataRow row)
        {
            this.SupplierID = (int)row["SupplierID"];
            this.SupplierName = (string)row["SupplierName"];
            this.Phone = (string)row["Phone"];
            this.Address = (string)row["Address"];
        }
        public int SupplierID { get => supplierID; set => supplierID = value; }
        public string SupplierName { get => supplierName; set => supplierName = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
    }
}
