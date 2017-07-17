using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatValue {

	public Stats stat { get; }
	public float value { get; }

	public StatValue(Stats stat, float value) {
		this.stat = stat;
		this.value = value;
	}
}
