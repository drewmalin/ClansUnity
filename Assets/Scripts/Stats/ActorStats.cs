using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorStats : MonoBehaviour {

	private Dictionary<Stats, float> baseStats = new Dictionary<Stats, float> ();
	private HashSet<StatValue> bonusStats = new HashSet<StatValue> ();

	public float GetStat(Stats stat) {
		float statValue = 0f;
		statValue += GetBaseStatValue (stat);
		statValue += GetStatBonusValue (stat);
		return statValue;
	}

	public void AddBonus(StatValue bonus) {
		this.bonusStats.Add (bonus);
	}

	public void RemoveBonus(StatValue bonus) {
		this.bonusStats.Remove (bonus);
	}

	private float GetBaseStatValue(Stats stat) {
		float statValue = 0f;
		this.baseStats.TryGetValue (stat, out statValue);
		return statValue;
	}

	private float GetStatBonusValue(Stats stat) {
		float statValue = 0f;
		foreach (StatValue bonusStat in this.bonusStats) {
			if (bonusStat.stat.Equals (stat)) {
				statValue += bonusStat.value;
			}
		}
		return statValue;
	}

}
