using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class DetailPenalize
    {
        private int penalizeID;
        private string memberName;
        private string nameBook;
        private int numberDay;
        private DateTime? date;
        private float pricePenalize;

        public DetailPenalize(int penalizeID, string memberName, string nameBook, int numberDay, DateTime date, float pricePenalize)
        {
            this.PenalizeID = penalizeID;
            this.MemberName = memberName;
            this.NameBook = nameBook;
            this.NumberDay = numberDay;
            this.Date = date;
            this.PricePenalize = pricePenalize;
        }
        public DetailPenalize(DataRow row) 
        {
            this.PenalizeID = (int)row["PenalizeID"];
            this.MemberName = (string)row["MemberName"];
            this.NameBook = (string)row["NameBook"];
            this.NumberDay = (int)row["NumberDay"];
            var payday = row["Date"];
            if (payday.ToString() != "")
            {
                this.Date = (DateTime?)row["Date"];
            }
            this.PricePenalize = (float)Convert.ToDouble(row["PricePenalize"].ToString());
        }
        public int PenalizeID { get => penalizeID; set => penalizeID = value; }
        public string MemberName { get => memberName; set => memberName = value; }
        public string NameBook { get => nameBook; set => nameBook = value; }
        public int NumberDay { get => numberDay; set => numberDay = value; }
        public DateTime? Date { get => date; set => date = value; }
        public float PricePenalize { get => pricePenalize; set => pricePenalize = value; }
    }
}
