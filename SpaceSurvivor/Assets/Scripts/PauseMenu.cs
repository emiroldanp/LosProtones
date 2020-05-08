using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject PauseUI;

    public GameObject HUD;

    private void Start()
    {
        PauseUI.SetActive(false);
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("KeyPress, should pause");
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
       
    }

    void Resume()
    {
        PauseUI.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;

    }

    void Pause()
    {
        PauseUI.SetActive(true);
        HUD.SetActive(false);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
}
