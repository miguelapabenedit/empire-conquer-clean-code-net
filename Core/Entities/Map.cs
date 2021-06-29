using System.Collections.Generic;

namespace Core.Entities
{
    public class Map:EntityBase
    {
        public string Name { get; set; }
        public IEnumerable<Region> Regions { get; set; }
    }
}