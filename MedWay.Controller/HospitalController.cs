using MedWay.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedWay.Controller
{
    public class HospitalController
    {
        private readonly HospitalRepository _hospitalRepository = new HospitalRepository();
        private readonly UsuarioController _usuarioController;

        public HospitalController(UsuarioController usuarioController)
        {
            _usuarioController = usuarioController;
        }

        public void ListarHospitais()
        {
            if (!_usuarioController.EstaLogado())
            {
                Console.WriteLine("⚠️ Você precisa estar logado para ver os hospitais.");
                return;
            }

            var cidade = _usuarioController.ObterUsuarioLogado().Cidade;

            Console.WriteLine($"\n=== 🏥 HOSPITAIS EM {cidade.ToUpper()} ===");

            var hospitais = _hospitalRepository.ListarHospitaisPorCidade(cidade);

            if (hospitais.Count == 0)
            {
                Console.WriteLine("❌ Nenhum hospital encontrado para essa localização.");
            }
            else
            {
                foreach (var hospital in hospitais)
                {
                    Console.WriteLine($"🏥 {hospital.Nome}");
                    Console.WriteLine($"Endereço: {hospital.Endereco}");
                    Console.WriteLine("-------------------------");
                }
            }
        }
    }
}
