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
			Equipable equipable = item.GetComponent<Equipable> ();
			if (equipable != null) {
				// TODO: identify that this item should be equipped to a particular 'slot' (e.g. 'head') -- also do this instantiation in the inventory manager
				GameObject equippedItem = Instantiate (item,
					new Vector3 (actor.transform.position.x, actor.transform.position.y + .6f, actor.transform.position.z),
					Quaternion.Euler(-12f, actor.transform.rotation.eulerAngles.y, actor.transform.rotation.eulerAngles.z)) as GameObject;
				equippedItem.transform.SetParent (actor.transform);

				actor.Equip (equipable);
			} 
			else {
				// TODO: add the item to the actor's inventory
				Debug.Log (item + " is not equipable");
			}
			this.items.Remove (item);
		} 
		else {
			Debug.Log ("crate is empty!");
		}
	}
}
