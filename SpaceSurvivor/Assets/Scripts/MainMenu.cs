using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour
{
    public GameObject loadGameButton;
    public GameMaster gm;
    private void Start()
    {
        string path = Application.persistentDataPath + "/player.save";
        if (File.Exists(path))
        {
            loadGameButton.SetActive(true);
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

   public void QuitGame() {
        Application.Quit();
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void LoadGame()
    {
        
        
        SceneManager.LoadScene("TileScene");

        gm.LoadFromMainMenu();

    }

}
