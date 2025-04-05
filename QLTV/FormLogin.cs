using QLTV.DAO;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        bool LoadLogin(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string name = txtNameAccount.Text;
            string pass = txtPassWord.Text;
            if (LoadLogin(name, pass))
            {
                FormMain frm = new FormMain();
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai thông tin tài khoản hoặc mật khẩu", "Thông Báo", MessageBoxButtons.OK);
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn muốn đóng chương trình?" , "Thông báo" ,MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
