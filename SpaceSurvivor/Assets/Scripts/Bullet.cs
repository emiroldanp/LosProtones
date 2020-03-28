using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public int damageToGive = 50;


    private void OnTriggerEnter2D(Collider2D collider)
    {
    	if(collider.gameObject.tag.Equals("Enemy")){

  		GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);

  		collider.GetComponent<AlienController>().DamageEnemy(damageToGive);
        Destroy(gameObject);
        Destroy(effect, 2f);

    	}

        
    }
}
