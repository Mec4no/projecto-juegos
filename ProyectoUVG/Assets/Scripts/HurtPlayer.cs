using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    public int damageToGive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Jax")
        {
            HealthManager.HurtPlayer(damageToGive);

            var player = other.GetComponent<PlayerController>();
            player.knockbackCount = player.knockbackLenght;

            if (other.transform.position.x < transform.position.x)
            {
                player.knockFromRight = true;
            }
            else {
                player.knockFromRight = false;
            }
        }
    }
}
