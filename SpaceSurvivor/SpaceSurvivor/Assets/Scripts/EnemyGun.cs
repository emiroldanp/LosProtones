using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
   public Transform firePoint;
   public Transform firePoint2;
    public GameObject bullet;
        // Start is called before the first frame update

        void Start(){
            InvokeRepeating("Shoot",0,1.5f);
        }
        // Update is called once per frame
        
        
        void Shoot(){
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            Instantiate(bullet,firePoint2.position, firePoint2.rotation);
            
        }
}
