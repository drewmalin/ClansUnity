using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClanDudeManager {

	public ClanDudeMovement movement;
	public GameObject instance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Setup() {
		movement = instance.GetComponent<ClanDudeMovement> ();
	}
}
