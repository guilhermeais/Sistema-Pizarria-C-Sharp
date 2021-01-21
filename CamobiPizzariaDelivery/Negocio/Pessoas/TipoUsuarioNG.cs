using BancoDeDados.Pessoas;
using Entidades.Entidades;
using Entidades.Pessoas;
using System.Collections.Generic;

namespace Negocio.Pessoas
{
    public class TipoUsuarioNG
    {
        private readonly TipoUsuarioBD _bd;

        public TipoUsuarioNG()
        {
            _bd = new TipoUsuarioBD();
        }

        public List<EntidadeViewPesquisa> ListarEntidasdessViewPesquisa()
        {
            return _bd.ListarEntidasdessViewPesquisa();
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
