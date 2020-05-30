using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFalling : MonoBehaviour
{
    private int nextSceneLoad;
    private GameMaster gm;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex - 3;
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {

        SceneManager.LoadScene(nextSceneLoad);
        gm.LoadNewGame();
    

    }
}
