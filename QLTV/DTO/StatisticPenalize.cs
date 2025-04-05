using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class StatisticPenalize
    {
        private string memberName;
        private Decimal pricePenalize;
        private int count;

        public StatisticPenalize(string memberName, decimal pricePenalize, int count)
        {
            MemberName = memberName;
            PricePenalize = pricePenalize;
            Count = count;
        }
        public StatisticPenalize(DataRow row)
        {
            this.MemberName = (string)row["MemberName"];
            this.PricePenalize = Convert.ToDecimal(row["PricePenalize"]);
            this.Count = Convert.ToInt32(row["Count"]);
        }
        public string MemberName { get => memberName; set => memberName = value; }
        public Decimal PricePenalize { get => pricePenalize; set => pricePenalize = value; }
        public int Count { get => count; set => count = value; }
    }
}
