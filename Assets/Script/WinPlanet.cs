using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPlanet : Planet {

	[SerializeField]
	private Text winText;

	public override void WhenIsHooked ()
	{

		winText.text = "You Win";

	}

}
