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
        private static Sessao Instance;
        /*public static Sessao GetInstance
        {
            *//*get
            {
                if (Instance == null)
                {
                    Instance = new Sessao();
                }
            }*//*
        }*/
