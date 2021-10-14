using FIVESTARS.Domain.Commands.Reservation.Output;
using FIVESTARS.Domain.Entities;
using FIVESTARS.Domain.Interfaces;
using FIVESTARS.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIVESTARS.Infra.Repository
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        private readonly Context _context;
        public ReservationRepository(Context context) : base(context)
        {
            _context = context;
        }

        public List<Reservation> AavailableForRent(int idBedroom, int idReseerve, DateTime initialDate, DateTime finalDate)
        {
            var teste = from reserve in DbSet
                        where reserve.STATUS != 1
                        && ((initialDate.Date >= reserve.INITIAL_DATE.Date && initialDate.Date <= reserve.FINAL_DATE.Date) 
                            || (finalDate.Date >=reserve.INITIAL_DATE.Date && finalDate.Date <= reserve.FINAL_DATE.Date))
                        && reserve.ID_BEDROOM == idBedroom
                        && reserve.ID != idReseerve
                        select reserve;
            return teste.ToList();
        }

        public int SaveReservation(Reservation reserve)
        {
            return Insert(reserve);
        }

        public Reservation SearchReservationForID(int id)
        {
            return DbSet.First(x => x.ID == id);
        }

        public List<SearchReservationsResult> SearchReservations()
        {
            var reservations = (from reserve in DbSet
                                join bedroom in Db.Bedroom on reserve.ID_BEDROOM equals bedroom.ID
                                join client in Db.Client on reserve.ID_CLIENT equals client.ID
                                where reserve.STATUS != 1 && bedroom.STATUS != 1
                                select new SearchReservationsResult
                                {
                                    id = reserve.ID,
                                    idClient = client.ID,
                                    idBedroom = bedroom.ID,
                                    quantityBeds = bedroom.QUANTITY_BEDS,
                                    quantityBathroom = bedroom.QUANTITY_BATHROOM,
                                    nameClient = client.NOME,
                                    emailClient = client.EMAIL,
                                    observation = reserve.OBSERVATION,
                                    cpfClient = client.CPF,
                                    finalDate = reserve.FINAL_DATE,
                                    initialDate = reserve.INITIAL_DATE
                                }).ToList();

            return reservations;
        }

        public int UpdateReservation(Reservation reserve)
        {
            return Update(reserve);
        }
    }
}
