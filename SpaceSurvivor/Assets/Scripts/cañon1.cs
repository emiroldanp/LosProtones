using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cañon1 : MonoBehaviour
{
    public float frecuenciaDeMinerales = 2;
    public GameObject MineralBullet;
    public GameObject MineralBullet2;
    public GameObject MineralBullet3;
    public GameObject MineralBullet4;

    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(frecuenciaDeMinerales);

            GameObject go = Instantiate(MineralBullet, firePoint1.position, MineralBullet.transform.rotation) as GameObject;
            Destroy(go,4);

            GameObject go2 = Instantiate(MineralBullet2, firePoint2.position, MineralBullet2.transform.rotation) as GameObject;
            Destroy(go2,4);

            GameObject go3 = Instantiate(MineralBullet3, firePoint3.position, MineralBullet3.transform.rotation) as GameObject;
            Destroy(go3,4);

            GameObject go4 = Instantiate(MineralBullet4, firePoint4.position, MineralBullet4.transform.rotation) as GameObject;
            Destroy(go4,4);






        }
        
    }

}
