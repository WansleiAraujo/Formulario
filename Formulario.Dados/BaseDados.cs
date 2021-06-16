using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Formulario.Dados
{
    public abstract class BaseDados<T>
    {
        public abstract void Salvar(T entidade);
        public abstract void Excluir(T entidade);
        public abstract void Atualizar(T entidade);
        public abstract T Recuperar(T entidade);
        public abstract List<T> Todos();

        #region Comandos Bases MySQL 5.1.7

        private const string V = @"database = webchamado; data source = localhost; user id = root; password = wanslei"; // Desenvolvimento

        // Conexão MySql
        private string _stringConexao = V;

        //Adicionar Parametro
        protected void AdicionarParametro(MySqlCommand cmd, string nomeParametro, MySqlDbType tipo, object valor)
        {
            AdicionarParametro(cmd, nomeParametro, tipo, ParameterDirection.Input, valor);
        }

        protected void AdicionarParametro(MySqlCommand cmd, string nomeParametro, MySqlDbType tipo, ParameterDirection direcao, object valor)
        {
            MySqlParameter parametro = new MySqlParameter
            {
                MySqlDbType = tipo,
                ParameterName = nomeParametro,
                Direction = direcao,
                Value = valor
            };

            cmd.Parameters.Add(parametro);
        }

        //Executar SQL
        protected int ExecutarSQL(string query, CommandType tipoComando)
        {
            MySqlCommand cmd = new MySqlCommand();
            return ExecutarSQL(cmd, query, tipoComando);
        }

        protected int ExecutarSQL(MySqlCommand cmd, string query, CommandType tipoComando)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection(_stringConexao))
                {
                    cmd.Connection = conexao;
                    cmd.CommandText = query;
                    cmd.CommandType = tipoComando;

                    conexao.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cmd != null)
                    cmd.Dispose();
            }
        }

        //Executar Data Reader
        protected MySqlDataReader ExecutaDataReader(string query, CommandType tipoComando)
        {
            MySqlCommand cmd = new MySqlCommand();
            return ExecutaDataReader(cmd, query, tipoComando);
        }

        protected MySqlDataReader ExecutaDataReader(MySqlCommand cmd, string query, CommandType tipoComando)
        {
            try
            {
                MySqlConnection conexao = new MySqlConnection(_stringConexao);
                cmd.Connection = conexao;
                cmd.CommandText = query;
                cmd.CommandType = tipoComando;

                conexao.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
