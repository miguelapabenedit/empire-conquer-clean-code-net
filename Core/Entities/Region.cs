using System.Collections.Generic;

namespace Core.Entities
{
    public class Region:EntityBase
    {
        public string Name { get; set; }
        public IEnumerable<Ground> Grounds { get; set; }
        public IEnumerable<RegionGuild> RegionGuilds { get; set; }
    }
}