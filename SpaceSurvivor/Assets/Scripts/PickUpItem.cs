﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Inventory inventory;

    public GameObject item;

    private AstronautMovement am;

    private bool ongoingDamage;

    
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag.Equals("DamageObject"))
        {
            ongoingDamage = false;
            CancelInvoke();
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
                ongoingDamage = true;
                am = collision.gameObject.GetComponent<AstronautMovement>();
                if(ongoingDamage)
                {
                    InvokeRepeating("damageOverTime", 0f, 2f);

                }
      
                

            }

            
            else
            {
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if (!inventory.isFull[i])
                    {
                        inventory.isFull[i] = true;

                        Instantiate(item, inventory.slots[i].transform, false);
                        Debug.Log("Picked up item");
                        Destroy(gameObject);
                        break;
                    }
                }
            }
            
        }
        
    }

    private void damageOverTime()
    {
        am.decreaseHealth(50);
    }
}
