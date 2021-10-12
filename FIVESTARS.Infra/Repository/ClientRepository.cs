using FIVESTARS.Domain.Entities;
using FIVESTARS.Domain.Interfaces;
using FIVESTARS.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIVESTARS.Infra.Repository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private readonly Context _context;
        public ClientRepository(Context context) : base(context)
        {
            _context = context;
        }

        public int SaveClient(Client bedroom)
        {
            return Insert(bedroom);
        }

        public Client SearchClientForID(int id)
        {
            return DbSet.FirstOrDefault(x => x.ID == id);
        }

        public List<Client> SearchClients()
        {
            var beedrooms = (from client in DbSet
                             where client.STATUS != 1
                             select client).ToList();

            return beedrooms;
        }

        public int UpdateClient(Client bedroom)
        {
            return Update(bedroom);
        }

        public bool ExistsEmail(string email)
        {
            return DbSet.Any(x => x.EMAIL == email);
        }
    }
}
