using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

/**
 * Actors move around the world and interact with InteractableObjects.
 */
public class Actor : MonoBehaviour {

	protected NavMeshAgent agent;
	protected InteractableObject targetInteractableObject;

	protected InventoryManager inventoryManager;
	protected ActorStats stats;

	private bool hasInteractedWithTarget;

	void Awake() {
		this.inventoryManager = GetComponent<InventoryManager>();
		this.stats = GetComponent<ActorStats>();
	}

	void Update() {
		if (ShouldMoveToInteractable()) {
			if (this.agent.remainingDistance <= this.agent.stoppingDistance) {
				FaceInteractable ();
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

	private void FaceInteractable() {
		this.agent.updateRotation = false;
		Vector3 interactableDirection = new Vector3 (this.targetInteractableObject.transform.position.x, this.agent.transform.position.y, this.targetInteractableObject.transform.position.z);
		this.agent.transform.LookAt (interactableDirection);
		this.agent.updateRotation = true;
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

	public virtual void InstantiateAndEquip(GameObject item) {
		//TODO -- determine appropriate inventory slot and instantiate there
		GameObject equippable = Instantiate (item,
			new Vector3 (
				this.transform.position.x,
				this.transform.position.y + .6f,
				this.transform.position.z),
			Quaternion.Euler(
				-12f,
				this.transform.rotation.eulerAngles.y,
				this.transform.rotation.eulerAngles.z)
		) as GameObject;
		equippable.transform.SetParent (this.transform);

		Equip (equippable.GetComponent<Equippable>());
	}

	public virtual void Equip(Equippable equippable) {
		if (equippable == null) {
			return;
		}
		this.inventoryManager.AddItem (equippable);
		this.inventoryManager.Equip (equippable);
		this.stats.AddStatsFromEquippable (equippable);
	}

	public virtual void Unquip(Equippable equippable) {
		if (equippable == null) {
			return;
		}
		this.inventoryManager.Unequip (equippable);
		this.inventoryManager.RemoveItem (equippable);
		this.stats.RemoveStatsFromEquippable (equippable);
	}

	public virtual void AddToInventory(Item item) {
		if (item == null) {
			return;
		}
		this.inventoryManager.AddItem (item);
	}

	public virtual void RemoveFromInventory(Item item) {
		if (item == null) {
			return;
		}
		this.inventoryManager.RemoveItem (item);
	}

	public virtual ActorStats GetStats() {
		return this.stats;
	}

	public void LogStatus () {
		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		sb.AppendLine (this + " status:");
		sb.AppendLine ("---------------");
		this.stats.LogStatus (sb);
		sb.AppendLine ("---------------");
		this.inventoryManager.LogStatus (sb);
		sb.AppendLine ("---------------");
		Debug.Log (sb.ToString());
	}
}
