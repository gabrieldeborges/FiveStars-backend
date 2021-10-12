using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Entities
{
    public class Reservation
    {
        public int ID { get; set; }
        public int ID_CLIENT { get; set; }
        public int ID_BEDROOM { get; set; }
        public string OBSERVATION { get; set; }
        public DateTime INITIAL_DATE { get; set; }
        public DateTime FINAL_DATE { get; set; }
        public int STATUS { get; set; }
        public virtual Client CLIENT { get; set; }
        public virtual Bedroom BEDROOM { get; set; }
        public Reservation()
        {

        }

        public Reservation(int idClient, int idBedroom, string observation, DateTime initialDate, DateTime finalDate)
        {
            ID_CLIENT = idClient;
            ID_BEDROOM = idBedroom;
            OBSERVATION = observation;
            INITIAL_DATE = initialDate;
            FINAL_DATE = finalDate;
        }
    }
}
