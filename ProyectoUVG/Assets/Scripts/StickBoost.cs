using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickBoost : MonoBehaviour {

    public float speedBoost;
    public float jumpSpeedBoost;
    public PlayerController player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Collar") {
            Debug.Log("Speedboosted.");
                player.moveSpeed += speedBoost;
                player.jumpSpeed += jumpSpeedBoost;
            
        }
    }
}
