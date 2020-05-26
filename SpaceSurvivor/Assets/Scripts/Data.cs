using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Data(AstronautMovement player, IceGolemScript iceGolem, FollowThePath lavaGolem, MineralGolemScript mineralGolem, FinalBossMovement finalBoss)
    {
        health = player.health;
        oxygen = player.oxygen;


        if(iceGolem != null)
        {
            positionIceGolem = new float[3];



            positionIceGolem[0] = iceGolem.transform.position.x;
            positionIceGolem[1] = iceGolem.transform.position.y;
            positionIceGolem[2] = iceGolem.transform.position.z;

            iceGolemHealth = iceGolem.health;
        }

        if(lavaGolem != null)
        {
            lavaGolemHealth = lavaGolem.health;

            positionLavaGolem = new float[3];

            positionLavaGolem[0] = lavaGolem.transform.position.x;
            positionLavaGolem[1] = lavaGolem.transform.position.y;
            positionLavaGolem[2] = lavaGolem.transform.position.z;

        }

        if(mineralGolem != null)
        {
            mineralGolemHealth = mineralGolem.health;

            positionMineralGolem = new float[3];

            positionMineralGolem[0] = mineralGolem.transform.position.x;
            positionMineralGolem[1] = mineralGolem.transform.position.y;
            positionMineralGolem[2] = mineralGolem.transform.position.z;
        }

        if(finalBoss != null)
        {
            finalBossHealth = finalBoss.health;

            positionFinalBoss = new float[3];

            positionFinalBoss[0] = finalBoss.transform.position.x;
            positionFinalBoss[1] = finalBoss.transform.position.y;
            positionFinalBoss[2] = finalBoss.transform.position.z;
        }

       
        
        
        


        positionPlayer = new float[3];



        positionPlayer[0] = player.transform.position.x;
        positionPlayer[1] = player.transform.position.y;
        positionPlayer[2] = player.transform.position.z;
    }
    
}
