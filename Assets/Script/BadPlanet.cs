using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadPlanet : Planet {

	[SerializeField]
	private float timeToDestroy;

	[SerializeField]
	private SpriteRenderer mySprite;

	private bool isHooked;

	private float elapsedTime;

	[SerializeField]
	private Color startColor;

	[SerializeField]
	private Color endColor;


	public override void WhenIsHooked ()
	{
		elapsedTime = 0;
		isHooked = true;

	}

	public override void PlanetTimer (){

		if (isHooked) {

			elapsedTime += Time.deltaTime;

			mySprite.color = Color.Lerp (startColor, endColor, elapsedTime / timeToDestroy);

			if (elapsedTime >= timeToDestroy) {
				Destroy (Player);
				Destroy (gameObject);
			}
				

		}

	}



}
