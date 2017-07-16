using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/**
 * Actors move around the world and interact with InteractableObjects.
 */
public class Actor : MonoBehaviour {

	protected NavMeshAgent agent;
	protected InteractableObject targetInteractableObject;

	private bool hasInteractedWithTarget;

	void Update() {
		if (ShouldMoveToInteractable()) {
			if (this.agent.remainingDistance <= this.agent.stoppingDistance) {
				this.targetInteractableObject.OnInteract (this);
				this.hasInteractedWithTarget = true;
			}
		}
	}

	private bool ShouldMoveToInteractable() {
		return !this.hasInteractedWithTarget
			&& this.targetInteractableObject != null
			&& this.agent != null
			&& !this.agent.pathPending;
	}
	
	/**
	 * The behavior which will occur when this Actor interacts with the given InteractableObject. By default, the Actor
	 * will move to within the interaction radius of the InteractableObject before invoking InteractableObject#OnInteract.
	 *
	 */ 
	public virtual void Interact(InteractableObject interactableObject) {
		this.targetInteractableObject = interactableObject;

		this.agent.stoppingDistance = this.targetInteractableObject.InteractionRadius ();
		this.hasInteractedWithTarget = false;

		MoveTo (this.targetInteractableObject);
	}

	/**
	 * Moves the Actor to the given Vector3.
	 */ 
	public virtual void MoveTo(Vector3 point) {
		this.agent.destination = point;
	}

	/**
	 * Moves the Actor to the transform of the given InteractableObject.
	 */
	public virtual void MoveTo(InteractableObject interactableObject) {
		this.agent.destination = interactableObject.transform.position;
	}
}
