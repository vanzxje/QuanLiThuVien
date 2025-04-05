using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class Account
    {
        public Account(int id, string name, string pass)
        {
            this.AccountID = id;
            this.AccountName = name;
            this.passWord = pass;
        }
        public Account(DataRow dataRow)
        {
            this.AccountID = (int)dataRow["AccountID"];
            this.AccountName = (string)dataRow["AccountName"];
            this.PassWord = (string)dataRow["PassWord"];
        }
        private int accountID;
        private string accountName;
        private string passWord;

        public int AccountID { get => accountID; set => accountID = value; }
        public string AccountName { get => accountName; set => accountName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
    }
}
