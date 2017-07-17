using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stats {

	/*
	 * Physical power. Controls the amount of weight that can be carried, melee
	 * attack damage, etc.
	 */
	Strength,

	/*
	 * Agility. Controls movement speed, attack speed, the ability to evade attacks,
	 * accuracy, etc.
	 */
	Dexterity,

	/*
	 * Vitality and stamina. Controls hit points, resistence to fatigue, the elements,
	 * poisons, sickness, etc.
	 */
	Constitution,

	/*
	 * Knowledge. Controls mental ability, task comprehension, etc.
	 */
	Intelligence,

	/*
	 * Wit, common sense. Controls the ability to read situations and others.
	 */
	Wisdom,

	/*
     * Charm, social aptitude. Controls social skills and the ability to navigate social
     * interactions.
     */
	Charisma
}
