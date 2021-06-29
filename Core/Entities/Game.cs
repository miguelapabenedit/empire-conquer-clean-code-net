using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Game:EntityBase
    {
        public Map Map { get; set; }
        public long MapId { get; set; }
        public IEnumerable<Empire> Empires { get; set; }
        public DateTime StartDate { get; set; }
        public int Rounds { get; set; }
        public int ProtectionTime { get; set; }
    }
}
