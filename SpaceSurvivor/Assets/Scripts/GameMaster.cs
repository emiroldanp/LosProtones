using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour {


    public AstronautMovement player;
    public IceGolemScript iceGolem;
    public FollowThePath lavaGolem;
    public MineralGolemScript mineralGolem;
    public FinalBossMovement finalBoss;
    public  List<GameObject> items;
    private Inventory inventory;

    private int[] tags;

    public GameObject[] shipParts;


    public bool finalBossDefeated;
    public bool iceGolemDefeated;
    public bool lavaGolemDefeated;
    public bool mineralGolemDefeated;

    private bool hasSaved;


    private bool assigned;

    List<string> visitedTags = new List<string>();

    private static GameMaster instance;
    public Vector2 lastCheckPointPos;

    
    void Awake() {
        if(instance == null) {
            Debug.Log("Hello");
            instance = this;
            DontDestroyOnLoad(instance);
        } else {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        string path = Application.persistentDataPath + "/player.save";
        if (SceneManager.GetActiveScene().name == "TileScene" && File.Exists(path))
        {
            assignScripts();
        }

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if(!inventory.slots[i].CompareTag("Untagged") && visitedTags.IndexOf(inventory.slots[i].tag) <0)
            {
                Debug.Log("inventory " + inventory.slots[i]);
               
                items.Add(inventory.slots[i]);
                visitedTags.Add(inventory.slots[i].tag);
            }

            
        }
        
        Debug.Log("inventory length " + items.Count);
        Debug.Log("Player: " + player);
        Save(player, iceGolem, lavaGolem, mineralGolem, finalBoss, items);
        hasSaved = true;
    }
   private void Update()
    {
        if(SceneManager.GetActiveScene().name == "TileScene" && !assigned )
        {
            assignScripts();
            assigned = true;
        }
    }

    private void Save(AstronautMovement player, IceGolemScript iceGolem, FollowThePath lavaGolem, MineralGolemScript mineralGolem, FinalBossMovement finalBoss, List<GameObject> items)
    {
        SaveSystem.Save(player, iceGolem, lavaGolem, mineralGolem, finalBoss, items);
        hasSaved = true;
    }

    public void Load()
    {
        player.gameObject.SetActive(true);
          

        /*string path = Application.persistentDataPath + "/player.save";
        if (SceneManager.GetActiveScene().name == "TileScene" && File.Exists(path) )
        {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<AstronautMovement>();
            iceGolem = GameObject.FindGameObjectWithTag("IceGollem").GetComponent<IceGolemScript>();
            lavaGolem = GameObject.FindGameObjectWithTag("Gollem").GetComponent<FollowThePath>();
            mineralGolem = GameObject.FindGameObjectWithTag("MineralGollem").GetComponent<MineralGolemScript>();
            finalBoss = GameObject.FindGameObjectWithTag("FinalBoss").GetComponent<FinalBossMovement>();
        }
        */
        Data data = SaveSystem.Load();

        lavaGolemDefeated = !data.lavaGolemAlive;
        mineralGolemDefeated = !data.mineralGolemAlive;
        iceGolemDefeated = !data.iceGolemAlive;
        finalBossDefeated = !data.finalBossAlive;

        tags = data.tags;

        LoadInventory();

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

    public void LoadInventory()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        ClearInventory(inventory);
        int pos;
        Debug.Log(tags.Length);
        for (int i = 0; i < tags.Length; i++)
        {
            
          
            
            for (int j = 0; j < inventory.slots.Length; j++) {
                if (!inventory.isFull[j])
                {
                    inventory.isFull[j] = true;


                    pos = tags[i];
                    Debug.Log("pos: "+pos);
                    
                    Instantiate(shipParts[pos-1], inventory.slots[j].transform, false);
                    inventory.slots[j].tag = shipParts[pos - 1].tag;

                    
                    GameObject part = GameObject.FindGameObjectWithTag(shipParts[pos-1].tag + "p");
                    if (part != null)
                    {
                        Destroy(part);
                    }
                    break;
                }
            }
        }
    }

    public void ClearInventory(Inventory inventory)
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            inventory.slots[i].tag = "Untagged";
            inventory.isFull[i] = false;
        }
    }

    

    public void assignScripts()
    {
        
        
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<AstronautMovement>();

        if (GameObject.FindGameObjectWithTag("IceGollem") != null)
        {
            iceGolem = GameObject.FindGameObjectWithTag("IceGollem").GetComponent<IceGolemScript>();
        }



        if (GameObject.FindGameObjectWithTag("Gollem") != null)
        {
            lavaGolem = GameObject.FindGameObjectWithTag("Gollem").GetComponent<FollowThePath>();
        }

        if (GameObject.FindGameObjectWithTag("MineralGollem") != null)
        {
            mineralGolem = GameObject.FindGameObjectWithTag("MineralGollem").GetComponent<MineralGolemScript>();
        }

        if (GameObject.FindGameObjectWithTag("FinalBoss") != null)
        {
            finalBoss = GameObject.FindGameObjectWithTag("FinalBoss").GetComponent<FinalBossMovement>();
        }

    }

    public void LoadNewGame()
    {
        Invoke("assignScripts", 1);
    }

    public void LoadFromMainMenu()
    {
        Invoke("assignScripts", 1);
        Invoke("Load", 0.5f);
    }
}

