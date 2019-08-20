﻿namespace WhateverRPGEngine.Factories
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using WhateverRPGEngine.Models;
    using WhateverRPGEngine.Utils.Extensions;

    public static class TraderFactory
    {
        private const string GAME_DATA_FILENAME = ".\\GameData\\Traders.xml";

        private static readonly List<Trader> _traders = new List<Trader>();

        static TraderFactory()
        {
            if (File.Exists(GAME_DATA_FILENAME))
            {
                XmlDocument data = new XmlDocument();
                data.LoadXml(File.ReadAllText(GAME_DATA_FILENAME));

                LoadTradersFromNodes(data.SelectNodes("/Traders/Trader"));
            }
            else
            {
                throw new FileNotFoundException($"Missing data file: {GAME_DATA_FILENAME}");
            }
        }

        private static void LoadTradersFromNodes(XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                Trader trader =
                    new Trader(node.AttributeAsInt("ID"),
                               node.SelectSingleNode("./Name")?.InnerText ?? "");

                foreach (XmlNode childNode in node.SelectNodes("./InventoryItems/Item"))
                {
                    int quantity = childNode.AttributeAsInt("Quantity");

                    for (int i = 0; i < quantity; i++)
                    {
                        trader.AddItemToInventory(ItemFactory.CreateGameItem(childNode.AttributeAsInt("ID")));
                    }
                }

                _traders.Add(trader);
            }
        }

        public static Trader GetTraderByName(string name)
        {
            return _traders.FirstOrDefault(t => t.Name == name);
        }
    }
}
