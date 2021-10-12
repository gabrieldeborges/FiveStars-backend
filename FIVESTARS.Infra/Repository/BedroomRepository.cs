using FIVESTARS.Domain.Entities;
using FIVESTARS.Domain.Interfaces;
using FIVESTARS.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIVESTARS.Infra.Repository
{
    public class BedroomRepository : BaseRepository<Bedroom>, IBedroomRepository
    {
        private readonly Context _context;
        public BedroomRepository(Context context) : base(context)
        {
            _context = context;
        }
        public int SaveBedroom(Bedroom bedroom)
        {
            return Insert(bedroom);
        }
        public int UpdateBedroom(Bedroom bedroom)
        {
            return Update(bedroom);
        }

        public List<Bedroom> SearchBedroom()
        {
            var beedrooms = (from bedroom in DbSet 
                             where bedroom.STATUS != 1
                             select bedroom).ToList();

            return beedrooms;
        }
        public Bedroom SearchBedroomForID(int id)
        {
            return DbSet.FirstOrDefault(x => x.ID == id);
        }
    }
}
