using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchMeteor", 0, 2.0f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LaunchMeteor(){
        Vector3 randomPosition = gameObject.transform.position;
        
        randomPosition.x = Random.Range(-6,6);
        
        gameObject.transform.position = randomPosition;
        
        Instantiate(objectToSpawn, gameObject.transform.position, Quaternion.identity);
    }
}
