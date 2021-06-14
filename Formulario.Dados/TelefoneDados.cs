using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Formulario.VO;

namespace Formulario.Dados
{
    public class TelefoneDados : BaseDados<Telefone>
    {
        public override void Salvar(Telefone entidade)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                AdicionarParametro(cmd, "@TipoTelefone", MySqlDbType.VarChar, entidade.TipoTelefone);
                AdicionarParametro(cmd, "@NumeroTelefone", MySqlDbType.VarChar, entidade.NumeroTelefone);
                AdicionarParametro(cmd, "@IdCliente", MySqlDbType.Int32, entidade.IdCliente);

                ExecutarSQL(cmd, "INSERT INTO TELEFONE VALUES(@TipoTelefone, @NumeroTelefone, @IdCliente)", CommandType.Text);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Excluir(Telefone entidade)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                AdicionarParametro(cmd, "@IdTelefone", MySqlDbType.Int32, entidade.IdTelefone);

                ExecutarSQL(cmd, "DELETE FROM TELEFONE WHERE IdTelefone=@IdTelefone", CommandType.Text);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Atualizar(Telefone entidade)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                AdicionarParametro(cmd, "@IdTelefone", MySqlDbType.Int32, entidade.IdTelefone);
                AdicionarParametro(cmd, "@NumeroTelefone", MySqlDbType.VarChar, entidade.NumeroTelefone);

                ExecutarSQL(cmd, "UPDATE TELEFONE SET NumeroTelefone=@NumeroTelefone WHERE IdTelefone=@IdTelefone", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Telefone Recuperar(Telefone entidade)
        {
            try
            {
                Telefone retorno = null;

                MySqlCommand cmd = new MySqlCommand();
                AdicionarParametro(cmd, "@IdTelefone", MySqlDbType.Int32, entidade.IdTelefone);

                //Utilizar o Using para fechar o reader e a conexao
                using (MySqlDataReader reader = ExecutaDataReader(cmd, "SELECT * FROM TELEFONE WHERE IdTelefone=@IdTelefone", CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        retorno = new Telefone
                        {
                            IdTelefone = Convert.ToInt32(reader["IdTelefone"]),
                            TipoTelefone = Convert.ToChar(reader["TipoTelefone"]),
                            NumeroTelefone = reader["NumeroTelefone"].ToString(),
                            IdCliente = Convert.ToInt32(reader["idStatus"])                         
                        };
                    }
                    return retorno;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override List<Telefone> Todos()
        {
            try
            {
                List<Telefone> retorno = new List<Telefone>();

                //Utiliza o using para fechar o reader e a conecao
                using (MySqlDataReader reader = ExecutaDataReader("SELECT * FROM TELEFONE ORDER BY IdTelefone", CommandType.Text))
                {
                    while (reader.Read())
                    {
                        Telefone status = new Telefone
                        {
                            IdTelefone = Convert.ToInt32(reader["IdTelefone"]),
                            TipoTelefone = Convert.ToChar(reader["TipoTelefone"]),
                            NumeroTelefone = reader["NumeroTelefone"].ToString(),
                            IdCliente = Convert.ToInt32(reader["idStatus"])
                        };

                        retorno.Add(status);
                    }
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
