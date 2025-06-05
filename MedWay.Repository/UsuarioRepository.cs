using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedWay.Model;
using Oracle.ManagedDataAccess.Client;

namespace MedWay.Repository
{
    public class UsuarioRepository
    {
        private readonly string _connectionString = "User Id=RM550366;Password=280105;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));";

        // Valida login
        public bool ValidarLogin(string email, string senha)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                string query = $"SELECT COUNT(1) FROM USUARIOS WHERE EMAIL = '{email}' AND SENHA = '{senha}'";

                connection.Open();
                OracleCommand cmd = new OracleCommand(query, connection);
                var resultado = cmd.ExecuteScalar();

                return Convert.ToInt32(resultado) > 0;
            }
        }

        // Cadastra usuário (evita duplicidade de email)
        public bool Cadastrar(Usuario usuario)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                connection.Open();

                // Verifica se email já existe
                string checkQuery = $"SELECT COUNT(1) FROM USUARIOS WHERE EMAIL = '{usuario.Email}'";
                OracleCommand checkCmd = new OracleCommand(checkQuery, connection);
                var existe = Convert.ToInt32(checkCmd.ExecuteScalar());

                if (existe > 0)
                    return false; // Email já cadastrado

                // Cadastro
                string insertQuery = $"INSERT INTO USUARIOS (ID, NOME, EMAIL, SENHA, DATANASCIMENTO, TIPOSANGUINEO, CIDADE, ESTADO) " +
                    $"VALUES (SEQ_USUARIOS.NEXTVAL, '{usuario.Nome}', '{usuario.Email}', '{usuario.Senha}', " +
                    $"TO_DATE('{usuario.DataNascimento:dd/MM/yyyy}', 'DD/MM/YYYY'), '{usuario.TipoSanguineo}', " +
                    $"'{usuario.Cidade}', '{usuario.Estado}')";

                OracleCommand insertCmd = new OracleCommand(insertQuery, connection);
                insertCmd.ExecuteNonQuery();

                return true;
            }
        }

        public Usuario BuscarPorEmail(string email)
        {
            using (var connection = new OracleConnection(_connectionString))
            {
                string query = $"SELECT * FROM USUARIOS WHERE EMAIL = '{email}'";

                connection.Open();
                OracleCommand cmd = new OracleCommand(query, connection);
                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new Usuario
                    {
                        Id = Convert.ToInt32(reader["ID"]),
                        Nome = reader["NOME"].ToString(),
                        Email = reader["EMAIL"].ToString(),
                        Senha = reader["SENHA"].ToString(),
                        DataNascimento = Convert.ToDateTime(reader["DATANASCIMENTO"]),
                        TipoSanguineo = Enum.Parse<TipoSanguineo>(reader["TIPOSANGUINEO"].ToString()),
                        Cidade = reader["CIDADE"].ToString(),
                        Estado = reader["ESTADO"].ToString()
                    };
                }

                return null;
            }
        }
    }

}
