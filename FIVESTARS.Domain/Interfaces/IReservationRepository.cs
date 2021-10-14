using FIVESTARS.Domain.Commands.Reservation.Output;
using FIVESTARS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Interfaces
{
    public interface IReservationRepository
    {
        public int SaveReservation(Reservation bedroom);
        public int UpdateReservation(Reservation bedroom);
        public List<SearchReservationsResult> SearchReservations();
        public Reservation SearchReservationForID(int ID);
        public bool AavailableForRent(int idBedroom, int idReserve, DateTime initialDate, DateTime finalDate);

    }
}
