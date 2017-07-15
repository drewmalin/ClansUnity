using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClanDudeMovement : MonoBehaviour {

	NavMeshAgent clanDudeAgent;

	void Start() {
		clanDudeAgent = GetComponent<NavMeshAgent> ();
	}

	void Update () {

	}

	public void SetDestination(Vector3 destination) {
		clanDudeAgent.destination = destination;
	}
}
