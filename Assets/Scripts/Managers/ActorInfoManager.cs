using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActorInfoManager : MonoBehaviour {

	public static ActorInfoManager SINGLETON { get; set; }
	public GameObject actorInfoPanel;

	private const string ACTOR_INFO = "ActorInfo";
	private const string ACTOR_STATS_1 = "ActorStats1";
	private const string ACTOR_STATS_2 = "ActorStats2";

	private Text info;
	private Text statsText1;
	private Text statsText2;

	void Awake () {
		this.info = actorInfoPanel.transform.Find (ACTOR_INFO).GetComponent<Text> ();
		this.statsText1 = actorInfoPanel.transform.Find(ACTOR_STATS_1).GetComponent<Text> ();
		this.statsText2 = actorInfoPanel.transform.Find(ACTOR_STATS_2).GetComponent<Text> ();
		this.actorInfoPanel.SetActive (false);

		if (SINGLETON != null && SINGLETON != this) {
			Destroy (SINGLETON);
		}
		else {
			SINGLETON = this;
		}
	}

	public void SetActor(Actor actor) {
		ActorStats stats = actor.GetStats ();

		this.info.text = actor.GetType ().ToString();

		System.Text.StringBuilder sb1 = new System.Text.StringBuilder ();
		sb1.AppendLine (GetStatLine (Stats.Strength, stats));
		sb1.AppendLine (GetStatLine (Stats.Dexterity, stats));
		sb1.AppendLine (GetStatLine (Stats.Constitution, stats));
		this.statsText1.text = sb1.ToString ();

		System.Text.StringBuilder sb2 = new System.Text.StringBuilder ();
		sb2.AppendLine (GetStatLine (Stats.Intelligence, stats));
		sb2.AppendLine (GetStatLine (Stats.Wisdom, stats));
		sb2.AppendLine (GetStatLine (Stats.Charisma, stats));
		this.statsText2.text = sb2.ToString ();

		this.actorInfoPanel.SetActive (true);
	}

	private string GetStatLine(Stats stat, ActorStats stats) {
		float baseValue = stats.GetBaseStatValue (stat);
		float bonusValue = stats.GetStatBonusValue (stat);

		string name = stat.ToString () + ":";
		string value = baseValue.ToString();
		if (bonusValue > 0) {
			value += " (+" + stats.GetStatBonusValue (stat) + ")";
		} 
		else if (bonusValue < 0) {
			value += " (-" + stats.GetStatBonusValue (stat) + ")";
		}

		return string.Format("{0, -14} {1}", name, value);
	}

	public void Clear() {
		this.info.text = "";
		this.statsText1.text = "";
		this.statsText2.text = "";
		this.actorInfoPanel.SetActive (false);
	}
}
