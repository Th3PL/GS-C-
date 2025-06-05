using MedWay.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedWay.Repository
{
    public class InformacaoEmergencialRepository
    {
        private readonly string _connectionString = "User Id=RM550366;Password=280105;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));";

        public List<InformacaoEmergencial> ListarInformacoes()
        {
            var lista = new List<InformacaoEmergencial>();

            using (var connection = new OracleConnection(_connectionString))
            {
                string query = "SELECT ID, TITULO, DESCRICAO FROM INFORMACOES_EMERGENCIA";

                connection.Open();
                OracleCommand cmd = new OracleCommand(query, connection);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    lista.Add(new InformacaoEmergencial
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Titulo = reader["TITULO"].ToString(),
                        Descricao = reader["DESCRICAO"].ToString()
                    });
                }
            }

            return lista;
        }
    }
}
