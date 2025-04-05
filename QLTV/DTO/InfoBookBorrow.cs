using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class InfoBookBorrow
    {

        public InfoBookBorrow(DataRow row) 
        {
            this.BorrowID = (int)row["BorrowID"];
            this.NameBook = (string)row["NameBook"];
            this.NameMember = (string)row["MemberName"];
            this.NumBer = (int)row["Number"];
            this.BorrowDay = (DateTime)row["BorrowDay"];
            var payday = row["PayDay"];
            if (payday.ToString() != "")
            {
                this.PayDay = (DateTime?)row["PayDay"];
            }
            
        }

        public InfoBookBorrow(int borrowID, string nameBook, string nameMember, int numBer, DateTime borrowDay, DateTime payDay)
        {
            this.BorrowID = borrowID;
            this.NameBook = nameBook;
            this.NameMember = nameMember;
            this.NumBer = numBer;
            this.BorrowDay = borrowDay;
            this.PayDay = payDay;   
        }

        private int borrowID;
        private string nameBook;
        private string nameMember;
        private int numBer;
        private DateTime borrowDay;
        private DateTime? payDay;

        public int BorrowID { get => borrowID; set => borrowID = value; }
        public string NameBook { get => nameBook; set => nameBook = value; }
        public string NameMember { get => nameMember; set => nameMember = value; }
        public int NumBer { get => numBer; set => numBer = value; }
        public DateTime BorrowDay { get => borrowDay; set => borrowDay = value; }
        public DateTime? PayDay { get => payDay; set => payDay = value; }
    }
}
