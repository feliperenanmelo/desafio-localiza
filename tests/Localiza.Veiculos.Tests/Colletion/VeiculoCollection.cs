using Localiza.Veiculos.Tests.Fixture;

namespace Localiza.Veiculos.Tests.Colletion
{
    [CollectionDefinition(nameof(VeiculoCollection))]
    public class VeiculoCollection
        : ICollectionFixture<VeiculoFixture>
    { }
}
