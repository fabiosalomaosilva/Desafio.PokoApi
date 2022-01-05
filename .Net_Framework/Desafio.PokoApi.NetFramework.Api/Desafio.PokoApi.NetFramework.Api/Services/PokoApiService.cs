using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Desafio.PokoApi.NetFramework.Api.Models;
using Desafio.PokoApi.NetFramework.Api.Models.Local;
using Desafio.PokoApi.NetFramework.Api.Models.PokoApi;
using Desafio.PokoApi.NetFramework.Api.Repositories;
using Newtonsoft.Json;

namespace Desafio.PokoApi.NetFramework.Api.Services
{
    public class PokoApiService
    {

        private readonly HttpClient _client;
        public PokoApiService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://pokeapi.co/api/v2/")
            };
        }

        public async Task<List<PokemonLocal>> GetAleatoryListPokemons()
        {
            var number = GetRandomNumber();
            var response = await _client.GetStringAsync($"pokemon/?limit=10&offset={number}");
            var data = JsonConvert.DeserializeObject<Paginacao>(response);

            var listOfPokemons = new List<PokemonLocal>();
            foreach (var pokemon in data.Results)
            {
                var pokemonLocal = await GetPokemon(pokemon);
                listOfPokemons.Add(pokemonLocal);
            }
            return listOfPokemons;
        }

        public async Task<PokemonLocal> GetPokemonById(int id)
        {
            return await GetPokemon(new PokemonList { Url = $"https://pokeapi.co/api/v2/pokemon/{id}" });
        }

        public async Task<List<PokemonLocal>> GetAllCaptured()
        {
            return await PokemonRepository.GetAllPokemonsCapturedsAsync();
        }


        public async Task<PokemonMaster> InsertPokemonMasterAsync(PokemonMaster master)
        {
            await PokemonRepository.AddPokemonMasterAsync(master);
            return master;
        }

        public async Task<PokemonLocal> InsertPokemonCapturedAsync(PokemonLocal pokemon)
        {
            await PokemonRepository.AddPokemonCapturedAsync(pokemon);
            return pokemon;
        }

        public void CreateBd()
        {
            PokemonRepository.CreateBd();
            PokemonRepository.CriarTabelaPokemonCaptured();
            PokemonRepository.CriarTabelaPokemonMaster();
        }


        private async Task<PokemonLocal> GetPokemon(PokemonList pokemon)
        {
            var pokoJson = await _client.GetStringAsync(pokemon.Url.Replace("https://pokeapi.co/api/v2/", ""));
            var poko = JsonConvert.DeserializeObject<Pokemon>(pokoJson);
            var specieJson = await _client.GetStringAsync(poko.species.url.Replace("https://pokeapi.co/api/v2/", ""));
            var pokoSpecie = JsonConvert.DeserializeObject<Specie>(specieJson);

            var pokemonLocal = new PokemonLocal
            {
                Id = poko.id,
                Name = poko.name,
                Height = poko.height,
                Weight = poko.weight,
                Color = pokoSpecie.color.name,
                Evolution = pokoSpecie.evolution_chain.url,
                SpriteBase64 = await GetImageAsBase64Url(poko.sprites.front_default)
            };
            return pokemonLocal;
        }

        private async Task<string> GetImageAsBase64Url(string url)
        {
            using (var client = new HttpClient())
            {
                var bytes = await client.GetByteArrayAsync(url);
                return "image/jpeg;base64," + Convert.ToBase64String(bytes);
            }
        }

        private int GetRandomNumber()
        {
            var r = new Random();
            return r.Next(0, 1108);
        }
    }
}