namespace CypherTools.Blazor.Models
{
    public class CharacterAttack
    {
        public string Name { get; set; }
        public string Stat { get; set; }
        public string AttackModifier { get; set; }
        public int Damage { get; set; }
        public string SkillLevel { get; set; }
        public int SkillLevelBonus
        {
            get
            {
                return (SkillLevel.ToLower()) switch
                {
                    "untrained" => 0,
                    "trained" => 1,
                    "specialized" => 2,
                    "inability" => -1,
                    _ => 0,
                };
            }
        }


    }
}