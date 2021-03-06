using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag.Equals("Missile")){
            SoundManager.PlaySound("MeteoriteDestroy");
            Destroy(gameObject);
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.tag.Equals("Player"))
        {
            SoundManager.PlaySound("MeteoriteDestroy");
            Destroy(gameObject);
        }
    }
}
