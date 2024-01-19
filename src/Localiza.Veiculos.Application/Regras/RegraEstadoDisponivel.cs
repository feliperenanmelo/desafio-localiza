using Localiza.Veiculos.Domain.Dtos;
using Localiza.Veiculos.Domain.Enum;
using Localiza.Veiculos.Domain.Interfaces;

namespace Localiza.Veiculos.Application.Regras
{
    public class RegraEstadoDisponivelStrategy : IRegraStrategy
    {
        public bool PodeAlterar(StatusDto novoStatus, Status statusAtualVeiculo, DateTime dataAlteracao)
        {
            if (dataAlteracao > DateTime.Now) return false;

            var statusPermitidoAlteracao = StatusDto.EmManutencao | StatusDto.Alugado | StatusDto.Desativado;

            return statusAtualVeiculo.Equals(Status.Disponivel) && statusPermitidoAlteracao.HasFlag(novoStatus);
        }

    }

    public class RegraEstadoEmManutencaoStrategy : IRegraStrategy
    {
        public bool PodeAlterar(StatusDto novoStatus, Status statusAtualVeiculo, DateTime dataAlteracao)
        {
            if (dataAlteracao > DateTime.Now) return false;

            var statusPermitidoAlteracao = StatusDto.Disponivel | StatusDto.Desativado;

            return statusAtualVeiculo.Equals(Status.EmManutencao) && statusPermitidoAlteracao.HasFlag(novoStatus);
        }
    }
    public class RegraEstadoAlugadoStrategy: IRegraStrategy
    {
        public bool PodeAlterar(StatusDto novoStatus, Status statusAtualVeiculo, DateTime dataAlteracao)
        {
            if (dataAlteracao > DateTime.Now) return false;

            var statusPermitidoAlteracao = StatusDto.Disponivel | StatusDto.EmManutencao;

            return statusAtualVeiculo.Equals(Status.Alugado) && statusPermitidoAlteracao.HasFlag(novoStatus);
        }
    }
}
