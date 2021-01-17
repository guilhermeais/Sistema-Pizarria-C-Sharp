using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Entidades.Pessoas;
using Entidades.Enumeradores;
using Entidades.Entidades;
using BancoDeDados.Modulos;

namespace BancoDeDados
{
    public class UsuarioBD
    {
        private readonly FuncoesBD FuncoesBD = new FuncoesBD();
        public List<EntidadeViewPesquisa> ListarEntidasdessViewPesquisa(Status status)
        {
            var listaEntidades = new List<EntidadeViewPesquisa>();
            using (MySqlConnection conexao = ConexaoDB.getInstancia().getConexao())
            {
                try
                {

                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd = conexao.CreateCommand();

                    string query = @"SELECT codigo, nome AS descricao, situacao  
                                        FROM usuario";
                    if (status != Status.Todos)
                        query += " WHERE situacao = @status;";

                    cmd.CommandText = query;

                    if (status != Status.Todos)             
                    cmd.Parameters.AddWithValue("situacao", (int)status);

                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        EntidadeViewPesquisa oEntidade = new EntidadeViewPesquisa();
                        oEntidade.Codigo = int.Parse(rd["codigo"].ToString()) ;
                        oEntidade.Descricao = rd["descricao"].ToString();
                        oEntidade.Status = (Status)Convert.ToInt16(rd["situacao"]);
             

                        listaEntidades.Add(oEntidade);
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
            return listaEntidades;
        }

        public List<Usuario> ListarUsuariosAtivos()
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
                        oUsuario.Codigo = int.Parse(rd["codigo"].ToString());
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

        public Usuario Buscar(int cod)
        {
            Usuario usu = new Usuario();
            using (MySqlConnection conexao = ConexaoDB.getInstancia().getConexao())
            {
                try
                {

                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd = conexao.CreateCommand();

                    cmd.CommandText = "select * from usuario where codigo = @codigo";
                    cmd.Parameters.AddWithValue("codigo", cod);

                    MySqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        
                        usu.Codigo = int.Parse(rd["codigo"].ToString());
                        usu.TipoUsuario = new TipoUsuario(Convert.ToInt32(rd["codigo_tipo_usuario"]), string.Empty);
                        usu.Nome = rd["nome"].ToString();
                        usu.Login = rd["login"].ToString();
                        usu.Senha = rd["senha"].ToString();
                        usu.Status = (Status)Convert.ToInt16(rd["situacao"]);
                        usu.DtAlteracao = DateTime.Parse(rd["dt_alteracao"].ToString());
                        usu.CodigoUsrAlteracao = int.Parse(rd["codigo_usr_alteracao"].ToString());

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
            return usu;
        }

        public int BuscarProximoCodigo()
        {
            return FuncoesBD.BuscaCodigo("SHOW TABLE STATUS LIKE 'usuario'");
        }

    }
    }

