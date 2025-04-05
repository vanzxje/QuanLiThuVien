using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class Category
    {
        public Category(int cateid, string name)
        {
            this.Cateid = cateid;
            this.Namecate = name;

        }
        public Category(DataRow row)
        {
            this.Cateid = (int)row["CategoryID"];
            this.Namecate = (string)row["NameCate"];
        }
        private int cateid;
        private string namecate;

        public int Cateid { get => cateid; set => cateid = value; }
        public string Namecate { get => namecate; set => namecate = value; }
    }
}
