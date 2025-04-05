using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class Location
    {
        private int locationID;
        private int areaID;
        private int rowID;
        private int compartmentID;

        public Location(int locationID, int areaID, int rowID, int compartmentID)
        {
            this.locationID = locationID;
            this.AreaID = areaID;
            this.RowID = rowID;
            this.CompartmentID = compartmentID;
        }
        public Location(DataRow row) 
        {
            this.locationID = (int)row["LocationID"];
            this.AreaID = (int)row["AreaID"];
            this.RowID = (int)row["RowID"];
            this.CompartmentID = (int)row["CompartmentID"];
        }
        public int LocationID { get => locationID; set => locationID = value; }
        public int AreaID { get => areaID; set => areaID = value; }
        public int RowID { get => rowID; set => rowID = value; }
        public int CompartmentID { get => compartmentID; set => compartmentID = value; }
    }
}
