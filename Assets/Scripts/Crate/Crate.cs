using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : InteractableObject {

	private float interactionRadius = 3f;

	public override float InteractionRadius() {
		return this.interactionRadius;
	}

	public override void OnInteract(Actor actor) {
		Debug.Log (actor + "has interacted with a Crate");
	}
}
