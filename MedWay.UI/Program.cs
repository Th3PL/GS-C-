using MedWay.Controller;

class Program
{
    static void Main(string[] args)
    {
        var usuarioController = new UsuarioController();
        var hospitalController = new HospitalController(usuarioController);
        var especialidadeController = new EspecialidadeController();
        var dicaController = new DicaComunitariaController();
        var infoController = new InformacaoEmergencialController();

        bool logado = false;
        bool continuar = true;

        // ✅ Tela de login obrigatória
        while (!logado)
        {
            Console.Clear();
            Console.WriteLine("=== 🔐 LOGIN OBRIGATÓRIO ===");
            Console.WriteLine("1 - Fazer Login");
            Console.WriteLine("2 - Cadastrar Usuário");
            Console.WriteLine("0 - Sair");

            Console.Write("\nEscolha: ");
            string opcaoLogin = Console.ReadLine();

            switch (opcaoLogin)
            {
                case "1":
                    Console.Clear();
                    logado = usuarioController.LoginRetornaStatus();
                    if (!logado)
                    {
                        Console.WriteLine("\n❌ Falha no login. Pressione qualquer tecla para tentar novamente.");
                        Console.ReadKey();
                    }
                    break;

                case "2":
                    Console.Clear();
                    usuarioController.Cadastrar();
                    Console.WriteLine("\n✅ Cadastro realizado. Pressione qualquer tecla para continuar.");
                    Console.ReadKey();
                    break;

                case "0":
                    Console.WriteLine("\n✅ Encerrando o programa...");
                    return;

                default:
                    Console.WriteLine("\n❌ Opção inválida.");
                    Console.ReadKey();
                    break;
            }
        }

        // ✅ Menu principal após login
        while (continuar)
        {
            Console.Clear();
            Console.WriteLine($"=== 🚀 MENU PRINCIPAL - Localização Atual: {usuarioController.ObterUsuarioLogado().Cidade}/{usuarioController.ObterUsuarioLogado().Estado} ===");
            Console.WriteLine("1 - Listar Hospitais Próximos");
            Console.WriteLine("2 - Listar Especialidades");
            Console.WriteLine("3 - Ver Dicas Comunitárias");
            Console.WriteLine("4 - Ver Informações de Emergência");
            Console.WriteLine("5 - Ver Meus Dados");
            Console.WriteLine("0 - Sair");

            Console.Write("\nEscolha: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    hospitalController.ListarHospitais();
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.Clear();
                    especialidadeController.ListarEspecialidades();
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    break;

                case "3":
                    Console.Clear();
                    dicaController.ListarDicas();
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    break;

                case "4":
                    Console.Clear();
                    infoController.ListarInformacoes();
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    break;

                case "5":
                    Console.Clear();
                    usuarioController.MostrarDadosUsuarioLogado();
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                    break;

                case "0":
                    continuar = false;
                    Console.WriteLine("\n✅ Encerrando o programa...");
                    break;

                default:
                    Console.WriteLine("\n❌ Opção inválida.");
                    Console.ReadKey();
                    break;
            }
        }
    }
}
