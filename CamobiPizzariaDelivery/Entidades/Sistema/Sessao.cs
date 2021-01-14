using Entidades.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    public class Sessao
    {
        public static Entidade Usuario { get; set; }
        public static TipoUsuario TipoUsuario{ get; set; }
        private Sessao Instance;
        public static  GetInstance{
            get{}
    }
}
