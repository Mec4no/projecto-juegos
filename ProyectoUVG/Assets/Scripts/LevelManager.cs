using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckpoint;
	private PlayerController player;
    public HealthManager HM;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
        HM = FindObjectOfType<HealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
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
