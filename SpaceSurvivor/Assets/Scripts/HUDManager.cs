using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public GameObject messagePanel;

    

   
    

    



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showMessagePanel(string text)
    {
        messagePanel.SetActive(true);
        
    }

    public void hideMessagePanel()
    {
        messagePanel.SetActive(false);
    }

   


    public void updateOxygen(float oxygen)
    {
        

    }


    

    

    
}
