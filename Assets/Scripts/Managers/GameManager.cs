using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject clanDudePrefab;

	Actor selectedActor;
	ClanDudeManager clanDude1;
	ClanDudeManager clanDude2;
	ClanDudeManager clanDude3;

	void Start () {
		SpawnClanDudes ();

	}

	private void SpawnClanDudes() {
		this.clanDude1 = new ClanDudeManager ();
		this.clanDude1.instance = Instantiate (clanDudePrefab, new Vector3 (2.78f, 1.62f, -23.12f), Quaternion.Euler(0, 0, 0)) as GameObject;
		this.clanDude1.Setup ();

		this.clanDude2 = new ClanDudeManager ();
		this.clanDude2.instance = Instantiate (clanDudePrefab, new Vector3 (.14f, 1.62f, -23.37f), Quaternion.Euler(0, 0, 0)) as GameObject;
		this.clanDude2.Setup ();

		this.clanDude3 = new ClanDudeManager ();
		this.clanDude3.instance = Instantiate (clanDudePrefab, new Vector3 (-2.78f, 1.62f, -25.37f), Quaternion.Euler(0, 0, 0)) as GameObject;
		this.clanDude3.Setup ();
	}

	void Update () {
		if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject ()) {
			if (Input.GetMouseButton (0)) {
				this.selectedActor = SelectActor ();
			} 
			else if (Input.GetMouseButton (1) && this.selectedActor != null) {
				Interact (this.selectedActor);
			}
		}
	}

	Actor SelectActor() {
		Ray clickRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit clickHit;
		if (Physics.Raycast (clickRay, out clickHit, Mathf.Infinity)) {
			if (clickHit.collider.gameObject.tag == "Actor") {
				return clickHit.collider.gameObject.GetComponent<Actor>();
			} 
			else {
				return null;
			}
		} 
		else {
			return null;
		}
	}

	void Interact(Actor actor) {
		Ray clickRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit clickHit;
		if (Physics.Raycast (clickRay, out clickHit, Mathf.Infinity)) {
			InteractableObject interactableObject = clickHit.collider.gameObject.GetComponent<InteractableObject> ();
			if (interactableObject != null) {
				actor.Interact (interactableObject);
			} 
			else {
				actor.MoveTo (clickHit.point);
			}
		}
	}
}
