namespace Desafio.PokoApi.Domain
{
    public class PokemonMaster
    {
        public int PokemonMasterId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Cpf { get; set; }
    }

    public class Captured
    {
        public int CapturedId { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public List<Evolution> Evolutions { get; set; }
    }
}