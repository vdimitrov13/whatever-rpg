namespace WhateverRPGEngine.Factories
{
    using WhateverRPGEngine.Models;

    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(-2, -1, "Farmer's Field",
                "There are rows of corn growing here, with giant rats hiding between them.",
                "/WhateverRPGEngine;component/Resources/FarmFields.png");

            newWorld.AddLocation(-1, -1, "Farmer's House",
                "This is the house of your neighbor, Farmer Ted.",
                "/WhateverRPGEngine;component/Resources/Farmhouse.png");

            newWorld.AddLocation(0, -1, "Home",
                "This is your home",
                "/WhateverRPGEngine;component/Resources/Home.png");

            newWorld.AddLocation(-1, 0, "Trading Shop",
                "The shop of Susan, the trader.",
                "/WhateverRPGEngine;component/Resources/Trader.png");

            newWorld.AddLocation(0, 0, "Town square",
                "You see a fountain here.",
                "/WhateverRPGEngine;component/Resources/TownSquare.png");

            newWorld.AddLocation(1, 0, "Town Gate",
                "There is a gate here, protecting the town from giant spiders.",
                "/WhateverRPGEngine;component/Resources/TownGate.png");

            newWorld.AddLocation(2, 0, "Spider Forest",
                "The trees in this forest are covered with spider webs.",
                "/WhateverRPGEngine;component/Resources/SpiderForest.png");

            newWorld.AddLocation(0, 1, "Herbalist's hut",
                "You see a small hut, with plants drying from the roof.",
                "/WhateverRPGEngine;component/Resources/HerbalistsHut.png");

            newWorld.AddLocation(0, 2, "Herbalist's garden",
                "There are many plants here, with snakes hiding behind them.",
                "/WhateverRPGEngine;component/Resources/HerbalistsGarden.png");

            return newWorld;
        }
    }
}
