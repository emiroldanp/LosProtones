using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CounterRestarGameShip : MonoBehaviour
{
    public float timeLeft = 3.0f;
    public Text startText;
    public Text startText2;  // used for showing countdown from 3, 2, 1 

    private void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = (timeLeft).ToString("0.0");
        startText2.text = (timeLeft).ToString("0.0");

        if (timeLeft < 0)
        {
            SceneManager.LoadScene("ShipBuilder");
            //Do something useful or Load a new game scene depending on your use-case
        }
    }
}
