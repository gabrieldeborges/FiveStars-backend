using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Entities
{
    public class Client
    {
        public int ID { get; set; }
        public string NOME { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public int STATUS { get; set; }

        public Client()
        {

        }

        public Client(string nome, string cpf, string cep)
        {
            NOME = nome;
            CPF = cpf;
            CEP = cep;
        }
    }
}
