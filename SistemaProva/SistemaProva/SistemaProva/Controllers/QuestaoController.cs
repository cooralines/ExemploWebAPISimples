using SistemaProva.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SistemaProva.Controllers
{
    public class QuestaoController : ApiController
    {
        [HttpPost]
        public void CriarQuestao([FromBody]Questao questao)
        {
            using (SqlConnection conn = new SqlConnection("Server=tcp:carolaine.database.windows.net,1433;" +
                "Initial Catalog=carolaine;Persist Security Info=False;User ID=xxxx;Password=xxxx;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO tb_Questao (Nome, Enunciado) VALUES (@nome, @enunciado)", conn))
                {

                    cmd.Parameters.AddWithValue("@nome", questao.Nome);
                    cmd.Parameters.AddWithValue("@enunciado", questao.Enunciado);
                   
                    cmd.ExecuteNonQuery();
                }
            }
        }


        [HttpPost]
        public void AlterarQuestao([FromBody]Questao questao)
        {
            using (SqlConnection conn = new SqlConnection("Server=tcp:carolaine.database.windows.net,1433;" +
                "Initial Catalog=carolaine;Persist Security Info=False;User ID=xxxx;Password=xxxx;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE tb_Questao SET Nome=@nome, Enunciado=@enunciado WHERE Id=@id", conn))
                {

                    cmd.Parameters.AddWithValue("@nome", questao.Nome);
                    cmd.Parameters.AddWithValue("@enunciado", questao.Enunciado);
                    cmd.Parameters.AddWithValue("@id", questao.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        [HttpPost]
        public void DeletarQuestao([FromBody]Questao questao)
        {
            using (SqlConnection conn = new SqlConnection("Server=tcp:carolaine.database.windows.net,1433;" +
                "Initial Catalog=carolaine;Persist Security Info=False;User ID=xxxx;Password=xxxx;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM tb_Questao WHERE Id = @id", conn))
                {

                    cmd.Parameters.AddWithValue("@id", questao.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
