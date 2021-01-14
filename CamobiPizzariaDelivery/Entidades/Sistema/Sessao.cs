using Entidades.Pessoas;

namespace Entidades.Sistema
{
    public class Sessao
    {
        public static Entidade Usuario { get; set; }
        public static TipoUsuario TipoUsuario { get; set; }
        private static Sessao Instance;
        public static Sessao GetInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new Sessao();
                }
                return Instance;
            }
        }
    }
}