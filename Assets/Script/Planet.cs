using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

	private LineRenderer myLineRenderer;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private GameObject player;
	private Rigidbody2D playerRb;
	private Vector3 normalDirectionNow;
	private float percentNow;
	private bool isOnThePlanet;


	[SerializeField]
	private float maxDrag;

	[SerializeField]
	private float forceToPlayer;





	// Use this for initialization
	void Start () {
		startPosition = transform.position;
		myLineRenderer = GetComponent<LineRenderer> ();
		isOnThePlanet = false;
	}
	
	// Update is called once per frame
	void Update () {
		MousePositionNow ();
		ItTimeToHaveFun ();
		PlanetTimer ();
	}


	void OnTriggerEnter2D(Collider2D other)
	{

		Debug.Log ("Yeah my boy");

		if (other.gameObject.tag == "player" && player == null)
		{

			player = other.gameObject;
			playerRb = player.GetComponent<Rigidbody2D> ();
			playerRb.velocity = Vector2.zero;
			player.transform.position = transform.position;
			GameManager.Instance.NotifyHit ();
			Debug.Log ("Score = " + GameManager.Instance.Score);
			WhenIsHooked ();
		}

	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "player")
			player = null;
			isOnThePlanet = false;
	}

	void OnMouseDown ()
	{
		
		myLineRenderer.SetPosition (0, startPosition);
		isOnThePlanet = true;

	}

	void MousePositionNow()
	{
		if (Input.GetMouseButton (0) && isOnThePlanet && player!=null) {
			Vector3 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mouse.z = transform.position.z;
			Vector3 directionNow = mouse - startPosition;

			directionNow = Vector3.ClampMagnitude (directionNow, maxDrag);
			normalDirectionNow = directionNow.normalized;
			percentNow = (directionNow.magnitude * maxDrag) / 100;
			RotateSpaceShip (directionNow.normalized);
			endPosition = directionNow + startPosition;
			myLineRenderer.SetPosition (1, endPosition);
		
		} else
		{
			myLineRenderer.SetPosition(0,startPosition);
			myLineRenderer.SetPosition(1,startPosition);
			//isOnThePlanet = false;
		}
	}

	void RotateSpaceShip (Vector3 direction)
	{
		player.transform.rotation = Quaternion.LookRotation (direction);
	}

	void ItTimeToHaveFun ()
	{

		if (Input.GetMouseButtonUp (0) && player!=null &&isOnThePlanet)
			ApplyForceToPlayer (normalDirectionNow, percentNow);

	}

	void ApplyForceToPlayer (Vector2 direction, float percent)
	{	
		playerRb.AddForce ((-direction * (percent * forceToPlayer)),ForceMode2D.Impulse);
		//player = null;
		//playerRb = null;
	}

	public virtual void WhenIsHooked ()
	{

		Debug.Log (" Is Hooked");

	}

	public virtual void PlanetTimer()
	{
		


	}

	public GameObject Player {
		get {
			return player;
		}
		set {
			player = value;
		}
	}


}
