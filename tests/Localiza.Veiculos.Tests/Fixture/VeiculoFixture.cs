using AutoMoqCore;
using Localiza.Veiculos.Application.Service;
using Localiza.Veiculos.Domain.Enities;
using Localiza.Veiculos.Domain.Enum;
using Localiza.Veiculos.Domain.Interfaces;
using Localiza.Veiculos.Domain.ValueObject;
using Moq;

namespace Localiza.Veiculos.Tests.Fixture
{
    public class VeiculoFixture
    {
        private AutoMoqer _mocker;

        public AutoMoqer Mocker { get => _mocker; }

        public VeiculoService SetupInicialEstadoDisponivel()
        {
            _mocker = new AutoMoqer();

            var vericuloService = _mocker.Create<VeiculoService>();

            _mocker
                .GetMock<IVeiculoRepository>()
                .Setup(veiculoRepo => veiculoRepo.ObterPorId(It.IsAny<int>()))
                .ReturnsAsync(Veiculo.Criar(1, "XC", Marca.Volvo));

            _mocker
                .GetMock<IVeiculoRepository>()
                .Setup(veiculoRepo => veiculoRepo.AlterarEstado(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>()))
                .ReturnsAsync(true);          

            return vericuloService;
        }

        public VeiculoService SetupInicialEstadoDisponivelAlugadoEmManutencao()
        {
            _mocker = new AutoMoqer();

            var vericuloService = _mocker.Create<VeiculoService>();

            var veiculo = Veiculo.Criar(1, "XC", Marca.Volvo);
            veiculo.Historico.Add(new Historico(1, Status.Alugado, DateTime.Now.AddMinutes(-3)));
            veiculo.Historico.Add(new Historico(1, Status.EmManutencao, DateTime.Now.AddMinutes(-1)));

            _mocker
                .GetMock<IVeiculoRepository>()
                .Setup(veiculoRepo => veiculoRepo.ObterPorId(It.IsAny<int>()))
                .ReturnsAsync(veiculo);

            _mocker
                .GetMock<IVeiculoRepository>()
                .Setup(veiculoRepo => veiculoRepo.AlterarEstado(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>()))
                .ReturnsAsync(true);

            _mocker
                .GetMock<IVeiculoRepository>()
                .Setup(veiculoRepo => veiculoRepo.DesfazerEstado(It.IsAny<int>()))
                .ReturnsAsync(true);

            return vericuloService;
        }

        public VeiculoService SetupInicialEstadoDisponivelAlugadoEmManutencaoDesfazerAlteracao()
        {
            _mocker = new AutoMoqer();

            var vericuloService = _mocker.Create<VeiculoService>();

            var veiculo = Veiculo.Criar(1, "XC", Marca.Volvo);
            veiculo.Historico.Add(new Historico(1, Status.Alugado, DateTime.Now.AddMinutes(-6)));
            veiculo.Historico.Add(new Historico(1, Status.EmManutencao, DateTime.Now.AddMinutes(-5)));

            _mocker
                .GetMock<IVeiculoRepository>()
                .Setup(veiculoRepo => veiculoRepo.ObterPorId(It.IsAny<int>()))
                .ReturnsAsync(veiculo);

            _mocker
                .GetMock<IVeiculoRepository>()
                .Setup(veiculoRepo => veiculoRepo.AlterarEstado(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>()))
                .ReturnsAsync(true);

            _mocker
                .GetMock<IVeiculoRepository>()
                .Setup(veiculoRepo => veiculoRepo.DesfazerEstado(It.IsAny<int>()))
                .ReturnsAsync(true);

            return vericuloService;
        }

        public VeiculoService SetupInicialEstadoDesativadoParaDisponivel()
        {
            _mocker = new AutoMoqer();

            var vericuloService = _mocker.Create<VeiculoService>();

            var veiculo = Veiculo.Criar(1, "XC", Marca.Volvo);
            veiculo.Historico.Add(new Historico(1, Status.Alugado, DateTime.Now.AddMinutes(-4)));
            veiculo.Historico.Add(new Historico(1, Status.EmManutencao, DateTime.Now.AddMinutes(-3)));
            veiculo.Historico.Add(new Historico(1, Status.Desativado, DateTime.Now.AddMinutes(-2)));

            _mocker
                .GetMock<IVeiculoRepository>()
                .Setup(veiculoRepo => veiculoRepo.ObterPorId(It.IsAny<int>()))
                .ReturnsAsync(veiculo);

            _mocker
                .GetMock<IVeiculoRepository>()
                .Setup(veiculoRepo => veiculoRepo.AlterarEstado(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<DateTime>()))
                .ReturnsAsync(true);       

            return vericuloService;
        }
    }
}
