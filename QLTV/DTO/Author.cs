using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class Author
    {
        public Author(int id, string name, string gender, string homland)
        {
            this.AuthorId = id;
            this.AuthorName = name;
            this.Gender = gender;
            this.HomeLand = homland;
        }
        public Author(DataRow row)
        {
            this.AuthorId = (int)row["AuthorID"];
            this.AuthorName = (string)row["AuthorName"];
            this.Gender = (string)row["Gender"];
            this.HomeLand = (string)row["HomeLand"];
        }
        private int authorId;
        private string authorName;
        private string gender;
        private string homeLand;

        public int AuthorId { get => authorId; set => authorId = value; }
        public string AuthorName { get => authorName; set => authorName = value; }
        public string Gender { get => gender; set => gender = value; }
        public string HomeLand { get => homeLand; set => homeLand = value; }
    }
}
