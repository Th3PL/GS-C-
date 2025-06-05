using MedWay.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedWay.Controller
{
    public class DicaComunitariaController
    {
        private readonly DicaComunitariaRepository _dicaRepository = new DicaComunitariaRepository();

        public void ListarDicas()
        {
            Console.WriteLine("\n=== DICAS PARA A COMUNIDADE ===");

            var dicas = _dicaRepository.ListarDicas();

            foreach (var dica in dicas)
            {
                Console.WriteLine($"📝 {dica.Titulo}");
                Console.WriteLine($"📄 {dica.Conteudo}");
                Console.WriteLine("-------------------------");
            }
        }
    }
}
