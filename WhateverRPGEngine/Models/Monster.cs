namespace WhateverRPGEngine.Models
{
    using System.Collections.ObjectModel;
    using WhateverRPGEngine.Utils;

    public class Monster : BaseNotificationClass
    {
        private int _hitPoints;
  
        public string Name { get; private set; }

        public string ImageName { get; set; }

        public int MaximumHitPoints { get; private set; }

        public int MinimumDamage { get; set; }

        public int MaximumDamage { get; set; }

        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }

        public int RewardExperiencePoints { get; private set; }

        public int RewardGold { get; private set; }

        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        public Monster(string name, string imageName,
            int maximumHitPoints, int hitPoints,
            int minimumDamage, int maximumDamage,
            int rewardExperiencePoints, int rewardGold)
        {
            Name = name;
            ImageName = string.Format($"/WhateverRPGEngine;component/Resources/MonsterImageFiles/{imageName}");
            MaximumHitPoints = maximumHitPoints;
            HitPoints = hitPoints;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;

            Inventory = new ObservableCollection<ItemQuantity>();
        }
    }
}
