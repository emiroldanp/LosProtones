﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienController : MonoBehaviour
{

	public Rigidbody2D rb;
	public float moveSpeed;

	public float rangeToChasePlayer;
	private Vector3 moveDirection;

	public Animator anim;

	public int health = 150;




	//public int 



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    	if(Vector3.Distance(transform.position, AstronautMovement.instance.transform.position) < rangeToChasePlayer){

    		moveDirection = AstronautMovement.instance.transform.position - transform.position;
    	} else {

    		moveDirection = Vector3.zero;


    	}

        

        moveDirection.Normalize();

        rb.velocity = moveDirection * moveSpeed;



        if(moveDirection != Vector3.zero){

            anim.SetBool("isRunning",true);

        } else {

            anim.SetBool("isRunning",false);
        }




    }

    public void DamageEnemy(int damage){

    	health -= damage;

    	if(health <= 0){

    		Destroy(gameObject);

    	}

    }




}
