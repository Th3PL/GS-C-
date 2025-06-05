using MedWay.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedWay.Controller
{
    public class InformacaoEmergencialController
    {
        private readonly InformacaoEmergencialRepository _infoRepository = new InformacaoEmergencialRepository();

        public void ListarInformacoes()
        {
            Console.WriteLine("\n=== INFORMAÇÕES DE EMERGÊNCIA ===");

            var lista = _infoRepository.ListarInformacoes();

            foreach (var info in lista)
            {
                Console.WriteLine($"🚨 {info.Titulo}");
                Console.WriteLine($"📄 {info.Descricao}");
                Console.WriteLine("-------------------------");
            }
        }
    }
}
