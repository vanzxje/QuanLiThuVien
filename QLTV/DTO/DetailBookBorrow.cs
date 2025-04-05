using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class DetailBookBorrow
    {
        public DetailBookBorrow(DataRow row) 
        { 
            this.DetailID = (int)row["DetailID"];
            this.NumBer = (int)row["NumBer"];
            this.BookID = (int)row["BookID"];
            this.BorrowID = (int)row["BorrowID"];
        }
        private int detailID;
        private int numBer;
        private int bookID;
        private int borrowID;

        public int DetailID { get => detailID; set => detailID = value; }
        public int NumBer { get => numBer; set => numBer = value; }
        public int BookID { get => bookID; set => bookID = value; }
        public int BorrowID { get => borrowID; set => borrowID = value; }
    }
}
