using QLTV.DAO;
using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLTV
{
    public partial class FormEditAccount : Form
    {
        public FormEditAccount()
        {
            InitializeComponent();
            LoadAccount();
        }
        void LoadAccount()
        {
            List<Account> accounts = AccountDAO.Instance.GetAccounts();
            foreach (Account account in accounts)
            {
                txtNameAccount.Text = account.AccountName;
                break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtNameAccount.Text;
            string pass = txtOldPass.Text;
            string newpass = txtNewPass.Text;
            string comfrompass = txtComfromPass.Text;
            if(newpass == comfrompass)
            {
                if (AccountDAO.Instance.UpdateAccount(name, pass, newpass))
                {
                    MessageBox.Show("Lưu Thành Công", "Thông Báo");
                    txtOldPass.ResetText();
                    txtNewPass.ResetText();
                    txtComfromPass.ResetText();
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu nhập lại không đúng", "Thông Báo", MessageBoxButtons.OK);
            }

        }
    }
}
