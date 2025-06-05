using MedWay.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedWay.Repository
{
    public class EspecialidadeRepository
    {
        private readonly string _connectionString = "User Id=RM550366;Password=280105;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));";

        public List<Especialidade> ListarEspecialidades()
        {
            var lista = new List<Especialidade>();

            using (var connection = new OracleConnection(_connectionString))
            {
                string query = "SELECT ID, NOME, DESCRICAO FROM ESPECIALIDADES";

                connection.Open();
                OracleCommand cmd = new OracleCommand(query, connection);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new Especialidade
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Nome = reader["NOME"].ToString(),
                        Descricao = reader["DESCRICAO"].ToString()
                    });
                }
            }

            return lista;
        }
    }
}
