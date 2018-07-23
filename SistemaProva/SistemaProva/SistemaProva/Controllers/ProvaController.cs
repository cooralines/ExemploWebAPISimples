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
    public class ProvaController : ApiController
    {

        [HttpPost]
        public void CriarProva([FromBody]Prova prova)
        {
            using (SqlConnection conn = new SqlConnection("Server=tcp:carolaine.database.windows.net,1433;" +
                "Initial Catalog=carolaine;Persist Security Info=False;User ID=xxxx;Password=xxxx;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO tb_Prova (Nome, DataAplicacao) VALUES (@nome, @dataAplicacao)", conn))
                {
                    cmd.Parameters.AddWithValue("@nome", prova.Nome);
                    cmd.Parameters.AddWithValue("@dataAplicacao", prova.DataAplicacao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        [HttpPost]
        public void AlterarProva([FromBody]Prova prova)
        {
            using (SqlConnection conn = new SqlConnection("Server=tcp:carolaine.database.windows.net,1433;" +
                "Initial Catalog=carolaine;Persist Security Info=False;User ID=xxxx;Password=xxxx;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE tb_Prova SET Nome=@nome, DataAplicacao=@dataAplicacao WHERE Id=@id", conn))
                {

                    cmd.Parameters.AddWithValue("@nome", prova.Nome);
                    cmd.Parameters.AddWithValue("@dataAplicacao", prova.DataAplicacao);
                    cmd.Parameters.AddWithValue("@id", prova.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        [HttpPost]
        public void DeletarProva([FromBody]Prova prova)
        {
            using (SqlConnection conn = new SqlConnection("Server=tcp:carolaine.database.windows.net,1433;" +
                "Initial Catalog=carolaine;Persist Security Info=False;User ID=xxxx;Password=xxxx;" +
                "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("DELETE FROM tb_Prova WHERE Id = @id", conn))
                {

                    cmd.Parameters.AddWithValue("@id", prova.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
