# Projeto VOLVO_API

Este é um projeto de API para gerenciar carros da marca Volvo, com suporte para carros a combustão e carros elétricos. A API oferece operações CRUD (Criar, Ler, Atualizar, Deletar) para ambas as categorias de carros, além de funcionalidades específicas para cada tipo, como abastecimento para carros a combustão e recarga de bateria para carros elétricos.

## Tecnologias Utilizadas

- **ASP.NET Core:** A API foi desenvolvida utilizando o framework ASP.NET Core, que é uma plataforma de código aberto, multiplataforma e modular, ideal para a construção de aplicativos modernos e escaláveis.

- **Swagger:** A API utiliza o Swagger para documentação e exposição de sua interface, facilitando a compreensão dos endpoints disponíveis e suas operações.

## Estrutura do Projeto

O projeto está dividido em dois controladores principais:

### CarroCombustaoController

- Responsável por gerenciar operações relacionadas a carros a combustão.
- Oferece endpoints para criar, listar, atualizar e deletar carros a combustão.
- Possui funcionalidades específicas, como checar o combustível do tanque, abastecer o tanque e viajar com o carro a combustão.

### CarroEletricoController

- Responsável por gerenciar operações relacionadas a carros elétricos.
- Oferece endpoints para criar, listar, atualizar e deletar carros elétricos.
- Possui funcionalidades específicas, como checar a carga da bateria, abastecer a bateria e viajar com o carro elétrico.

## Como Utilizar a API

### Endpoints Gerais

- `GET /CarroCombustao`: Obtém a lista de modelos de carros a combustão.
- `GET /CarroEletrico`: Obtém a lista de modelos de carros elétricos.

### Endpoints Carro a Combustão

- `POST /CarroCombustao`: Cria um novo carro a combustão.
- `DELETE /CarroCombustao/{placa}`: Deleta um carro a combustão com base em sua placa.
- `PUT /CarroCombustao/{placa}`: Atualiza as informações de um carro a combustão com base em sua placa.
- `GET /CarroCombustao/{placa}`: Obtém o nível de combustível do tanque de um carro a combustão com base em sua placa.
- `POST /CarroCombustao/Abastecer/{placa}/{quantidadeL}`: Abastece o tanque de um carro a combustão com base em sua placa e uma quantidade de litros de combustível.
- `POST /CarroCombustao/Viajar/{placa}/{distanciaKM}`: Realiza uma viagem com um carro a combustão com base em sua placa e uma quantidade de quilômetros.

### Endpoints Carro Elétrico

- `POST /CarroEletrico`: Cria um novo carro elétrico.
- `DELETE /CarroEletrico/{placa}`: Deleta um carro elétrico com base em sua placa.
- `PUT /CarroEletrico/{placa}`: Atualiza as informações de um carro elétrico com base em sua placa.
- `GET /CarroEletrico/{placa}`: Obtém a carga da bateria de um carro elétrico com base em sua placa.
- `POST /CarroEletrico/Abastecer/{placa}/{quantidadeKW}`: Abastece a bateria de um carro elétrico com base em sua placa e uma quantidade de kilowatts.
- `POST /CarroEletrico/Viajar/{placa}/{distanciaKM}`: Realiza uma viagem com um carro elétrico com base em sua placa e uma quantidade de quilômetros.

Lembre-se de substituir `{placa}`, `{quantidadeL}`, `{quantidadeKW}`, `{distanciaKM}` e '{quantidadeL}' pelos valores reais desejados.

Para obter mais detalhes sobre cada endpoint, consulte a documentação Swagger da API, acessível em `/swagger` após a inicialização do servidor.

## Como Executar o Projeto

1. Certifique-se de ter o [.NET Core SDK](https://dotnet.microsoft.com/download) instalado em sua máquina.
2. Clone este repositório.
3. Navegue até o diretório do projeto.
4. Execute o comando `dotnet run`.
5. Acesse a documentação Swagger em [http://localhost:5297/swagger] para explorar os endpoints disponíveis.
6. Nota: Caso a aplicação apresente problemas por causa da porta escolhida (5297), você pode modificala no arquivo VOLVO.http .
