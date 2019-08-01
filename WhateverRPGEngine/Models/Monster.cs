namespace WhateverRPGEngine.Models
{
    using System.Collections.ObjectModel;
    using WhateverRPGEngine.Utils;

    public class Monster : LivingEntity
    {
        public string ImageName { get; }

        public int RewardExperiencePoints { get; }

        public Monster(string name, string imageName,
                int maximumHitPoints, int currentHitPoints,
                int rewardExperiencePoints, int gold) :
            base(name, maximumHitPoints, currentHitPoints, gold)
        {
            ImageName = $"/WhateverRPGEngine;component/Resources/MonsterImageFiles/{imageName}";
            RewardExperiencePoints = rewardExperiencePoints;
        }
    }
}
