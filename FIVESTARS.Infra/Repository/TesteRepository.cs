using FIVESTARS.Domain.Entities;
using FIVESTARS.Domain.Interfaces;
using FIVESTARS.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIVESTARS.Infra.Repository
{
    public class TesteRepository : BaseRepository<Teste>, ITesteRepository
    {
        private readonly Context _context;
        public TesteRepository(Context context)  : base(context)
        {
            _context = context;
        }

        public List<Teste> listarTeste()
        {
            return DbSet.Where(x => x.NOME != null).ToList();
        }
    }
}
