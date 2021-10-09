using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Entities
{
    public class Bedroom
    {
        public int ID { get; set; }
        public int QUANTITY_BEDS { get; set; }
        public string BED_TYPE { get; set; }
        public string MORE_INFORMATION { get; set; }
        public int QUANTITY_BATHROOM { get; set; }
        public int FLOOR { get; set; }
        public int DOOR { get; set; }
        public int STATUS { get; set; }
        public Bedroom()
        {

        }

        public Bedroom(string bedType, int door, string moreInformation, int bquantityBeds, int quantityBathroom, int floor)
        {
            QUANTITY_BEDS = bquantityBeds;
            BED_TYPE = bedType;
            MORE_INFORMATION = moreInformation;
            QUANTITY_BATHROOM = quantityBathroom;
            FLOOR = floor;
            DOOR = door;
        } 
    }
}
