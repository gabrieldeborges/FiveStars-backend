using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Commands.Client
{
    public class SaveClientCommand : BaseCommand
    {
        public int id { get; set; }
        public string NOME { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public string Email { get; set; }
        public DateTime? birthDate { get; set; }


        public override bool isvalid()
        {
            AddNotifications(new ValidationContract()
                 .IsNotNullOrEmpty(NOME, "Nome Cliente", "Nome não pode ser nulo")
                 .IsNotNullOrEmpty(CPF, "CPF", "CPF não pode ser nulo")
                 .HasLen(CPF, 11, "CPF", "O campo de CPF tem de ser preenchido com 11 caracteres.")
                 .HasLen((CEP.Replace("-", "")), 8, "Quantidade", "É necessário 9 caracteres para o campo de CEP.")
             );
            return Valid;
        }
    }
}
