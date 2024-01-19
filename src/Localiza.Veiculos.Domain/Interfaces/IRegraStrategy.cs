using Localiza.Veiculos.Domain.Dtos;
using Localiza.Veiculos.Domain.Enum;

namespace Localiza.Veiculos.Domain.Interfaces
{
    public interface IRegraStrategy
    {
        bool PodeAlterar(StatusDto novoStatus, Status statusAtualVeiculo, DateTime dataAlteracao);
    }
}
