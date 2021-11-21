using FIVESTARS.Domain.Commands.Client;
using FIVESTARS.Domain.Entities;
using FIVESTARS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Handlers
{
    public class ClientHandler : BaseHandler
    {
        private readonly IClientRepository _repository;

        public ClientHandler(IClientRepository repository)
        {
            _repository = repository;
        }

        public List<Client> Handler()
        {
            return _repository.SearchClients();
        }

        public int Handler(SaveClientCommand command)
        {
            command.CEP = command.CEP.Replace("-", "");
            command.CPF = command.CPF.Replace("-", "");

            if (!command.isvalid())
            {
                AddNotifications(command.Notifications);
                return 0;
            }

            if (_repository.ExistsEmail(command.Email, command.id))
            {
                AddNotification("Email", "Email já cadastrado");
                return 0;
            }

            if (command.id == 0)
            {
                Client cliemt = new Client(
                    command.NOME,
                    command.CPF,
                    command.CEP,
                    command.Email,
                    command.birthDate
                );

                return _repository.SaveClient(cliemt);
            }
            else
            {
                Client client = _repository.SearchClientForID(command.id);
                client.NOME = command.NOME;
                client.CPF = command.CPF;
                client.CEP = command.CEP;
                client.EMAIL = command.Email;
                client.BIRTH_DATE = command.birthDate;

                return _repository.UpdateClient(client);
            }

        }

        public int Handler(int idClient)
        {
            Client client = _repository.SearchClientForID(idClient);
            client.STATUS = 1;
            return _repository.UpdateClient(client);
        }
    }
}
