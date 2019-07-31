namespace WhateverRPGEngine.Models
{
    using System.Collections.ObjectModel;
    using WhateverRPGEngine.Utils;

    public class Monster : LivingEntity
    {
        public string ImageName { get; }

        public int MinimumDamage { get; }

        public int MaximumDamage { get; }

        public int RewardExperiencePoints { get; }

        public Monster(string name, string imageName,
                int maximumHitPoints, int currentHitPoints,
                int minimumDamage, int maximumDamage,
                int rewardExperiencePoints, int gold) :
            base(name, maximumHitPoints, currentHitPoints, gold)
        {
            ImageName = $"/WhateverRPGEngine;component/Resources/MonsterImageFiles/{imageName}";
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            RewardExperiencePoints = rewardExperiencePoints;
        }
    }
}
