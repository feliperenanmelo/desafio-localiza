using Localiza.Veiculos.Api.Response;
using Localiza.Veiculos.Domain.Dtos;
using Localiza.Veiculos.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Localiza.Veiculos.Api.Controllers
{
    [Route("api/veiculos")]
    [ApiController]
    public class VeiculoController : ControllerBase
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodos()
            => Ok(await _veiculoService.ListarTodos());

        [HttpGet("{veiculoId:int}")]
        public async Task<IActionResult> ObterPorId(int veiculoId)
        {
            var veiculo = await _veiculoService.ObterPorId(veiculoId);

            if (veiculo is null) return NotFound();

            return Ok(veiculo);
        }


        [HttpGet("historico/{veiculoId:int}")]
        public async Task<IActionResult> ListarHistorico(int veiculoId)
        {
            var veiculoHistorico = await _veiculoService.ObterHistorico(veiculoId);

            if (veiculoHistorico is null) return NotFound();

            return Ok(veiculoHistorico);
        }

        [HttpPut("{veiculoId:int}")]
        public async Task<IActionResult> AlterarEstado(int veiculoId, [FromBody] VeiculoAlteracaoEstadoDto veiculoAlteracaoEstadoDto)
        {
            var validationResult = new VeiculoAlteracaoEstadoDtoValidator().Validate(veiculoAlteracaoEstadoDto);

            if (!validationResult.IsValid)
                return BadRequest(new ResponseRequest(HttpStatusCode.BadRequest.GetHashCode(), validationResult.IsValid, data: null, validationResult.Errors.Select(er => er.ErrorMessage)));

            var estadoAlterado = await _veiculoService.AlterarEstado(veiculoId, veiculoAlteracaoEstadoDto);

            if (!estadoAlterado) return UnprocessableEntity(new ResponseRequest(HttpStatusCode.BadRequest.GetHashCode(),false, data: null, new[] { "Estado desejado não pode ser aplicado para esta veículo" }));

            return NoContent();
        }

        [HttpDelete("historico/{veiculoId:int}")]
        public async Task<IActionResult> DesfazerEstado(int veiculoId)
        {
            var estadoFoiDesfeito = await _veiculoService.DesfazerEstado(veiculoId);


            if (!estadoFoiDesfeito)
                return UnprocessableEntity(new ResponseRequest(HttpStatusCode.UnprocessableEntity.GetHashCode(),false, data: null, new[] { "Não é possível desfazer estado, tempo limite excedido" }));

            return NoContent();
        }
    }
}
