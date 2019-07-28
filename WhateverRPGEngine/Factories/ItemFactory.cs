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
                new GameItem(9001, "Snake Fang", 1),
                new GameItem(9002, "Snake Skin", 2)
            };
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            GameItem standardItem = _gameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);

            if (standardItem != null)
            {
                return standardItem.Clone();
            }

            return null;
        }
    }
}
