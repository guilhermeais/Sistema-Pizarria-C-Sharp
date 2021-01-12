using BancoDeDados;
using Entidades.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Pessoas
{
    public class UsuarioNG
    {
        private readonly UsuarioBD _bd;

        public UsuarioNG()
        {
            _bd = new UsuarioBD();
        }
        public List<Usuario> ListarUsuarios()
        {
            return _bd.ListarUsuarios();
        }
    }
}
