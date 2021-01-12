using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Entidades.Pessoas;
using Entidades.Enumeradores;

namespace BancoDeDados
{
    public class UsuarioBD
    {
        public List<Usuario> ListarUsuarios()
        {
            var listaUsuarios = new List<Usuario>();
            using (MySqlConnection conexao = ConexaoDB.getInstancia().getConexao())
            {
                try
                {

                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd = conexao.CreateCommand();

                    cmd.CommandText = "select * from usuario where situacao = 1";
                    MySqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        Usuario oUsuario = new Usuario();
                        oUsuario.Codigo = int.Parse(rd["codigo"].ToString()) ;
                        oUsuario.TipoUsuario = new TipoUsuario(Convert.ToInt32(rd["codigo_tipo_usuario"]), string.Empty);
                        oUsuario.Nome = rd["nome"].ToString();
                        oUsuario.Login = rd["login"].ToString();
                        oUsuario.Senha = rd["senha"].ToString();
                        oUsuario.Status = (Status)Convert.ToInt16(rd["situacao"]);
                        oUsuario.DtAlteracao = DateTime.Parse(rd["dt_alteracao"].ToString());
                        oUsuario.CodigoUsrAlteracao = int.Parse(rd["codigo_usr_alteracao"].ToString());

                        listaUsuarios.Add(oUsuario);
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
            return listaUsuarios;
        }
	
	}
    }

