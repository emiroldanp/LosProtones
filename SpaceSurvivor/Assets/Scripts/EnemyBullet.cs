using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float speed = 10.0f;
    public Rigidbody2D rb;

    public GameObject impactEffect;

    private Transform target;

    public int damageToGive = 50;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (AstronautMovement.instance.transform.position - transform.position) *speed;

        
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {

            other.gameObject.GetComponent<AstronautMovement>().decreaseHealth(damageToGive);
            Destroy(gameObject);
            Instantiate(impactEffect, transform.position, transform.rotation);



        }

    }


    private void OnBecameInvisible()
    {

        Destroy(gameObject);
    }
}
