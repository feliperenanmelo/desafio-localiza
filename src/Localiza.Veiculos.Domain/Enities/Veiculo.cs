using Localiza.Veiculos.Domain.Enum;
using Localiza.Veiculos.Domain.ValueObject;

namespace Localiza.Veiculos.Domain.Enities
{
    public class Veiculo
    {
        public int Id { get; private set; }
        public Status Status { get; private set; }
        public Marca Marca { get; private set; }
        public string Modelo { get; private set; } = string.Empty;
        public DateTime CriadoEm { get; private set; }
        public DateTime? AlteradoEm { get; private set; }

        public ICollection<Historico> Historico { get; set; }

        private Veiculo(int id, string modelo, Marca marca)
        {
            Id = id;
            Status = Status.Disponivel;
            Marca = marca;
            Modelo = modelo;
            CriadoEm = DateTime.Now;
            AlteradoEm = null;

            Historico = new List<Historico>();
        }

        private Veiculo(int id, Status status, string modelo, Marca marca)
        {
            Id = id;
            Status = status;
            Marca = marca;
            Modelo = modelo;
            CriadoEm = DateTime.Now;
            AlteradoEm = null;

            Historico = new List<Historico>();
        }

        public static Veiculo Criar(int id, string modelo, Marca marca)
            => new Veiculo(id, modelo, marca);

        public void AlterarEstado(Status status, DateTime dataAlteracao)
        {
            Status = status;
            AlteradoEm = dataAlteracao;
            Historico.Add(GerarHisotrico());
        }

        public void DesfazerEstado()
        {
            var historico = Historico?.Last();

            Historico?.Remove(historico);

            Status = historico.Status;

            AlteradoEm = historico.AlteradoEm;

            if (Historico?.Count == 0)
            {
                Status = Status.Disponivel;
                AlteradoEm = null;
            }
        }

        private Historico GerarHisotrico()
        {
            return new Historico(Id, Status, AlteradoEm.Value);
        }
    }
}
