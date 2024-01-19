namespace Localiza.Veiculos.Domain.Enum
{
    [Flags]
    public enum Status
    {
        Disponivel = 1,
        Alugado,
        EmManutencao,
        Desativado
    }
}
