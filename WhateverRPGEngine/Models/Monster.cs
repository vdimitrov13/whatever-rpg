﻿namespace WhateverRPGEngine.Models
{
    using System.Collections.ObjectModel;
    using WhateverRPGEngine.Utils;

    public class Monster : LivingEntity
    {
        public string ImageName { get; set; }

        public int MinimumDamage { get; set; }

        public int MaximumDamage { get; set; }

        public int RewardExperiencePoints { get; private set; }

        public Monster(string name, string imageName,
            int maximumHitPoints, int hitPoints,
            int minimumDamage, int maximumDamage,
            int rewardExperiencePoints, int rewardGold)
        {
            Name = name;
            ImageName = string.Format($"/WhateverRPGEngine;component/Resources/MonsterImageFiles/{imageName}");
            MaximumHitPoints = maximumHitPoints;
            CurrentHitPoints = hitPoints;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;
            RewardExperiencePoints = rewardExperiencePoints;
            Gold = rewardGold;
        }
    }
}
