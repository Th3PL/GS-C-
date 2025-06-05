using MedWay.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedWay.Controller
{
    public class EspecialidadeController
    {
        private readonly EspecialidadeRepository _especialidadeRepository = new EspecialidadeRepository();

        public void ListarEspecialidades()
        {
            Console.WriteLine("\n=== ESPECIALIDADES ===");

            var lista = _especialidadeRepository.ListarEspecialidades();

            foreach (var item in lista)
            {
                Console.WriteLine($"🔸 {item.Nome}: {item.Descricao}");
            }
        }
    }
}
