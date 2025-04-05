using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class Row
    {
        private int rowID;
        private string rowName;

        public Row(int rowID, string rowName)
        {
            this.RowID = rowID;
            this.RowName = rowName;
        }
        public Row(DataRow row)
        {
            this.RowID = (int)row["RowID"];
            this.RowName = (string)row["RowName"];
        }
        public int RowID { get => rowID; set => rowID = value; }
        public string RowName { get => rowName; set => rowName = value; }
    }
}
