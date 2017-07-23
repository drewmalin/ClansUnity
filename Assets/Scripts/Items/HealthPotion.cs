using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour, Consumable {

	private const string NAME = "Health Potion";
	private const string DESCRIPTION = "Drink me!";
	private const string ACTION_NAME = "Drink";

	private const float DURATION_SECONDS = 5f;

	private HashSet<StatValue> stats;

	public HealthPotion() {
		this.stats = new HashSet<StatValue>();
	}

	public HashSet<StatValue> BaseStats (){
		return this.stats;
	}

	public float GetDurationInSeconds () {
		return DURATION_SECONDS;
	}

	public string GetConsumeActionName () {
		return ACTION_NAME;
	}

	public string GetName () {
		return NAME;
	}

	public string GetDescription () {
		return DESCRIPTION;
	}
}
