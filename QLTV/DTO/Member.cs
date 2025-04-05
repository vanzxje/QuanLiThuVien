using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class Member
    {
        public Member(int id, string name, string phone, string idCard, DateTime start, DateTime end)
        {
            this.MemberID = id;
            this.MemberName = name;
            this.PhoneNumber = phone;
            this.iDCard = idCard;
            this.StartDay = start;
            this.EndDay = end;
        }
        public Member(DataRow row)
        {
            this.MemberID = (int)row["MemberID"];
            this.MemberName = (string)row["MemberName"];
            this.PhoneNumber = (string)row["PhoneNumber"];
            this.iDCard = (string)row["IDCard"];
            this.StartDay = (DateTime)row["StartDay"];
            this.EndDay = (DateTime)row["EndDay"];
        }

        private int memberID;
        private string memberName;
        private string phoneNumber;
        private string iDCard;
        private DateTime startDay;
        private DateTime endDay;

        public int MemberID { get => memberID; set => memberID = value; }
        public string MemberName { get => memberName; set => memberName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string IDCard { get => iDCard; set => iDCard = value; }
        public DateTime StartDay { get => startDay; set => startDay = value; }
        public DateTime EndDay { get => endDay; set => endDay = value; }
    }
}
