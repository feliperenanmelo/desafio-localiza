using Localiza.Veiculos.Domain.Dtos;

namespace Localiza.Veiculos.Domain.Interfaces
{
    public interface IVeiculoService
    {
        Task<IEnumerable<VeiculoDto>> ListarTodos();
        Task<VeiculoDto> ObterPorId(int id);
        Task<VeiculoHistoricoDto> ObterHistorico(int veiculoId);
        Task<bool> AlterarEstado(int veiculoId, VeiculoAlteracaoEstadoDto veiculoAlteracaoEstadoDto);
        Task<bool> DesfazerEstado(int veiculoId);
    }
}
