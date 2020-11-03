using System;
using System.Collections.Generic;
using System.Text;

namespace CypherTools.Blazor.Models
{
    public class CharacterPool
    {
        public string Name { get; set; }
        public int PoolIndex { get; set; }
        public int PoolMax { get; set; }
        public int PoolCurrentVaue { get; set; }
        public int PoolEdge { get; set; }
    }
}
