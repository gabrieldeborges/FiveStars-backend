using FIVESTARS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Interfaces
{
    public interface IClientRepository
    {
        public int SaveClient(Client bedroom);
        public int UpdateClient(Client bedroom);
        public List<Client> SearchClients();
        public Client SearchClientForID(int ID);
        public bool ExistsEmail(string email);
    }
}
