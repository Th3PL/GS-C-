using MedWay.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedWay.Repository
{
    public class HospitalRepository
    {
        private readonly string _connectionString = "User Id=RM550366;Password=280105;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));";

        public List<Hospital> ListarHospitais()
        {
            var hospitais = new List<Hospital>();

            using (var connection = new OracleConnection(_connectionString))
            {
                string query = "SELECT ID, NOME, ENDERECO, CIDADE, ESTADO FROM HOSPITAIS";

                connection.Open();
                OracleCommand cmd = new OracleCommand(query, connection);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    hospitais.Add(new Hospital
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Nome = reader["NOME"].ToString(),
                        Endereco = reader["ENDERECO"].ToString(),
                        Cidade = reader["CIDADE"].ToString(),
                        Estado = reader["ESTADO"].ToString(),
                        Especialidades = new List<Especialidade>() // Especialidades podem ser carregadas depois
                    });
                }
            }

            return hospitais;
        }

        public List<Hospital> ListarHospitaisPorCidade(string cidade)
        {
            var hospitais = new List<Hospital>();

            using (var connection = new OracleConnection(_connectionString))
            {
                string query = $"SELECT ID, NOME, ENDERECO, CIDADE, ESTADO FROM HOSPITAIS WHERE CIDADE = '{cidade}'";

                connection.Open();
                OracleCommand cmd = new OracleCommand(query, connection);
                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    hospitais.Add(new Hospital
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Nome = reader["NOME"].ToString(),
                        Endereco = reader["ENDERECO"].ToString(),
                        Cidade = reader["CIDADE"].ToString(),
                        Estado = reader["ESTADO"].ToString(),
                        Especialidades = new List<Especialidade>()
                    });
                }
            }

            return hospitais;
        }
    }

}
