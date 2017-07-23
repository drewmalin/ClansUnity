using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Consumable : Item {

	HashSet<StatValue> BaseStats();

	float GetDurationInSeconds();

	string GetConsumeActionName();
}
