using MedWay.Model;
using MedWay.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedWay.Controller
{
    public class UsuarioController
    {
        private readonly UsuarioRepository _usuarioRepository = new UsuarioRepository();

        private Usuario _usuarioLogado; // Guarda o usuário logado

        public void Login()
        {
            Console.WriteLine("\n=== LOGIN ===");
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            bool logado = _usuarioRepository.ValidarLogin(email, senha);

            if (logado)
            {
                _usuarioLogado = _usuarioRepository.BuscarPorEmail(email);
                Console.WriteLine($"✅ Login realizado com sucesso! Bem-vindo, {_usuarioLogado.Nome}");
            }
            else
            {
                Console.WriteLine("❌ Email ou senha inválidos.");
            }
        }

        public void Cadastrar()
        {
            Console.WriteLine("\n=== CADASTRO ===");

            try
            {
                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                string senha;
                while (true)
                {
                    Console.Write("Senha (mínimo 1 número e 1 caractere especial): ");
                    senha = Console.ReadLine();

                    if (!ValidarSenha(senha))
                    {
                        Console.WriteLine("❌ A senha deve conter ao menos um número e um caractere especial.");
                    }
                    else
                    {
                        break;
                    }
                }

                DateTime dataNascimento;
                while (true)
                {
                    Console.Write("Data de nascimento (dd/mm/aaaa): ");
                    if (!DateTime.TryParse(Console.ReadLine(), out dataNascimento))
                    {
                        Console.WriteLine("❌ Data inválida. Tente novamente.");
                        continue;
                    }

                    if (dataNascimento > DateTime.Today)
                    {
                        Console.WriteLine("❌ Data de nascimento não pode ser no futuro.");
                    }
                    else
                    {
                        break;
                    }
                }

                Console.WriteLine("Selecione o Tipo Sanguíneo:");
                foreach (var tipo in Enum.GetValues(typeof(TipoSanguineo)))
                {
                    Console.WriteLine($"{(int)tipo} - {tipo}");
                }

                Console.Write("Digite o número correspondente: ");
                int tipoSelecionado = int.Parse(Console.ReadLine());
                var tipoSanguineo = (TipoSanguineo)tipoSelecionado;

                var usuario = new Usuario
                {
                    Nome = nome,
                    Email = email,
                    Senha = senha,
                    DataNascimento = dataNascimento,
                    TipoSanguineo = tipoSanguineo,
                    Cidade = "",
                    Estado = ""
                };

                bool sucesso = _usuarioRepository.Cadastrar(usuario);

                if (sucesso)
                    Console.WriteLine("✅ Usuário cadastrado com sucesso!");
                else
                    Console.WriteLine("❌ Email já cadastrado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Ocorreu um erro no cadastro: {ex.Message}");
            }
        }
        public void MostrarDadosUsuarioLogado()
        {
            if (_usuarioLogado == null)
            {
                Console.WriteLine("⚠️ Nenhum usuário está logado.");
                return;
            }

            Console.WriteLine("\n=== DADOS DO USUÁRIO LOGADO ===");
            Console.WriteLine($"👤 Nome: {_usuarioLogado.Nome}");
            Console.WriteLine($"🎂 Idade: {CalcularIdade(_usuarioLogado.DataNascimento)} anos");
            Console.WriteLine($"🩸 Tipo Sanguíneo: {_usuarioLogado.TipoSanguineo}");
            Console.WriteLine($"🏙️ Localização: {_usuarioLogado.Cidade}/{_usuarioLogado.Estado}");
        }

        private int CalcularIdade(DateTime dataNascimento)
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - dataNascimento.Year;

            if (dataNascimento.Date > hoje.AddYears(-idade)) idade--;

            return idade;
        }

        public bool LoginRetornaStatus()
        {
            Console.WriteLine("\n=== LOGIN ===");
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Senha: ");
            string senha = Console.ReadLine();

            bool logado = _usuarioRepository.ValidarLogin(email, senha);

            if (logado)
            {
                _usuarioLogado = _usuarioRepository.BuscarPorEmail(email);


                var localizacao = GerarLocalizacaoAleatoria();
                _usuarioLogado.Cidade = localizacao.cidade;
                _usuarioLogado.Estado = localizacao.estado;

                Console.WriteLine($"\n✅ Login realizado com sucesso! Bem-vindo, {_usuarioLogado.Nome}");
                Console.WriteLine($"📍 Localização simulada: {_usuarioLogado.Cidade}/{_usuarioLogado.Estado}");
                return true;
            }
            else
            {
                Console.WriteLine("\n❌ Email ou senha inválidos.");
                return false;
            }
        }
        private (string cidade, string estado) GerarLocalizacaoAleatoria()
        {
            var localizacoes = new List<(string cidade, string estado)>
    {
        ("São Paulo", "SP"),
        ("Rio de Janeiro", "RJ"),
        ("Belo Horizonte", "MG"),
        ("Curitiba", "PR"),
        ("Porto Alegre", "RS"),
        ("Salvador", "BA"),
        ("Recife", "PE"),
        ("Fortaleza", "CE"),
        ("Brasília", "DF")
    };

            var random = new Random();
            int index = random.Next(localizacoes.Count);
            return localizacoes[index];
        }

        public Usuario ObterUsuarioLogado()
        {
            return _usuarioLogado;
        }

        public bool EstaLogado()
        {
            return _usuarioLogado != null;
        }

        private bool ValidarSenha(string senha)
        {
            bool temNumero = senha.Any(char.IsDigit);
            bool temEspecial = senha.Any(ch => !char.IsLetterOrDigit(ch));
            return temNumero && temEspecial;
        }
    }

}
