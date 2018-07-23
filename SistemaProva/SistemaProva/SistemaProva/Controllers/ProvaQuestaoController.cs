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
    public class ProvaQuestaoController : ApiController
    {
        [HttpPost]
        public void AssociarQuestaoProva([FromBody]ProvaQuestao provaQuestao)
        {
            using (SqlConnection conn = new SqlConnection("Server=tcp:carolaine.database.windows.net,1433;" +
                "Initial Catalog=carolaine;Persist Security Info=False;User ID=xxxx;Password=xxxx;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO tbProvaQuestao (IdProva, IdQuestao, Valor) VALUES (@idProva, @idQuestao, @valor)", conn))
                {

                    cmd.Parameters.AddWithValue("@idProva", provaQuestao.IdProva);
                    cmd.Parameters.AddWithValue("@idQuestao", provaQuestao.IdQuestao );
                    cmd.Parameters.AddWithValue("@valor", provaQuestao.Valor);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        [HttpPost]
        public void DeletarQuestaoProva([FromBody]ProvaQuestao provaQuestao)
        {
            using (SqlConnection conn = new SqlConnection("Server=tcp:carolaine.database.windows.net,1433;" +
                "Initial Catalog=carolaine;Persist Security Info=False;User ID=xxxx;Password=xxxx;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM tbProvaQuestao WHERE IdProvaQuestao = @idProvaQuestao", conn))
                {

                    cmd.Parameters.AddWithValue("@idProvaQuestao", provaQuestao.IdProvaQuestao);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
