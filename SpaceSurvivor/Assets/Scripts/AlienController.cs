using System.Collections;
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


	//public bool shouldShoot;
	//public GameObject bullet;

	//public Transform firePoint;
	//public float fireRate;
	//private float fireCounter;

    bool lookingRight = true;





    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AstronautMovement.instance != null)
        {


            if (Vector3.Distance(transform.position, AstronautMovement.instance.transform.position) < rangeToChasePlayer)
            {

                moveDirection = AstronautMovement.instance.transform.position - transform.position;
            }
            else
            {

                moveDirection = Vector3.zero;


            }

            moveDirection.Normalize();

            rb.velocity = moveDirection * moveSpeed;

        }


        if((!lookingRight && rb.velocity.x > 0) || (lookingRight && rb.velocity.x < 0)){
            Flip();
        }

    
        

/*
        if(shouldShoot){

        	fireCounter -= Time.deltaTime;

        	if(fireCounter <= 0){

        		Instantiate(bullet, firePoint.position, firePoint.rotation);

        		fireCounter = fireRate;
        		

        	}

        }*/



    }

    public void DamageEnemy(int damage){

    	health -= damage;

    	if(health <= 0){

    		Destroy(gameObject);

    	}

    }

    void Flip(){

        lookingRight = !lookingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }




}
