using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[ System.Serializable ]
public class Data
{
    public int health;
    public int oxygen;
    public int iceGolemHealth;
    public int lavaGolemHealth;
    public int mineralGolemHealth;
    public int finalBossHealth;
    public float[] positionPlayer;
    public float[] positionIceGolem;
    public float[] positionLavaGolem;
    public float[] positionMineralGolem;
    public float[] positionFinalBoss;
    public bool iceGolemAlive = true;
    public bool lavaGolemAlive = true;
    public bool mineralGolemAlive = true;
    public bool finalBossAlive = true;

    public int[] tags;

    public Data(AstronautMovement player, IceGolemScript iceGolem, FollowThePath lavaGolem, MineralGolemScript mineralGolem, FinalBossMovement finalBoss, List<GameObject> items)
    {
        health = player.health;
        oxygen = player.oxygen;


        if(items.Count > 0)
        {
            Debug.Log("Entered");
            tags = new int[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                if(items[i].tag != "Untagged")
                {
                    string tag = items[i].tag;
                    Debug.Log(tag);
                    tags[i] = int.Parse(tag);
                }
                
            }
        }

        if(iceGolem != null)
        {
            positionIceGolem = new float[3];



            positionIceGolem[0] = iceGolem.transform.position.x;
            positionIceGolem[1] = iceGolem.transform.position.y;
            positionIceGolem[2] = iceGolem.transform.position.z;

            iceGolemHealth = iceGolem.health;

        }
        else
        {
            iceGolemAlive = false;
        }

        if(lavaGolem != null)
        {
            lavaGolemHealth = lavaGolem.health;

            positionLavaGolem = new float[3];

            positionLavaGolem[0] = lavaGolem.transform.position.x;
            positionLavaGolem[1] = lavaGolem.transform.position.y;
            positionLavaGolem[2] = lavaGolem.transform.position.z;

        }
        else
        {
            lavaGolemAlive = false;
        }

        if(mineralGolem != null)
        {
            mineralGolemHealth = mineralGolem.health;

            positionMineralGolem = new float[3];

            positionMineralGolem[0] = mineralGolem.transform.position.x;
            positionMineralGolem[1] = mineralGolem.transform.position.y;
            positionMineralGolem[2] = mineralGolem.transform.position.z;
        }
        else
        {
            mineralGolemAlive = false;
        }

        if(finalBoss != null)
        {
            finalBossHealth = finalBoss.health;

            positionFinalBoss = new float[3];

            positionFinalBoss[0] = finalBoss.transform.position.x;
            positionFinalBoss[1] = finalBoss.transform.position.y;
            positionFinalBoss[2] = finalBoss.transform.position.z;
        }
        else
        {
            finalBossAlive = false;
        }

       
        
        
        


        positionPlayer = new float[3];



        positionPlayer[0] = player.transform.position.x;
        positionPlayer[1] = player.transform.position.y;
        positionPlayer[2] = player.transform.position.z;
    }
    
}
