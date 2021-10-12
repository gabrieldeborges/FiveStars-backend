using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Commands.Reservation.Input
{
    public class SaveReservationCommand : BaseCommand
    {
        public int id { get; set; }
        public int idClient { get; set; }
        public int idBedroom { get; set; }
        public string observation { get; set; }
        public DateTime initialDate { get; set; }
        public DateTime finalDate { get; set; }

        public override bool isvalid()
        {
            AddNotifications(new ValidationContract()
                 .IsFalse(idClient == 0, "Cliente", "Cliente não encontrado.")
                 .IsFalse(idBedroom == 0, "Quarto", "Quarto não encontrado.")
                 .IsGreaterThan(initialDate, DateTime.Now,  "Data de inicio", "A data de inicio da reserva não pode ser menor que hoje")
                 .IsGreaterThan(finalDate, DateTime.Now, "Data de fim", "A data de fim da reserva não pode ser menor que hoje")
                 .IsGreaterThan(finalDate, initialDate, "Datas", "A data de inicio não pode ser maior que a de fim")
             );
            return Valid;
        }
    }
}
