using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Walls : MonoBehaviour {

	[SerializeField]


	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "player") 
		{

			other.GetComponent<Player> ().Health = 0;


		}

	}

}
