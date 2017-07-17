using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHat : MonoBehaviour, Equipable {

	private HashSet<StatValue> stats;

	public MagicHat() {
		this.stats = new HashSet<StatValue>();

		this.stats.Add (new StatValue (Stats.Charisma, 10f));
		this.stats.Add (new StatValue (Stats.Wisdom, 5f));
	}

	HashSet<StatValue> Equipable.BaseStats() {
		return this.stats;
	}
}
