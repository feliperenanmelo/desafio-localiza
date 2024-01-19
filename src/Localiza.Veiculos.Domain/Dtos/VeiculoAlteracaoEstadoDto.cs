using FluentValidation;
using Newtonsoft.Json;

namespace Localiza.Veiculos.Domain.Dtos
{
    public class VeiculoAlteracaoEstadoDto
    {
        [JsonProperty("status_alteracao_veiculo")]
        public StatusDto Status { get; set; }

        [JsonProperty("data_alteracao_veiculo")]
        public DateTime? DataAlteracao { get; set; }
    }

    public class VeiculoAlteracaoEstadoDtoValidator : AbstractValidator<VeiculoAlteracaoEstadoDto>
    {
        public VeiculoAlteracaoEstadoDtoValidator()
        {
            RuleFor(dto => dto.Status)
                .Must(status => System.Enum.IsDefined(typeof(StatusDto), status))
                .WithMessage("{PropertyName} inválido");

            RuleFor(dto => dto.DataAlteracao)
                .GreaterThan(new DateTime(1900,01,01))
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("{PropertyName} deve ser menor que a data atual");
        }
    }
}
