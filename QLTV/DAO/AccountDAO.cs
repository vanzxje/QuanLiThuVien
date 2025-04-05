using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            set { AccountDAO.instance = value; }
        }
        private AccountDAO() { }
        public bool Login(string username, string password)
        {
            string query = string.Format("SELECT * FROM Account where AccountName = N'{0}' and PassWord = N'{1}'",username,password);
            DataTable dataTable = DataProvider.Instance.ExecuteQuery(query);
            return dataTable.Rows.Count > 0;
        }

        public bool UpdateAccount(string username, string password, string newpass)
        {
            string query =string.Format("UPDATE Account SET PassWord = N'{0}' where AccountName = N'{1}' And PassWord = N'{2}'",newpass,username,password);
            int data = DataProvider.Instance.ExecuteNonQuery(query);
            return data > 0;
        }
        public List<Account> GetAccounts()
        {
            List<Account> accounts = new List<Account>();
            string query = "Select * from Account";
            DataTable dt = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                Account account = new Account(row);
                accounts.Add(account);
            }
            return accounts;
        }
    }
}
