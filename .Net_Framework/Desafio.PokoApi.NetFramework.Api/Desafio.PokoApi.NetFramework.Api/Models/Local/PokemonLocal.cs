namespace Desafio.PokoApi.NetFramework.Api.Models.Local
{
    public class PokemonLocal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Evolution { get; set; }
        public string SpriteBase64 { get; set; }
        public string Color { get; set; }
    }
}