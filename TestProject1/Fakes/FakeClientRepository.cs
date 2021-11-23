using FIVESTARS.Domain.Entities;
using FIVESTARS.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace TestProject1.Fakes
{
    public class FakeClientRepository : IClientRepository
    {
        public bool ExistsEmail(string email, int id)
        {
            return false;
        }

        public int SaveClient(Client bedroom)
        {
            return 1;
        }

        public Client SearchClientForID(int ID)
        {
            if (ID == 1)
            {
                return new Client() { BIRTH_DATE = DateTime.Now, CEP = "00000000", EMAIL = "SGADHAG@GMAIL.COM", CPF = "000000000", NOME = "GABRIEL", STATUS = 0, ID = 1 };
            }
            else
            {
                return null;
            }
        }

        public List<Client> SearchClients()
        {
            var listClient = new List<Client>();
            listClient.Add(new Client() {BIRTH_DATE = DateTime.Now, CEP = "00000000", EMAIL = "SGADHAG@GMAIL.COM", CPF = "000000000", NOME = "GABRIEL", STATUS = 0, ID = 1 });
            return listClient;
        }

        public int UpdateClient(Client bedroom)
        {
            return 1;
        }
    }
}
