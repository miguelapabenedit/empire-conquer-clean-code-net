using System.Collections.Generic;

namespace Core.Entities
{
    public class Guild:EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<RegionGuild> RegionGuilds { get; set; }
    }
}
