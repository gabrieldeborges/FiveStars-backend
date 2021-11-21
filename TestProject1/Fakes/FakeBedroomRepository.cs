using FIVESTARS.Domain.Entities;
using FIVESTARS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject1.Fakes
{
    public class FakeBedroomRepository : IBedroomRepository
    {
        public int SaveBedroom(Bedroom bedroom)
        {
            return 1;
        }

        public List<Bedroom> SearchBedroom()
        {

            var quarto = new Bedroom() { BED_TYPE = "CAMAS DE SOLTEIRO", DOOR = 2, FLOOR = 1, MORE_INFORMATION = "TESTE", ID = 1, QUANTITY_BATHROOM = 2, QUANTITY_BEDS = 2, STATUS = 0 };
            var listaRetorno = new List<Bedroom>();
            listaRetorno.Add(quarto);
            return listaRetorno;
        }

        public Bedroom SearchBedroomForID(int ID)
        {
            if (ID == 1)
            {

                return new Bedroom() { BED_TYPE = "CAMAS DE SOLTEIRO", DOOR = 2, FLOOR = 1, MORE_INFORMATION = "TESTE", ID = 1, QUANTITY_BATHROOM = 2, QUANTITY_BEDS = 2, STATUS = 0 };
            }
            return null;

        }

        public int UpdateBedroom(Bedroom bedroom)
        {
            return 1;
        }
    }
}
