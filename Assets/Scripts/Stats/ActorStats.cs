using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

	public void AddStatsFromEquippable (Equippable equippable) {
		foreach (StatValue statValue in equippable.BaseStats()) {
			AddBonus (statValue);
		}
	}
		
	public void RemoveStatsFromEquippable(Equippable equippable) {
		foreach (StatValue statValue in equippable.BaseStats()) {
			RemoveBonus (statValue);
		}
	}
		
	public float GetBaseStatValue(Stats stat) {
		float statValue = 0f;
		this.baseStats.TryGetValue (stat, out statValue);
		return statValue;
	}

	public float GetStatBonusValue(Stats stat) {
		float statValue = 0f;
		foreach (StatValue bonusStat in this.bonusStats) {
			if (bonusStat.stat.Equals (stat)) {
				statValue += bonusStat.value;
			}
		}
		return statValue;
	}

	public void LogStatus(System.Text.StringBuilder sb) {
		sb.AppendLine ("Stats:");
		foreach (Stats stat in Enum.GetValues(typeof(Stats))) {
			sb.AppendLine(stat + ": " + GetStat (stat));
		}
	}
}
