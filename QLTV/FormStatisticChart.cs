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
    public partial class FormStatisticChart : Form
    {
        public int qui1;
        public int namchon;
        public int luachon;
        public FormStatisticChart()
        {
            InitializeComponent();
        }
        public void loadChartMember()
        {

            chart1.Series["Series1"].XValueMember = "MemberName";
            chart1.Series["Series1"].YValueMembers = "Number";
            chart1.Series["Series1"].IsValueShownAsLabel = true;
            chart1.Series["Series1"].Name = "Số Lượng Sách";
            chart1.Series["Series2"].YValueMembers = "Count";
            chart1.Series["Series2"].IsValueShownAsLabel = true;
            chart1.Series["Series2"].Name = "Số Lần Mượn";
        }
        public void loadChartImportBook()
        {

            chart1.Series["Series1"].XValueMember = "NameBook";
            chart1.Series["Series1"].YValueMembers = "Quanlity";
            chart1.Series["Series1"].IsValueShownAsLabel = true;
            chart1.Series["Series1"].Name = "Số Lượng Nhập";
            chart1.Series["Series2"].YValueMembers = "Total";
            chart1.Series["Series2"].IsValueShownAsLabel = true;
            chart1.Series["Series2"].Name = "Tổng Tiền";
        }
        public void loadChartPenalize()
        {

            chart1.Series["Series1"].XValueMember = "MemberName";
            chart1.Series["Series1"].YValueMembers = "Count";
            chart1.Series["Series1"].IsValueShownAsLabel = true;
            chart1.Series["Series1"].Name = "Số Lần Phạt";
            chart1.Series["Series2"].YValueMembers = "PricePenalize";
            chart1.Series["Series2"].IsValueShownAsLabel = true;
            chart1.Series["Series2"].Name = "Tiền Nộp Phạt";

        }
        public FormStatisticChart(int qui , int nam , int loai) : this()
        {
            qui1 = qui;
            namchon = nam;
            luachon = loai;
        }
        private void FormStatisticChart_Load(object sender, EventArgs e)
        {
            string Squi1 = "1/1/" + namchon;
            string Equi1 = "3/31/" + namchon;

            string Squi2 = "4/1/" + namchon;
            string Equi2 = "6/30/" + namchon;

            string Squi3 = "7/1/" + namchon;
            string Equi3 = "9/30/" + namchon;

            string Squi4 = "10/1/" + namchon;
            string Equi4 = "12/31/" + namchon;
            if (luachon == 1)
            {
                if(qui1 == 1)
                {
                    label6.Text = "Biểu Đồ Quí 1";
                    chart1.DataSource = StatisticMemberDAO.Instance.GetStatictisMemberListBYDate(Convert.ToDateTime(Squi1), Convert.ToDateTime(Equi1));
                    loadChartMember();
                }
                if (qui1 == 2)
                {
                    label6.Text = "Biểu Đồ Quí 2";
                    chart1.DataSource = StatisticMemberDAO.Instance.GetStatictisMemberListBYDate(Convert.ToDateTime(Squi2), Convert.ToDateTime(Equi2));
                    loadChartMember();
                }
                if (qui1 == 3)
                {
                    label6.Text = "Biểu Đồ Quí 3";
                    chart1.DataSource = StatisticMemberDAO.Instance.GetStatictisMemberListBYDate(Convert.ToDateTime(Squi3), Convert.ToDateTime(Equi3));
                    loadChartMember();
                }
                if (qui1 == 4)
                {
                    label6.Text = "Biểu Đồ Quí 4";
                    chart1.DataSource = StatisticMemberDAO.Instance.GetStatictisMemberListBYDate(Convert.ToDateTime(Squi4), Convert.ToDateTime(Equi4));
                    loadChartMember();
                }
            }
            if(luachon == 2)
            {
                if (qui1 == 1)
                {
                    label6.Text = "Biểu Đồ Quí 1";
                    chart1.DataSource = StatisticImportBookDAO.Instance.GetStatictisImportBookListBYDate(Convert.ToDateTime(Squi1), Convert.ToDateTime(Equi1));
                    loadChartImportBook();
                }
                if (qui1 == 2)
                {
                    label6.Text = "Biểu Đồ Quí 2";
                    chart1.DataSource = StatisticImportBookDAO.Instance.GetStatictisImportBookListBYDate(Convert.ToDateTime(Squi2), Convert.ToDateTime(Equi2));
                    loadChartImportBook();
                }
                if (qui1 == 3)
                {
                    label6.Text = "Biểu Đồ Quí 3";
                    chart1.DataSource = StatisticImportBookDAO.Instance.GetStatictisImportBookListBYDate(Convert.ToDateTime(Squi3), Convert.ToDateTime(Equi3));
                    loadChartImportBook();

                }
                if (qui1 == 4)
                {
                    label6.Text = "Biểu Đồ Quí 4";
                    chart1.DataSource = StatisticImportBookDAO.Instance.GetStatictisImportBookListBYDate(Convert.ToDateTime(Squi4), Convert.ToDateTime(Equi4));
                    loadChartImportBook();
                }

            }
            if(luachon == 3)
            {
                if (qui1 == 1)
                {
                    label6.Text = "Biểu Đồ Quí 1";
                    chart1.DataSource = StatisticPenalizeDAO.Instance.GetStatictisPenalizeListBYDate(Convert.ToDateTime(Squi1), Convert.ToDateTime(Equi1));
                    loadChartPenalize();
                }
                if (qui1 == 2)
                {
                    label6.Text = "Biểu Đồ Quí 2";
                    chart1.DataSource = StatisticPenalizeDAO.Instance.GetStatictisPenalizeListBYDate(Convert.ToDateTime(Squi2), Convert.ToDateTime(Equi2));
                    loadChartPenalize();
                }
                if (qui1 == 3)
                {
                    label6.Text = "Biểu Đồ Quí 3";
                    chart1.DataSource = StatisticPenalizeDAO.Instance.GetStatictisPenalizeListBYDate(Convert.ToDateTime(Squi3), Convert.ToDateTime(Equi3));
                    loadChartPenalize();
                }
                if (qui1 == 4)
                {
                    label6.Text = "Biểu Đồ Quí 4";
                    chart1.DataSource = StatisticPenalizeDAO.Instance.GetStatictisPenalizeListBYDate(Convert.ToDateTime(Squi4), Convert.ToDateTime(Equi4));
                    loadChartPenalize();
                }
            }
        }
    }
}
