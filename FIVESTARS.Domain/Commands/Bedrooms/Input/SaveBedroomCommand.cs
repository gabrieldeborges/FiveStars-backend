using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Commands.Bedrooms.Input
{
    public class SaveBedroomCommand : Notifiable
    {
        public int id { get; set; }
        public int quantityBeds { get; set; }
        public string bedType { get; set; }
        public string moreInformation { get; set; }
        public int quantityBathroom { get; set; }
        public int floor { get; set; }
        public int door { get; set; }

        public bool isvalid()
        {
            AddNotifications(new ValidationContract()
                    .IsFalse(this.quantityBeds <= 0, "Quantidade", "A quantidade de camas deve ser possitiva.")
                );

            return Valid;
        }

    }
}
