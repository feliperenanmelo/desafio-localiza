using Localiza.Veiculos.Domain.Enum;

namespace Localiza.Veiculos.Domain.ValueObject
{
    public class Historico
    {
        public Guid Id { get; private set; }
        public int VeiculoId { get; private set; }
        public Status Status { get; private set; }
        public DateTime AlteradoEm { get; private set; }

        public Historico(int veiculoId, Status status, DateTime alteradoEm)
        {
            Id = Guid.NewGuid();
            VeiculoId = veiculoId;
            Status = status;
            AlteradoEm = alteradoEm;
        }
    }
}
