using System.Collections.Generic;

namespace Desafio.PokoApi.NetFramework.Api.Models.PokoApi
{
    public class Paginacao
    {
        public int count { get; set; }
        public List<PokemonList> Results { get; set; }

    }
}