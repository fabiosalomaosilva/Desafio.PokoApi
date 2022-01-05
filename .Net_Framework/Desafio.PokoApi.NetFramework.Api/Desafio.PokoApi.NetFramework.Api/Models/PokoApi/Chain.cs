namespace Desafio.PokoApi.NetFramework.Api.Models.PokoApi
{
    public class Chain
    {
        public object[] evolution_details { get; set; }
        public Evolves_To[] evolves_to { get; set; }
        public bool is_baby { get; set; }
        public Species species { get; set; }
    }
}