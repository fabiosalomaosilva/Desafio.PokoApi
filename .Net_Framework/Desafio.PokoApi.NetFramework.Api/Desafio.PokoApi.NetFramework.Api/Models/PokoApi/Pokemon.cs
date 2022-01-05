namespace Desafio.PokoApi.NetFramework.Api.Models.PokoApi
{
    public class Pokemon
    {
        public int id { get; set; }
        public string name { get; set; }
        public int height { get; set; }
        public int order { get; set; }
        public int weight { get; set; }
        public Species species { get; set; }
        public Sprites sprites { get; set; }
    }

    public class Specie
    {
        public int id { get; set; }
        public string name { get; set; }
        public Color color { get; set; }
        public Evolution_Chain evolution_chain { get; set; }
        public object habitat { get; set; }
    }

    public class Color
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Evolution_Chain
    {
        public string url { get; set; }
    }
}