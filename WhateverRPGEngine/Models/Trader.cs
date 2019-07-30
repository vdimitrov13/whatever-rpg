namespace WhateverRPGEngine.Models
{
    using System.Collections.ObjectModel;

    public class Trader : LivingEntity
    {
        public Trader(string name)
        {
            Name = name;
            Inventory = new ObservableCollection<GameItem>();
        }
    }
}
