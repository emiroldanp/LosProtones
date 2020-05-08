using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineralBullet4 : MonoBehaviour
{
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }


    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

    }
       
}
