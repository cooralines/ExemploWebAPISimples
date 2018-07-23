using SistemaProva.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SistemaProva.Controllers
{
    public class AlunoProvaQuestaoController : ApiController
    {
        public void AtribuirRespostasDoAlunoATodasAsQuestoesDaProva([FromBody] AlunoProvaQuestao[] respostas)
        {
            foreach (var resposta in respostas)
            {
                using (SqlConnection connection = new SqlConnection("Server=tcp:carolaine.database.windows.net,1433;" +
                "Initial Catalog=carolaine;Persist Security Info=False;User ID=xxxx;Password=xxxx;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("INSERT INTO tbAlunoProvaQuestao (IdProvaQuestao, IdAluno, Resposta) VALUES (@IdProvaQuestao, @IdAluno, @Resposta)", connection))
                    {
                        // Esses valores poderiam vir de qualquer outro lugar, como uma TextBox...
                        cmd.Parameters.AddWithValue("@IdProvaQuestao", resposta.IdProvaQuestao);
                        cmd.Parameters.AddWithValue("@IdAluno", resposta.IdAluno);
                        cmd.Parameters.AddWithValue("@Resposta", resposta.Resposta);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void AtribuirValorATodasAsRespostasDoAlunoDeUmaProva([FromBody] AlunoProvaQuestao[] notas)
        {
            foreach (var nota in notas)
            {
                using (SqlConnection connection = new SqlConnection("Server=tcp:carolaine.database.windows.net,1433;" +
                "Initial Catalog=carolaine;Persist Security Info=False;User ID=xxxx;Password=xxxx;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand("UPDATE tbAlunoProvaQuestao SET NOTA=@Nota WHERE IdProvaQuestao=@IdProvaQuestao AND IdAluno =@IdAluno ", connection))
                    {
                        // Esses valores poderiam vir de qualquer outro lugar, como uma TextBox...
                        cmd.Parameters.AddWithValue("@IdProvaQuestao", nota.IdProvaQuestao);
                        cmd.Parameters.AddWithValue("@IdAluno", nota.IdAluno);
                        cmd.Parameters.AddWithValue("@Nota", nota.Nota);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        [HttpGet]
        public double ObterNotaFinalDoAlunoNaProva(int idAluno, int idProva)
        {
            double nota = 0;
            using (SqlConnection connection = new SqlConnection("Server=tcp:carolaine.database.windows.net,1433;" +
                "Initial Catalog=carolaine;Persist Security Info=False;User ID=xxxx;Password=xxxx;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                connection.Open();

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();

                using (SqlCommand cmd = new SqlCommand(
                    "SELECT ALUNO.NOME, tbAlunoProvaQuestao.NOTA" +
                    "FROM tbAlunoProvaQuestao" +
                    "INNER JOIN tbProvaQuestao ON tbProvaQuestao.IdQuestao = tbAlunoProvaQuestao.IdProvaQuestao" +
                    "INNER JOIN tbProva        ON tbProva.DataAplicacao = tbProvaQuestao.IdProva" +
                    "INNER JOIN tbAluno       ON tbAluno.ID = tbAlunoProvaQuestao.IdAluno" +
                    "WHERE tbAluno.Id = @IdAluno" +
                    "AND   tbProva.Id = @IdProva "
                    , connection))
                {
                    cmd.Parameters.AddWithValue("@IdAluno", idAluno);
                    cmd.Parameters.AddWithValue("@IdProva", idProva);
                    cmd.ExecuteNonQuery();

                    sda.SelectCommand = cmd;
                    sda.Fill(dt);

                }
                foreach (DataRow dr in dt.Rows)
                    nota += (double)dr["nota"];
            }

            return nota;
        }
    }
}

