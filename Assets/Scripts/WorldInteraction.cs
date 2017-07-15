using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WorldInteraction : MonoBehaviour {

	NavMeshAgent selectedObjectAgent;

	void Start() {
		selectedObjectAgent = GetComponent<NavMeshAgent> ();
	}

	void Update () {
		if (Input.GetMouseButton (0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
			// clicked, but not on a game object
			GetClicked();
		}
	}

	void GetClicked() {
		Ray clickRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit clickHit;
		if (Physics.Raycast (clickRay, out clickHit, Mathf.Infinity)) {
			GameObject clickedObject = clickHit.collider.gameObject;
			if (clickedObject.tag == "Clickable Object") {
				Debug.Log ("clicked on a clickable object");
			} 
			else {
				selectedObjectAgent.destination = clickHit.point;
			}
		}
	}
}
