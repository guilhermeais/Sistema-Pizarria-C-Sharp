using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados.Modulos
{
    public class FuncoesBD
    {
        public int BuscaCodigo(string sql)
        {
            int codigo = 1;
            using (MySqlConnection conexao = ConexaoDB.getInstancia().getConexao())
            {
                try
                {

                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd = conexao.CreateCommand();

                    cmd.CommandText = sql;

                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        codigo = int.Parse(rd["Auto_increment"].ToString());
                    }
                }
                catch (MySqlException mysqle)
                {
                    throw new System.Exception(mysqle.ToString());
                }
                finally
                {
                    conexao.Close();
                }
            }
            return codigo;
        }
    }
}
