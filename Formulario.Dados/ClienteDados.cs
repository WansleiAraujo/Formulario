using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Formulario.VO;

namespace Formulario.Dados
{
    public class ClienteDados : BaseDados<Cliente>
    {
        public override void Salvar(Cliente entidade)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                //AdicionarParametro(cmd, "@IdCliente", MySqlDbType.Int32, entidade.IdCliente);
                AdicionarParametro(cmd, "@Nome", MySqlDbType.VarChar, entidade.Nome);
                AdicionarParametro(cmd, "@Cpf", MySqlDbType.VarChar, entidade.Cpf);
                AdicionarParametro(cmd, "@Email", MySqlDbType.VarChar, entidade.Email);
                AdicionarParametro(cmd, "@Cep", MySqlDbType.VarChar, entidade.Cep);
                AdicionarParametro(cmd, "@Rua", MySqlDbType.VarChar, entidade.Rua);
                AdicionarParametro(cmd, "@Numero", MySqlDbType.VarChar, entidade.Numero);
                AdicionarParametro(cmd, "@Cidade", MySqlDbType.VarChar, entidade.Cidade);
                AdicionarParametro(cmd, "@Estado", MySqlDbType.VarChar, entidade.Estado);

                ExecutarSQL(cmd, "INSERT INTO CLIENTE VALUES(@Nome, @Cpf, @Email, @Cep, @Rua, @Numero, @Cidade, @Estado)", CommandType.Text);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Excluir(Cliente entidade)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                AdicionarParametro(cmd, "@IdCliente", MySqlDbType.Int32, entidade.IdCliente);

                ExecutarSQL(cmd, "DELETE FROM CLIENTE WHERE IdCliente=@IdCliente", CommandType.Text);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void Atualizar(Cliente entidade)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                AdicionarParametro(cmd, "@IdCliente", MySqlDbType.Int32, entidade.IdCliente);
                AdicionarParametro(cmd, "@Nome", MySqlDbType.VarChar, entidade.Nome);
                AdicionarParametro(cmd, "@Cpf", MySqlDbType.VarChar, entidade.Cpf);
                AdicionarParametro(cmd, "@Email", MySqlDbType.VarChar, entidade.Email);
                AdicionarParametro(cmd, "@Cep", MySqlDbType.VarChar, entidade.Cep);
                AdicionarParametro(cmd, "@Rua", MySqlDbType.VarChar, entidade.Rua);
                AdicionarParametro(cmd, "@Numero", MySqlDbType.VarChar, entidade.Numero);
                AdicionarParametro(cmd, "@Cidade", MySqlDbType.VarChar, entidade.Cidade);
                AdicionarParametro(cmd, "@Estado", MySqlDbType.VarChar, entidade.Estado);

                ExecutarSQL(cmd, "UPDATE CLIENTE SET Nome=@Nome, Cpf=@Cpf, Email=@Email, Cep=@Cep, Rua=@Rua, Numero=@Numero, Cidade=@Cidade, Estado=@Estado WHERE IdCliente=@IdCliente", CommandType.Text);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override Cliente Recuperar(Cliente entidade)
        {
            try
            {
                Cliente retorno = null;

                MySqlCommand cmd = new MySqlCommand();
                AdicionarParametro(cmd, "@IdCliente", MySqlDbType.Int32, entidade.IdCliente);

                //Utilizar o Using para fechar o reader e a conexao
                using (MySqlDataReader reader = ExecutaDataReader(cmd, "SELECT * FROM CLIENTE WHERE IdCliente=@IdCliente", CommandType.Text))
                {
                    if (reader.HasRows)
                    {
                        reader.Read();

                        retorno = new Cliente
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            Nome = reader["Nome"].ToString(),
                            Cpf = reader["Cpf"].ToString(),
                            Email = reader["Email"].ToString(),
                            Cep = reader["Cep"].ToString(),
                            Rua = reader["Rua"].ToString(),
                            Numero = reader["Numero"].ToString(),
                            Cidade = reader["Cidade"].ToString(),
                            Estado = reader["Estado"].ToString()
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

        public override List<Cliente> Todos()
        {
            try
            {
                List<Cliente> retorno = new List<Cliente>();

                //Utiliza o using para fechar o reader e a conecao
                using (MySqlDataReader reader = ExecutaDataReader("SELECT * FROM CLIENTE ORDER BY Nome", CommandType.Text))
                {
                    while (reader.Read())
                    {
                        Cliente status = new Cliente
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            Nome = reader["Nome"].ToString(),
                            Cpf = reader["Cpf"].ToString(),
                            Email = reader["Email"].ToString(),
                            Cep = reader["Cep"].ToString(),
                            Rua = reader["Rua"].ToString(),
                            Numero = reader["Numero"].ToString(),
                            Cidade = reader["Cidade"].ToString(),
                            Estado = reader["Estado"].ToString()
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

        public object BucStatus(string p)
        {
            try
            {
                List<Cliente> retorno = new List<Cliente>();

                //Utiliza o using para fechar o reader e a conexao
                using (MySqlDataReader reader = ExecutaDataReader("SELECT * FROM CLIENTE WHERE Nome LIKE '%" + p + "%' ORDER BY Nome", CommandType.Text))
                {
                    while (reader.Read())
                    {
                        Cliente status = new Cliente
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            Nome = reader["Nome"].ToString(),
                            Cpf = reader["Cpf"].ToString(),
                            Email = reader["Email"].ToString(),
                            Cep = reader["Cep"].ToString(),
                            Rua = reader["Rua"].ToString(),
                            Numero = reader["Numero"].ToString(),
                            Cidade = reader["Cidade"].ToString(),
                            Estado = reader["Estado"].ToString()
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
