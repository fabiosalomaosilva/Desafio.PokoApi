using System.Collections.Generic;
using Desafio.PokoApi.NetFramework.Api.Models.PokoApi;

namespace Desafio.PokoApi.NetFramework.Api.Models.Local
{
    public class Captured
    {
        public int CapturedId { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public List<Evolution> Evolutions { get; set; }
    }
}