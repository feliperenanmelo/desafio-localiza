using Localiza.Veiculos.Domain.Enum;
using Localiza.Veiculos.Domain.Interfaces;

namespace Localiza.Veiculos.Application.Regras
{
    public static class RegraStrategyFactory
    {
        public static IRegraStrategy CriarRegra(Status statusAtualVeiculo)
        {
            switch (statusAtualVeiculo)
            {
                case Status.Disponivel:
                    return new RegraEstadoDisponivelStrategy();
                case Status.Alugado:
                    return new RegraEstadoAlugadoStrategy();
                case Status.EmManutencao:
                    return new RegraEstadoEmManutencaoStrategy();                
                default:
                    throw new ArgumentException("Regra não identificada");                    
            }
        }
    }
}
