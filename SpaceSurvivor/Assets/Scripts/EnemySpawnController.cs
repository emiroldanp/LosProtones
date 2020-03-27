using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject objectToSpawn;
       // Start is called before the first frame update
       void Start()
       {
           InvokeRepeating("LaunchEnemy", 0, 4.0f);
           
       }

       // Update is called once per frame
       void Update()
       {
           
       }
       void LaunchEnemy(){
           Vector3 randomPosition = gameObject.transform.position;
           
           randomPosition.x = Random.Range(-7,7);
           
           gameObject.transform.position = randomPosition;
           
           Instantiate(objectToSpawn, gameObject.transform.position, Quaternion.identity);
       }
}
