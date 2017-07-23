using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	private HashSet<Item> items = new HashSet<Item> ();
	private HashSet<Equippable> equipped = new HashSet<Equippable>();

	public void AddItem(Item item) {
		if (item == null) {
			return;
		}
		this.items.Add (item);
	}

	public void RemoveItem(Item item) {
		if (item == null) {
			return;
		}
		this.items.Remove (item);
	}

	public void Equip(Equippable equipable) {
		if (equipable == null) {
			return;
		}
		if (equipped.Contains(equipable)) {
			// throw 'already equipped'?
			return;
		}
		if (!items.Contains (equipable)) {
			// throw 'not in inventory'?
			return;
		}
		this.equipped.Add (equipable);
	}

	public void Unequip(Equippable equipable) {
		if (equipable == null) {
			return;
		}
		if (!equipped.Contains(equipable)) {
			// throw 'not equipped'?
			return;
		}
		if (!items.Contains (equipable)) {
			// throw 'not in inventory'?
			return;
		}
		this.equipped.Remove (equipable);
	}

	public void LogStatus(System.Text.StringBuilder sb) {
		sb.AppendLine ("Items:");
		if (this.items.Count == 0) {
			sb.AppendLine ("(none)");
		}
		else {
			foreach (Equippable equippable in this.equipped) {
				LogEquippable (equippable, sb);
			}
			foreach (Item item in this.items) {
				LogItem (item, sb);
			}
		}
	}

	private void LogEquippable(Equippable equippable, System.Text.StringBuilder sb) {
		sb.AppendLine (equippable + " (equipped)");
		foreach (StatValue stat in equippable.BaseStats()) {
			string sign = stat.value >= 0 ? "+" : "-";
			sb.AppendLine("    " + sign + " " + stat.value + " " + stat.stat);
		}
	}

	private void LogItem(Item item, System.Text.StringBuilder sb) {
		if (item is Equippable && !this.equipped.Contains (item as Equippable)) {
			sb.AppendLine (item.GetName() + " (" + item.GetDescription() + ")");
		}
	}
}