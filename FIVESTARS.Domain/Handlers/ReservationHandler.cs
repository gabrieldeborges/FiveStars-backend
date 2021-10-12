﻿using FIVESTARS.Domain.Commands.Reservation.Input;
using FIVESTARS.Domain.Commands.Reservation.Output;
using FIVESTARS.Domain.Entities;
using FIVESTARS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Handlers
{
    public class ReservationHandler : BaseHandler
    {
        private readonly IReservationRepository _repository;
        private readonly IClientRepository _repositoryClient;
        private readonly IBedroomRepository _repositoryBedroom;

        public ReservationHandler(IReservationRepository repository, IClientRepository repositoryClient, IBedroomRepository repositoryBedroom)
        {
            _repository = repository;
            _repositoryClient = repositoryClient;
            _repositoryBedroom = repositoryBedroom;
        }

        public List<SearchReservationsResult> Handler()
        {
            return _repository.SearchReservations();
        }

        public int Handler(SaveReservationCommand command)
        {
            if (!command.isvalid())
            {
                AddNotifications(command.Notifications);
                return 0;
            }

            if(_repositoryClient.SearchClientForID(command.idClient) == null)
            {
                AddNotification("Cliente", "Cliente não encontrado no sistema.");
                return 0;
            }

            if (_repositoryBedroom.SearchBedroomForID(command.idBedroom) == null)
            {
                AddNotification("Quarto", "Quarto não encontrado no sistema.");
                return 0;
            }

            if (!_repository.AavailableForRent(command.idBedroom))
            {
                AddNotification("Quarto", "O quarto não está disponpivel para a reserva nas datas selecionadas.");
                return 0;
            }

            if (command.id == 0)
            {
                var reserve = new Reservation(
                       command.idClient,
                       command.idBedroom,
                       command.observation,
                       command.initialDate,
                       command.finalDate
                );

                return _repository.SaveReservation(reserve);
            }
            else
            {
                var reserve = _repository.SearchReservationForID(command.id);
                reserve.ID_BEDROOM = command.idBedroom;
                reserve.ID_CLIENT = command.idClient;
                reserve.OBSERVATION = command.observation;
                reserve.FINAL_DATE = command.finalDate;
                reserve.INITIAL_DATE = command.initialDate;
                return _repository.SaveReservation(reserve);
            }
        }

        public int Handler(int idReserve)
        {
            Reservation reserve = _repository.SearchReservationForID(idReserve);
            reserve.STATUS = 1;
            return _repository.UpdateReservation(reserve);
        }
    }
}
