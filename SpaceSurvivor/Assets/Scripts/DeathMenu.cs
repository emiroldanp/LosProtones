using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject DeathUI;

    public GameObject PauseUI;

    public GameObject HUD;

    public GameMaster gm;

    public GameObject checkpointButton;

    string path;

    private void Start()
    {
        DeathUI.SetActive(false);

        path = Application.persistentDataPath + "/player.save";
        if(!File.Exists(path)){
            checkpointButton.SetActive(false);
        } else {

            checkpointButton.SetActive(true);
        }
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        
    }

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

        if (File.Exists(path))
        {
            checkpointButton.SetActive(true);
        }

    }

    public void LoadMainMenu()
    {

        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;

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