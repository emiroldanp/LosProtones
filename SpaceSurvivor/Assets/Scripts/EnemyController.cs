using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed;
    public int life = 10;
    public SpriteRenderer spriteRenderer;
    Color initialColor;
    
    // Start is called before the first frame update
    void Start()
    {
        initialColor = spriteRenderer.color;
        rigidBody.velocity = -transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag.Equals("Missile")){
            spriteRenderer.color = Color.red;
            InvokeRepeating("resetColor",1,0);
            Destroy(collider.gameObject);
            
            life--;
            if(life == 0){
                SoundManager.PlaySound("MeteoriteDestroy");
                Destroy(gameObject);
            }
        }
    }
    private void resetColor(){
           spriteRenderer.color = initialColor;
       }
}
