namespace WhateverRPGEngine.Utils
{
    using System.IO;
    using System.Xml;
    using WhateverRPGEngine.Models;
    using WhateverRPGEngine.ViewModels;

    public static class SaveLoadUtility
    {
        private const string PLAYER_DATA_FILE_NAME = "PlayerData.xml";

        public static bool Save(GameSession gameSession)
        {
            if(gameSession != null)
            {
                File.WriteAllText(PLAYER_DATA_FILE_NAME, ConvertPlayerDataToXmlString(gameSession));
                return true;
            }
            
            return false;
        }

        private static string ConvertPlayerDataToXmlString(GameSession gameSession)
        {
            XmlDocument playerData = new XmlDocument();

            XmlNode player = playerData.CreateElement("Player");
            playerData.AppendChild(player);

            XmlNode stats = playerData.CreateElement("Stats");
            player.AppendChild(stats);

            XmlNode currentHitPoints = playerData.CreateElement("CurrentHitPoints");
            currentHitPoints.AppendChild(playerData.CreateTextNode(gameSession.CurrentPlayer.CurrentHitPoints.ToString()));
            stats.AppendChild(currentHitPoints);

            XmlNode maximumHitPoints = playerData.CreateElement("MaximumHitPoints");
            maximumHitPoints.AppendChild(playerData.CreateTextNode(gameSession.CurrentPlayer.MaximumHitPoints.ToString()));
            stats.AppendChild(maximumHitPoints);

            XmlNode gold = playerData.CreateElement("Gold");
            gold.AppendChild(playerData.CreateTextNode(gameSession.CurrentPlayer.Gold.ToString()));
            stats.AppendChild(gold);

            XmlNode experiencePoints = playerData.CreateElement("ExperiencePoints");
            experiencePoints.AppendChild(playerData.CreateTextNode(gameSession.CurrentPlayer.ExperiencePoints.ToString()));
            stats.AppendChild(experiencePoints);

            XmlNode currentLocation = playerData.CreateElement("CurrentLocation");
            currentLocation.AppendChild(playerData.CreateTextNode(gameSession.CurrentLocation.Name));
            stats.AppendChild(currentLocation);

            XmlNode inventoryItems = playerData.CreateElement("InventoryItems");
            player.AppendChild(inventoryItems);

            XmlNode groupedInventoryItems = playerData.CreateElement("GroupedInventoryItems");
            player.AppendChild(inventoryItems);

            // "InventoryItem"
            foreach (GameItem item in gameSession.CurrentPlayer.Inventory)
            {
                XmlNode inventoryItem = playerData.CreateElement("InventoryItem");

                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = item.ItemTypeID.ToString();
                inventoryItem.Attributes.Append(idAttribute);

                inventoryItems.AppendChild(inventoryItem);
            }

            // "GroupedUpInventoryItems"
            foreach (GroupedInventoryItem item in gameSession.CurrentPlayer.GroupedInventory)
            {
                XmlNode groupedInventoryItem = playerData.CreateElement("GroupedInventoryItem");

                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = item.Item.ItemTypeID.ToString();
                groupedInventoryItem.Attributes.Append(idAttribute);

                XmlAttribute quantityAttribute = playerData.CreateAttribute("Quantity");
                quantityAttribute.Value = item.Quantity.ToString();
                groupedInventoryItem.Attributes.Append(quantityAttribute);

                inventoryItems.AppendChild(groupedInventoryItem);
            }

            // Create the "PlayerQuests" child node to hold each PlayerQuest node
            XmlNode playerQuests = playerData.CreateElement("PlayerQuests");
            player.AppendChild(playerQuests);

            // Create a "PlayerQuest" node for each quest the player has acquired
            foreach (QuestStatus quest in gameSession.CurrentPlayer.Quests)
            {
                XmlNode playerQuest = playerData.CreateElement("PlayerQuest");

                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = quest.PlayerQuest.ID.ToString();
                playerQuest.Attributes.Append(idAttribute);

                XmlAttribute isCompletedAttribute = playerData.CreateAttribute("IsCompleted");
                isCompletedAttribute.Value = quest.IsCompleted.ToString();
                playerQuest.Attributes.Append(isCompletedAttribute);

                playerQuests.AppendChild(playerQuest);
            }

            return playerData.InnerXml; // The XML document, as a string, so we can save the data to disk
        }
    }
}
