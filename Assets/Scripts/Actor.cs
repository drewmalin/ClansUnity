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
	public InventoryManager inventoryManager;

	// TODO: move to 'inventory' manager
	protected HashSet<Equipable> equipables;
	protected ActorStats stats;

	private bool hasInteractedWithTarget;

	void Awake() {
		// TODO: move to 'inventory' manager
		this.equipables = new HashSet<Equipable> ();
		this.stats = new ActorStats ();
	}

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

	public virtual void Equip(Equipable equipable) {
		if (equipable == null) {
			return;
		}
		this.equipables.Add (equipable);
		foreach (StatValue statValue in equipable.BaseStats()) {
			this.stats.AddBonus (statValue);
		}
	}

	public virtual void Unquip(Equipable equipable) {
		if (equipable == null) {
			return;
		}
		this.equipables.Remove (equipable);
		foreach (StatValue statValue in equipable.BaseStats()) {
			this.stats.RemoveBonus (statValue);
		}
	}

	public void LogStatus () {
		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		sb.AppendLine (this + " has the following stats:");
		foreach (Stats stat in Enum.GetValues(typeof(Stats))) {
			sb.AppendLine(stat + ": " + this.stats.GetStat (stat));
		}
		if (this.equipables.Count > 0) {
			sb.AppendLine ("and the following items:");
			foreach (Equipable equipable in this.equipables) {
				sb.AppendLine (equipable + " -- adds the following bonuses:");
				foreach (StatValue statValue in equipable.BaseStats()) {
					sb.AppendLine ("    " + statValue.value + " " + statValue.stat);
				}
			}
		}
		Debug.Log (sb.ToString());

	}
}
