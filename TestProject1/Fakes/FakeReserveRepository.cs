using FIVESTARS.Domain.Commands.Reservation.Output;
using FIVESTARS.Domain.Entities;
using FIVESTARS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject1.Fakes
{
    public class FakeReserveRepository : IReservationRepository
    {
        public List<Reservation> AavailableForRent(int idBedroom, int idReserve, DateTime initialDate, DateTime finalDate)
        {

            //var bedroom = new Bedroom() { BED_TYPE = "CAMAS DE SOLTEIRO", DOOR = 2, FLOOR = 1, MORE_INFORMATION = "TESTE", ID = 1, QUANTITY_BATHROOM = 2, QUANTITY_BEDS = 2, STATUS = 0 };
            //var client = new Client() { BIRTH_DATE = DateTime.Now, CEP = "00000000", EMAIL = "SGADHAG@GMAIL.COM", CPF = "000000000", NOME = "GABRIEL", STATUS = 0, ID = 1 };
            //var reserve = new Reservation() { BEDROOM = bedroom, CLIENT = client, FINAL_DATE = DateTime.Parse("30/11/2001"), ID = 1, ID_BEDROOM = 1, ID_CLIENT = 1, INITIAL_DATE = DateTime.Now, OBSERVATION = "", STATUS = 0 };
            //var listaRetorno = new List<Reservation>();
            //listaRetorno.Add(reserve);
            return  new List<Reservation>(); 
        }

        public int SaveReservation(Reservation bedroom)
        {
            return 1;
        }

        public Reservation SearchReservationForID(int ID)
        {
            var bedroom = new Bedroom() { BED_TYPE = "CAMAS DE SOLTEIRO", DOOR = 2, FLOOR = 1, MORE_INFORMATION = "TESTE", ID = 1, QUANTITY_BATHROOM = 2, QUANTITY_BEDS = 2, STATUS = 0 };
            var client = new Client() { BIRTH_DATE = DateTime.Now, CEP = "00000000", EMAIL = "SGADHAG@GMAIL.COM", CPF = "000000000", NOME = "GABRIEL", STATUS = 0 , ID = 1};
            return new Reservation() { BEDROOM = bedroom, CLIENT = client, FINAL_DATE = DateTime.Now.AddDays(-20), ID = 1, ID_BEDROOM = 1, ID_CLIENT = 1, INITIAL_DATE = DateTime.Now, OBSERVATION = "", STATUS = 0 };
        }

        public List<SearchReservationsResult> SearchReservations()
        {

            var listBedroom = new List<Bedroom>();
            listBedroom.Add(new Bedroom() { BED_TYPE = "CAMAS DE SOLTEIRO", DOOR = 2, FLOOR = 1, MORE_INFORMATION = "TESTE", ID = 1, QUANTITY_BATHROOM = 2, QUANTITY_BEDS = 2, STATUS = 0 });

            var listClient  = new List<Client>();
            listClient.Add(new Client() { BIRTH_DATE = DateTime.Now, CEP = "00000000", EMAIL = "SGADHAG@GMAIL.COM", CPF = "000000000", NOME = "GABRIEL", STATUS = 0, ID = 1 });

            var listReserve = new List<Reservation>();
            listReserve.Add(new Reservation() { BEDROOM = listBedroom[0], CLIENT = listClient[0], FINAL_DATE = DateTime.Now.AddDays(-20), ID = 1, ID_BEDROOM = 1, ID_CLIENT = 1, INITIAL_DATE = DateTime.Now.AddDays(-19), OBSERVATION = "", STATUS = 0 });


            var reservations = (from reserve in listReserve
                                join bedroom in listBedroom on reserve.ID_BEDROOM equals bedroom.ID
                                join client in listClient on reserve.ID_CLIENT equals client.ID
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

        public int UpdateReservation(Reservation bedroom)
        {
            return 1;
        }
    }
}
