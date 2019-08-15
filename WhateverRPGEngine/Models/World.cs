namespace WhateverRPGEngine.Models
{
    using System.Collections.Generic;
    using WhateverRPGEngine.ViewModels;

    public class World
    {
        private IList<Location> _locations = new List<Location>();

        internal void AddLocation(Location location)
        {
            _locations.Add(location);
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
