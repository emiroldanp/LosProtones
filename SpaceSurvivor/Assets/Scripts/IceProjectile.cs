﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceProjectile : MonoBehaviour
{
    public float speed;

    public float speed2;
    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

            target = new Vector2(player.position.x, player.position.y);
        }


        Destroy(gameObject, 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            //DestroyProjectile();
        }
    }

    /*
        void OnTriggerEnter2D(Collider2D other){
            if(other.CompareTag("Player")){
                DestroyProjectile();

            }


        }

        void DestroyProjectile(){
            Destroy(gameObject);
        }
        */
}