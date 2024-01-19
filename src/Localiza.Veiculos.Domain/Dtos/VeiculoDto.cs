using Localiza.Veiculos.Domain.Enum;

namespace Localiza.Veiculos.Domain.Dtos
{
    public class VeiculoDto
    {
        public int Id { get; set; }
        public StatusDto Status { get; set; }
        public MarcaDto MarcaDto { get; set; }
        public string Modelo { get; set; } = string.Empty;
        public DateTime CriadoEm { get; set; }
        public DateTime? AlteradoEm { get; set; }

        public VeiculoDto(
            int id, 
            Status status, 
            Marca marca, 
            string modelo, 
            DateTime criadoEm, 
            DateTime? alteradoEm)
        {
            Id = id;
            Status = (StatusDto)status;
            MarcaDto = (MarcaDto)marca;
            Modelo = modelo;
            CriadoEm = criadoEm;
            AlteradoEm = alteradoEm;
        }
    }
}
