using AutoMoqCore;
using Localiza.Veiculos.Domain.Dtos;
using Localiza.Veiculos.Domain.Interfaces;
using Localiza.Veiculos.Tests.Colletion;
using Localiza.Veiculos.Tests.Fixture;
using Moq;

namespace Localiza.Veiculos.Tests.Application
{
    [Collection(nameof(VeiculoCollection))]
    public class VeiculoServiceTests
    {
        private readonly VeiculoFixture _fixture;

        public VeiculoServiceTests(VeiculoFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact(DisplayName = "VeiculoService - Alterar estado Disponivel para EmManutencao sucesso")]
        [Trait("Application", "VeiculoService")]
        public async Task DadoVeiculoAlteracaoEstadoDtoComVeiculoValidoEstadoEmManutencao_QuandoAlterarEstado_AlterarStatusParaEmManutencaoSucesso()
        {
            // Arrange
            var alterarStatusDto = new VeiculoAlteracaoEstadoDto() { Status = StatusDto.EmManutencao, DataAlteracao = DateTime.Now.AddMinutes(-3) };

            var veiculoId = 1;

            var veiculoService = _fixture.SetupInicialEstadoDisponivel();

            // Act
            var alterado = await veiculoService.AlterarEstado(veiculoId, alterarStatusDto);

            // Assert
            Assert.True(alterado);

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo 
                    => veiculoRepo.ObterPorId(It.Is<int>(id => id == veiculoId)), Times.Once);

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo
                    => veiculoRepo.AlterarEstado(
                            It.Is<int>(id => id == veiculoId),
                            It.Is<int>(novoStatus => novoStatus == StatusDto.EmManutencao.GetHashCode()),
                            It.IsAny<DateTime>()), Times.Once);
        }

        [Fact(DisplayName = "VeiculoService - Alterar estado Disponivel para Alugado sucesso")]
        [Trait("Application", "VeiculoService")]
        public async Task DadoVeiculoAlteracaoEstadoDtoComVeiculoValidoEstadoAlugado_QuandoAlterarEstado_AlterarParaAlugadoSucesso()
        {
            // Arrange
            var alterarStatusDto = new VeiculoAlteracaoEstadoDto() { Status = StatusDto.Alugado, DataAlteracao = DateTime.Now.AddMinutes(-3) };

            var veiculoId = 1;

            var veiculoService = _fixture.SetupInicialEstadoDisponivel();

            // Act
            var alterado = await veiculoService.AlterarEstado(veiculoId, alterarStatusDto);

            // Assert
            Assert.True(alterado);

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo
                    => veiculoRepo.ObterPorId(It.Is<int>(id => id == veiculoId)), Times.Once);

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo
                    => veiculoRepo.AlterarEstado(
                            It.Is<int>(id => id == veiculoId),
                            It.Is<int>(novoStatus => novoStatus == StatusDto.Alugado.GetHashCode()),
                            It.IsAny<DateTime>()), Times.Once);
        }

        [Fact(DisplayName = "VeiculoService - Alterar estado Disponivel para Desativado sucesso")]
        [Trait("Application", "VeiculoService")]
        public async Task DadoVeiculoAlteracaoEstadoDtoComVeiculoValidoEstadoDesativado_QuandoAlterarEstado_AlterarParaDesativadoSucesso()
        {
            // Arrange
            var alterarStatusDto = new VeiculoAlteracaoEstadoDto() { Status = StatusDto.Desativado, DataAlteracao = DateTime.Now.AddMinutes(-3) };

            var veiculoId = 1;

            var veiculoService = _fixture.SetupInicialEstadoDisponivel();

            // Act
            var alterado = await veiculoService.AlterarEstado(veiculoId, alterarStatusDto);

            // Assert
            Assert.True(alterado);

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo
                    => veiculoRepo.ObterPorId(It.Is<int>(id => id == veiculoId)), Times.Once);

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo
                    => veiculoRepo.AlterarEstado(
                            It.Is<int>(id => id == veiculoId),
                            It.Is<int>(novoStatus => novoStatus == StatusDto.Desativado.GetHashCode()),
                            It.IsAny<DateTime>()), Times.Once);
        }

        [Fact(DisplayName = "VeiculoService - Alterar estado Disponivel para Desativado no futuro falha")]
        [Trait("Application", "VeiculoService")]
        public async Task DadoVeiculoAlteracaoEstadoDtoComVeiculoValidoEstadoDesativado_QuandoAlterarEstado_FalhaPorDataAlteracaoFutura()
        {
            // Arrange
            var alterarStatusDto = new VeiculoAlteracaoEstadoDto() { Status = StatusDto.Desativado, DataAlteracao = DateTime.Now.AddMinutes(3) };

            var veiculoId = 1;

            var veiculoService = _fixture.SetupInicialEstadoDisponivel();

            // Act
            var alterado = await veiculoService.AlterarEstado(veiculoId, alterarStatusDto);

            // Assert
            Assert.False(alterado);

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo
                    => veiculoRepo.ObterPorId(It.Is<int>(id => id == veiculoId)), Times.Once);

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo
                    => veiculoRepo.AlterarEstado(
                            It.Is<int>(id => id == veiculoId),
                            It.Is<int>(novoStatus => novoStatus == StatusDto.Alugado.GetHashCode()),
                            It.IsAny<DateTime>()), Times.Never);
        }


        [Fact(DisplayName = "VeiculoService - Desfazer alteração de estado EmManutencao sucesso")]
        [Trait("Application", "VeiculoService")]
        public async Task DadoVeiculoAlteracaoEstadoDtoComVeiculoValidoEstadoEmManutencao_QuandoDesfazerEstado_RetornaEstadoAlugadoSucesso()
        {
            // Arrange
            var statusAlugado = new VeiculoAlteracaoEstadoDto() { Status = StatusDto.Alugado, DataAlteracao = DateTime.Now.AddMinutes(-3) };
            var statusEmManutencao = new VeiculoAlteracaoEstadoDto() { Status = StatusDto.EmManutencao, DataAlteracao = DateTime.Now.AddMinutes(-1) };

            var veiculoId = 1;
            var veiculoService = _fixture.SetupInicialEstadoDisponivelAlugadoEmManutencao();

            // Act
            var alterouParaAlugado = await veiculoService.AlterarEstado(veiculoId, statusAlugado);
            var alterouParaEmManutencao = await veiculoService.AlterarEstado(veiculoId, statusEmManutencao);

            var desfazerEstadoEmManutencao = await veiculoService.DesfazerEstado(veiculoId);

            // Assert
            Assert.True(alterouParaAlugado);
            Assert.True(alterouParaEmManutencao);
            Assert.True(desfazerEstadoEmManutencao);

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo
                    => veiculoRepo.ObterPorId(It.Is<int>(id => id == veiculoId)), Times.Exactly(3));

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo
                    => veiculoRepo.AlterarEstado(
                            It.Is<int>(id => id == veiculoId),
                            It.Is<int>(novoStatus => novoStatus == StatusDto.Alugado.GetHashCode()),
                            It.IsAny<DateTime>()), Times.Once);

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo
                    => veiculoRepo.AlterarEstado(
                            It.Is<int>(id => id == veiculoId),
                            It.Is<int>(novoStatus => novoStatus == StatusDto.EmManutencao.GetHashCode()),
                            It.IsAny<DateTime>()), Times.Once);

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo 
                    => veiculoRepo.DesfazerEstado(It.Is<int>(id => id == veiculoId)), Times.Once);
        }

        [Fact(DisplayName = "VeiculoService - Desfazer alteração de estado EmManutencao falha por passar do tempo permitido")]
        [Trait("Application", "VeiculoService")]
        public async Task DadoVeiculoAlteracaoEstadoDtoComVeiculoValidoEstadoEmManutencao_QuandoDesfazerEstado_FalhaPorPassarDe5Minutos()
        {
            // Arrange
            var statusAlugado = new VeiculoAlteracaoEstadoDto() { Status = StatusDto.Alugado, DataAlteracao = DateTime.Now.AddMinutes(-6) };
            var statusEmManutencao = new VeiculoAlteracaoEstadoDto() { Status = StatusDto.EmManutencao, DataAlteracao = DateTime.Now.AddMinutes(-5) };

            var veiculoId = 1;
            var veiculoService = _fixture.SetupInicialEstadoDisponivelAlugadoEmManutencaoDesfazerAlteracao();

            // Act
            var alterouParaAlugado = await veiculoService.AlterarEstado(veiculoId, statusAlugado);
            var alterouParaEmManutencao = await veiculoService.AlterarEstado(veiculoId, statusEmManutencao);

            var desfazerEstadoEmManutencao = await veiculoService.DesfazerEstado(veiculoId);

            // Assert
            Assert.True(alterouParaAlugado);
            Assert.True(alterouParaEmManutencao);
            Assert.False(desfazerEstadoEmManutencao);

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo
                    => veiculoRepo.ObterPorId(It.Is<int>(id => id == veiculoId)), Times.Exactly(3));

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo
                    => veiculoRepo.AlterarEstado(
                            It.Is<int>(id => id == veiculoId),
                            It.Is<int>(novoStatus => novoStatus == StatusDto.Alugado.GetHashCode()),
                            It.IsAny<DateTime>()), Times.Once);

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo
                    => veiculoRepo.AlterarEstado(
                            It.Is<int>(id => id == veiculoId),
                            It.Is<int>(novoStatus => novoStatus == StatusDto.EmManutencao.GetHashCode()),
                            It.IsAny<DateTime>()), Times.Once);

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo
                    => veiculoRepo.DesfazerEstado(It.Is<int>(id => id == veiculoId)), Times.Never);
        }

        [Fact(DisplayName = "VeiculoService - Alterar estado desativo falha")]
        [Trait("Application", "VeiculoService")]
        public async Task DadoVeiculoAlteracaoEstadoDtoComVeiculoValidoEstadoDisponivel_QuandoDesfazerEstado_FalhaEstadoDesativoNaoPodeSerAlterado()
        {
            // Arrange            
            var statusDisponivel = new VeiculoAlteracaoEstadoDto() { Status = StatusDto.Disponivel, DataAlteracao = DateTime.Now.AddMinutes(-1) };

            var veiculoId = 1;
            var veiculoService = _fixture.SetupInicialEstadoDesativadoParaDisponivel();

            // Act
            var alterouParaDisponivel = await veiculoService.AlterarEstado(veiculoId, statusDisponivel);          

            // Assert            
            Assert.False(alterouParaDisponivel);

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo
                    => veiculoRepo.ObterPorId(It.Is<int>(id => id == veiculoId)), Times.Exactly(1));

            _fixture.Mocker
                .GetMock<IVeiculoRepository>()
                .Verify(veiculoRepo
                    => veiculoRepo.AlterarEstado(
                            It.Is<int>(id => id == veiculoId),
                            It.Is<int>(novoStatus => novoStatus == StatusDto.EmManutencao.GetHashCode()),
                            It.IsAny<DateTime>()), Times.Never);
        }
    }
}