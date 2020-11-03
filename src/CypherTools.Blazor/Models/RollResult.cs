using CypherTools.Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CypherTools.Blazor.Models
{
    public class RollResult
    {
        public int Result { get; set; }
        public int OriginalTargetNumber { get; set; }
        public int ModifiedTargetNumber { get; set; }
        public string Reason { get; set; }
        public string CharacterName { get; set; }
        public bool Success { get; set; }
        public string Notes { get; set; }
        public string Type { get; set; }
        public int Trained { get; set; }
        public int Modifiers { get; set; }
        public string Stat { get; set; }
        public string SpecialText { get; set; }

        public static RollResult PerformSkillRoll(string characterName, int roll, int target, int modifiers, CharacterSkill skill)
        {
            var result = new RollResult();

            result.Type = "skill";
            result.Reason = skill.Name;
            result.OriginalTargetNumber = target;
            result.ModifiedTargetNumber = target + modifiers - skill.SkillLevelBonus;
            result.Result = roll;
            result.CharacterName = characterName;
            result.Trained = skill.SkillLevelBonus;
            result.Modifiers = modifiers;
            result.Stat = skill.Stat;

            result.SpecialText = (roll)switch
            {
                17 =>"+1 to Damage",
                18 =>"+2 to Damage",
                19 =>"Minor Effect or +3 to Damage",
                20 =>"Major Effect or +4 to Damage.  No pool points spent.",
                _ =>""
            };

            result.Success = result.ModifiedTargetNumber * 3 <= roll;

            return result;
        }

    }
}
