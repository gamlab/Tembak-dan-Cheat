using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text scoreText;

    public PlayerControll player;

    public GameObject panelPause;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = player.scorePlayer + "";
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    void Pause()
    {
        panelPause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        //panelPause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PrintSomething(string anything)
    {
        Debug.Log(anything);
    }
}
