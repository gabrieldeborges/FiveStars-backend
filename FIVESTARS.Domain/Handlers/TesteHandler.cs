using FIVESTARS.Domain.Commands.Bedrooms.Input;
using FIVESTARS.Domain.Entities;
using FIVESTARS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIVESTARS.Domain.Handlers
{
    //private readonly ICustomerRepository _customerRepository;
    public class TesteHandler : BaseHandler
    {
        private readonly ITesteRepository _repository;

        public TesteHandler(ITesteRepository repository)
        {
            _repository = repository;
        }
        public List<Teste> Handler()
        {
            return _repository.listarTeste();
        }
    }
}
