

namespace Entidades.Sistema
{
    public class ComboBoxItemUsuario
    {
        public string Login;
        public int Codigo;
        public string Senha;

        public ComboBoxItemUsuario(string login, int codigo, string senha)
        {
            Login = login;
            Codigo = codigo;
            Senha = senha;
        }

        public override string ToString()
        {
            return Login;
        }
    }
}
