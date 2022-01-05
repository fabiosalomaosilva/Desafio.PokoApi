# Desafio.PokoApi

Critérios do Desafio

O desafio trata-se de construir uma API em .NET Framework que consuma a API (https://pokeapi.co/) e possua as seguintes rotas:

1 - get para 10 pokemons aleatórios;
2 - get para 1 pokemon específico;
    Todas elas devem retornar os dados básicos do pokemon, suas evoluções e o base64 de sprite default de cada pokemon;
3 - Cadastro do mestre pokemon (dados basicos como nome, idade e cpf) em SQLite;
4 - Post para informar que um pokemon foi capturado;
5 - Listagem dos pokemons já capturados;

Soluções:

  - Embora eu tenha achado estranho, foi solicitado para cria a API em .Net Framework, e não em .Net Core. Desta forma, criei a API com .Net Framework 4.7.2
  - Foram criados apenas as 5 rotas especificadas
 
# Endpoints:

GET api/Pokemons/getAllCaptureds	

POST api/Pokemons/PostMaster	

                {
                  "PokemonMasterId": 1,
                  "Name": "sample string 2",
                  "Age": 3,
                  "Cpf": 4
                }

POST api/Pokemons/PostCaptured	

GET api/Pokemons	

GET api/Pokemons/{id}	
