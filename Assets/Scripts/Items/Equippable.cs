using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Equippable : Item {

	HashSet<StatValue> BaseStats();

}
