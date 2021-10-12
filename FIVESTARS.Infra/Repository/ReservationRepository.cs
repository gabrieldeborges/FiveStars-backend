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

        public bool AavailableForRent(int idBedroom)
        {
            var teste = from reserve in DbSet
                        where reserve.STATUS != 1
                        && (DateTime.Now.Date >= reserve.INITIAL_DATE.Date && DateTime.Now.Date <= reserve.FINAL_DATE.Date)
                        && reserve.ID_BEDROOM == idBedroom
                        select reserve;
            return !teste.Any();
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
                                    idClient = client.ID,
                                    idBedroom = bedroom.ID,
                                    quantityBeds = bedroom.QUANTITY_BEDS,
                                    quantityBathroom = bedroom.QUANTITY_BATHROOM,
                                    nameClient = client.NOME,
                                    emailClient = client.EMAIL,
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
