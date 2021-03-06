﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePath : MonoBehaviour {

    // Array of waypoints to walk from one to the next one
    [SerializeField]
    private Transform[] waypoints;

    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;

    private float timeBtwShots;

    public float startTimeBtwShots;

    public GameObject projectile;

    public GameObject shipPart;

    public int health;

    public float hp;


    public HealthBarController healthBar;

    //private Transform player;



    // Index of current waypoint from which Enemy walks
    // to the next one
    private int waypointIndex = 0;

    //bool facingRight = true;

	// Use this for initialization
	private void Start () {

        hp = health / 5000f;

        
        // Set position of Enemy as position of the first waypoint
        transform.position = waypoints[waypointIndex].transform.position;
  
        timeBtwShots = startTimeBtwShots;
        
	}
	
	// Update is called once per frame
	private void Update () {



        if (hp >= 0)
        {
            healthBar.setSize(hp);
        }
        if (hp <= .5 && health > .2)
        {
            healthBar.setColor(Color.yellow);
        }
        if (hp <= .2)
        {
            healthBar.setColor(Color.red);
        }
        // Move Enemy
        Move();

        if(timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        } else {
            timeBtwShots -= Time.deltaTime;
        }

      


      
	}

    // Method that actually make Enemy walk
    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops
        if(waypointIndex == waypoints.Length){
            waypointIndex = 0;
        }

        if (waypointIndex <= waypoints.Length - 1)
        {

            // Move Enemy from current waypoint to the next one
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
               waypoints[waypointIndex].transform.position,
               moveSpeed * Time.deltaTime);

            // If Enemy reaches position of waypoint he walked towards
            // then waypointIndex is increased by 1
            // and Enemy starts to walk to the next waypoint
            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }

    public void DamageEnemy(int damage)
    {
        health -= damage;

        hp = health / 5000f;

   

        if(health <= 0)
        {
            Instantiate(shipPart, transform.position, Quaternion.identity);
            Destroy(gameObject);
            

            
        }
    }


   
}