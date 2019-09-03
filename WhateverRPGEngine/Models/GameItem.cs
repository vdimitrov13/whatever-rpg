
namespace WhateverRPGEngine.Models
{
    using WhateverRPGEngine.Interfaces.Actions;

    public class GameItem
    {
        public enum ItemCategory
        {
            Miscellaneous,
            Weapon,
            Armor,
            Consumable
        }

        public ItemCategory Category { get; }

        public int ItemTypeID { get; }

        public string Name { get; }

        public int Price { get; }

        public bool IsUnique { get; }

        public IAction Action { get; set; }

        public bool IsEquiped { get; set; }

        public GameItem(
            ItemCategory category, 
            int itemTypeID, 
            string name, 
            int price, 
            bool isUnique = false, 
            IAction action = null,
            bool isEquiped = false)
        {
            Category = category;
            ItemTypeID = itemTypeID;
            Name = name;
            Price = price;
            IsUnique = isUnique;
            Action = action;
            IsEquiped = isEquiped;
        }

        public void PerformAction(LivingEntity actor, LivingEntity target)
        {
            Action?.Execute(actor, target);
        }

        public GameItem Clone()
        {
            return new GameItem(Category, ItemTypeID, Name, Price, IsUnique, Action);
        }
    }
}
