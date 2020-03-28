﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    private Inventory inventory;

    public GameObject item;

    private AstronautMovement am;

    
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (gameObject.name.Equals("HealthCanister"))
            {

                am = collision.gameObject.GetComponent<AstronautMovement>();
                am.increaseHealth(100);

                Destroy(gameObject);
            }else if (gameObject.name.Equals("OxygenCanister"))
            {
                am = collision.gameObject.GetComponent<AstronautMovement>();
                am.increaseOxygen(50);

                Destroy(gameObject);
            }else if (gameObject.name.Equals("DamageObject"))
            {
                am = collision.gameObject.GetComponent<AstronautMovement>();
                am.decreaseHealth(50);

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
}