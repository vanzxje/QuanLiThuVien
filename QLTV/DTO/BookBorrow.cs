using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class BookBorrow
    {
        public BookBorrow(int borrowID , DateTime borrowDay , DateTime payDay , int memberID) 
        {
            this.BorrowID = borrowID;
            this.BorrowDay = borrowDay;
            this.PayDay = payDay;
            this.MemberID = memberID;
        }
        public BookBorrow (DataRow row) 
        { 
            this.BorrowID = (int)row["BorrowID"];
            this.BorrowDay = (DateTime)row["BorrowDay"];
            this.PayDay = (DateTime)row["PayDay"];
            this.MemberID = (int)row["MemberID"];
        }    
        private int borrowID;
        private DateTime borrowDay;
        private DateTime payDay;
        private int memberID;

        public int BorrowID { get => borrowID; set => borrowID = value; }
        public DateTime BorrowDay { get => borrowDay; set => borrowDay = value; }
        public DateTime PayDay { get => payDay; set => payDay = value; }
        public int MemberID { get => memberID; set => memberID = value; }
    }
}
