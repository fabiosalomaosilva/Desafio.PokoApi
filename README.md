# Desafio.PokoApi

O desafio trata-se de construir uma API em .NET Framework que consuma a API (https://pokeapi.co/) e possua as seguintes rotas:

1 - get para 10 pokemons aleatórios;
2 - get para 1 pokemon específico;
    Todas elas devem retornar os dados básicos do pokemon, suas evoluções e o base64 de sprite default de cada pokemon;
3 - Cadastro do mestre pokemon (dados basicos como nome, idade e cpf) em SQLite;
4 - Post para informar que um pokemon foi capturado;
5 - Listagem dos pokemons já capturados;

# Soluções

  - Embora eu tenha achado estranho, foi solicitado para criar a API em *.Net Framework*, e não em *.Net Core*. Desta forma, criei a API com .Net Framework 4.7.2.
  - API Rest construída como base no template do ASP.NET Web API com documentação incluída.
  - Foram criados apenas as 5 rotas especificadas.
  - Arquivo SQL Lite incluído na pasta App_Data, mas há uma rota desativada na controller, para criação do bd e de sua estrutura (caso necessário).
  - Como não foi especificado, não utilizei ORM para acesso à dados, fazendo a conexão e manipulação através de ADO.NET e do Package Nuget System.Data.SQLLite.
  - Pela simplicidade do projeto, deixei de utilizar projetos separados para criação de services, interfaces, repositórios e injeção de dependência, pois acrescentaria complexidade desnecessária.  
 
# Endpoints:

- Rota para retornar 10 pokemons aleatórios

        GET api/Pokemons	

- Rota para retornar 1 pokemon específico, passando o ID como parâmetro de rota


        GET api/Pokemons/{id}	

- Rota para retornar os pokemons capturados


        GET api/Pokemons/getAllCaptureds	

- Rota para informar o pokemons capturados


        POST api/Pokemons/PostCaptured	

        POST - application/json
        {
            "Name": "string Name",
            "Height": 5,
            "Weight": 3,
            "Evolution": "evolution",
            "SpriteBase64": "string sprite",
            "Evolution": "string evolution",
            "Color": "string color",
        }

- Rota para cadastrar um pokemon mestre


        POST api/Pokemons/PostMaster	

        POST - application/json
        {
            "PokemonMasterId": 1,
            "Name": "string 1",
            "Age": 3,
            "Cpf": 4
        }
