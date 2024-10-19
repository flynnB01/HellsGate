using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    // Save the player's data
    public static void SavePlayer(character player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.sav";

        try
        {
            using (FileStream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                playerData data = new playerData(player);
                formatter.Serialize(stream, data);
            }
        }
        catch (IOException ex)
        {
            Debug.LogError("Failed to save game: " + ex.Message);
        }
    }

    // Load the player's data
    public static playerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.sav";

        if (File.Exists(path))
        {
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    playerData data = formatter.Deserialize(stream) as playerData;
                    return data;
                }
            }
            catch (IOException ex)
            {
                Debug.LogError("Failed to load game: " + ex.Message);
                return null;
            }
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
