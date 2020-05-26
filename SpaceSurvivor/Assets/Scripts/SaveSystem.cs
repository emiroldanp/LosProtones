using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
   public static void Save(AstronautMovement player, IceGolemScript iceGolem, FollowThePath lavaGolem, MineralGolemScript mineralGolem, FinalBossMovement finalBoss)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.save";

        FileStream stream = new FileStream(path, FileMode.Create);

        Data data = new Data(player, iceGolem, lavaGolem, mineralGolem, finalBoss);

        formatter.Serialize(stream, data);
        stream.Close();
          
    }

    public static Data Load()
    {
        string path = Application.persistentDataPath + "/player.save";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(stream) as Data;

            stream.Close();

            return data;

        }
        else {
            Debug.LogError("Save file not found");
            return null;
        }

    }
}
