using FIVESTARS.Domain.Entities;
using FIVESTARS.Domain.Interfaces;
using FIVESTARS.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIVESTARS.Infra.Repository
{
    public class TesteRepository : IBaseRepository<Teste>, ITesteRepository
    {
        private readonly Context _context;
        public TesteRepository(Context context) 
        {
            _context = context;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Insert(Teste obj)
        {
            throw new NotImplementedException();
        }

        public List<Teste> listarTeste()
        {
            return _context.teste.Where(x => x.NOME != null).ToList();
        }

        public IList<Teste> Select()
        {
            throw new NotImplementedException();
        }

        public Teste Select(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Teste obj)
        {
            throw new NotImplementedException();
        }
    }
}
