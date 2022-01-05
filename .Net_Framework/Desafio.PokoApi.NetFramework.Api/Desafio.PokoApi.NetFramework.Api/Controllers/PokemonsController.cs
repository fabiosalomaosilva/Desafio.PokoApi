using Desafio.PokoApi.NetFramework.Api.Models.Local;
using Desafio.PokoApi.NetFramework.Api.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Http;

namespace Desafio.PokoApi.NetFramework.Api.Controllers
{
    public class PokemonsController : ApiController
    {
        private readonly PokoApiService _pokoApiService;

        public PokemonsController()
        {
            _pokoApiService = new PokoApiService();
        }

        // GET: api/Pokemons
        public async Task<List<PokemonLocal>> Get()
        {
            return await _pokoApiService.GetAleatoryListPokemons();
        }

        // GET: api/Pokemons/5
        public async Task<PokemonLocal> Get(int id)
        {
            return await _pokoApiService.GetPokemonById(id);
        }

        [HttpGet]
        [Route("api/Pokemons/getAllCaptureds")]
        public async Task<List<PokemonLocal>> GetAllCaptureds()
        {
            return await _pokoApiService.GetAllCaptured();
        }

        //[HttpPost]
        //[Route("api/Pokemons/CreateDb")]
        //public IHttpActionResult CreateDb()
        //{
        //    _pokoApiService.CreateBd();
        //    return Ok();
        //}

        [HttpPost]
        [Route("api/Pokemons/PostMaster")]
        public async Task<PokemonMaster> PostMaster(PokemonMaster master)
        {
            return await _pokoApiService.InsertPokemonMasterAsync(master);
        }

        [HttpPost]
        [Route("api/Pokemons/PostCaptured")]
        public async Task<PokemonLocal> PostCaptured(PokemonLocal pokemon)
        {
            return await _pokoApiService.InsertPokemonCapturedAsync(pokemon);
        }

    }
}