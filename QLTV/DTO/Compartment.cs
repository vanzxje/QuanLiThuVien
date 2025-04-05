using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace QLTV.DTO
{
    public class Compartment
    {

        private int compartmentID;
        private string compartmentName;

        public Compartment(int compartmentID, string compartmentName)
        {
            this.CompartmentID = compartmentID;
            this.CompartmentName = compartmentName;
        }
        public Compartment(DataRow row)
        {
            this.CompartmentID = (int)row["CompartmentID"];
            this.CompartmentName = (string)row["CompartmentName"];
        }
        public int CompartmentID { get => compartmentID; set => compartmentID = value; }
        public string CompartmentName { get => compartmentName; set => compartmentName = value; }
    }
}
