using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClanDude : Actor {

	void Start() {
		this.agent = GetComponent<NavMeshAgent> ();
	}
}
