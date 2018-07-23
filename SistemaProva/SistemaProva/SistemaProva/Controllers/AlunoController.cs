using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using SistemaProva.Models;

namespace SistemaProva.Controllers
{
    public class AlunoController : ApiController
    {
        [HttpPost]
        public void CriarAluno([FromBody]Aluno aluno)
        {
            using (SqlConnection conn = new SqlConnection("Server=tcp:carolaine.database.windows.net,1433;" +
                "Initial Catalog=carolaine;Persist Security Info=False;User ID=xxxx;Password=xxxx;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO tb_Aluno (Nome, Email, Ra) VALUES (@nome, @email, @Ra)", conn))
                {
                  
                    cmd.Parameters.AddWithValue("@nome", aluno.Nome);
                    cmd.Parameters.AddWithValue("@email", aluno.Email);
                    cmd.Parameters.AddWithValue("@ra", aluno.Ra);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        [HttpPost]
        public void AlterarAluno([FromBody]Aluno aluno)
        {
            using (SqlConnection conn = new SqlConnection("Server=tcp:carolaine.database.windows.net,1433;" +
                "Initial Catalog=carolaine;Persist Security Info=False;User ID=xxxx;Password=xxxx;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE tb_Aluno SET Nome=@nome, Email=@email, Ra=@ra WHERE Id=@id", conn))
                {
                    
                    cmd.Parameters.AddWithValue("@nome", aluno.Nome);     
                    cmd.Parameters.AddWithValue("@email", aluno.Email);
                    cmd.Parameters.AddWithValue("@ra", aluno.Ra);
                    cmd.Parameters.AddWithValue("@id", aluno.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        [HttpPost]
        public void DeletarAluno([FromBody]Aluno aluno)
        {
            using (SqlConnection conn = new SqlConnection("Server=tcp:carolaine.database.windows.net,1433;" +
                "Initial Catalog=carolaine;Persist Security Info=False;User ID=xxxx;Password=xxxx;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM tb_Aluno WHERE Id = @id", conn))
                {
                    
                    cmd.Parameters.AddWithValue("@id", aluno.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }   
}
