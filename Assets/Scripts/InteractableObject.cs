using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/**
 * InteractableObjects may be interacted with by Actors.
 */
public abstract class InteractableObject : MonoBehaviour {

	/**
	 * The maximum distance from this InteractableObject where interaction is possible. 
	 */
	public abstract float InteractionRadius();

	/**
	 * The behavior which will occur upon interaction by a given Actor.
	 */
	public abstract void OnInteract(Actor actor);
}
