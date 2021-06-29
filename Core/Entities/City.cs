using System.Text.Json.Serialization;

namespace Core.Entities
{
    public class City:EntityBase
    {
        public string Name { get; set; }
        public int Population { get; set; }
        [JsonIgnore]
        public Empire Empire { get; set; }
        public long EmpireId { get; set; }
        public Region Region { get; set; }
        public long RegionId { get; set; }
    }
}