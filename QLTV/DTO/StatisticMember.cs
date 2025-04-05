using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class StatisticMember
    {
        private string memberName;
        private int number;
        private int count;

        public StatisticMember(string memberName, int number, int count)
        {
            MemberName = memberName;
            Number = number;
            Count = count;
        }
        public StatisticMember(DataRow row)
        {
            this.MemberName = (string)row["MemberName"];
            this.Number = (int)row["Number"];
            this.Count = (int)row["Count"];
        }
        public string MemberName { get => memberName; set => memberName = value; }
        public int Number { get => number; set => number = value; }
        public int Count { get => count; set => count = value; }
    }
}
