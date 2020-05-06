using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    // Start is called before the first frame update
   public float speed = 20f;
    public Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start(){
        SoundManager.PlaySound("LaserSound");
        rigidBody.velocity = transform.up * speed;
        Destroy(gameObject, 2f);
    }
}
