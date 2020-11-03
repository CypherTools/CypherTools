using System;
using System.Collections.Generic;
using System.Text;

namespace CypherTools.Blazor.Models
{
    public class CharacterCypher
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public bool IsIdentified { get; set; }

        public int Level { get; set; }
        public int LevelDie { get; set; }
        public int LevelBonus { get; set; }
        public string Form { get; set; }
        public string Effect { get; set; }
        public string EffectOption { get; set; }
        public string Source { get; set; }
        public Character Character { get; set; }
    }
}
