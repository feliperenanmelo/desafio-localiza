using Localiza.Veiculos.Domain.Enities;

namespace Localiza.Veiculos.Domain.Interfaces
{
    public interface IVeiculoRepository
    {
        Task<ICollection<Veiculo>> ListarTodos();
        Task<Veiculo> ObterPorId(int veiculoId);
        Task<bool> AlterarEstado(int veiculoId, int novoStatus, DateTime dataAlteracao);
        Task<bool> DesfazerEstado(int veiculoId);
    }
}
