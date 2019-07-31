namespace WhateverRPGEngine.Models
{
    using System.Collections.Generic;
    using WhateverRPGEngine.ViewModels;

    public class World
    {
        private IList<Location> _locations = new List<Location>();

        internal void AddLocation(int xCoordinate, int yCoordinate, string name, string description, string imageName)
        {
            _locations.Add(new Location(
                xCoordinate, 
                yCoordinate, 
                name, 
                description, 
                $"/WhateverRPGEngine;component/Resources/{imageName}"));
        }

        public Location LocationAt(int xCoordinate, int yCoordinate)
        {
            foreach (Location loc in _locations)
            {
                if (loc.XCoordinate == xCoordinate && loc.YCoordinate == yCoordinate)
                {
                    return loc;
                }
            }

            return null;
        }
    }
}
