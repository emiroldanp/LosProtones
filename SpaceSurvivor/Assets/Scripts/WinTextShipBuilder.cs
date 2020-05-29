using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTextShipBuilder : MonoBehaviour
{
    private int pointsToWin;
    private int currentPoints;
    public GameObject myShips;

    public CounterRestarGameShip script;


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

            Invoke("LoadFinalScene", 1f);

        }
    }

    public void AddPoints(){

        currentPoints++;

    }

    public void LoadFinalScene(){

        SceneManager.LoadScene("FinalWinScene");


    }
    
}
