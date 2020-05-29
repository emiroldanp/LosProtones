using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject DeathUI;

    public GameObject PauseUI;

    public GameObject HUD;

    public GameMaster gm;

    private void Start()
    {
       DeathUI.SetActive(false);
        

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Update is called once per frame


    public void Resume()
    {
        PauseUI.SetActive(false);
        HUD.SetActive(true);
        Time.timeScale = 1f;
        gameIsPaused = false;

    }

    public void Died()
    {
        Time.timeScale = 0f;
        PauseUI.SetActive(false);
        HUD.SetActive(false);
        gameIsPaused = true;
    }

    public void LoadMainMenu()
    {

        SceneManager.LoadScene("MainMenu");
        
    }

    public void Load()
    {
        gm.Load();
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        HUD.SetActive(true);
        gameIsPaused = false;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
