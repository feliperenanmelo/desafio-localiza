using Localiza.Veiculos.Domain.Enities;
using Localiza.Veiculos.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Localiza.Veiculos.Data.Repository
{
    public class Context
    {
        private ICollection<Veiculo> _veiculos;

        public ICollection<Veiculo> Veiculos { get => _veiculos; }

        public Context()
        {
             _veiculos= new Collection<Veiculo>() 
             {
                Veiculo.Criar(1, "XC40", Marca.Volvo),
                Veiculo.Criar(2, "XC60", Marca.Volvo),
                Veiculo.Criar(3, "XC90", Marca.Volvo),
                Veiculo.Criar(4, "Q3", Marca.Audi),
                Veiculo.Criar(5, "Q5", Marca.Audi),
                Veiculo.Criar(6, "Uno", Marca.Fiat),
                Veiculo.Criar(7, "Pálio", Marca.Fiat),
                Veiculo.Criar(8, "X4", Marca.Bmw),
                Veiculo.Criar(9, "X6", Marca.Bmw),
                Veiculo.Criar(10, "220i", Marca.Bmw),
             };
        }    
    }
}
