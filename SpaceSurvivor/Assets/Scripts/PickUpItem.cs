using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class PickUpItem : MonoBehaviour
{
    private Inventory inventory;

    
    public GameObject item;

    private AstronautMovement am;

    private int counter;

    GameMaster gm;

    
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void Update() {
        if(inventory.isFull[inventory.slots.Length -1]){
            SceneManager.LoadScene("ShipBuilder");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (gameObject.tag.Equals("Health"))
            {

                am = collision.gameObject.GetComponent<AstronautMovement>();
                am.increaseHealth(100);

                Destroy(gameObject);
            }else if (gameObject.tag.Equals("Oxygen"))
            {
                am = collision.gameObject.GetComponent<AstronautMovement>();
                am.increaseOxygen(50);

                Destroy(gameObject);
            }else if (gameObject.tag.Equals("DamageObject"))
            {
                
                am = collision.gameObject.GetComponent<AstronautMovement>();
                am.decreaseHealth(10);
      
                

            }
            else if (gameObject.tag.Equals("DecreaseOxygen"))
            {

                am = collision.gameObject.GetComponent<AstronautMovement>();
                am.decreaseOxygen(5);



            }
            else
            {
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (!inventory.isFull[i] && counter == 0)
                    {
                        inventory.isFull[i] = true;

                        inventory.slots[i].tag = item.tag;

                        Instantiate(item, inventory.slots[i].transform, false);
                        counter++;
                        Debug.Log("Picked up item");
                        Destroy(gameObject);
                        break;
                    }
                }
            }
            
        }
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.tag.Equals("DamageObject"))
        {
            
            if (collision.gameObject.tag.Equals("Player"))
            {   
                am = collision.gameObject.GetComponent<AstronautMovement>();
                am.decreaseHealth(10 * Time.deltaTime);
            }
        }

        if (gameObject.tag.Equals("DecreaseOxygen"))
        {

            if (collision.gameObject.tag.Equals("Player"))
            {
                am = collision.gameObject.GetComponent<AstronautMovement>();
                am.decreaseOxygen(10 * Time.deltaTime);
            }




        }

        
    }
}
