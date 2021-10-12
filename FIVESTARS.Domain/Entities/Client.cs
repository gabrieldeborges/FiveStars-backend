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
        public DateTime? BIRTH_DATE { get; set; }
        public string EMAIL { get; set; }
        public int STATUS { get; set; }
        public virtual List<Reservation> RESERVATION { get; set; }

        public Client()
        {

        }

        public Client(string nome, string cpf, string cep, string email, DateTime? birthDay)
        {
            NOME = nome;
            CPF = cpf;
            CEP = cep;
            EMAIL = email;
            BIRTH_DATE = birthDay;
        }
    }
}
