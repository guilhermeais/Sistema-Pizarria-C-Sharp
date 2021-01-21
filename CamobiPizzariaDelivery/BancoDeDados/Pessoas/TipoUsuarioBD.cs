using Entidades.Entidades;
using Entidades.Enumeradores;
using Entidades.Pessoas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BancoDeDados.Pessoas
{
    public class TipoUsuarioBD
    {
        public List<EntidadeViewPesquisa> ListarEntidasdessViewPesquisa()
        {
            var listaEntidades = new List<EntidadeViewPesquisa>();
            using (MySqlConnection conexao = ConexaoDB.getInstancia().getConexao())
            {
                try
                {

                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd = conexao.CreateCommand();

                    string query = @"SELECT codigo, descricao, '1' as situacao  
                                        FROM tipo_usuario";

                    cmd.CommandText = query;


                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        EntidadeViewPesquisa oEntidade = new EntidadeViewPesquisa();
                        oEntidade.Codigo = int.Parse(rd["codigo"].ToString());
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

        public TipoUsuario BuscarTipoUsuario(int codigo)
        {
            TipoUsuario tipoUsuario = new TipoUsuario();
            using (MySqlConnection conexao = ConexaoDB.getInstancia().getConexao())
            {
                try
                {

                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd = conexao.CreateCommand();

                    cmd.CommandText = @"SELECT
                                        U.codigo_tipo_usuario AS CodigoTipoUsuario,
	                                    TU.descricao AS DescricaoTipoUsuario
                                        FROM
                                        usuario AS U
                                        INNER JOIN tipo_usuario AS TU ON U.codigo_tipo_usuario = TU.codigo
                                        WHERE U.codigo = @codigo";
                    cmd.Parameters.AddWithValue("codigo", codigo);
                    MySqlDataReader rd = cmd.ExecuteReader();

                    while (rd.Read())
                    {
                        tipoUsuario.Codigo = int.Parse(rd["CodigoTipoUsuario"].ToString());
                        tipoUsuario.Descricao = rd["DescricaoTipoUsuario"].ToString(); 
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
            return tipoUsuario;
        }

        public TipoUsuario Buscar(int codigo)
        {
            TipoUsuario tipoUsuario = new TipoUsuario();
            using (MySqlConnection conexao = ConexaoDB.getInstancia().getConexao())
            {
                try
                {

                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd = conexao.CreateCommand();

                    cmd.CommandText = @"SELECT * from tipo_usuario Where codigo = @codigo";
                    cmd.Parameters.AddWithValue("codigo", codigo);

                    MySqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        tipoUsuario.Codigo = int.Parse(rd["codigo"].ToString());
                        tipoUsuario.Descricao = rd["descricao"].ToString();
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
            return tipoUsuario;
        }

    }
}
