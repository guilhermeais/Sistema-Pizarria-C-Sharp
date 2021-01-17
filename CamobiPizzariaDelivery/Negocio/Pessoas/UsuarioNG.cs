using BancoDeDados;
using Entidades.Entidades;
using Entidades.Enumeradores;
using Entidades.Pessoas;
using System.Collections.Generic;

namespace Negocio.Pessoas
{
    public class UsuarioNG
    {
        private readonly UsuarioBD _bd;

        public UsuarioNG()
        {
            _bd = new UsuarioBD();
        }
        public List<EntidadeViewPesquisa> ListarEntidasdessViewPesquisa(Status status)
        {
            return _bd.ListarEntidasdessViewPesquisa(status);
        }
        public List<Usuario> ListarUsuariosAtivos()
        {
            return _bd.ListarUsuariosAtivos();
        }
        public Usuario Buscar(int cod)
        {
            return _bd.Buscar(cod);
        }

       
    }
}
