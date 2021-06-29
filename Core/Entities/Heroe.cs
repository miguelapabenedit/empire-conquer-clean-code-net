using Core.Enums;

namespace Core.Entities
{
    public class Heroe:EntityBase
    {
        public string Name { get; set; }
        public HeroType Type { get; set; }
        public byte[] Avatar { get; set; }
        public int Level { get; set; }
        public double Experience { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Damage { get; set; }
        public int Life { get; set; }
        public int Speed { get; set; }
        public int Moral { get; set; }
        public Empire Empire { get; set; }
        public long EmpireId { get; set; }
    }
}