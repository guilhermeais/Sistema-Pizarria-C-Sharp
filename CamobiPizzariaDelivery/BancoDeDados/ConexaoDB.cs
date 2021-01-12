using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados
{
    public class ConexaoDB
    {
        // Vamos instanciar a classe como instanciaMySQL, ela será privada e readonly
        private static readonly ConexaoDB intanciaMySQL = new ConexaoDB();

        public static ConexaoDB getInstancia()
        {
            return intanciaMySQL;
        }

        public MySqlConnection getConexao()
        {
            string conn = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ToString();
            return new MySqlConnection(conn);
        }
    }
}
