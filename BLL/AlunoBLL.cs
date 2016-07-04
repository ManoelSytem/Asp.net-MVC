using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BLL
{
    public class AlunoBLL
    {
        public IEnumerable<Aluno> getAlunos()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConSQLServer"].ConnectionString;

            List<Aluno> alunos = new List<Aluno>();

            try
            {
              using (SqlConnection con = new SqlConnection(connectionString))
              {     
                    SqlCommand cmd = new SqlCommand("GetAlunos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Aluno aluno = new Aluno();
                        aluno.Id = Convert.ToInt32(rdr["Id"]);
                        aluno.Nome = rdr["Nome"].ToString();
                        aluno.Email = rdr["Email"].ToString();
                        aluno.DataNascimento = Convert.ToDateTime(rdr["DataNascimento"]);
                        aluno.Idade = aluno.CalculaIdade();
                        //aluno.DataEscricao = Convert.ToDateTime(rdr["DataInscricao"]);
                        aluno.Sexo = rdr["Sexo"].ToString();
                        //aluno.Foto = rdr["Foto"].ToString();
                        //aluno.Texto = rdr["Texto"].ToString();
                        alunos.Add(aluno);
                    }
              }
              return alunos;
            }
            catch
            {
                throw;
            }
        }
        //Insert Modelo de Negocio
        public void IncluirAluno(Aluno aluno)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConSQLServer"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("IncluirAluno", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramNome = new SqlParameter();
                    paramNome.ParameterName = "@Nome";
                    paramNome.Value = aluno.Nome;
                    cmd.Parameters.Add(paramNome);

                    SqlParameter paramEmail = new SqlParameter();
                    paramEmail.ParameterName = "@Email";
                    paramEmail.Value = aluno.Email;
                    cmd.Parameters.Add(paramEmail);

                    //SqlParameter paramIdade = new SqlParameter();
                    //paramIdade.ParameterName = "@Idade";
                    //paramIdade.Value = aluno.Idade;
                    //cmd.Parameters.Add(paramIdade);

                    SqlParameter paramDataNascimento = new SqlParameter();
                    paramDataNascimento.ParameterName = "@DataNascimento";
                    paramDataNascimento.Value = aluno.DataNascimento;
                    cmd.Parameters.Add(paramDataNascimento);

                    SqlParameter paramSexo = new SqlParameter();
                    paramSexo.ParameterName = "@Sexo";
                    paramSexo.Value = aluno.Sexo;
                    cmd.Parameters.Add(paramSexo);

                    //SqlParameter paramFoto = new SqlParameter();
                    //paramFoto.ParameterName = "@Foto";
                    //paramFoto.Value = Convert.ToInt32(aluno.Foto);
                    //cmd.Parameters.Add(paramFoto);

                    //SqlParameter paramTexto = new SqlParameter();
                    //paramTexto.ParameterName = "@Texto";
                    //paramTexto.Value = Convert.ToInt32(aluno.Texto);
                    //cmd.Parameters.Add(paramTexto);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        public void AtualizaAluno(Aluno aluno)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConSQLServer"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("AtualizaAluno", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramNome = new SqlParameter();
                    paramNome.ParameterName = "@Nome";
                    paramNome.Value = aluno.Nome;
                    cmd.Parameters.Add(paramNome);

                    SqlParameter paramEmail = new SqlParameter();
                    paramEmail.ParameterName = "@Email";
                    paramEmail.Value = aluno.Email;
                    cmd.Parameters.Add(paramEmail);

                    //SqlParameter paramIdade = new SqlParameter();
                    //paramIdade.ParameterName = "@Idade";
                    //paramIdade.Value = aluno.Idade;
                    //cmd.Parameters.Add(paramIdade);

                    SqlParameter paramDataNascimento = new SqlParameter();
                    paramDataNascimento.ParameterName = "@DataNascimento";
                    paramDataNascimento.Value = Convert.ToDateTime(aluno.DataNascimento);
                    cmd.Parameters.Add(paramDataNascimento);

                    SqlParameter paramSexo = new SqlParameter();
                    paramSexo.ParameterName = "@Sexo";
                    paramSexo.Value = aluno.Sexo;
                    cmd.Parameters.Add(paramSexo);

                    SqlParameter paramId = new SqlParameter();
                    paramId.ParameterName = "@id";
                    paramId.Value = Convert.ToInt32(aluno.Id);
                    cmd.Parameters.Add(paramId);

                    SqlParameter paramFoto = new SqlParameter();
                    paramFoto.ParameterName = "@Foto";
                    paramFoto.Value = Convert.ToInt32(aluno.Foto);
                    cmd.Parameters.Add(paramFoto);

                    SqlParameter paramTexto = new SqlParameter();
                    paramTexto.ParameterName = "@Texto";
                    paramTexto.Value = Convert.ToInt32(aluno.Texto);
                    cmd.Parameters.Add(paramTexto);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
        }

        public void DeleteAluno(int Id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConSQLServer"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DeletarAluno", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramNome = new SqlParameter();
                    paramNome.ParameterName = "@id";
                    paramNome.Value = Id;
                    cmd.Parameters.Add(paramNome);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

            }
            catch
            {
                throw;
            }
        }
    }
}
