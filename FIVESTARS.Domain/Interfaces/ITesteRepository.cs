using FIVESTARS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FIVESTARS.Domain.Interfaces
{
    public interface ITesteRepository
    {
        public List<Teste> listarTeste();
    }
}
