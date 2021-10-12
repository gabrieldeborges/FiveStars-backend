using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Commands.Reservation.Output
{
    public class SearchReservationsResult
    {
        public int idClient { get; set; }
        public int idBedroom { get; set; }
        public int quantityBeds { get; set; }
        public int quantityBathroom { get; set; }
        public string nameClient { get; set; }
        public string emailClient { get; set; }
        public string cpfClient { get; set; }
        public DateTime initialDate { get; set; }
        public DateTime finalDate { get; set; }
        //public int MyProperty { get; set; }
    }
}
