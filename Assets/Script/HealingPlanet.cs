using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPlanet : Planet {

	// Use this for initialization
	public override void WhenIsHooked()
	{
		Debug.Log ("happend");
		Player.GetComponent<Player> ().Heal();
	}
}
