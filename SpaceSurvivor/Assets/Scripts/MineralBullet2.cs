using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralBullet2 : MonoBehaviour
{
    public float speed;
    
    

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }


    void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

    }
       
}
