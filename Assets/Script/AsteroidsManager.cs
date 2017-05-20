using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsManager : MonoBehaviour {

	[SerializeField]
	private Transform[] path1;

	[SerializeField]
	private Transform[] path2;

	[SerializeField]
	private Transform[] path3;

	[SerializeField]
	private GameObject ateroidPrefab;

	private float elapsedTime;

	private List<Transform[]> listPath  = new List<Transform[]>();


	// Use this for initialization
	void Start () 
	{
		listPath.Add (path1);
		listPath.Add (path2);
		listPath.Add (path3);
	}
	
	// Update is called once per frame
	void Update () 
	{
		elapsedTime += Time.deltaTime;

		if (elapsedTime >= 4) 
		{
			elapsedTime = 0;
			GameObject tempAsteroid = Instantiate (ateroidPrefab);
			tempAsteroid.GetComponent<Asteroide> ().SetPath (listPath [Random.Range (0, listPath.Count)]);
		}
	}
}
