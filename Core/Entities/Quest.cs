namespace Core.Entities
{
    public class Quest:EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int LevelRequired { get; set; }
    }
}
