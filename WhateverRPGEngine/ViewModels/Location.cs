using System.Collections.Generic;
using WhateverRPGEngine.Models;

namespace WhateverRPGEngine.ViewModels
{
    public class Location
    {
        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        public IList<Quest> LocationQuests { get; set; } = new List<Quest>();
    }
}
