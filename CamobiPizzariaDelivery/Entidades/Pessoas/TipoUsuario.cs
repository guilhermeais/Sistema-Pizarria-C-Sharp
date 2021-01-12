using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Pessoas
{
    public class TipoUsuario : Entidade
    {
        public TipoUsuario()
        {

        }

        public TipoUsuario(int codigo, string descricao) : base(codigo, descricao)
        {

        }
    }
}
