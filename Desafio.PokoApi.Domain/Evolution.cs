namespace Desafio.PokoApi.Domain
{
    public class Evolution
    {
        public object baby_trigger_item { get; set; }
        public Chain chain { get; set; }
        public int id { get; set; }
    }

    public class Chain
    {
        public object[] evolution_details { get; set; }
        public Evolves_To[] evolves_to { get; set; }
        public bool is_baby { get; set; }
        public Species species { get; set; }
    }

    public class Species
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Evolves_To
    {
        public Evolution_Details[] evolution_details { get; set; }
        public object[] evolves_to { get; set; }
        public bool is_baby { get; set; }
        public Species1 species { get; set; }
    }

    public class Species1
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Evolution_Details
    {
        public object gender { get; set; }
        public object held_item { get; set; }
        public Item item { get; set; }
        public object known_move { get; set; }
        public object known_move_type { get; set; }
        public object location { get; set; }
        public object min_affection { get; set; }
        public object min_beauty { get; set; }
        public object min_happiness { get; set; }
        public object min_level { get; set; }
        public bool needs_overworld_rain { get; set; }
        public object party_species { get; set; }
        public object party_type { get; set; }
        public object relative_physical_stats { get; set; }
        public string time_of_day { get; set; }
        public object trade_species { get; set; }
        public Trigger trigger { get; set; }
        public bool turn_upside_down { get; set; }
    }

    public class Item
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Trigger
    {
        public string name { get; set; }
        public string url { get; set; }
    }

}