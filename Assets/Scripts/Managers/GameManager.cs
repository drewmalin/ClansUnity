using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject clanDudePrefab;

	GameObject selectedGameObject;
	ClanDudeManager clanDude1;
	ClanDudeManager clanDude2;
	ClanDudeManager clanDude3;

	void Start () {
		SpawnClanDudes ();
	}

	private void SpawnClanDudes() {
		clanDude1 = new ClanDudeManager ();
		clanDude1.instance = Instantiate (clanDudePrefab, new Vector3 (2.78f, 1.62f, -23.12f), Quaternion.Euler(0, 0, 0)) as GameObject;
		clanDude1.Setup ();

		clanDude2 = new ClanDudeManager ();
		clanDude2.instance = Instantiate (clanDudePrefab, new Vector3 (.14f, 1.62f, -23.37f), Quaternion.Euler(0, 0, 0)) as GameObject;
		clanDude2.Setup ();

		clanDude3 = new ClanDudeManager ();
		clanDude3.instance = Instantiate (clanDudePrefab, new Vector3 (-2.78f, 1.62f, -25.37f), Quaternion.Euler(0, 0, 0)) as GameObject;
		clanDude3.Setup ();
	}

	void Update () {
		if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject ()) {
			if (Input.GetMouseButton (0)) {
				selectedGameObject = ClickedGameObject ();
			} 
			else if (Input.GetMouseButton (1) && selectedGameObject != null) {
				Vector3 clickedPoint = ClickedPoint ();
				selectedGameObject.GetComponent<ClanDudeMovement> ().SetDestination (destination: clickedPoint);
			}
		}
	}

	GameObject ClickedGameObject() {
		Ray clickRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit clickHit;
		if (Physics.Raycast (clickRay, out clickHit, Mathf.Infinity)) {
			if (clickHit.collider.gameObject.tag == "ClanDude") {
				return clickHit.collider.gameObject;
			} 
			else {
				return null;
			}
		} 
		else {
			return null;
		}
	}

	Vector3 ClickedPoint() {
		Ray clickRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit clickHit;
		if (Physics.Raycast (clickRay, out clickHit, Mathf.Infinity)) {
			GameObject clickedObject = clickHit.collider.gameObject;
			return clickHit.point;
		}
		else {
			// return some sentinel value?
			return new Vector3(0, 0, 0);
		}
	}
}
