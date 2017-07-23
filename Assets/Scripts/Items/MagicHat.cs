using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHat : MonoBehaviour, Equippable {

	private const string NAME = "Magic Hat";
	private const string DESCRIPTION = "It's magic!";

	private const float CHARISMA = 10f;
	private const float WISDOM = 5f;

	private HashSet<StatValue> stats;

	public MagicHat() {
		this.stats = new HashSet<StatValue>();

		this.stats.Add (new StatValue (Stats.Charisma, CHARISMA));
		this.stats.Add (new StatValue (Stats.Wisdom, WISDOM));
	}

	HashSet<StatValue> Equippable.BaseStats() {
		return this.stats;
	}

	public string GetName () {
		return NAME;
	}

	public string GetDescription () {
		return DESCRIPTION;
	}
}
