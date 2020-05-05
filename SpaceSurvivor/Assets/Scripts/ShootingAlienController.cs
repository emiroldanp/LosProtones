using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAlienController : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public float moveSpeed;

    public float rangeToChasePlayer;

    public float stopRange;

    private Vector3 moveDirection;

    public Animator anim;

    public int health = 150;


    //public bool shouldShoot;
    //public GameObject bullet;

    public Transform firePoint;

    public Transform target;

    public GameObject bulletToFire;

    private float lastAttack;

    public float attackDelay;


    //public float fireRate;
    //private float fireCounter;





    //public int 



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, AstronautMovement.instance.transform.position) < rangeToChasePlayer)
        {
            moveDirection = AstronautMovement.instance.transform.position - transform.position;

            if (Vector3.Distance(transform.position, AstronautMovement.instance.transform.position) <= stopRange)
            {
                moveDirection = Vector3.zero;
            }

            


            /*;
            */
            if (Time.time > lastAttack + attackDelay)
            {
                /*RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, rangeToChasePlayer);

                if(hit.transform == target)
                {
                    Shoot()
                }*/

                Shoot();
            }
            

        }
        else
        {

            moveDirection = Vector3.zero;


        }



        moveDirection.Normalize();

        rb.velocity = moveDirection * moveSpeed;


        if(anim != null)
        {
            if (moveDirection != Vector3.zero)
            {

                anim.SetBool("isRunning", true);

            }
            else
            {

                anim.SetBool("isRunning", false);
            }
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

    public void DamageEnemy(int damage)
    {

        health -= damage;

        if (health <= 0)
        {

            Destroy(gameObject);

        }

    }

    void Shoot()
    {
        Instantiate(bulletToFire, firePoint.position, firePoint.rotation);
        lastAttack = Time.time;
    }
}
