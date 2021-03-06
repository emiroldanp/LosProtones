using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int life;
    public float health;
    public SpriteRenderer spriteRenderer;
    public Color initialColor;
    
    
    public HealthBarController healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        health = life/30f;
        Debug.Log(health);
        
        initialColor = spriteRenderer.color;

    }

    // Update is called once per frame
    void Update()
    {

     
        if (health >= 0){
            healthBar.setSize(health);
        }
        if(health <= .5 && health > .2){
            healthBar.setColor(Color.yellow);
        }
        if(health <= .2){
            healthBar.setColor(Color.red);
        }
        
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        gameObject.transform.Translate(new Vector3(x/8,y/8,0));
        
    }
    
    private void OnTriggerEnter2D(Collider2D collider){
        
        if(collider.gameObject.tag.Equals("Enemy")){
            SoundManager.PlaySound("PlayerHit");

            spriteRenderer.color = Color.red;

            InvokeRepeating("resetColor",1,0);
            life--;
            if(life == 0){
                Destroy(gameObject);
            }
        }
        if(collider.gameObject.tag.Equals("EnemyMissile")){
            SoundManager.PlaySound("PlayerHit");
            spriteRenderer.color = Color.red;
            InvokeRepeating("resetColor",1,0);
            Destroy(collider.gameObject);
            life--;
            health = life/30f;
            if(life == 0){
                Destroy(gameObject);
                SceneManager.LoadScene("TileScene");
            }
        }
    }
    
    private void resetColor(){
        spriteRenderer.color = initialColor;
    }

}




    

