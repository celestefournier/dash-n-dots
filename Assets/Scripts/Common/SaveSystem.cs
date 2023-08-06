using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Common
{
    public static class SaveSystem
    {
        public static void Save(PlayerData playerData)
        {
            var binaryFormatter = new BinaryFormatter();

            var path = Application.persistentDataPath + "/player.sav";
            var fileStream = new FileStream(path, FileMode.Create);

            binaryFormatter.Serialize(fileStream, playerData);
            fileStream.Close();
        }

        public static PlayerData Load()
        {
            var path = Application.persistentDataPath + "/player.sav";
            PlayerData playerData;

            if (File.Exists(path))
            {
                var binaryFormatter = new BinaryFormatter();
                var fileStream = new FileStream(path, FileMode.Open);

                playerData = binaryFormatter.Deserialize(fileStream) as PlayerData;

                fileStream.Close();

                return playerData;
            }

            Debug.Log("Save file not found in " + path + ", returning new PlayerData instance.");
            playerData = new PlayerData(new List<int> {0, 0, 0});

            return playerData;
        }
    }

    [Serializable]
    public class PlayerData
    {
        public List<int> BestScores;

        public PlayerData(List<int> bestScores)
        {
            BestScores = bestScores;
        }
    }
}