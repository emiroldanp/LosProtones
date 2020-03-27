using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 15f;
    public Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start(){
        rigidBody.velocity = -transform.up * speed;
        Destroy(gameObject, 5f);
    }
}
