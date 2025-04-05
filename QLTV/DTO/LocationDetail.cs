using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class LocationDetail
    {
        private int locationID;
        private string areaName;
        private string rowName;
        private string compartmentName;

        public int LocationID { get => locationID; set => locationID = value; }
        public string AreaName { get => areaName; set => areaName = value; }
        public string RowName { get => rowName; set => rowName = value; }
        public string CompartmentName { get => compartmentName; set => compartmentName = value; }

       
        public LocationDetail(DataRow row)
        {
            this.LocationID = (int)row["LocationID"];
            this.AreaName = (string)row["AreaName"];
            this.RowName = (string)row["RowName"];
            this.CompartmentName = (string)row["CompartmentName"];
        }

        public LocationDetail(int locationID, string areaName, string rowName, string compartmentName)
        {
            this.LocationID = locationID;
            this.AreaName = areaName;
            this.RowName = rowName;
            this.CompartmentName = compartmentName;
        }
    }
}
