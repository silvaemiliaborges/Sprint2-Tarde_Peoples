using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_Peoples;User Id=sa;Pwd=132;";

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> funcionarios = new List<FuncionarioDomain>();

            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                string Query = "SELECT * FROM Funcionarios";
                conexao.Open();

                SqlDataReader sdr;

                using (SqlCommand comando = new SqlCommand(Query, conexao))
                {
                    sdr = comando.ExecuteReader();

                    while(sdr.Read())
                    {
                        FuncionarioDomain funcionario = new FuncionarioDomain
                        {
                            IdFuncionarios = Convert.ToInt32(sdr["IdFuncionarios"]),
                            Nome = sdr["Nome"].ToString(),
                            Sobrenome = sdr["Sobrenome"].ToString()
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            string Query = "SELECT * FROM Funcionarios WHERE IdFuncionarios = @IdFuncionarios";

            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                conexao.Open();
                SqlDataReader sdr;

                using (SqlCommand comando = new SqlCommand(Query, conexao))
                {
                    comando.Parameters.AddWithValue("@IdFuncionarios", id);
                    sdr = comando.ExecuteReader();

                    if(sdr.HasRows)
                    {
                        while(sdr.Read())
                        {
                            //chamando o funcionario
                            FuncionarioDomain funcionario = new FuncionarioDomain
                            {
                                IdFuncionarios = Convert.ToInt32(sdr["IdFuncionarios"]),
                                Nome = sdr["Nome"].ToString(),
                                Sobrenome = sdr["Sobrenome"].ToString()
                            };
                            return funcionario;
                        }
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(FuncionarioDomain funcionarioDomain)
        {
            string Query = "INSERT INTO Funcionarios(Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";
            {
                using (SqlConnection conexao = new SqlConnection(StringConexao))
                {
                    conexao.Open();
                    SqlDataReader sdr;

                    using (SqlCommand comando = new SqlCommand(Query, conexao))
                    {
                        comando.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                        comando.Parameters.AddWithValue("@Sobrenome", funcionarioDomain.Sobrenome);
                        comando.ExecuteNonQuery();
                    }
                }

                
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Funcionarios WHERE IdFuncionarios = @Id";

            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                using (SqlCommand comando = new SqlCommand(Query, conexao))
                {
                    comando.Parameters.AddWithValue("@Id", id);
                    conexao.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Atualizar(FuncionarioDomain funcionarioDomain)
        {
            string Query1 = "UPDATE Funcionarios SET Nome = @Nome WHERE IdFuncionarios = @Id";
            string Query2 = "UPDATE Funcionarios SET Sobrenome = @Sobrenome WHERE IdFuncionarios = @Id";


            using (SqlConnection conexao = new SqlConnection(StringConexao))
            {
                SqlCommand comando = new SqlCommand(Query1, conexao);
                SqlCommand comando2 = new SqlCommand(Query2, conexao);
                comando.Parameters.AddWithValue("@Id", funcionarioDomain.IdFuncionarios);
                comando2.Parameters.AddWithValue("@Id", funcionarioDomain.IdFuncionarios);
                comando.Parameters.AddWithValue("@Nome", funcionarioDomain.Nome);
                comando2.Parameters.AddWithValue("@Sobrenome", funcionarioDomain.Sobrenome);
                conexao.Open();
                comando.ExecuteNonQuery();
                comando2.ExecuteNonQuery();


            }
        }

    }
}
