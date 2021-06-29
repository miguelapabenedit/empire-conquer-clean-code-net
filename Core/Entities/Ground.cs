using Core.Enums;

namespace Core.Entities
{
    public class Ground:EntityBase
    {
        public int Name { get; set; }
        public GroundType Type { get; set; }
        public byte[] Image { get; set; }
    }
}