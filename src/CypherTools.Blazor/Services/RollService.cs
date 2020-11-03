using CypherTools.Blazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CypherTools.Blazor.Services
{
    public class RollService
    {
        private Random random = new Random();

        public RollService()
        {

        }

        public async Task<RollResult> GetSkillResult(string characterName, CharacterSkill skill, int targetLevel)
        {
            var result = random.Next(1, 21);

            var rollresult = RollResult.PerformSkillRoll(characterName, result, 0, 0, skill);

            return rollresult;
        }
    }
}
