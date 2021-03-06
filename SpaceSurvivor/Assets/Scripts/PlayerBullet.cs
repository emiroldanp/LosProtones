﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

	public float speed = 10.0f;
	public Rigidbody2D rb;

	public GameObject impactEffect;

	public int damageToGive = 50;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
    }


    private void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "Enemy") {
        
        other.GetComponent<AlienController>().DamageEnemy(damageToGive);
		Destroy(gameObject);
        Instantiate(impactEffect, transform.position, transform.rotation);

     	}

        if (other.gameObject.tag == "LightEnemy")
        {

            other.GetComponent<AlienController>().DamageEnemy(damageToGive);
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);

        }
        if (other.gameObject.tag == "ShootingEnemy")
        {

            other.GetComponent<ShootingAlienController>().DamageEnemy(damageToGive);
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);

        }

        if (other.gameObject.tag == "Gollem")
        {

            other.GetComponent<FollowThePath>().DamageEnemy(damageToGive);
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);

        }

        if (other.gameObject.tag == "IceGollem")
        {

            other.GetComponent<IceGolemScript>().DamageEnemy(damageToGive);
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);

        }

        if (other.gameObject.tag == "MineralGollem")
        {

            other.GetComponent<MineralGolemScript>().DamageEnemy(damageToGive);
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);

        }

        if (other.gameObject.tag == "FinalBoss")
        {

            other.GetComponent<FinalBossMovement>().DamageEnemy(damageToGive);
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);

        }



    }


	private void OnBecameInvisible(){

		Destroy(gameObject);
	}
	


}
