using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : InteractableObject {

	public float interactionRadius;
	public List<GameObject> items;

	public override float InteractionRadius() {
		return this.interactionRadius;
	}

	public override void OnInteract(Actor actor) {
		if (this.items.Count > 0) {
			// TODO: grab all items?
			GameObject item = items [this.items.Count - 1];
			if (item.GetComponent<Equippable> () != null) {
				actor.InstantiateAndEquip (item);
			} 
			else if (item.GetComponent<Item> () != null) {
				actor.AddToInventory (item.GetComponent<Item> ());
			}
			this.items.Remove (item);
		} 
		else {
			Debug.Log ("crate is empty!");
		}
	}
}
