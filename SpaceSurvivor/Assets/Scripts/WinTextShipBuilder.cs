using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTextShipBuilder : MonoBehaviour
{
    private int pointsToWin;
    private int currentPoints;
    public GameObject myShips;
    // Start is called before the first frame update
    void Start()
    {
        pointsToWin = myShips.transform.childCount;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPoints >= pointsToWin){
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void AddPoints(){

        currentPoints++;

    }
}
