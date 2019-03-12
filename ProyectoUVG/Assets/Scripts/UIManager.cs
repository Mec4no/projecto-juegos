using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private string text;
    public GameObject pauseUI;
    public static bool isPaused;
    public string time;
    public int min;
    public int sec;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pauseUI.SetActive(false);
        min = 0;
        sec = 0;
        time = min + ":" + sec;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Text").GetComponent<Text>().text = "Dirt Stack: " + PlayerController.dirtStash;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            control();
        }
        if (!isPaused)
        {
            sec = (int)Time.timeSinceLevelLoad - min * 60;
            min = (int)(Time.timeSinceLevelLoad / 60);
            time = min + ":" + sec;
            GameObject.Find("Timer").GetComponent<Text>().text = "Time: " + time;
        }
    }
    public void control()
    {
        if (isPaused)
        {
            continuar();
        }
        else
        {
            pausar();
        }
    }
    void continuar()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    void pausar()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
