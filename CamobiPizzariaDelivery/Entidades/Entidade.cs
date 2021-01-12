using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Entidade : IEntidade
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public Entidade()
        {

        }

        public Entidade(int codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }
    }
}
