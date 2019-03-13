using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject player_one, player_two;
    private string text;
    public GameObject pauseUI;
    public static bool isPaused;
    public string time;
    public int min;
    public int sec;
    // Start is called before the first frame update
    void Start()
    {
        player_one = GameObject.FindGameObjectWithTag("Player");
        player_two = GameObject.FindGameObjectWithTag("Player 2");
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
        if (player_one.transform.position.y < -7f)
        {
            Debug.Log("player 2 wins");
            
        }
        else if (player_two.transform.position.y < -7f)
        {
            Debug.Log("player 1 wins");
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
