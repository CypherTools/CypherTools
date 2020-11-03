using System;
using System.Collections.Generic;
using System.Text;

namespace CypherTools.Blazor.Models
{
    public class CharacterRecoveryRoll
    {
        public int RollIndex { get; set; }
        public string RollName { get; set; }
        public bool IsUsed { get; set; }
    }
}
