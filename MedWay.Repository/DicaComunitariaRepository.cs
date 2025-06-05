using MedWay.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedWay.Repository
{
    public class DicaComunitariaRepository
    {
        private readonly string _connectionString = "User Id=RM550366;Password=280105;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));";

        public List<DicaComunitaria> ListarDicas()
        {
            var dicas = new List<DicaComunitaria>();

            using (var connection = new OracleConnection(_connectionString))
            {
                string query = "SELECT ID, TITULO, CONTEUDO FROM DICAS_COMUNITARIAS";

                connection.Open();
                OracleCommand cmd = new OracleCommand(query, connection);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dicas.Add(new DicaComunitaria
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Titulo = reader["TITULO"].ToString(),
                        Conteudo = reader["CONTEUDO"].ToString()
                    });
                }
            }

            return dicas;
        }
    }
}
