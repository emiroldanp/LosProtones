using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGolemScript : MonoBehaviour
{
    
	public Rigidbody2D rb;
	public float moveSpeed;

	public float rangeToChasePlayer;
	private Vector3 moveDirection;

    public GameObject shipPart;

	public Animator anim;

	public int health = 450;

    private float timeBtwShots;

    public float startTimeBtwShots;

    public GameObject projectile;

    public HealthBarController healthBar;

    private float hp;

   
    void Start()
    {
        hp = health / 5000f;
        timeBtwShots = startTimeBtwShots;
        
    }

    void Update()
    {

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

        if (Vector3.Distance(transform.position, AstronautMovement.instance.transform.position) < rangeToChasePlayer){

    		moveDirection = AstronautMovement.instance.transform.position - transform.position;
    	} else {

    		moveDirection = Vector3.zero;


    	}

        

        moveDirection.Normalize();

        rb.velocity = moveDirection * moveSpeed;

    

        if(timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;

        } else {
            timeBtwShots -= Time.deltaTime;
        }

      




    }

    public void DamageEnemy(int damage){

    	health -= damage;

        hp = health / 5000f;

    	if(health <= 0){

            Instantiate(shipPart, transform.position, Quaternion.identity);
            Destroy(gameObject);


    	}

    }




}
