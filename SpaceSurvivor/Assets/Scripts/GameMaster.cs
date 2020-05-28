﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {


    public AstronautMovement player;
    public IceGolemScript iceGolem;
    public FollowThePath lavaGolem;
    public MineralGolemScript mineralGolem;
    public FinalBossMovement finalBoss;

    public bool finalBossDefeated;
    public bool iceGolemDefeated;
    public bool lavaGolemDefeated;
    public bool mineralGolemDefeated;

    private bool hasSaved;

    private static GameMaster instance;
    public Vector2 lastCheckPointPos;

    public void Start()
    {
        
        if (hasSaved)
        {
            Load();
        }
        
    }
    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        Debug.Log("Player: " + player);
        Save(player, iceGolem, lavaGolem, mineralGolem, finalBoss);
    }

    private void Save(AstronautMovement player, IceGolemScript iceGolem, FollowThePath lavaGolem, MineralGolemScript mineralGolem, FinalBossMovement finalBoss)
    {
        SaveSystem.Save(player, iceGolem, lavaGolem, mineralGolem, finalBoss);
        hasSaved = true;
    }

    public void Load()
    {
        Data data = SaveSystem.Load();

        lavaGolemDefeated = !data.lavaGolemAlive;
        mineralGolemDefeated = !data.mineralGolemAlive;
        iceGolemDefeated = !data.iceGolemAlive;
        finalBossDefeated = !data.finalBossAlive;


        player.health = data.health;
        player.oxygen = data.oxygen;

        Vector3 position;
        position.x = data.positionPlayer[0];
        position.y = data.positionPlayer[1];
        position.z = data.positionPlayer[2];

        player.transform.position = position;

        if (data.positionFinalBoss != null && !finalBossDefeated)
        {
            finalBoss.health = data.finalBossHealth;

            Vector3 positionFinalBoss;

            positionFinalBoss.x = data.positionFinalBoss[0];
            positionFinalBoss.y = data.positionFinalBoss[1];
            positionFinalBoss.z = data.positionFinalBoss[2];

            finalBoss.transform.position = positionFinalBoss;
        }
        else
        {
            if(finalBoss != null)
            {
                finalBossDefeated = true;
                Destroy(finalBoss.gameObject);
            }
            
            
        }

        if (data.positionIceGolem!= null && !finalBossDefeated)
        {
            iceGolem.health = data.iceGolemHealth;

            Vector3 positionIceGolem;

            positionIceGolem.x = data.positionIceGolem[0];
            positionIceGolem.y = data.positionIceGolem[1];
            positionIceGolem.z = data.positionIceGolem[2];

            iceGolem.transform.position = positionIceGolem;
        }
        else
        {
            if(iceGolem != null)
            {
                iceGolemDefeated = true;
                Destroy(iceGolem.gameObject);
            }
            
        }

        if (data.positionLavaGolem != null && !lavaGolemDefeated)
        {
            lavaGolem.health = data.lavaGolemHealth;

            Vector3 positionLavaGolem;

            positionLavaGolem.x = data.positionLavaGolem[0];
            positionLavaGolem.y = data.positionLavaGolem[1];
            positionLavaGolem.z = data.positionLavaGolem[2];

            lavaGolem.transform.position = positionLavaGolem;
        }
        else
        {
            if(lavaGolem != null)
            {
                lavaGolemDefeated = true;
                Destroy(lavaGolem.gameObject);
            }
            
        }

        if (data.positionMineralGolem != null && !mineralGolemDefeated)
        {
            mineralGolem.health = data.mineralGolemHealth;

            Vector3 positionMineralGolem;

            positionMineralGolem.x = data.positionMineralGolem[0];
            positionMineralGolem.y = data.positionMineralGolem[1];
            positionMineralGolem.z = data.positionMineralGolem[2];

            mineralGolem.transform.position = positionMineralGolem;
        }
        else
        {
            if(mineralGolem != null)
            {
                mineralGolemDefeated = true;
                Destroy(mineralGolem.gameObject);
            }
            
        }


    }

    public void resetValues()
    {
        finalBossDefeated = false;
        iceGolemDefeated = false;
        lavaGolemDefeated = false;
        mineralGolemDefeated = false;
}
}

