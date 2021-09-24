using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIVESTARS.Domain.Entities
{
    [Table("TABELA_TESTE")]
    public class Teste : BaseEntity
    {
        //public int ID { get; set; }
        public string NOME { get; set; }

        public Teste(int ID, string NOME)
        {
            //Id = Guid.NewGuid();
            this.ID = ID;
            this.NOME = NOME;

            //Validate(this, new UsuarioValidator());
        }
    }
}
