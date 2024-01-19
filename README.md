# desafio-localiza
Desafio localiza

O projeto Localiza.Veiculos.Api consiste em controlar o fluxo de locação de um veículo

Estados

1 - Disponivel  
2 - Alugado  
3 - EmManutencao  
4 - Desativo  

# Api desenvolvida utilizando NET 6.0 

| Método  | Enpoint                          | Body                                             | Parameters       | Descrição                                       |
| ------- | ------------------               | ------------------------------------------------ | ---------------- | ----------------------------------------------- |
| GET     | /api/veiculos                    |                                                  |                  | Retorna todos os veículos                       |
| GET     | /api/veiculos                    |                                                  | veiculoId        | Parametro tipo int representa id do veículo     |
| PUT     | /api/veiculos                    | status_alteracao_veiculo, data_alteracao_veiculo | json             | Body json para alteração de estado              |
| GET     | /api/veiculos/historico          |                                                  | veiculoId        | Parametro tipo int representa id do veículo     |
| DELETE  | /api/veiculos/historico          |                                                  | veiculoId        | Parametro tipo int representa id do veículo     |

# Desenvolvimento
  Projeto foi desenvolido pensando em um código simples e fácil de manter, as regras foram aplicadas por meio de um design pattern strategy que é criado em tempo de execução por uma factory
se baseando no status atual do veículo, isso me permite aplicar o OCP (solid) com mais eficiência, onde consigo separar as regras e em caso de surgirem mais regras ou mais estados,
serão criados novos strategies, o código fica simples com poucas linhas, de fácil entendimento pela escolha dos nomes das variavéis e métodos, provendo rápidez em mudanças por qualquer 
programador de qualquer nível

# Execução do projeto

Acesse o caminho :
docker e execute o comando docker-compose -f bycorders-production.yaml up

