namespace Core.Entities
{
    public class RegionGuild
    {
        public long RegionId { get; set; }
        public Region Region { get; set; }
        public long GuildId { get; set; }
        public Guild Guild { get; set; }
    }
}
