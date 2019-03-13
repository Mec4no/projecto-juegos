using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint, player_one, player_two;
	private PlayerController player;
    public HealthManager HM;

	// Use this for initialization
	void Start () {
        player_one = GameObject.FindGameObjectWithTag("Player");
        player_two = GameObject.FindGameObjectWithTag("Player 2");
        player = FindObjectOfType<PlayerController> ();
        HM = FindObjectOfType<HealthManager>();
	}

    // Update is called once per frame
    void Update()
    {
        if (player_one.transform.position.y < 11f)
        {
            Debug.Log("player 2 wins");
        }
        else if (player_two.transform.position.y < 11f)
        {
            Debug.Log("player 1 wins");
        }
    }

    public void RespawnPlayer(){
		Debug.Log ("Player respawned");
		player.transform.position = currentCheckpoint.transform.position;
        HM.FullHealth();
	}

    public void AddSpeedToPlayer() {
        Debug.Log("Player SpeedBoosted");
        player.moveSpeed += 5;
    }

    

}
