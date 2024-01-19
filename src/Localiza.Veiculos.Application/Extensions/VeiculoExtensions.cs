using Localiza.Veiculos.Domain.Dtos;
using Localiza.Veiculos.Domain.Enities;
using Localiza.Veiculos.Domain.ValueObject;

namespace Localiza.Veiculos.Application.Extensions
{
    public  static class VeiculoExtensions
    {
        public static IEnumerable<VeiculoDto> ParaVeiculoDto(this ICollection<Veiculo> veiculos)
        {
            foreach (var veiculo in veiculos)
                yield return ParaVeiculoDto(veiculo);
        }
            

        public static VeiculoDto ParaVeiculoDto(this Veiculo veiculo)
        {
            if (veiculo is null) return null;
                    
            return new VeiculoDto(veiculo.Id, veiculo.Status, veiculo.Marca, veiculo.Modelo, veiculo.CriadoEm, veiculo.AlteradoEm);
        }

        public static VeiculoHistoricoDto ParaVeiculoHistoricoDto(this Veiculo veiculo)
        {
            if (veiculo is null) return null;

            return new VeiculoHistoricoDto(veiculo.Id, veiculo.Status, veiculo.Marca, veiculo.Modelo, veiculo.CriadoEm, veiculo.AlteradoEm, veiculo.Historico.ParaHistoricoDto());
        }

        public static IEnumerable<HistoricoDto> ParaHistoricoDto(this ICollection<Historico> historicos)
        {
            foreach (var historico in historicos)
                yield return ParaHistoricoDto(historico);
        }

        public static HistoricoDto ParaHistoricoDto(this Historico historico)
        {
            if (historico is null) return null;
                     
            return new HistoricoDto(historico.VeiculoId, historico.Status, historico.AlteradoEm);
        }
    
    }
}
