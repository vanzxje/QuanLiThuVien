using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class Area
    {
        private int areaID;
        private string areaName;

        public Area(int areaID, string areaName)
        {
            AreaID = areaID;
            AreaName = areaName;
        }
        public Area(DataRow row)
        {
            this.AreaID = (int)row["AreaID"];
            this.AreaName = (string)row["AreaName"];
        }
        public int AreaID { get => areaID; set => areaID = value; }
        public string AreaName { get => areaName; set => areaName = value; }
    }
}
