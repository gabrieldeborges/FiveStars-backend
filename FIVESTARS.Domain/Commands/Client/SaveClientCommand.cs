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

        public bool isValid()
        {
            AddNotifications(new ValidationContract()
                .IsNotNullOrEmpty(NOME, "Nome Cliente", "Nome mão pode ser nulo")
                .IsNotNullOrEmpty(CPF, "CPF", "CPF não pode ser nulo")
                .HasLen(CPF, 11, "CPF", "O campo de CPF tem de ser preenchido com 11 caracteres.")
                .HasMaxLen(this.CEP, 9, "Quantidade", "A quantidade de camas deve ser possitiva.")
            );
            return Valid;
        }
    }
}
