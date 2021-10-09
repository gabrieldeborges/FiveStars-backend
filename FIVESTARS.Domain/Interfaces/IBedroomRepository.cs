using FIVESTARS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Interfaces
{
    public interface IBedroomRepository
    {
        public int SaveBedroom(Bedroom bedroom);
        public int UpdateBedroom(Bedroom bedroom);
        public List<Bedroom> SearchBedroom();
        public Bedroom SearchBedroomForID(int ID);
    }
}
