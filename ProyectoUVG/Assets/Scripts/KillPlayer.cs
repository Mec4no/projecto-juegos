﻿using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {

	public LevelManager LM;

	// Use this for initialization
	void Start () {
		LM = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Jax") {
			LM.RespawnPlayer ();
		}
	}
}
