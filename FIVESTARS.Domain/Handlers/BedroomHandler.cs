using FIVESTARS.Domain.Commands.Bedrooms.Input;
using FIVESTARS.Domain.Entities;
using FIVESTARS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Handlers
{
    public class BedroomHandler : BaseHandler
    {

        private readonly IBedroomRepository _repository;

        public BedroomHandler(IBedroomRepository repository)
        {
            _repository = repository;
        }

        public List<Bedroom> Handler()
        {
            return _repository.SearchBedroom();
        }

        public int Handler(SaveBedroomCommand command)
        {
            if (!command.isvalid())
            {
                AddNotifications(command.Notifications);
                return 0;
            }

            if (command.id == 0)
            {
                Bedroom bedroom = new Bedroom(
                    command.bedType,
                    command.door,
                    command.moreInformation,
                    command.quantityBeds,
                    command.quantityBathroom,
                    command.floor
                );

                return _repository.SaveBedroom(bedroom);
            }
            else
            {
                Bedroom bedroom = _repository.SearchBedroomForID(command.id);
                bedroom.BED_TYPE = command.bedType;
                bedroom.DOOR = command.door;
                bedroom.QUANTITY_BEDS = command.quantityBeds;
                bedroom.QUANTITY_BATHROOM = command.quantityBathroom;
                bedroom.FLOOR = command.floor;
                bedroom.MORE_INFORMATION = command.moreInformation;

                return _repository.UpdateBedroom(bedroom);
            }
            
        }

        public int Handler(int idCBedroom)
        {
            Bedroom bedroom = _repository.SearchBedroomForID(idCBedroom);
            bedroom.STATUS = 1;
            return _repository.UpdateBedroom(bedroom);
        }
    }
}
