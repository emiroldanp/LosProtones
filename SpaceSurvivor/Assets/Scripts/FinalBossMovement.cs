using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossMovement : MonoBehaviour
{

    public float speed;

    public float stoppingDistance;
    public float retreatDistance;

    public int health = 10000;

    public Transform player;

    public GameObject shipPart;

    public HealthBarController healthBar;

    private float hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = health / 10000f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
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
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) {

            transform.position = this.transform.position;
        } else if(Vector2.Distance(transform.position, player.position) < retreatDistance){

            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);

        }
    }

    public void DamageEnemy(int damage)
    {

        health -= damage;
        hp = health / 10000f;

        if (health <= 0)
        {
            Instantiate(shipPart, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }

    }
}
