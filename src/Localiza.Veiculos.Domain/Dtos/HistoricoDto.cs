using Localiza.Veiculos.Domain.Enum;

namespace Localiza.Veiculos.Domain.Dtos
{
    public class HistoricoDto
    {
        public Guid Id { get; private set; }
        public int VeiculoId { get; private set; }
        public StatusDto Status { get; private set; }
        public DateTime AlteradoEm { get; private set; }

        public HistoricoDto(int veiculoId, Status status, DateTime alteradoEm)
        {
            Id = Guid.NewGuid();
            VeiculoId = veiculoId;
            Status = (StatusDto)status.GetHashCode();
            AlteradoEm = alteradoEm;
        }
    }
}
