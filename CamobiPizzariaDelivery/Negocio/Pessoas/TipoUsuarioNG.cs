using BancoDeDados.Pessoas;
using Entidades.Pessoas;

namespace Negocio.Pessoas
{
    public class TipoUsuarioNG
    {
        private readonly TipoUsuarioBD _bd;

        public TipoUsuarioNG()
        {
            _bd = new TipoUsuarioBD();
        }

        public TipoUsuario BuscarTipoUsuario(int codigo)
        {
            return _bd.BuscarTipoUsuario(codigo);
        }

        public TipoUsuario Buscar(int codigo)
        {
            return _bd.Buscar(codigo);
        }
    }
}
