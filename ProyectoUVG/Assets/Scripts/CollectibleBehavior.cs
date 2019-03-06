using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class CollectibleBehavior : MonoBehaviour {

    public AudioSource pickupSoundEffect;

	// Use this for initialization
	void Start () {
        pickupSoundEffect = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            pickupSoundEffect.Play();
            Destroy(gameObject);
        }
    }
}
