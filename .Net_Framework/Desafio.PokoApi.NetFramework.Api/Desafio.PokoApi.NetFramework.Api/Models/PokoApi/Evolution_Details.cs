﻿namespace Desafio.PokoApi.NetFramework.Api.Models.PokoApi
{
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
}