using Localiza.Veiculos.Application.Extensions;
using Localiza.Veiculos.Application.Regras;
using Localiza.Veiculos.Domain.Dtos;
using Localiza.Veiculos.Domain.Enum;
using Localiza.Veiculos.Domain.Interfaces;

namespace Localiza.Veiculos.Application.Service
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public VeiculoService(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<IEnumerable<VeiculoDto>> ListarTodos()
        {
            var veiculos = await _veiculoRepository.ListarTodos();

            return veiculos.ParaVeiculoDto();
        }

        public async Task<VeiculoDto> ObterPorId(int veiculoId)
        {
            var veiculo = await _veiculoRepository.ObterPorId(veiculoId);

            return veiculo.ParaVeiculoDto();
        }

        public async Task<VeiculoHistoricoDto> ObterHistorico(int veiculoId)
        {
            var veiculo = await _veiculoRepository.ObterPorId(veiculoId);

            return veiculo.ParaVeiculoHistoricoDto();
        }

        public async Task<bool> AlterarEstado(int veiculoId, VeiculoAlteracaoEstadoDto veiculoAlteracaoEstadoDto)
        {
            var veiculo = await _veiculoRepository.ObterPorId(veiculoId);

            if (veiculo is null) return false;

            if (veiculo.Status == Status.Desativado || veiculo.Status == (Status)veiculoAlteracaoEstadoDto.Status) return false;
            
            var podeAlterar = RegraStrategyFactory
                .CriarRegra(veiculo.Status)
                .PodeAlterar(veiculoAlteracaoEstadoDto.Status, veiculo.Status, veiculoAlteracaoEstadoDto.DataAlteracao.Value);

            if (!podeAlterar) return false;

            return await _veiculoRepository
                 .AlterarEstado(veiculoId, veiculoAlteracaoEstadoDto.Status.GetHashCode(), veiculoAlteracaoEstadoDto.DataAlteracao.Value);
        }

        public async Task<bool> DesfazerEstado(int veiculoId)
        {
            var veiculo = await _veiculoRepository.ObterPorId(veiculoId);

            if (veiculo is null) return false;

            var dataAtual = DateTime.Now;

            var historico = veiculo.Historico?.LastOrDefault();

            if(historico is null) return true;

            var dataHistoricoMais5Minutos = historico.AlteradoEm.AddMinutes(5);

            if(dataAtual > dataHistoricoMais5Minutos) return false;

            return await _veiculoRepository.DesfazerEstado(veiculoId);
        }
    }
}
