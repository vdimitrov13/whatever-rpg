namespace WhateverRPGEngine.Models
{
    using System.Collections.Generic;
    using WhateverRPGEngine.Factories;
    using WhateverRPGEngine.Utils;

    public class Monster : LivingEntity
    {
        private readonly List<ItemPercentage> _lootTable =
            new List<ItemPercentage>();

        public int ID { get; }

        public string ImageName { get; }

        public int RewardExperiencePoints { get; }

        public Monster(int id, string name, string imageName,
                int maximumHitPoints,
                GameItem currentWeapon,int rewardExperiencePoints, int gold) :
            base(name, maximumHitPoints, maximumHitPoints, gold)
        {
            ID = id;
            ImageName = $"/WhateverRPGEngine;component/Resources/MonsterImageFiles/{imageName}";
            CurrentWeapon = currentWeapon;
            RewardExperiencePoints = rewardExperiencePoints;
        }

        public void AddItemToLootTable(int id, int percentage)
        {
            // Remove the entry from the loot table,
            // if it already contains an entry with this ID
            _lootTable.RemoveAll(ip => ip.ID == id);

            _lootTable.Add(new ItemPercentage(id, percentage));
        }

        public Monster GetNewInstance()
        {
            Monster newMonster =
                new Monster(ID, Name, ImageName, MaximumHitPoints, CurrentWeapon,
                            RewardExperiencePoints, Gold);

            foreach (ItemPercentage itemPercentage in _lootTable)
            {
                newMonster.AddItemToLootTable(itemPercentage.ID, itemPercentage.Percentage);

                if (RandomNumberGenerator.NumberBetween(1, 100) <= itemPercentage.Percentage)
                {
                    newMonster.AddItemToInventory(ItemFactory.CreateGameItem(itemPercentage.ID));
                }
            }

            return newMonster;
        }
    }
}
