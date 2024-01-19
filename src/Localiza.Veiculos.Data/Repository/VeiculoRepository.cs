using Localiza.Veiculos.Domain.Enities;
using Localiza.Veiculos.Domain.Enum;
using Localiza.Veiculos.Domain.Interfaces;

namespace Localiza.Veiculos.Data.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly Context _context;
        public VeiculoRepository(Context context)
        {
            _context = context;
        }

        public async Task<ICollection<Veiculo>> ListarTodos()
        {
            var veiculos = _context.Veiculos;

            await Task.CompletedTask;

            return veiculos;
        }

        public async Task<Veiculo> ObterPorId(int veiculoId)
        {
            var veiculo = _context.Veiculos.FirstOrDefault(veiculo => veiculo.Id == veiculoId);

            await Task.CompletedTask;

            return veiculo;
        }


        public async Task<bool> AlterarEstado(int veiculoId, int novoStatus, DateTime dataAlteracao)
        {
            var veiculo = _context.Veiculos.FirstOrDefault(veiculo => veiculo.Id == veiculoId);

            veiculo.AlterarEstado((Status)novoStatus, dataAlteracao);

            return true;
        }

        public async Task<bool> DesfazerEstado(int veiculoId)
        {
            var veiculo = _context
                 .Veiculos
                 .FirstOrDefault(veiculo => veiculo.Id == veiculoId);

            veiculo.DesfazerEstado();

            return true;
        }
    }
}
