using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopPup : MonoBehaviour
{

    public GameObject dialogBox;
    //public Text dialogText;
    //public string dialog;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()  
    {

        
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerInRange = true;

            dialogBox.SetActive(true);

        }

    }

    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerInRange = false;
            dialogBox.SetActive(false);

        }
    }
}
