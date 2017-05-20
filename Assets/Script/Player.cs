using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {


	private float health;

	[SerializeField]
	private Text deadText;

	// Use this for initialization
	void Start () {
		health = 100;
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "damage") {

			Health -= 1 ;
			Debug.Log("health = "+ health);

		}

		if (other.gameObject.tag == "asteroid") {
			Health = 0;
		}

	}

	public void Heal()
	{

		Health = 100;

	}
		
	

	public float Health {
		get {
			return health;
		}
		set {
			health = value;
			Debug.Log("health = "+ health);
			if(health<=0)
				deadText.text = "You are dead";
		}
	}
}
