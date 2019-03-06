using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

    private PlayerController player;
    public static int playerHealth;
    public int maxPlayerHealth;
    Text text;
    private LevelManager LM;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        playerHealth = maxPlayerHealth;
        LM = FindObjectOfType<LevelManager>();
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (playerHealth <= 0) {
            playerHealth = 0;
            LM.RespawnPlayer();

        }

        text.text = "Health: "+playerHealth;


	}

    public static void HurtPlayer(int damageToGive) {
        playerHealth -= damageToGive;
    }

    public void FullHealth() {
        playerHealth = maxPlayerHealth;
    }
}
