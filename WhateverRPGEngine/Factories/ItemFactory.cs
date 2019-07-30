namespace WhateverRPGEngine.Factories
{
    using System.Collections.Generic;
    using System.Linq;
    using WhateverRPGEngine.Models;

    internal static class ItemFactory
    {
        private readonly static IList<GameItem> _gameItems;

        static ItemFactory()
        {
            _gameItems = new List<GameItem>
            {
                new Weapon(1001, "Pointy Stick", 1, 1, 2),
                new Weapon(1002, "Rusty Sword", 5, 1, 3),
                new GameItem(9001, "Snake Fang", 1, false),
                new GameItem(9002, "Snake Skin", 2, false),
                new GameItem(9003, "Rat tail", 1, false),
                new GameItem(9004, "Rat fur", 2, false),
                new GameItem(9005, "Spider fang", 1, false),
                new GameItem(9006, "Spider silk", 2, false)
        };
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            GameItem standardItem = _gameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);

            if (standardItem != null)
            {
                if (standardItem is Weapon)
                {
                    return (standardItem as Weapon).Clone();
                }

                return standardItem.Clone();
            }

            return null;
        }
    }
}
