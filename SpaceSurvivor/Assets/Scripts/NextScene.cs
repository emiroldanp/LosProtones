using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    private GameMaster gm;
    private string nextSceneLoad;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = "TileScene";
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(nextSceneLoad);
        gm.LoadNewGame();
        
    }
}
